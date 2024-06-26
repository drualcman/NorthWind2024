﻿namespace NorthWind.Validation.Entities.Interfaces;
public interface IValidationService<T>
{
    IValidationRules<T, TProperty> AddRuleFor<TProperty>(
        Expression<Func<T, TProperty>> expresion);

    ICollectionValidationRules<T, TProperty> AddRuleForEach<TProperty>(
        Expression<Func<T, IEnumerable<TProperty>>> expresion);

    Task<IEnumerable<ValidationError>> Validate(T model);
}
