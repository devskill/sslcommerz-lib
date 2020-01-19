using System.ComponentModel.DataAnnotations;

namespace DevSkill.SSLCommerz.Core
{
	public class DecimalAttribute 
		: RegularExpressionAttribute
	{
		public int DecimalPlaces { get; set; }

		public DecimalAttribute(int decimalPlaces)
		    : this(
				 decimalPlaces,
				 "This number can have maximum {0} decimal places"
			)
		{
			DecimalPlaces = decimalPlaces;
		}

		public DecimalAttribute(
			int decimalPlaces,
			string errorMessage)
		    : base($@"^\d*\.?\d{{0,{decimalPlaces}}}$")
		{
			DecimalPlaces = decimalPlaces;
			if (string.IsNullOrEmpty(errorMessage))
				errorMessage = "This number can have maximum {0} decimal places";
			ErrorMessage = errorMessage;
		}

		public override string FormatErrorMessage(string name) 
			=> string.Format(
				ErrorMessage,
				DecimalPlaces
			);
	}
}
