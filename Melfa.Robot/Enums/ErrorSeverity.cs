namespace Melfa.Robot
{
    public enum ErrorSeverity : sbyte
    {
        High = 1,
        Low = 2,
        Caution = 3,
        Warning = 3,
        Message = sbyte.MaxValue,
        Unknown = -1,
    }
}