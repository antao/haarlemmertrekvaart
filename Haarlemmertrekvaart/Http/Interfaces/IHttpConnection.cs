using System.Threading.Tasks;

namespace Haarlemmertrekvaart.Http.Interfaces
{
    public interface IHttpConnection
    {
        Task<IHttpResponse> Get(IHttpRequest request);
    }
}
