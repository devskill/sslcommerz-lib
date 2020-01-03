using System.ComponentModel.DataAnnotations;

namespace DevSkill.SSLCommerz.Core
{
	public class NumericAttribute 
		: RegularExpressionAttribute
	{
		public int DecimalPlaces { get; set; }

		public NumericAttribute()
		    : this(
				 "This string must contain only numerical characters"
			)
		{
		}

		public NumericAttribute(
			string errorMessage
		)
		    : base($@"^[1-9]\d*$")
		{
			if (string.IsNullOrEmpty(errorMessage))
				errorMessage = "This string must contain only numerical characters";
			ErrorMessage = errorMessage;
		}
	}
}
