using Newtonsoft.Json;

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text;

namespace DevSkill.SSLCommerz.Core.Models
{
	public class SSLCommerzPaymentInitiationRequest
	{
		#region integration info
		[Required]
		[StringLength(30)]
		[JsonProperty(
			PropertyName = "store_id",
			Required = Required.Always
		)]
		public string StoreId { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[StringLength(30)]
		[JsonProperty(
			PropertyName = "store_passwd",
			Required = Required.Always
		)]
		public string StorePassword { get; set; }

		[Required]
		[DataType(DataType.Currency)]
		[Decimal(2)]
		[Range(10.00D, 500000.00D)]
		[JsonProperty(
			PropertyName = "total_amount",
			Required = Required.Always
		)]
		public decimal TotalAmount { get; set; }

		[Required]
		[StringLength(3)]
		[JsonProperty(
			PropertyName = "currency",
			Required = Required.Always
		)]
		public string Currency { get; set; }

		[Required]
		[StringLength(30)]
		[JsonProperty(
			PropertyName = "tran_id",
			Required = Required.Always
		)]
		public string TransactionId { get; set; }

		[Required]
		[StringLength(255)]
		[Url]
		[JsonProperty(
			PropertyName = "success_url",
			Required = Required.Always
		)]
		public string SuccessUrl { get; set; }

		[Required]
		[StringLength(255)]
		[Url]
		[JsonProperty(
			PropertyName = "fail_url",
			Required = Required.Always
		)]
		public string FailUrl { get; set; }

		[Required]
		[StringLength(255)]
		[Url]
		[JsonProperty(
			PropertyName = "cancel_url",
			Required = Required.Always
		)]
		public string CancelUrl { get; set; }

		[StringLength(255)]
		[Url]
		[JsonProperty(
			PropertyName = "ipn_url"
		)]
		public string IpnUrl { get; set; }

		[StringLength(30)]
		[JsonProperty(
			PropertyName = "multi_card_name",
			Required = Required.AllowNull
		)]
		public string VisibleGateways { get; set; }
		#endregion

		#region EMI info

		[Required]
		[JsonProperty(
			PropertyName = "emi_option",
			Required = Required.Always
		)]
		public EMITransactionModel.EMIOption EmiOption { get; set; }

		[JsonProperty(
			PropertyName = "emi_max_inst_option",
			Required = Required.AllowNull
		)]
		public EMITransactionModel.EMIMaxInstallmentOption MaxInstallmentOption { get; set; }

		[JsonProperty(
			PropertyName = "emi_selected_ins",
			Required = Required.AllowNull
		)]
		public EMITransactionModel.EMIMaxInstallmentOption SelectedInstallmentOption { get; set; }

		[Range(0, 1)]
		[JsonProperty(
			PropertyName = "emi_allow_only"
		)]
		public int EmiAllowOnly { get; set; }
		#endregion

		#region customer info 
		[Required]
		[StringLength(50)]
		[JsonProperty(
			PropertyName = "cus_name"
		)]
		public string CustomerName { get; set; }

		[Required]
		[StringLength(50)]
		[EmailAddress]
		[DataType(DataType.EmailAddress)]
		[JsonProperty(
			PropertyName = "cus_email"
		)]
		public string CustomerEmail { get; set; }

		[Required]
		[StringLength(50)]
		[JsonProperty(
			PropertyName = "cus_add1"
		)]
		public string CustomerAddress1 { get; set; }

		[StringLength(50)]
		[JsonProperty(
			PropertyName = "cus_add2"
		)]
		public string CustomerAddress2 { get; set; }

		[Required]
		[StringLength(50)]
		[JsonProperty(
			PropertyName = "cus_city"
		)]
		public string CustomerCity { get; set; }

		[StringLength(50)]
		[JsonProperty(
			PropertyName = "cus_state"
		)]
		public string CustomerState { get; set; }

		[Required]
		[StringLength(30)]
		[JsonProperty(
			PropertyName = "cus_posatcode"
		)]
		public string CustomerPostCode { get; set; }

		[Required]
		[StringLength(50)]
		[JsonProperty(
			PropertyName = "cus_country"
		)]
		public string CustomerCountry { get; set; }

		[Required]
		[StringLength(20)]
		[JsonProperty(
			PropertyName = "cus_phone",
			Required = Required.Always
		)]
		public string CustomerPhone { get; set; }

		[StringLength(20)]
		[JsonProperty(
			PropertyName = "cus_fax"
		)]
		public string CustomerFax { get; set; }

		#endregion

		#region shipment info
		[Required]
		[StringLength(50)]
		[JsonProperty(
			PropertyName = "shipping_method",
			Required = Required.Always
		)]
		public string ShippingMethod { get; set; }

		[Required]
		[Range(0, 9)]
		[JsonProperty(
			PropertyName = "num_of_item"
		)]
		public int Quantity { get; set; }

		// public string ShipName { get; set; }
		#endregion

		#region product information
		[Required]
		[StringLength(256)]
		[JsonProperty(
			PropertyName = "product_name",
			Required = Required.Always
		)]
		public string ProductName { get; set; }

		[Required]
		[StringLength(100)]
		[JsonProperty(
			PropertyName = "product_category",
			Required = Required.Always
		)]
		public string ProductCategory { get; set; }

		[Required]
		[StringLength(100)]
		[JsonProperty(
			PropertyName = "product_profile",
			Required = Required.Always
		)]
		public string ProductProfile { get; set; }

		[JsonProperty(
			PropertyName = "cart",
			Required = Required.AllowNull
		)]
		public IEnumerable<Cart> CartItems { get; set; }

		[Decimal(10,2)]
		[JsonProperty(
			PropertyName = "product_amount",
			Required = Required.AllowNull
		)]
		public decimal ProductAmount { get; set; }

		[Decimal(10, 2)]
		[JsonProperty(
			PropertyName = "vat",
			Required = Required.AllowNull
		)]
		public decimal VAT { get; set; }

		[Decimal(10, 2)]
		[JsonProperty(
			PropertyName = "discount_amount",
			Required = Required.AllowNull
		)]
		public decimal DiscountAmount { get; set; }

		[Decimal(10, 2)]
		[JsonProperty(
			PropertyName = "convenience_fee",
			Required = Required.AllowNull
		)]
		public decimal ConvenienceFee { get; set; }

		#endregion

		public override string ToString()
		{
			var i = 0;
			var sb = new StringBuilder();
			var properties = typeof(SSLCommerzPaymentInitiationRequest).GetProperties();
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
					else if (p.PropertyType == typeof(IEnumerable)
						|| p.PropertyType == typeof(IEnumerable<>)
						|| p.PropertyType == typeof(Array))
					{						
						var values = (Array)p.GetValue(this);
						if (values.Length > 0)
						{
							var jsonValues = JsonConvert.SerializeObject(values);
							var encodedString = WebUtility.UrlEncode(jsonValues);
							sb.Append($"{jsonPropertyName}={encodedString}");
						}
					}
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
