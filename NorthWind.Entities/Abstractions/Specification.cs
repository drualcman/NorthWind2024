namespace NorthWind.Entities.Abstractions;
public abstract class Specification<TModel>
{
    public abstract Expression<Func<TModel, bool>> ConditionExpression { get; }

    public bool IsSatisfiedBy(TModel entity)
    {
        Func<TModel, bool> ExpressionDelegate = ConditionExpression.Compile();
        return ExpressionDelegate(entity);
    }
}
