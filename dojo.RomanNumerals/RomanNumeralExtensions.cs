using System.Text;

namespace dojo.RomanNumerals
{
	public static class RomanNumeralExtensions
	{
		public static int FromRomanNumerals(this string romanNumerals)
		{
			if (string.IsNullOrEmpty(romanNumerals))
				return 0;
			int result = 0;
			int currentNumber, nextNumber;
			for (int i = 0; i < romanNumerals.Length; i++)
			{
				currentNumber = GetNumberFromNumeral(romanNumerals[i]);
				if (i < romanNumerals.Length - 1)
				{
					nextNumber = GetNumberFromNumeral(romanNumerals[i + 1]);
					if (nextNumber > currentNumber)
					{
						currentNumber = nextNumber - currentNumber;
						i++;
					}
				}

				result += currentNumber;
			}

			return result;
		}

		public static string ToRomanNumeral(this int original)
		{
			ArgumentOutOfRangeException.ThrowIfGreaterThan(original, 3999);
			ArgumentOutOfRangeException.ThrowIfLessThan(original, 0);
			StringBuilder sb = new();
			if (original == 0)
				return string.Empty;

			sb.Append(ConvertThousands(original));
			sb.Append(ConvertHundreds(original));
			sb.Append(ConvertTens(original));
			sb.Append(ConvertOnes(original));
			return sb.ToString();
		}

		private static string ConvertHundreds(int original)
		{
			string uot = original.ToString().PadLeft(4, '0').Substring(1, 1);
			return uot switch
			{
				"1" => "C",
				"2" => "CC",
				"3" => "CCC",
				"4" => "CD",
				"5" => "D",
				"6" => "DC",
				"7" => "DCC",
				"8" => "DCCC",
				"9" => "CM",
				_ => "",
			};
		}

		private static string ConvertOnes(int original)
		{
			string uot = original.ToString().PadLeft(4, '0').Substring(3, 1);
			return uot switch
			{
				"1" => "I",
				"2" => "II",
				"3" => "III",
				"4" => "IV",
				"5" => "V",
				"6" => "VI",
				"7" => "VII",
				"8" => "VIII",
				"9" => "IX",
				_ => "",
			};
		}

		private static string ConvertTens(int original)
		{
			string uot = original.ToString().PadLeft(4, '0').Substring(2, 1);
			return uot switch
			{
				"1" => "X",
				"2" => "XX",
				"3" => "XXX",
				"4" => "XL",
				"5" => "L",
				"6" => "LX",
				"7" => "LXX",
				"8" => "LXXX",
				"9" => "XC",
				_ => "",
			};
		}

		private static string ConvertThousands(int original)
		{
			string uot = original.ToString().PadLeft(4, '0')[..1];
			return uot switch
			{
				"1" => "M",
				"2" => "MM",
				"3" => "MMM",
				_ => "",
			};
		}

		private static int GetNumberFromNumeral(char romanNumeral) => romanNumeral switch
		{
			'I' => 1,
			'V' => 5,
			'X' => 10,
			'L' => 50,
			'C' => 100,
			'D' => 500,
			'M' => 1000,
			_ => throw new ArgumentOutOfRangeException($"Unknown roman numeral '{romanNumeral}'!"),
		};
	}
}