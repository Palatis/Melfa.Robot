using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace Melfa.Robot
{
    internal static class EnumExtensions
    {
        public static string ToCommandString(this HourMeterKind kind)
        {
            switch (kind)
            {
                case HourMeterKind.PowerOnTime: return "T";
                case HourMeterKind.ServoOnTime: return "S";
                case HourMeterKind.ProgramOperationTime: return "D";
                case HourMeterKind.BatteryAccumulationTime: return "B";
                case HourMeterKind.All: return "Z";
            }
            throw new InvalidEnumArgumentException(nameof(kind), (int)kind, typeof(HourMeterKind));
        }

        public static string ToCommandString(this StepMethod method)
        {
            switch (method)
            {
                case StepMethod.Forward: return "1";
                case StepMethod.Continuous: return "R";
                case StepMethod.Backward: return "B";
                case StepMethod.Stop: return "S";
            }
            throw new InvalidEnumArgumentException(nameof(method), (int)method, typeof(StepMethod));
        }

        public static string ToCommandString(this LocationType type)
        {
            switch (type)
            {
                case LocationType.Top: return "TOP";
                case LocationType.Bottom: return "END";
                case LocationType.Next: return "+1";
                case LocationType.Previous: return "-1";
            }
            throw new InvalidEnumArgumentException(nameof(type), (int)type, typeof(LocationType));
        }

        public static string ToCommandString(this TaskMode mode)
        {
            switch (mode)
            {
                case TaskMode.Repeat: return "REP";
                case TaskMode.Cycle: return "CYC";
            }
            throw new InvalidEnumArgumentException(nameof(mode), (int)mode, typeof(TaskMode));
        }

        public static string ToCommandString(this TaskCondition condition)
        {
            switch (condition)
            {
                case TaskCondition.Start: return "START";
                case TaskCondition.Always: return "ALWAYS";
                case TaskCondition.Error: return "ERROR";
            }
            throw new InvalidEnumArgumentException(nameof(condition), (int)condition, typeof(TaskCondition));
        }
    }
}