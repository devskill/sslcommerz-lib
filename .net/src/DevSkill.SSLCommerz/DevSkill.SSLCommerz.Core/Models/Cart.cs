using Newtonsoft.Json;

using System.ComponentModel.DataAnnotations;

namespace DevSkill.SSLCommerz.Core.Models
{
	[JsonObject]
	public class Cart
	{
		[Required]
		[JsonProperty(
			PropertyName = "product",
			Required = Required.Always
		)]
		public string Name { get; set; }

		[Required]
		[Numeric]
		[JsonProperty(
			PropertyName = "quantity",
			Required = Required.Always
		)]
		public string Quantity { get; set; }

		[Required]
		[Decimal(12, 2)]
		[JsonProperty(
			PropertyName = "amount",
			Required = Required.Always
		)]
		public decimal Amount { get; set; }
	}
}
