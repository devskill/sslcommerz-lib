namespace DevSkill.SSLCommerz.Core.Models
{
	public class EMITransactionModel
	{
		public enum EMIOption
		{
			Allowed = 1,
			NotAllowed = 0
		}

		public enum EMIMaxInstallmentOption
		{
			Three = 3,
			Six = 6,
			Nine = 9
		}
	}
}
