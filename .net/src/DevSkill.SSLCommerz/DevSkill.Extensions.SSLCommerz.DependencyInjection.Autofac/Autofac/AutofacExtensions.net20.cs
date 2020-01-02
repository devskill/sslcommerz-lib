using Autofac;

using DevSkill.SSLCommerz.Core;
using DevSkill.SSLCommerz.Core.Services;

using Microsoft.Extensions.DependencyInjection;

using System;
using System.Net.Http;

namespace DevSkill.Extensions.SSLCommerz.DependencyInjection
{
	public static class AutofacExtensions
	{
		private static SSLCommerzSettings _Settings;
		internal static IServiceCollection ConfigureSSLCommerzSettings(
			this IServiceCollection services,
			SSLCommerzSettings settings,
			Action<SSLCommerzApiSettings> apiSetting,
			Action<SSLCommerzUrlSettings> urlSetting
		)
		{
			_Settings = settings;
			apiSetting?.Invoke(settings.ApiSettings);
			urlSetting?.Invoke(settings.CallbackUrlSettings);
			services.AddSingleton(_Settings);
			return services;
		}
		internal static IServiceCollection ConfigureSSLCommerzServices(
			this IServiceCollection services,
			SSLCommerzSettings settings,
			Action<SSLCommerzApiSettings> apiSetting,
			Action<SSLCommerzUrlSettings> urlSetting
		)
		{
			_Settings = settings;
			apiSetting?.Invoke(settings.ApiSettings);
			urlSetting?.Invoke(settings.CallbackUrlSettings);
			services.AddSingleton<ISettingService, SettingService>(sp => new SettingService(settings));

			using (var client = new HttpClient
			{
				BaseAddress = new Uri(_Settings.BaseUrl)
			})
			{
				var svc = services.BuildServiceProvider().GetRequiredService<ISettingService>();
				services.AddSingleton<ISSLCommerzService, SSLCommerzService>(sp => new SSLCommerzService(client, svc));
			}
			return services;
		}
		public static IServiceCollection AddSSLCommerz(
			this IServiceCollection services,
			Action<SSLCommerzSettings> setting,
			Action<SSLCommerzApiSettings> apiSetting,
			Action<SSLCommerzUrlSettings> urlSetting
		)
		{
			var settings = new SSLCommerzSettings();
			setting?.Invoke(settings);
			services.ConfigureSSLCommerzSettings(settings, apiSetting, urlSetting);
			services.ConfigureSSLCommerzServices(settings, apiSetting, urlSetting);
			return services;
		}
		public static ContainerBuilder RegisterSSLCommerz(
			this ContainerBuilder cb,
			Action<SSLCommerzApiSettings> apiSetting,
			Action<SSLCommerzUrlSettings> urlSetting
		)
		{
			cb.RegisterModule(new SSLCommerzModule(apiSetting, urlSetting));
			return cb;
		}
	}
}
