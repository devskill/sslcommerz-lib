using System;
using System.Collections.Generic;
using System.Text;

namespace DevSkill.SSLCommerz.Core
{
	public class SSLCommerzUrlSettings
	{
		public string SuccessUrl { get; internal set; }
		public string FailUrl { get; internal set; }
		public string CancelUrl { get; internal set; }
		public string IpnUrl { get; internal set; }
	}
}
