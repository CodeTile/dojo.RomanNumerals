namespace dojo.RomanNumerals.MsTest
{
	[TestClass]
	public class ConvertFromTests
	{
		[DataRow("ACD")]
		[DataRow("MCM LXXXIV")]
		[DataRow("MCi")]
		[DataRow("MC.i")]
		[DataRow(" MCI")]
		[DataRow("MCI ")]
		[DataRow(" ")]
		[TestMethod]
		public void ConvertFromTests_ArgumentOutOfRangeException(string numerals)
		{
			// Act
			Action act = () => numerals.FromRomanNumerals();
			// Assert
			Assert.ThrowsException<ArgumentOutOfRangeException>(act);
		}

		[DataRow("", 0)]
		[DataRow("I", 1)]
		[DataRow("V", 5)]
		[DataRow("X", 10)]
		[DataRow("L", 50)]
		[DataRow("C", 100)]
		[DataRow("D", 500)]
		[DataRow("M", 1000)]
		[DataRow("MCMLXXXIV", 1984)]
		[DataRow("XXXII", 32)]
		[DataRow("XLVIII", 48)]
		[DataRow("LIII", 53)]
		[DataRow("LXXXIX", 89)]
		[DataRow("CD", 400)]
		[DataRow("DCC", 700)]
		[DataRow("CM", 900)]
		[TestMethod]
		public void ConvertFromTests_Good(string numerals, int expected)
		{
			// Act
			var actual = numerals.FromRomanNumerals();
			// Assert
			Assert.AreEqual(expected, actual);
		}
	}
}