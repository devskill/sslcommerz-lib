namespace DevSkill.SSLCommerz.Core
{
	public class SSLCommerzSettings
	{
		public string BaseUrl { get; internal set; }
		public string PaymentInitiationUrl { get => $"gwprocess/v{Version}/api.php"; }
		public string PaymentValidationUrl { get; internal set; }
		public int Version { get; internal set; }

		public SSLCommerzApiSettings ApiSettings { get; internal set; } = new SSLCommerzApiSettings();
		public SSLCommerzUrlSettings CallbackUrlSettings { get; internal set; } = new SSLCommerzUrlSettings();
	}
}
