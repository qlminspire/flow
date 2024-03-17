﻿using Flow.Domain.Abstractions;
using FluentValidation;
using FluentValidation.Results;

namespace Flow.Application.Shared.Validation;

public static class Ensure
{
    public static void NotExists<T>(bool exists)
    {
        if (!exists)
            return;

        throw new ValidationException(new[]
        {
            new ValidationFailure
            {
                PropertyName = typeof(T).Name,
                ErrorCode = Error.AlreadyExistsError.Code,
                ErrorMessage = Error.AlreadyExistsError.Message
            }
        });
    }

    public static class Result
    {
        public static T Success<T>(Result<T> result)
        {
            if (result.IsSuccess)
                return result.Value;

            throw new ValidationException(new[]
            {
                new ValidationFailure
                {
                    PropertyName = typeof(T).Name,
                    ErrorCode = result.Error.Code,
                    ErrorMessage = result.Error.Message
                }
            });
        }
    }
}