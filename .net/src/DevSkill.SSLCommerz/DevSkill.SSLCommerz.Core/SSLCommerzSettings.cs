namespace DevSkill.SSLCommerz.Core
{
	public class SSLCommerzSettings
	{
		private readonly string _paymentEnvironment;
		public string BaseUrl { get => $"https://{_paymentEnvironment}.sslcommerz.com"; }
		public string PaymentInitiationUrl { get => $"gwprocess/v{Version}/api.php"; }
		public string PaymentValidationUrl { get => "validator/api/validationserverAPI.php"; }
		public int Version { get; set; }

		public SSLCommerzApiSettings ApiSettings { get; internal set; } = new SSLCommerzApiSettings();
		public SSLCommerzUrlSettings CallbackUrlSettings { get; internal set; } = new SSLCommerzUrlSettings();

		public bool IsProduction { get; set; } = false;

		public SSLCommerzSettings()
		{
			_paymentEnvironment = IsProduction ? "securepay" : "sandbox";
		}
	}
}
