using System.ComponentModel.DataAnnotations;

namespace DevSkill.SSLCommerz.Core
{
	public class DecimalAttribute
		: RegularExpressionAttribute
	{
		public int NumberOfDigits { get; set; }
		public int DecimalPlaces { get; set; }

		public DecimalAttribute(int decimalPlaces)
		    : this(
				 decimalPlaces,
				 "This number can have maximum {0} decimal places"
			)
		{
			NumberOfDigits = 0;
			DecimalPlaces = decimalPlaces;
		}

		public DecimalAttribute(int numberOfDigits, int decimalPlaces)
		    : this(
				 numberOfDigits,
				 decimalPlaces,
				 "This number can have maximum {0} decimal places with maximum {1} digit(s)"
			)
		{
			NumberOfDigits = numberOfDigits;
			DecimalPlaces = decimalPlaces;
		}

		public DecimalAttribute(
			int decimalPlaces,
			string errorMessage)
		    : base($@"^[1-9]\d+(\.\d{{{2}}})?$")
		{
			DecimalPlaces = decimalPlaces;
			if (string.IsNullOrEmpty(errorMessage))
				errorMessage = "This number can have maximum {0} decimal places";
			ErrorMessage = errorMessage;
		}

		public DecimalAttribute(
			int numberOfDigits,
			int decimalPlaces,
			string errorMessage)
		    : base($@"^[1-9]\d{{{numberOfDigits}}}(\.\d{{{decimalPlaces}}})?$")
		{
			NumberOfDigits = numberOfDigits;
			DecimalPlaces = decimalPlaces;
			if (string.IsNullOrEmpty(errorMessage))
				errorMessage = "This number can have maximum {0} decimal places with maximum {1} digits(s)";
			ErrorMessage = errorMessage;
		}

		public override string FormatErrorMessage(string name)
		{
			if (NumberOfDigits > 0)
				return string.Format(
				   ErrorMessage,
				   DecimalPlaces,
				   NumberOfDigits
				);
			return string.Format(
				ErrorMessage,
				DecimalPlaces
			);
		}
	}
}
