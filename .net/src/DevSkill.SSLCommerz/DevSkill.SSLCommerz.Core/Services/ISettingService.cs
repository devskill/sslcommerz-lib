namespace DevSkill.SSLCommerz.Core.Services
{
	public interface ISettingService
	{
		SSLCommerzSettings GetSettings();
		void Settings(SSLCommerzSettings settings);
	}
}