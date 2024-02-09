using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Melfa.Robot
{
    public readonly partial struct PositionP : IPosition
    {
        public double X { get; }
        public double Y { get; }
        public double Z { get; }
        public double A { get; }
        public double B { get; }
        public double C { get; }
        public double L1 { get; }
        public double L2 { get; }
        public PositionConfig FLG1 { get; }
        public uint FLG2 { get; }

        public short Turn1 => _GetTurn(FLG2, 0);
        public short Turn2 => _GetTurn(FLG2, 1);
        public short Turn3 => _GetTurn(FLG2, 2);
        public short Turn4 => _GetTurn(FLG2, 3);
        public short Turn5 => _GetTurn(FLG2, 4);
        public short Turn6 => _GetTurn(FLG2, 5);
        public short Turn7 => _GetTurn(FLG2, 6);
        public short Turn8 => _GetTurn(FLG2, 7);

        public PositionP(double x, double y, double z, double a, double b, double c, double l1, double l2, PositionConfig flg1, uint flg2)
        {
            X = x;
            Y = y;
            Z = z;
            A = _NormalizeAngle(a);
            B = _NormalizeAngle(b);
            C = _NormalizeAngle(c);
            L1 = l1;
            L2 = l2;
            FLG1 = flg1;
            FLG2 = flg2;
        }

        public PositionP(string raw)
        {
            var match = RegexHelper.PositionXyzRegex().Match(raw);
            if (!match.Success)
                throw new PositionParseException(raw, typeof(PositionP));
            X = PositionHelper.DoubleFromString(match.Groups[nameof(X)].Value);
            Y = PositionHelper.DoubleFromString(match.Groups[nameof(Y)].Value);
            Z = PositionHelper.DoubleFromString(match.Groups[nameof(Z)].Value);
            A = _NormalizeAngle(PositionHelper.DoubleFromString(match.Groups[nameof(A)].Value));
            B = _NormalizeAngle(PositionHelper.DoubleFromString(match.Groups[nameof(B)].Value));
            C = _NormalizeAngle(PositionHelper.DoubleFromString(match.Groups[nameof(C)].Value));
            L1 = PositionHelper.DoubleFromString(match.Groups[nameof(L1)].Value);
            L2 = PositionHelper.DoubleFromString(match.Groups[nameof(L2)].Value);
            FLG1 = (PositionConfig)Enum.Parse(typeof(PositionConfig), match.Groups[nameof(FLG1)].Value, true);
            FLG2 = PositionHelper.UInt32FromString(match.Groups[nameof(FLG2)].Value);
        }

        public override string ToString() => string.Format(
            "({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}) ({8}, {9})",
            PositionHelper.StringFromDouble("{0:0.00}", X),
            PositionHelper.StringFromDouble("{0:0.00}", Y),
            PositionHelper.StringFromDouble("{0:0.00}", Z),
            PositionHelper.StringFromDouble("{0:0.00}", A),
            PositionHelper.StringFromDouble("{0:0.00}", B),
            PositionHelper.StringFromDouble("{0:0.00}", C),
            PositionHelper.StringFromDouble("{0:0.00}", L1),
            PositionHelper.StringFromDouble("{0:0.00}", L2),
            (byte)FLG1,
            FLG2
        );

        private PositionP(Match pmatch, MatchCollection amatches) :
            this(double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, double.NaN, PositionConfig.LBF, 0)
        {
            foreach (var match in amatches.Cast<Match>())
            {
                try
                {
                    switch (match.Groups["AXIS"].Value)
                    {
                        case nameof(X): X = double.Parse(match.Groups["VALUE"].Value); break;
                        case nameof(Y): Y = double.Parse(match.Groups["VALUE"].Value); break;
                        case nameof(Z): Z = double.Parse(match.Groups["VALUE"].Value); break;
                        case nameof(A): A = _NormalizeAngle(double.Parse(match.Groups["VALUE"].Value)); break;
                        case nameof(B): B = _NormalizeAngle(double.Parse(match.Groups["VALUE"].Value)); break;
                        case nameof(C): C = _NormalizeAngle(double.Parse(match.Groups["VALUE"].Value)); break;
                        case nameof(L1): L1 = double.Parse(match.Groups["VALUE"].Value); break;
                        case nameof(L2): L2 = double.Parse(match.Groups["VALUE"].Value); break;
                    }
                }
                catch { }
            }
            try { FLG1 = (PositionConfig)(int.Parse(pmatch.Groups["FLG1"].Value)); } catch { }
            try { FLG2 = uint.Parse(pmatch.Groups["FLG2"].Value); } catch { }

        }

        //QokX;-400.94;Y;22.33;Z;985.71;A;-166.69;B;0.52;C;0.13;L1;0.00;L2;0.00;;6,0;100;0.00;00000000
        public static PositionP FromCommand(string raw)
        {
            var pmatch = RegexHelper.PositionXyzPosRegex().Match(raw);
            var amatches = RegexHelper.PositionXyzAxisRegex().Matches(pmatch.Groups["POS"].Value);
            return new PositionP(pmatch, amatches);
        }

        private static short _GetTurn(uint flg, int axis)
        {
            var n = (flg >> (axis * 4)) & 0x0F;
            if ((n & 0x08) == 0x08)
                n = ~n + 8;
            return (short)n;
        }

        private static double _NormalizeAngle(double angle)
        {
            if (double.IsNaN(angle) || double.IsInfinity(angle))
                return angle;
            if (angle > 180)
                return angle % 360;
            if (angle < -180)
                return angle % 360;
            return angle;
        }

        private static bool _AngleEquals(double left, double right)
        {
            var l = _NormalizeAngle(left);
            var r = _NormalizeAngle(right);

            if (l == r)
                return true;
            if (l == -180.0 && r == 180.0)
                return true;
            if (l == 180.0 && r == -180.0)
                return true;
            return false;
        }

        public static bool operator ==(PositionP left, PositionP right) => left.Equals(right);

        public static bool operator !=(PositionP left, PositionP right) => !(left == right);

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            var pother = obj as PositionP?;
            if (obj != null)
                return false;
            var other = pother.Value;
            if (X != other.X || Y != other.Y || Z != other.Z ||
                L1 != other.L1 || L2 != other.L2 ||
                FLG1 != other.FLG1 || FLG2 != other.FLG2)
                return false;
            if (!_AngleEquals(A, other.A) || !_AngleEquals(B, other.B) || !_AngleEquals(C, other.C))
                return false;
            return true;
        }

        public override int GetHashCode() =>
            HashCode.Combine(
                HashCode.Combine(X, Y, Z),
                HashCode.Combine(A, B, C),
                HashCode.Combine(L1, L2),
                HashCode.Combine(FLG1, FLG2)
            );
    }
}