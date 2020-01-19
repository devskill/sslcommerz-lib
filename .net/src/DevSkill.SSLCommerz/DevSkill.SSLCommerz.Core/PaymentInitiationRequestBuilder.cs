using System;

namespace DevSkill.SSLCommerz.Core
{
	public class PaymentInitiationRequestBuilder
	{
		internal SSLCommerzSettings _Settings;

		public PaymentInitiationRequestBuilder()
		{
			_Settings = new SSLCommerzSettings();
			_Settings.ApiSettings = new SSLCommerzApiSettings();
			_Settings.CallbackUrlSettings = new SSLCommerzUrlSettings();
		}

		public PaymentInitiationRequestBuilder ConfigureApi(Action<SSLCommerzApiSettings> predicate)
		{
			predicate?.Invoke(_Settings.ApiSettings);
			return this;
		}

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
