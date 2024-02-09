using System;
using System.Text.RegularExpressions;

namespace Melfa.Robot
{
    internal static partial class RegexHelper
    {
#if NET8_0_OR_GREATER
        [GeneratedRegex(@"(?'ErrorNumber'\d+);(?'ErrorLevel'\d+)", RegexOptions.ExplicitCapture | RegexOptions.Compiled)]
        public static partial Regex ErrorRegex();

        [GeneratedRegex(
            @"(?'P_AXIS_PATTERN'[0-9a-fA-F]{2});" +
            @"(?'J_AXIS_PATTERN'[0-9a-fA-F]{2});" +
            @"(?'FLG1'\d+),(?'FLG2'\d+);" +
            @"(?'JSPD1'[0-9a-fA-F]{1,2})," +
            @"(?'JSPD2'[0-9a-fA-F]{1,2})," +
            @"(?'JSPD3'[0-9a-fA-F]{1,2})," +
            @"(?'JSPD4'[0-9a-fA-F]{1,2})," +
            @"(?'JSPD5'[0-9a-fA-F]{1,2})," +
            @"(?'JSPD6'[0-9a-fA-F]{1,2})," +
            @"(?'JSPD7'[0-9a-fA-F]{1,2});" +
            @"(?'PROG_EXT'[^;]*);" +
            @"(?'PRM_EXT'[^;]*);" +
            @"(?'RobotType'[^;]*);" +
            @"(?'Controller'[^;]*);" +
            @"(?'Series'[^;]*);" +
            @"(?'DATE_YEAR'[0-9]+)-(?'DATE_MONTH'[0-9]+)-(?'DATE_DAY'[0-9]+);" +
            @"(?'Version'[^;]*);" +
            @"(?'Language'[^;]*);" +
            @"(?'Copyright'[^;]*);" +
            @"(?'ROBOT_INFO'\d+);" +
            @"(?'SerialNumber'[^;]*);" +
            @"(?'TASKMAX'\d+);",
            RegexOptions.ExplicitCapture | RegexOptions.Compiled
        )]
        public static partial Regex InfoRegex();

        [GeneratedRegex(
            @"(?'ProgramName'[^;]*);" +
            @"(?'LineNumber'\d+);" +
            @"(?'Override'\d+);" +
            @"(?'EditStatus'\d+);" +
            @"(?'RunStatus'[0-9a-fA-F]{2})" +
            @"(?'StopStatus'[0-9a-fA-F]{2})" +
            @"(?'ErrorNumber'\d+);(?'StepNumber'\d+);" +
            @"(?'MechInfo'\d+);{8}" +
            @"(?'TaskProgramName'[^;]*);" +
            @"(?'TaskMode'\w+);" +
            @"(?'TaskCondition'\w+);" +
            @"(?'TaskPriority'\d+);" +
            @"(?'MechNumber'\d+)",
            RegexOptions.ExplicitCapture | RegexOptions.Compiled
        )]
        public static partial Regex RunStateRegex();

        [GeneratedRegex(@"(?'SignalNumber'-?\d+);(?'State'-?\d+);(?'HandType'-?\d+)", RegexOptions.ExplicitCapture | RegexOptions.Compiled)]
        public static partial Regex HandStatesRegex();

