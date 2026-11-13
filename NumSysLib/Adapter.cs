using System;

namespace NumSysLib
{
    public static class Adapter
    {
        public static string Convert(string value, int fromBase, int toBase)
        {
            if (fromBase != 2 && fromBase != 8 && fromBase != 16)
                throw new ArgumentException($"Ошибка ввода данных: недопустимое основание {fromBase} (допустимо 2, 8, 16).");
            if (toBase != 2 && toBase != 8 && toBase != 16)
                throw new ArgumentException($"Ошибка ввода данных: недопустимое основание {toBase} (допустимо 2, 8, 16).");

            ConverterBase from = Create(value, fromBase);
            ConverterBase to = Create("0", toBase);

            long dec = from.ToDecimal();
            return to.FromDecimal(dec);
        }

        public static string BinaryToOct(string value) => Convert(value, 2, 8);

        public static string BinaryToHex(string value) => Convert(value, 2, 16);

        public static string OctToBinary(string value) => Convert(value, 8, 2);

        public static string OctToHex(string value) => Convert(value, 8, 16);

        public static string HexToBinary(string value) => Convert(value, 16, 2);

        public static string HexToOct(string value) => Convert(value, 16, 8);

        public static long ToDecimal(string value, int fromBase)
        {
            if (fromBase != 2 && fromBase != 8 && fromBase != 16)
                throw new ArgumentException($"Ошибка ввода данных: недопустимое основание {fromBase} (допустимо 2, 8, 16).");

            var from = Create(value, fromBase);
            return from.ToDecimal();
        }

        public static string FromDecimal(long number, int toBase)
        {
            if (toBase != 2 && toBase != 8 && toBase != 16)
                throw new ArgumentException($"Ошибка ввода данных: недопустимое основание {toBase} (допустимо 2, 8, 16).");

            var to = Create("0", toBase);
            return to.FromDecimal(number);
        }

        private static ConverterBase Create(string value, int baseValue)
        {
            return baseValue switch
            {
                2 => new Binary(value),
                8 => new Oct(value),
                16 => new Hex(value),
                _ => throw new ArgumentException($"Ошибка ввода данных: недопустимое основание {baseValue}.")
            };
        }
    }
}