
using Refit;
using System.Threading.Tasks;

namespace CSharp_REST_WEB_API__JSON
{
    public interface ApiService
    {
        [Get("")]
        Task<RestResponse> GetAddressAsync(string vlr_cotacao);
    }
}
