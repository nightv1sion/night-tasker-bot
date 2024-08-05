﻿using Planner.Common.Domain.Core.Primitives;

namespace Planner.Common.Domain.Core.Primitives.Result;

public class Result
{
    protected Result(bool isSuccess, Error? error)
    {
        if (isSuccess && error != null)
        {
            throw new InvalidOperationException();
        }

        if (!isSuccess && error == null)
        {
            throw new InvalidOperationException();
        }

        IsSuccess = isSuccess;
        Error = error;
    }

    public bool IsSuccess { get; set; }

    public bool IsFailure => !IsSuccess;

    public Error? Error { get; set; }

    public static Result Success()
    {
        return new Result(true, null);
    }

    public static Result<TValue> Success<TValue>(TValue value) => new(value, true, null);

    public static Result Failure(Error error)
    {
        return new Result(false, error);
    }

    public static Result<TValue> Failure<TValue>(Error error) => new(default!, false, error);
}

public class Result<TValue> : Result
{
    private readonly TValue _value;

    protected internal Result(TValue value, bool isSuccess, Error? error) : base(isSuccess, error)
    {
        _value = value;
    }

    public TValue Value => IsSuccess
        ? _value
        : throw new InvalidOperationException("The value of a failure result can not be accessed.");
}