using Newtonsoft.Json;

using SSLCommerzSample.Core;

using System;
using System.ComponentModel.DataAnnotations;

namespace SSLCommerzSample.Models
{
	public class SSLCommerzIPNRequest
	{
		[StringLength(20)]
		[JsonProperty(
			PropertyName = "status"
		)]
		public string Status { get; set; }

		[DataType(DataType.Date)]
		[JsonProperty(
			PropertyName = "trans_date"
		)]
		public DateTime TransactionDate { get; set; }

		[StringLength(30)]
		[JsonProperty(
			PropertyName = "tran_id"
		)]
		public string TransactionId { get; set; }

		[StringLength(50)]
		[JsonProperty(
			PropertyName = "val_id"
		)]
		public string ValidationId { get; set; }

		[DataType(DataType.Currency)]
		[Decimal(2)]
		[JsonProperty(
			PropertyName = "amount"
		)]
		public decimal Amount { get; set; }

		[DataType(DataType.Currency)]
		[Decimal(2)]
		[JsonProperty(
			PropertyName = "store_amount"
		)]
		public decimal StoreAmount { get; set; }

		[StringLength(50)]
		[JsonProperty(
			PropertyName = "card_type"
		)]
		public string CardType { get; set; }

		[StringLength(30)]
		[JsonProperty(
			PropertyName = "card_no"
		)]
		public string CardNumber { get; set; }

		[StringLength(3)]
		[JsonProperty(
			PropertyName = "currency"
		)]
		public string Currency { get; set; }

		[StringLength(50)]
		[JsonProperty(
			PropertyName = "bank_tran_id"
		)]
		public string BankTransactionId { get; set; }

		[StringLength(50)]
		[JsonProperty(
			PropertyName = "card_issuer"
		)]
		public string CardIssuer { get; set; }

		[StringLength(30)]
		[JsonProperty(
			PropertyName = "card_brand"
		)]
		public string CardBrand { get; set; }

		[StringLength(50)]
		[JsonProperty(
			PropertyName = "card_issuer_country"
		)]
		public string CardIssuerCountry { get; set; }

		[StringLength(2)]
		[JsonProperty(
			PropertyName = "card_issuer_country_code"
		)]
		public string CardIssuerCountryCode { get; set; }

		[StringLength(3)]
		[JsonProperty(
			PropertyName = "currency_type"
		)]
		public string CurrencyType { get; set; }

		[DataType(DataType.Currency)]
		[Decimal(2)]
		public decimal CurrencyAmount { get; set; }

		[StringLength(255)]
		[JsonProperty(
			PropertyName = "value_a"
		)]
		public string ValueA { get; set; }

		[StringLength(255)]
		[JsonProperty(
			PropertyName = "value_b"
		)]
		public string ValueB { get; set; }

		[StringLength(255)]
		[JsonProperty(
			PropertyName = "value_c"
		)]
		public string ValueC { get; set; }

		[StringLength(255)]
		[JsonProperty(
			PropertyName = "value_d"
		)]
		public string ValueD { get; set; }

		[StringLength(255)]
		[JsonProperty(
			PropertyName = "verify_sign"
		)]
		public string VerifySign { get; set; }

		[JsonProperty(
			PropertyName = "verify_key"
		)]
		public string VerifyKey { get; set; }

		[Range(0,1)]
		[JsonProperty(
			PropertyName = "risk_level"
		)]
		public int RiskLevel { get; set; }

		[StringLength(50)]
		[JsonProperty(
			PropertyName = "risk_title"
		)]
		public string RiskTitle { get; set; }
	}
}
