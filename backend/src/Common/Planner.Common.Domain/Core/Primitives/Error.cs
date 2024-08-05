﻿namespace Planner.Common.Domain.Core.Primitives;

public sealed class Error
{
    public string Message { get; private set; }

    public string Code { get; private set; }

    public ErrorType Type { get; set; }

    private Error(string code, string message, ErrorType type)
    {
        Code = code;
        Message = message;
        Type = type;
    }

    public static Error Failure(string code, string message)
    {
        return new Error(code, message, ErrorType.Failure);
    }

    public static Error Validation(string code, string message)
    {
        return new Error(code, message, ErrorType.Validation);
    }

    public static Error NotFound(string code, string message)
    {
        return new Error(code, message, ErrorType.NotFound);
    }
}