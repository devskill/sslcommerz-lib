using DevSkill.SSLCommerz.Core.Models;

namespace DevSkill.SSLCommerz.Core
{
	public class PaymentInitiationRequestBuilder
	{
		internal SSLCommerzSettings _Settings;
		internal SSLCommerzPaymentInitiationRequest _Request;

		public PaymentInitiationRequestBuilder(SSLCommerzSettings settings)
		{
			_Settings = settings;
			_Request = new SSLCommerzPaymentInitiationRequest()
			{
				StoreId = _Settings.ApiSettings.StoreId,
				StorePassword = _Settings.ApiSettings.StorePassword,

				SuccessUrl = _Settings.CallbackUrlSettings.SuccessUrl,
				FailUrl = _Settings.CallbackUrlSettings.FailUrl,
				CancelUrl = _Settings.CallbackUrlSettings.CancelUrl,
				IpnUrl = _Settings.CallbackUrlSettings.IpnUrl
			};
		}

		public PaymentInitiationRequestBuilder ConfigureCustomer(
			string name,
			string email,
			string profile,
			decimal? amount,
			decimal? vat,
			decimal? discountAmount,
			decimal? convenienceFee
		)
		{
			_Request.ProductName = name;
			_Request.ProductCategory = category;
			_Request.ProductProfile = profile;
			_Request.ProductAmount = amount.HasValue ? amount.Value : 0;
			_Request.VAT = vat.HasValue ? vat.Value : 0;
			_Request.DiscountAmount = discountAmount.HasValue ? discountAmount.Value : 0;
			_Request.ConvenienceFee = convenienceFee.HasValue ? convenienceFee.Value : 0;
			return this;
		}

		public PaymentInitiationRequestBuilder ConfigureProduct(
			string name,
			string category,
			string profile,
			decimal? amount,
			decimal? vat,
			decimal? discountAmount,
			decimal? convenienceFee
		)
		{
			_Request.ProductName = name;
			_Request.ProductCategory = category;
			_Request.ProductProfile = profile;
			_Request.ProductAmount = amount.HasValue ? amount.Value : 0;
			_Request.VAT = vat.HasValue ? vat.Value : 0;
			_Request.DiscountAmount = discountAmount.HasValue ? discountAmount.Value : 0;
			_Request.ConvenienceFee = convenienceFee.HasValue ? convenienceFee.Value : 0;
			return this;
		}

		public void ConfigureEnvironment(PaymentEnvionment env)
			=> _Settings.IsProduction = env == PaymentEnvionment.Production;

		public SSLCommerzPaymentInitiationRequest Build()
		{
			return _Request;
		}
	}
}
