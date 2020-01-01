using DevSkill.SSLCommerz.Core.Models;

using System.Threading.Tasks;

namespace DevSkill.SSLCommerz.Core.Services
{
	public interface ISSLCommerzService
	{
		Task<SSLCommerzSessionResponse> InitiateRequestAsync(SSLCommerzSessionRequest request);
	}
}
