using Autofac;
using Autofac.Core;

using DevSkill.SSLCommerz.Core.Services;
using DevSkill.SSLCommerz.Core;
using System.Collections.Generic;
using System;

namespace DevSkill.Extensions.SSLCommerz.DependencyInjection
{
	internal class SSLCommerzModule
		: Module
	{
		Action<SSLCommerzApiSettings> _apiSettings;
		Action<SSLCommerzUrlSettings> _urlSettings;
		public SSLCommerzModule(Action<SSLCommerzApiSettings> apiSettings, Action<SSLCommerzUrlSettings> urlSettings)
			: base()
		{
			_apiSettings = apiSettings;
			_urlSettings = urlSettings;
		}

		protected override void Load(ContainerBuilder builder)
		{
			var settings = new SSLCommerzSettings();
			_apiSettings?.Invoke(settings.ApiSettings);
			_urlSettings?.Invoke(settings.CallbackUrlSettings);
			ICollection<Parameter> props = new List<Parameter>();
			props.Add(new TypedParameter(typeof(SSLCommerzApiSettings), settings.ApiSettings));
			props.Add(new TypedParameter(typeof(SSLCommerzUrlSettings), settings.CallbackUrlSettings));
			builder.RegisterType<SSLCommerzSettings>().WithProperties(props).AsSelf();
			builder.RegisterType<SettingService>().As<ISettingService>().WithProperties(props).SingleInstance();
			builder.RegisterType<SSLCommerzService>().As<ISSLCommerzService>().SingleInstance();
		}
	}
}