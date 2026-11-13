using System;

namespace NumSysLib
{
    internal class Oct : ConverterBase
    {
        protected override string Digits => "01234567";

        public Oct(string value) : base(8, value) { }

        public override long ToDecimal()
        {
            string s = Value.StartsWith("-") ? Value.Substring(1) : Value;
            long result = 0;
            foreach (char c in s)
                result = result * 8 + (c - '0');
            return Value.StartsWith("-") ? -result : result;
        }

        public override string FromDecimal(long number)
        {
            if (number == 0) return "0";
            bool neg = number < 0;
            long abs = Math.Abs(number);
            string result = "";
            while (abs > 0)
            {
                result = (abs % 8) + result;
                abs /= 8;
            }
            return neg ? "-" + result : result;
        }
    }
}