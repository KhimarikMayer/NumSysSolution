using System;

namespace NumSysLib
{
    internal abstract class ConverterBase
    {
        private string _value = "0";
        public string Value
        {
            get => _value;
            set
            {
                if (!IsValid(value))
                    throw new ArgumentException($"Ошибка ввода данных: '{value}' не является корректным числом в системе с основанием {Base}");
                _value = value.Trim().ToUpper();
            }
        }

        public int Base { get; protected set; }
        protected abstract string Digits { get; }

        protected ConverterBase(int baseValue, string initial)
        {
            Base = baseValue;
            Value = initial;
        }

        public virtual bool IsValid(string number)
        {
            if (string.IsNullOrWhiteSpace(number)) return false;
            string upper = number.Trim().ToUpper();
            int start = upper.StartsWith("-") ? 1 : 0;
            if (start == upper.Length) return false;
            for (int i = start; i < upper.Length; i++)
            {
                int idx = Digits.IndexOf(upper[i]);
                if (idx < 0 || idx >= Base) return false;
            }
            return true;
        }

        public abstract long ToDecimal();

        public abstract string FromDecimal(long number);
    }
}