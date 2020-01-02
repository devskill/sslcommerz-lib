using DevSkill.SSLCommerz.Core.Models;

using Newtonsoft.Json;

using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.SSLCommerz.Core.Services
{
	public class SSLCommerzService
		: ISSLCommerzService
	{
		private readonly HttpClient _httpClient;
		private readonly ISettingService _settingService;

		public SSLCommerzService(HttpClient httlpClient, ISettingService settingService)
		{
			_httpClient = httlpClient;
			_settingService = settingService;
		}

		public async Task<SSLCommerzPaymentInitiationResponse> InitiateRequestAsync(SSLCommerzPaymentInitiationRequest request)
		{
			var settings = _settingService.GetSettings();
			var requestJson = request.ToString();
			var content = new StringContent(
				requestJson,
				Encoding.UTF8,
				"application/x-www-form-urlencoded"
			);
			var response = await _httpClient.PostAsync(settings.PaymentInitiationUrl, content);

			var responseString = await response.Content.ReadAsStringAsync();

			return JsonConvert
				.DeserializeObject<SSLCommerzPaymentInitiationResponse>(
				responseString,
				new JsonSerializerSettings()
				{
					ObjectCreationHandling = ObjectCreationHandling.Replace,
					NullValueHandling = NullValueHandling.Ignore,
				});
		}
	}
}
