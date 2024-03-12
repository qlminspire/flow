﻿using Flow.Domain.Abstractions;
using FluentValidation;
using FluentValidation.Results;

namespace Flow.Application.Shared;

public static class FluentValidationExtensions
{
    public static IRuleBuilderOptions<T, string> MustBeValueObject<T, TValueObject>(
        this IRuleBuilder<T, string> ruleBui1der, Func<string, Result<TValueObject>> factoryMethod)
        where TValueObject : IValueObject
    {
        return (IRuleBuilderOptions<T, string>)ruleBui1der.Custom((value, context) =>
        {
            Result<TValueObject> result = factoryMethod(value);
            if (!result.IsFailure)
                return;

            var failure = new ValidationFailure
            {
                ErrorCode = result.Error.Code,
                ErrorMessage = result.Error.Name
            };
            context.AddFailure(failure);
        });
    }
}