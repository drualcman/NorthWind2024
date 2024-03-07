namespace NorthWind.Sales.Backend.UseCases.CreateOrder;
internal class CreateOrderProductValidator(IQueriesRepository Repository) : IModelValidator<CreateOrderDto>
{
    readonly List<ValidationError> ErrorsField = [];
    public ValidationConstraint Constraint => ValidationConstraint.ValidateIfThereAreNoPreviousErrors;

    public IEnumerable<ValidationError> Errors => ErrorsField;

    public async Task<bool> Validate(CreateOrderDto model)
    {
        IEnumerable<ProductUnitsInStock> requiredQuantities =
            model.OrderDetails
            .GroupBy(x => x.ProductId)
            .Select(d => new ProductUnitsInStock(
                d.Key, (short)d.Sum(d => d.Quantity)));

        IEnumerable<int> productIds = requiredQuantities
            .Select(p => p.ProductId);

        IEnumerable<ProductUnitsInStock> InStockQuantities =
            await Repository.GetProductsUnitsInStockAsync(productIds);

        #region Validar
        foreach (ProductUnitsInStock product in requiredQuantities)
        {
            ProductUnitsInStock element = InStockQuantities
                .Where(i => i.ProductId == product.ProductId)
                .FirstOrDefault();

            if (element is null)
            {
                string propertyName = GetPropertyNameWithIndex(
                    model, product.ProductId,
                    nameof(CreateOrderDetailDto.ProductId));

                ErrorsField.Add(
                    new ValidationError(
                        propertyName,
                        string.Format(
                            CreateOrderMessages.ProductIdNotFoundErrorTemplate,
                            product.ProductId)));
            }
            else if (product.UnitsInStock > element.UnitsInStock)
            {
                string propertyName = GetPropertyNameWithIndex(
                    model, product.ProductId,
                    nameof(CreateOrderDetailDto.Quantity));

                ErrorsField.Add(new ValidationError(
                    propertyName,
                    string.Format(
                        CreateOrderMessages.UnitInStockLessThanQuantityErrorTemplate,
                        product.UnitsInStock, element.UnitsInStock, product.ProductId)));
            }
        }
        #endregion

        return !ErrorsField.Any();
    }

    string GetPropertyNameWithIndex(CreateOrderDto model, int productId, string propertyName)
    {
        CreateOrderDetailDto orderDetail = model.OrderDetails
            .First(d => d.ProductId == productId);

        int orderDetailIndex = model.OrderDetails
            .ToList()
            .IndexOf(orderDetail);

        return string.Format("{0}[{1}].{2}",
            nameof(model.OrderDetails),
            orderDetailIndex, propertyName);
    }
}
