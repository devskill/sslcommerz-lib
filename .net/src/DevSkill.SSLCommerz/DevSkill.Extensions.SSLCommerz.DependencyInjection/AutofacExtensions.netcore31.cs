using Autofac;
using Autofac.Core.Registration;
using DevSkill.SSLCommerz.Core;

namespace DevSkill.Extensions.SSLCommerz.DependencyInjection
{
	public static class AutofacExtensions
	{
		public static IModuleRegistrar RegisterSSLCommerzPaymentModule(
			this ContainerBuilder cb,
			SSLCommerzSettings settings
			)
			=> cb.RegisterModule(new SSLCommerzModule(settings));
	}
}
