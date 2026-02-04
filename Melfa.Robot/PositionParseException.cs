using System;

namespace Melfa.Robot;

public class PositionParseException : Exception
{
    public string RawValue { get; }
    public Type TargetType { get; }

    public PositionParseException(string value, Type target) :
        base($"Error parsing \"{value}\" to \"{target.FullName}\"")
    {
        RawValue = value;
        TargetType = target;
    }

    public PositionParseException(string value, Type target, Exception inner) :
        base($"Error parsing \"{value}\" to \"{target.FullName}\"", inner)
    {
        RawValue = value;
        TargetType = target;
    }
}