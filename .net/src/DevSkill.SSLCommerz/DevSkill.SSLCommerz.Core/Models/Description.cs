
using Newtonsoft.Json;

namespace DevSkill.SSLCommerz.Core.Models
{
	[JsonObject]
	public class Description
	{
		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }

		[JsonProperty("logo")]
		public string Logo { get; set; }

		[JsonProperty("gw")]
		public string Gateway { get; set; }

		[JsonProperty("r_flag")]
		public string Rflag { get; set; }

		[JsonProperty("redirectGatewayUrl")]
		public string RedirectGatewayUrl { get; set; }
	}
}
