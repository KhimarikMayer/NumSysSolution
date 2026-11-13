using Xunit;
using System;
using NumSysLib;

namespace NumSysTests
{
    public class AdapterTests
    {
        [Theory]
        [InlineData("1010", "12")]
        [InlineData("11111111", "377")]
        [InlineData("0", "0")]
        [InlineData("-1010", "-12")]
        public void BinaryToOct_Works(string binary, string expectedOct)
        {
            Assert.Equal(expectedOct, Adapter.BinaryToOct(binary));
        }

        [Theory]
        [InlineData("777", "111111111")]
        [InlineData("10", "1000")]
        [InlineData("0", "0")]
        public void OctToBinary_Works(string oct, string expectedBinary)
        {
            Assert.Equal(expectedBinary, Adapter.OctToBinary(oct));
        }

        [Theory]
        [InlineData("FF", 255L)]
        [InlineData("A", 10L)]
        [InlineData("0", 0L)]
        [InlineData("-FF", -255L)]
        public void HexToDecimal_Works(string hex, long expectedDecimal)
        {
            long actual = Adapter.ToDecimal(hex, 16);
            Assert.Equal(expectedDecimal, actual);
        }

        [Theory]
        [InlineData(255L, "FF")]
        [InlineData(10L, "A")]
        [InlineData(0L, "0")]
        [InlineData(-255L, "-FF")]
        public void DecimalToHex_Works(long number, string expectedHex)
        {
            string actual = Adapter.FromDecimal(number, 16);
            Assert.Equal(expectedHex, actual);
        }

        [Theory]
        [InlineData("1010", 2, 16, "A")]
        [InlineData("FF", 16, 2, "11111111")]
        [InlineData("777", 8, 16, "1FF")]
        [InlineData("111111111", 2, 8, "777")]
        public void Convert_Works(string value, int from, int to, string expected)
        {
            Assert.Equal(expected, Adapter.Convert(value, from, to));
        }

        [Fact]
        public void Convert_Throws_OnInvalidBase()
        {
            Assert.Throws<ArgumentException>(() => Adapter.Convert("10", 10, 2));
        }

        [Fact]
        public void Convert_Throws_OnInvalidValue()
        {
            Assert.Throws<ArgumentException>(() => Adapter.Convert("XYZ", 16, 2));
        }

        [Fact]
        public void Binary_Throws_OnInvalidInput()
        {
            Assert.Throws<ArgumentException>(() => Adapter.Convert("102", 2, 8));
        }
    }
}