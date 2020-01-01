using Newtonsoft.Json;

namespace SSLCommerzSample.Models
{
	public class Gateways
	{
		[JsonProperty("visa")]
		public string Visa { get; set; }
		[JsonProperty("master")]
		public string MasterCard { get; set; }
		[JsonProperty("Amex")]
		public string AmericanExpress { get; set; }
		[JsonProperty("othercards")]
		public string OtherCards { get; set; }
		[JsonProperty("internetbanking")]
		public string InternetBanking { get; set; }
		[JsonProperty("mobilebanking")]
		public string MobileBanking { get; set; }
	}
}
