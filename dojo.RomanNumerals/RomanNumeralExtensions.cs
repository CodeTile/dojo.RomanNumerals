namespace dojo.RomanNumerals
{
	public static class RomanNumeralExtensions
	{
		public static int FromRomanNumerals(this string romanNumerals)
		{
			if (string.IsNullOrEmpty(romanNumerals))
				throw new ArgumentNullException(nameof(romanNumerals));
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

		private static int GetNumberFromNumeral(char romanNumeral)
		{
			return romanNumeral switch
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
}