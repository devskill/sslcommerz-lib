using Autofac;

using DevSkill.SSLCommerz.Core;
using DevSkill.SSLCommerz.Core.Services;

using System.Net.Http;

namespace DevSkill.Extensions.SSLCommerz.DependencyInjection
{
	internal class SSLCommerzModule
		: Module
	{
		private readonly SSLCommerzSettings _settings;

		public SSLCommerzModule(SSLCommerzSettings settings)
			: base()
		{
			_settings = settings;
		}

		protected override void Load(ContainerBuilder builder)
		{
			builder
				.Register(c => _settings)
				.AsSelf()
				.SingleInstance();

			builder
				.Register(c =>
				{
					var client = new HttpClient();
					client.BaseAddress = new System.Uri(_settings.BaseUrl);
					return client;
				})
				.AsSelf()
				.InstancePerLifetimeScope();

			builder
				.RegisterType<SettingService>()
				.As<ISettingService>()
				.InstancePerRequest();

			builder
				.RegisterType<SSLCommerzService>()
				.As<ISSLCommerzService>()
				.InstancePerRequest();
		}
	}
}