        [GeneratedRegex(
            @"^\s*\(" +
                @"\s*(?'J1'-?\d*\.?\d*|[nN][aA][nN]|[-+]?[iI][nN][fF])\s*," +
                @"\s*(?'J2'-?\d*\.?\d*|[nN][aA][nN]|[-+]?[iI][nN][fF])\s*," +
                @"\s*(?'J3'-?\d*\.?\d*|[nN][aA][nN]|[-+]?[iI][nN][fF])\s*," +
                @"\s*(?'J4'-?\d*\.?\d*|[nN][aA][nN]|[-+]?[iI][nN][fF])\s*," +
                @"\s*(?'J5'-?\d*\.?\d*|[nN][aA][nN]|[-+]?[iI][nN][fF])\s*," +
                @"\s*(?'J6'-?\d*\.?\d*|[nN][aA][nN]|[-+]?[iI][nN][fF])\s*," +
                @"\s*(?'J7'-?\d*\.?\d*|[nN][aA][nN]|[-+]?[iI][nN][fF])\s*," +
                @"\s*(?'J8'-?\d*\.?\d*|[nN][aA][nN]|[-+]?[iI][nN][fF])\s*" +
            @"\)\s*$",
            RegexOptions.ExplicitCapture | RegexOptions.Compiled
        )]
        public static partial Regex PositionJointRegex();
        [GeneratedRegex(
            @"(?'POS'(J[1-8];-?\d+\.?\d+;){6,8});?\*{4},\*{4};(?'OVRD'\d+);(?'ENDSPEED'-?\d+.\d+);(?'LIMIT'[0-9a-fA-F]{8})",
            RegexOptions.ExplicitCapture | RegexOptions.Compiled
        )]
        public static partial Regex PositionJointPosRegex();
        [GeneratedRegex(
            @"(?'AXIS'J[1-8]);(?'VALUE'-?\d+.\d+);",
            RegexOptions.ExplicitCapture | RegexOptions.Compiled
        )]
        public static partial Regex PositionJointAxisRegex();

        [GeneratedRegex(
            @"^\s*\(" +
                @"\s*(?'X'-?\d*\.?\d*|[nN][aA][nN]|[-+?][iI][nN][fF])\s*," +
                @"\s*(?'Y'-?\d*\.?\d*|[nN][aA][nN]|[-+]?[iI][nN][fF])\s*," +
                @"\s*(?'Z'-?\d*\.?\d*|[nN][aA][nN]|[-+]?[iI][nN][fF])\s*," +
                @"\s*(?'A'-?\d*\.?\d*|[nN][aA][nN]|[-+]?[iI][nN][fF])\s*," +
                @"\s*(?'B'-?\d*\.?\d*|[nN][aA][nN]|[-+]?[iI][nN][fF])\s*," +
                @"\s*(?'C'-?\d*\.?\d*|[nN][aA][nN]|[-+]?[iI][nN][fF])\s*," +
                @"\s*(?'L1'-?\d*\.?\d*|[nN][aA][nN]|[-+]?[iI][nN][fF])\s*," +
                @"\s*(?'L2'-?\d*\.?\d*|[nN][aA][nN]|[-+]?[iI][nN][fF])\s*" +
            @"\)\s*\(" +
                @"\s*(?'FLG1'(?>0[xX][0-9a-fA-F]+|[0-9]+|[lLrR][bBaA][fFnN]))\s*," +
                @"\s*(?'FLG2'(?>0[xX][0-9a-fA-F]+|[0-9]+))\s*" +
            @"\)\s*$",
            RegexOptions.ExplicitCapture | RegexOptions.Compiled
        )]
        public static partial Regex PositionXyzRegex();

        [GeneratedRegex(
            @"(?'POS'((X|Y|Z|A|B|C|L1|L2);-?\d+\.?\d+;){6,8});?(?'FLG1'\d+),(?'FLG2'\d+);(?'OVRD'\d+);(?'ENDSPEED'-?\d+.\d+);(?'LIMIT'[0-9a-fA-F]{8})",
            RegexOptions.ExplicitCapture | RegexOptions.Compiled
        )]
        public static partial Regex PositionXyzPosRegex();
        [GeneratedRegex(
            @"(?'AXIS'(X|Y|Z|A|B|C|L1|L2));(?'VALUE'-?\d+.\d+);",
            RegexOptions.ExplicitCapture | RegexOptions.Compiled
        )]
        public static partial Regex PositionXyzAxisRegex();
#else
        private static readonly Lazy<Regex> _ErrorRegex =
            new Lazy<Regex>(() => new Regex(@"(?'ErrorNumber'\d+);(?'ErrorLevel'\d+)", RegexOptions.ExplicitCapture | RegexOptions.Compiled));
        public static Regex ErrorRegex() => _ErrorRegex.Value;

        private static readonly Lazy<Regex> _HandStateRegex =
            new Lazy<Regex>(() => new Regex(@"(?'SignalNumber'-?\d+);(?'State'-?\d+);(?'HandType'-?\d+)", RegexOptions.ExplicitCapture | RegexOptions.Compiled));
        public static Regex HandStatesRegex() => _HandStateRegex.Value;

