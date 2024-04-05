namespace NorthWind.Sales.Backend.BusinessObjects.Specifications;
public class SpecialOrderSpecification : Specification<OrderAgregate>
{
    public override Expression<Func<OrderAgregate, bool>> ConditionExpression => 
        order => order.OrderDetails.Count > 3;
}
