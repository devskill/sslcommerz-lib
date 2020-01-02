using System;

namespace DevSkill.SSLCommerz.Core.Services
{
	public class SettingService
		: ISettingService
	{
		private SSLCommerzSettings _settings;

		public SettingService(SSLCommerzSettings settings)
		{
			_settings = settings;
		}

		public SSLCommerzSettings GetSettings()
		{
			return _settings ?? throw new NullReferenceException();
		}
		public void SetSettings(SSLCommerzSettings settings)
			=> _settings = settings;
	}
}