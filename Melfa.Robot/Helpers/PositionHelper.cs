using CommunityToolkit.Diagnostics;
using System;

namespace Melfa.Robot
{
    internal static class PositionHelper
    {
        public static double DoubleFromString(string value)
        {
            Guard.IsNotNull(value);
            switch (value.ToLowerInvariant())
            {
                case "nan": return double.NaN;
                case "inf": return double.PositiveInfinity;
                case "+inf": return double.PositiveInfinity;
                case "-inf": return double.NegativeInfinity;
                default: return double.Parse(value);
            }
        }

        public static double DoubleFromStringOrDefault(string value, double defaultValue = double.NaN)
        {
            try { return DoubleFromString(value); }
            catch { return defaultValue; }
        }

        public static uint UInt32FromString(string value)
        {
            Guard.IsNotNull(value);
            return value.StartsWith("0x", StringComparison.InvariantCultureIgnoreCase) ?
                uint.Parse(value.Substring(2), System.Globalization.NumberStyles.HexNumber) :
                uint.Parse(value);
        }

        public static string StringFromDouble(string format, double value)
        {
            if (double.IsNaN(value))
                return "NaN";
            if (double.IsPositiveInfinity(value))
                return "Inf";
            if (double.IsNegativeInfinity(value))
                return "-Inf";
            return string.Format(format, value);
        }
    }
}