        private static readonly Lazy<Regex> _InfoRegex = new Lazy<Regex>(() => new Regex(
            @"(?'P_AXIS_PATTERN'[0-9a-fA-F]{2});" +
            @"(?'J_AXIS_PATTERN'[0-9a-fA-F]{2});" +
            @"(?'FLG1'\d+),(?'FLG2'\d+);" +
            @"(?'JSPD1'[0-9a-fA-F]{1,2})," +
            @"(?'JSPD2'[0-9a-fA-F]{1,2})," +
            @"(?'JSPD3'[0-9a-fA-F]{1,2})," +
            @"(?'JSPD4'[0-9a-fA-F]{1,2})," +
            @"(?'JSPD5'[0-9a-fA-F]{1,2})," +
            @"(?'JSPD6'[0-9a-fA-F]{1,2})," +
            @"(?'JSPD7'[0-9a-fA-F]{1,2});" +
            @"(?'PROG_EXT'[^;]*);" +
            @"(?'PRM_EXT'[^;]*);" +
            @"(?'RobotType'[^;]*);" +
            @"(?'Controller'[^;]*);" +
            @"(?'Series'[^;]*);" +
            @"(?'DATE_YEAR'[0-9]+)-(?'DATE_MONTH'[0-9]+)-(?'DATE_DAY'[0-9]+);" +
            @"(?'Version'[^;]*);" +
            @"(?'Language'[^;]*);" +
            @"(?'Copyright'[^;]*);" +
            @"(?'ROBOT_INFO'\d+);" +
            @"(?'SerialNumber'[^;]*);" +
            @"(?'TASKMAX'\d+);",
            RegexOptions.ExplicitCapture | RegexOptions.Compiled
        ));
        public static Regex InfoRegex() => _InfoRegex.Value;

        private static readonly Lazy<Regex> _RunStateRegex = new Lazy<Regex>(() => new Regex(
            @"(?'ProgramName'[^;]*);" +
            @"(?'LineNumber'\d+);" +
            @"(?'Override'\d+);" +
            @"(?'EditStatus'\d+);" +
            @"(?'RunStatus'[0-9a-fA-F]{2})" +
            @"(?'StopStatus'[0-9a-fA-F]{2})" +
            @"(?'ErrorNumber'\d+);(?'StepNumber'\d+);" +
            @"(?'MechInfo'\d+);{8}" +
            @"(?'TaskProgramName'[^;]*);" +
            @"(?'TaskMode'\w+);" +
            @"(?'TaskCondition'\w+);" +
            @"(?'TaskPriority'\d+);" +
            @"(?'MechNumber'\d+)",
            RegexOptions.ExplicitCapture | RegexOptions.Compiled
        ));
        public static Regex RunStateRegex() => _RunStateRegex.Value;

        private static readonly Lazy<Regex> _PositionJointRegex =
            new Lazy<Regex>(() => new Regex(
                @"^\s*\(" +
                    @"\s*(?'J1'-?\d*\.?\d*|[nN][aA][nN]|[-+]?[iI][nN][fF])\s*," +
                    @"\s*(?'J2'-?\d*\.?\d*|[nN][aA][nN]|[-+]?[iI][nN][fF])\s*," +
                    @"\s*(?'J3'-?\d*\.?\d*|[nN][aA][nN]|[-+]?[iI][nN][fF])\s*," +
                    @"\s*(?'J4'-?\d*\.?\d*|[nN][aA][nN]|[-+]?[iI][nN][fF])\s*," +
                    @"\s*(?'J5'-?\d*\.?\d*|[nN][aA][nN]|[-+]?[iI][nN][fF])\s*," +
                    @"\s*(?'J6'-?\d*\.?\d*|[nN][aA][nN]|[-+]?[iI][nN][fF])\s*," +
                    @"\s*(?'J7'-?\d*\.?\d*|[nN][aA][nN]|[-+]?[iI][nN][fF])\s*," +
                    @"\s*(?'J8'-?\d*\.?\d*|[nN][aA][nN]|[-+]?[iI][nN][fF])\s*" +
                @"\)\s*$",
                RegexOptions.ExplicitCapture | RegexOptions.Compiled
            ));
        public static Regex PositionJointRegex() => _PositionJointRegex.Value;

