using Melfa.Robot.Properties;
using System;
using System.Resources;

namespace Melfa.Robot
{
    public sealed partial class MelfaRobotException : Exception
    {
        private static ResourceManager ResourceManager => Resources.ResourceManager;

        public static MelfaRobotException FromCommandResult(string ret) =>
            new MelfaRobotException(int.Parse(RegexHelper.ErrorRegex().Match(ret).Groups[nameof(ErrorNumber)].Value), null);

        public static MelfaRobotException FromErrorResult(string cmd, string ret, Exception inner = null) =>
            new MelfaRobotException(int.Parse(ret.Substring(3, 7)), cmd, inner);

        public static MelfaRobotException FromErrorNumber(int err) =>
            new MelfaRobotException(err, null);

        public string Command { get; }
        public int ErrorNumber { get; }
        public string ErrorMessage { get; }
        public string ErrorCause { get; }
        public string ErrorMeasures { get; }
        public ErrorSeverity ErrorLevel { get; }

        public override string Message => $"{ErrorNumber:0000} ({ErrorLevel}) - {ErrorMessage}";

        public MelfaRobotException(int err, string cmd, Exception inner = null) :
            base(null, inner)
        {
            ErrorNumber = err;
            ErrorMessage = ResourceManager.GetString($"Error.{ErrorNumber:0000}.Message") ?? ResourceManager.GetString("Error.Unknown.Message");
            ErrorCause = ResourceManager.GetString($"Error.{ErrorNumber:0000}.Cause") ?? ResourceManager.GetString("Error.Unknown.Cause");
            ErrorMeasures = ResourceManager.GetString($"Error.{ErrorNumber:0000}.Measures") ?? ResourceManager.GetString("Error.Unknown.Measures");
            var level = ResourceManager.GetString($"Error.{ErrorNumber:0000}.Level") ?? ResourceManager.GetString($"Error.Unknown.Level");
            switch (level)
            {
                case nameof(ErrorSeverity.High): ErrorLevel = ErrorSeverity.High; break;
                case nameof(ErrorSeverity.Low): ErrorLevel = ErrorSeverity.Low; break;
                case nameof(ErrorSeverity.Warning): ErrorLevel = ErrorSeverity.Warning; break;
                case nameof(ErrorSeverity.Caution): ErrorLevel = ErrorSeverity.Caution; break;
                default: ErrorLevel = ErrorSeverity.Unknown; break;
            }
            Command = cmd;
        }
    }
}