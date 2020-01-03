using Autofac;
using Autofac.Core.Registration;

using DevSkill.SSLCommerz.Core;

using System;

namespace DevSkill.Extensions.SSLCommerz.DependencyInjection
{
	public static class AutofacExtensions
	{
		public static IModuleRegistrar RegisterSSLCommerzPaymentModule(
			this ContainerBuilder cb,
			SSLCommerzApiSettings apiSettings,
			SSLCommerzUrlSettings urlSettings,
			SSLCommerzSettings settings
			)
			=> cb.RegisterModule(new SSLCommerzModule(settings, apiSettings, urlSettings, 4));

		public static IModuleRegistrar RegisterSSLCommerzPaymentModule(
			this ContainerBuilder cb,
			Action<SSLCommerzApiSettings> apiSettingsDelegate,
			Action<SSLCommerzUrlSettings> urlSettingsDelegate,
			SSLCommerzSettings settings
			)
			=> cb.RegisterModule(new SSLCommerzModule(settings, apiSettingsDelegate, urlSettingsDelegate, 4));
	}
}