        private static readonly Lazy<Regex> _PositionJointPosRegex =
            new Lazy<Regex>(() => new Regex(
                @"(?'POS'(J[1-8];-?\d+\.?\d+;){6,8});?\*{4},\*{4};(?'OVRD'\d+);(?'ENDSPEED'-?\d+.\d+);(?'LIMIT'[0-9a-fA-F]{8})",
                RegexOptions.ExplicitCapture | RegexOptions.Compiled
            ));
        public static Regex PositionJointPosRegex() => _PositionJointPosRegex.Value;

        private static readonly Lazy<Regex> _PositionJointAxisRegex =
            new Lazy<Regex>(() => new Regex(
            @"(?'AXIS'J[1-8]);(?'VALUE'-?\d+.\d+);",
                RegexOptions.ExplicitCapture | RegexOptions.Compiled
            ));
        public static Regex PositionJointAxisRegex() => _PositionJointAxisRegex.Value;

        private static readonly Lazy<Regex> _PositionXyzRegex =
            new Lazy<Regex>(() => new Regex(
                @"^\s*\(" +
                    @"\s*(?'X'-?\d*\.?\d*|[nN][aA][nN]|[-+?][iI][nN][fF])\s*," +
                    @"\s*(?'Y'-?\d*\.?\d*|[nN][aA][nN]|[-+]?[iI][nN][fF])\s*," +
                    @"\s*(?'Z'-?\d*\.?\d*|[nN][aA][nN]|[-+]?[iI][nN][fF])\s*," +
                    @"\s*(?'A'-?\d*\.?\d*|[nN][aA][nN]|[-+]?[iI][nN][fF])\s*," +
                    @"\s*(?'B'-?\d*\.?\d*|[nN][aA][nN]|[-+]?[iI][nN][fF])\s*," +
                    @"\s*(?'C'-?\d*\.?\d*|[nN][aA][nN]|[-+]?[iI][nN][fF])\s*," +
                    @"\s*(?'L1'-?\d*\.?\d*|[nN][aA][nN]|[-+]?[iI][nN][fF])\s*," +
                    @"\s*(?'L2'-?\d*\.?\d*|[nN][aA][nN]|[-+]?[iI][nN][fF])\s*" +
                @"\)\s*\(" +
                    @"\s*(?'FLG1'(?>0[xX][0-9a-fA-F]+|[0-9]+|[lLrR][bBaA][fFnN]))\s*," +
                    @"\s*(?'FLG2'(?>0[xX][0-9a-fA-F]+|[0-9]+))\s*" +
                @"\)\s*$",
                RegexOptions.ExplicitCapture | RegexOptions.Compiled
            ));
        public static Regex PositionXyzRegex() => _PositionXyzRegex.Value;

        private static readonly Lazy<Regex> _PositionXyzPosRegex =
            new Lazy<Regex>(() => new Regex(
                @"(?'POS'((X|Y|Z|A|B|C|L1|L2);-?\d+\.?\d+;){6,8});?(?'FLG1'\d+),(?'FLG2'\d+);(?'OVRD'\d+);(?'ENDSPEED'-?\d+.\d+);(?'LIMIT'[0-9a-fA-F]{8})",
                RegexOptions.ExplicitCapture | RegexOptions.Compiled
            ));
        public static Regex PositionXyzPosRegex() => _PositionXyzPosRegex.Value;

        private static readonly Lazy<Regex> _PositionXyzAxisRegex =
            new Lazy<Regex>(() => new Regex(
                @"(?'AXIS'(X|Y|Z|A|B|C|L1|L2));(?'VALUE'-?\d+.\d+);",
                RegexOptions.ExplicitCapture | RegexOptions.Compiled
            ));
        public static Regex PositionXyzAxisRegex() => _PositionXyzAxisRegex.Value;
#endif
    }
}
