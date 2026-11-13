using System;

namespace NumSysLib
{
    internal class Hex : ConverterBase
    {
        protected override string Digits => "0123456789ABCDEF";

        public Hex(string value) : base(16, value) { }

        public override long ToDecimal()
        {
            string s = Value.StartsWith("-") ? Value.Substring(1) : Value;
            long result = 0;
            foreach (char c in s)
            {
                int digit = Digits.IndexOf(c);
                result = result * 16 + digit;
            }
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
                int digit = (int)(abs % 16);
                result = Digits[digit] + result;
                abs /= 16;
            }
            return neg ? "-" + result : result;
        }
    }
}