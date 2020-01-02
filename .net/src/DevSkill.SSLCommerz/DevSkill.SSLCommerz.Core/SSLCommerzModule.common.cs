using Autofac;

using DevSkill.SSLCommerz.Core;
using DevSkill.SSLCommerz.Core.Services;

using System;
using System.Net.Http;

namespace DevSkill.Extensions.SSLCommerz.DependencyInjection
{
	public class SSLCommerzModule
		: Module
	{
		private readonly SSLCommerzSettings _settings;

		public SSLCommerzModule(
			SSLCommerzSettings settings,
			int version
		)
			: base()
		{
			_settings = settings;
			if (version != 4)
				throw new ArgumentOutOfRangeException(nameof(version), "Only API version 4 is supperted");
			_settings.Version = version;
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
					client.BaseAddress = new Uri(_settings.BaseUrl);
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
