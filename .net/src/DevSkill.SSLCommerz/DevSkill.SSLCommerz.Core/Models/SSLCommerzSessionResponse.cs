using DevSkill.SSLCommerz.Core.Models;

using Newtonsoft.Json;

using System;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DevSkill.SSLCommerz.Core.Models
{
	public class SSLCommerzPaymentInitiationResponse
	{
		[StringLength(10)]
		[JsonProperty("status")]
		public string Status { get; set; }

		[StringLength(255)]
		[JsonProperty("failedreason")]
		public string FailedReason { get; set; }

		[StringLength(50)]
		[JsonProperty("sessionkey")]
		public string SessionKey { get; set; }

		[JsonProperty("gw")]
		public Gateways Gateway { get; set; }

		[StringLength(255)]
		[JsonProperty("GatewayPageUrl")]
		public string GatewayPageUrl { get; set; }

		[StringLength(255)]
		[JsonProperty("storeBanner")]
		public string StoreBanner { get; set; }

		[StringLength(255)]
		[JsonProperty("storeLogo")]
		public string StoreLogo { get; set; }

		[JsonProperty("desc")]
		public Description[] Description { get; set; }

		[JsonProperty("is_direct_pay_enable")]
		public string IsDirectPayEnabled { get; set; }

		[JsonProperty("directPaymentURL")]
		public string DirectPaymentUrl { get; set; }

		[JsonProperty("directPaymentURLBank")]
		public string DirectPaymentUrlBank { get; set; }

		[JsonProperty("directPaymentURLCard")]
		public string DirectPaymentUrlCard { get; set; }

		[JsonProperty("redirectGatewayURL")]
		public string RedirectGatewayUrl { get; set; }

		[JsonProperty("redirectGatewayURLFailed")]
		public string RedirectPaymentUrlFailed { get; set; }

		public override string ToString()
		{
			var i = 0;
			var sb = new StringBuilder();
			var properties = typeof(SSLCommerzPaymentInitiationResponse).GetProperties();
			foreach (var p in properties)
			{
				var jsonPropertyAttribute = (JsonPropertyAttribute)Attribute.GetCustomAttribute(p, typeof(JsonPropertyAttribute));
				if (jsonPropertyAttribute != null)
				{
					var jsonPropertyName = jsonPropertyAttribute
						.PropertyName;
					if (p.PropertyType == typeof(int)
						|| p.PropertyType == typeof(decimal))
						sb.Append($"{jsonPropertyName}={p.GetValue(this)}");
					else if (p.PropertyType == typeof(string))
					{
						var val = p.GetValue(this) as string;
						if (!string.IsNullOrEmpty(val))
							sb.Append($"{jsonPropertyName}={val}");
					}
					else if (p.PropertyType == typeof(EMITransactionModel.EMIOption)
						|| p.PropertyType == typeof(EMITransactionModel.EMIMaxInstallmentOption))
						sb.Append($"{jsonPropertyName}={ (int)p.GetValue(this)}");
					if (i < properties.Length - 1)
						sb.Append("&");
				}
				i++;
			}
			var result = sb.ToString();
			if (result.EndsWith("&"))
				result = result.Substring(0, result.Length - 2);
			return result;
		}
	}
}
