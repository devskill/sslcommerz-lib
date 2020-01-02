using System;

namespace DevSkill.SSLCommerz.Core
{
	public class PaymentInitiationRequestBuilder
	{
		internal SSLCommerzSettings _Settings;

		public PaymentInitiationRequestBuilder(SSLCommerzSettings settings, string storeId, string storePassword, string successUrl, string failUrl, string cancelUrl, string ipnUrl)
		{
			_Settings = settings;
			_Settings.ApiSettings.StoreId = storeId;
			_Settings.ApiSettings.StorePassword = storePassword;
			_Settings.CallbackUrlSettings.SuccessUrl = successUrl;
			_Settings.CallbackUrlSettings.FailUrl = failUrl;
			_Settings.CallbackUrlSettings.CancelUrl = cancelUrl;
			_Settings.CallbackUrlSettings.IpnUrl = ipnUrl;
		}

		public PaymentInitiationRequestBuilder ConfigureApi(Action<SSLCommerzApiSettings> predicate)
		{
			predicate?.Invoke(_Settings.ApiSettings);
			return this;
		}

		public void ConfigureEnvironment(PaymentEnvionment env)
			=> _Settings.IsProduction = env == PaymentEnvionment.Production;

		public PaymentInitiationRequestBuilder ConfigureUrl(Action<SSLCommerzUrlSettings> predicate)
		{
			predicate?.Invoke(_Settings.CallbackUrlSettings);
			return this;
		}

		public SSLCommerzSettings Build()
		{
			return _Settings;
		}
	}
}
