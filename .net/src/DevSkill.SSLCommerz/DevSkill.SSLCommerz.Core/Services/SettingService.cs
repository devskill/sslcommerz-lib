using System;

namespace DevSkill.SSLCommerz.Core.Services
{
	internal class SettingService
		: ISettingService
	{
		private SSLCommerzSettings _settings;
		public SSLCommerzSettings GetSettings()
		{
			return _settings ?? throw new NullReferenceException();
		}
		public void SetSettings(SSLCommerzSettings settings)
			=> _settings = settings;
	}
}