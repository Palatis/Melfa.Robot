using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Melfa.Robot
{
    public partial struct PositionJ : IPosition
    {
        public double J1 { get; }
        public double J2 { get; }
        public double J3 { get; }
        public double J4 { get; }
        public double J5 { get; }
        public double J6 { get; }
        public double J7 { get; }
        public double J8 { get; }

        public PositionJ(double j1, double j2, double j3, double j4, double j5, double j6, double j7, double j8)
        {
            J1 = j1;
            J2 = j2;
            J3 = j3;
            J4 = j4;
            J5 = j5;
            J6 = j6;
            J7 = j7;
            J8 = j8;
        }

        public PositionJ(string raw)
        {
            var match = RegexHelper.PositionJointRegex().Match(raw);
            if (!match.Success)
                throw new PositionParseException(raw, typeof(PositionJ));
            J1 = PositionHelper.DoubleFromStringOrDefault(match.Groups[nameof(J1)].Value);
            J2 = PositionHelper.DoubleFromStringOrDefault(match.Groups[nameof(J2)].Value);
            J3 = PositionHelper.DoubleFromStringOrDefault(match.Groups[nameof(J3)].Value);
            J4 = PositionHelper.DoubleFromStringOrDefault(match.Groups[nameof(J4)].Value);
            J5 = PositionHelper.DoubleFromStringOrDefault(match.Groups[nameof(J5)].Value);
            J6 = PositionHelper.DoubleFromStringOrDefault(match.Groups[nameof(J6)].Value);
            J7 = PositionHelper.DoubleFromStringOrDefault(match.Groups[nameof(J7)].Value);
            J8 = PositionHelper.DoubleFromStringOrDefault(match.Groups[nameof(J8)].Value);
        }

        public PositionJ(MatchCollection matches) :
            this(double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN)
        {
            foreach (var m in matches.Cast<Match>())
            {
                try
                {
                    switch (m.Groups["AXIS"].Value)
                    {
                        case nameof(J1): J1 = double.Parse(m.Groups["VALUE"].Value); break;
                        case nameof(J2): J2 = double.Parse(m.Groups["VALUE"].Value); break;
                        case nameof(J3): J3 = double.Parse(m.Groups["VALUE"].Value); break;
                        case nameof(J4): J4 = double.Parse(m.Groups["VALUE"].Value); break;
                        case nameof(J5): J5 = double.Parse(m.Groups["VALUE"].Value); break;
                        case nameof(J6): J6 = double.Parse(m.Groups["VALUE"].Value); break;
                        case nameof(J7): J7 = double.Parse(m.Groups["VALUE"].Value); break;
                        case nameof(J8): J8 = double.Parse(m.Groups["VALUE"].Value); break;
                    }
                }
                catch { }
            }
        }

        public override string ToString() => string.Format(
            "({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7})",
            PositionHelper.StringFromDouble("{0:0.00}", J1),
            PositionHelper.StringFromDouble("{0:0.00}", J2),
            PositionHelper.StringFromDouble("{0:0.00}", J3),
            PositionHelper.StringFromDouble("{0:0.00}", J4),
            PositionHelper.StringFromDouble("{0:0.00}", J5),
            PositionHelper.StringFromDouble("{0:0.00}", J6),
            PositionHelper.StringFromDouble("{0:0.00}", J7),
            PositionHelper.StringFromDouble("{0:0.00}", J8)
        );

        //1;1;JPOSF
        //QokJ1;0.00;J2;-0.00;J3;89.99;J4;-166.69;J5;-90.54;J6;-0.00;J7;0.00;J8;0.00;;****,****;100;0.00;00000000
        public static PositionJ FromCommand(string raw) =>
            new PositionJ(RegexHelper.PositionJointAxisRegex().Matches(RegexHelper.PositionJointPosRegex().Match(raw).Groups["POS"].Value));

        public static bool operator ==(PositionJ left, PositionJ right) => left.Equals(right);

        public static bool operator !=(PositionJ left, PositionJ right) => !(left == right);

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            return obj is PositionJ other &&
                   J1 == other.J1 &&
                   J2 == other.J2 &&
                   J3 == other.J3 &&
                   J4 == other.J4 &&
                   J5 == other.J5 &&
                   J6 == other.J6 &&
                   J7 == other.J7 &&
                   J8 == other.J8;
        }

        public override int GetHashCode() => HashCode.Combine(J1, J2, J3, J4, J5, J6, J7, J8);
    }
}