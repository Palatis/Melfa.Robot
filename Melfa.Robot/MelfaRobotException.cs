using Melfa.Robot.Resources;
using System;

namespace Melfa.Robot;

public sealed partial class MelfaRobotException : Exception
{
    private static string GetErrorMessage(int errno)
    {
        return ErrorMessages.ResourceManager.GetString($"Error.{errno:0000}.Message")
            ?? ErrorMessages.ResourceManager.GetString("Error.Unknown.Message");
    }

    private static string GetErrorCause(int errno)
    {
        return ErrorMessages.ResourceManager.GetString($"Error.{errno:0000}.Cause")
            ?? ErrorMessages.ResourceManager.GetString("Error.Unknown.Cause");
    }

    private static string GetErrorMeasures(int errno)
    {
        return ErrorMessages.ResourceManager.GetString($"Error.{errno:0000}.Measures")
            ?? ErrorMessages.ResourceManager.GetString("Error.Unknown.Measures");
    }

    private static ErrorSeverity GetErrorSeverity(int errno)
    {
        var level = ErrorMessages.ResourceManager.GetString($"Error.{errno:0000}.Level")
            ?? ErrorMessages.ResourceManager.GetString("Error.Unknown.Level");
        return level switch
        {
            nameof(ErrorSeverity.High) => ErrorSeverity.High,
            nameof(ErrorSeverity.Low) => ErrorSeverity.Low,
            nameof(ErrorSeverity.Warning) => ErrorSeverity.Warning,
            nameof(ErrorSeverity.Caution) => ErrorSeverity.Caution,
            _ => ErrorSeverity.Unknown,
        };
    }

    public static MelfaRobotException FromCommandResult(string ret) =>
        new(int.Parse(RegexHelper.ErrorRegex().Match(ret).Groups[nameof(ErrorNumber)].Value), null);

    public static MelfaRobotException FromErrorResult(string cmd, string ret, Exception inner = null) =>
        new(int.Parse(ret.Substring(3, 4)), cmd, inner);

    public static MelfaRobotException FromErrorNumber(int err) =>
        new(err, null);

    public string Command { get; }
    public int ErrorNumber { get; }
    public string ErrorMessage { get; }
    public string ErrorCause { get; }
    public string ErrorMeasures { get; }
    public ErrorSeverity ErrorLevel { get; }

    public override string Message => $"{ErrorNumber:0000} ({ErrorLevel}) - {ErrorMessage}";

    private MelfaRobotException(int errno, string cmd, Exception inner = null) :
        base(null, inner)
    {
        ErrorNumber = errno;
        ErrorMessage = GetErrorMessage(errno);
        ErrorCause = GetErrorCause(errno);
        ErrorMeasures = GetErrorMeasures(errno);
        ErrorLevel = GetErrorSeverity(errno);
        Command = cmd;
    }
}