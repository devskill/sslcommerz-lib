using System;
using System.Collections.Generic;

namespace SSLCommerzSample.Models
{
	public class PaymentChannel
	{
		public enum PaymentOrganization
		{
			BRAC,
			DBBL,
			EBL,
			SBL,
			CITY,
			BankAsia,
			ABBank,
			IBBL,
			MTBL,
			QCash
		}

		public enum PaymentMedium
		{
			AMEX,
			VISA,
			MasterCard,
			Nexus,
			OtherCards,
			InternetBanking,
			MobileBanking
		}

		public static Func<IEnumerable<string>> Channels { get; set; }

		public static string GetPaymentChannel(
			PaymentOrganization bank,
			PaymentMedium medium
		)
		{
			switch (bank)
			{
				case PaymentOrganization.ABBank:
				{
					switch (medium)
					{
						case PaymentMedium.InternetBanking: return "abbank";
						default: throw new InvalidOperationException("Payment Medium not supported");
					}
				}
				case PaymentOrganization.BankAsia:
				{
					switch (medium)
					{
						case PaymentMedium.InternetBanking: return "abbank";
						default: throw new InvalidOperationException("Payment Medium not supported");
					}
				}
				case PaymentOrganization.BRAC:
				{
					switch (medium)
					{
						case PaymentMedium.VISA: return "brac_visa";
						case PaymentMedium.MasterCard: return "brac_master";
						case PaymentMedium.MobileBanking: return "bkash";
						default: throw new InvalidOperationException("Payment Medium not supported");
					}
				}
				case PaymentOrganization.CITY:
				{
					switch (medium)
					{
						case PaymentMedium.AMEX: return "city_visa";
						case PaymentMedium.MasterCard: return "city_master";
						case PaymentMedium.VISA: return "city_visa";
						case PaymentMedium.InternetBanking: return "city";
						default: throw new InvalidOperationException("Payment Medium not supported");
					}
				}
				case PaymentOrganization.DBBL:
				{
					switch (medium)
					{
						case PaymentMedium.VISA: return "dbbl_visa";
						case PaymentMedium.MasterCard: return "dbbl_master";
						case PaymentMedium.Nexus: return "dbbl_nexus";
						case PaymentMedium.MobileBanking: return "dbblmobilebanking";
						default: throw new InvalidOperationException("Payment Medium not supported");
					}
				}
				case PaymentOrganization.EBL:
				{
					switch (medium)
					{
						case PaymentMedium.VISA: return "ebl_visa";
						case PaymentMedium.MasterCard
   :
							return "ebl_master";
						default: throw new InvalidOperationException("Payment Medium not supported");
					}
				}
				case PaymentOrganization.IBBL:
				{
					switch (medium)
					{
						case PaymentMedium.InternetBanking: return "ibbl";
						default: throw new InvalidOperationException("Payment Medium not supported");
					}
				}
				case PaymentOrganization.MTBL:
				{
					switch (medium)
					{
						case PaymentMedium.InternetBanking: return "mtbl";
						default: throw new InvalidOperationException("Payment Medium not supported");
					}
				}
				case PaymentOrganization.QCash:
				{
					switch (medium)
					{
						case PaymentMedium.OtherCards: return "qcash";
						default: throw new InvalidOperationException("Payment Medium not supported");
					}
				}
				case PaymentOrganization.SBL:
				{
					switch (medium)
					{
						case PaymentMedium.VISA: return "sbl_visa";
						case PaymentMedium.MasterCard: return "sbl_master";
						default: throw new InvalidOperationException("Payment Medium not supported");
					}
				}
				default: throw new InvalidOperationException("Payment Medium not supported");
			};
		}
	}
}
