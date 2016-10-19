using System.Threading.Tasks;

namespace Haarlemmertrekvaart.Http.Interfaces
{
    public interface IHttpConnection
    {
        Task<IHttpResponse> Get(IHttpRequest request);

        Task<IHttpResponse> Put(IHttpRequest request);

        Task<IHttpResponse> Post(IHttpRequest request);

        Task<IHttpResponse> Delete(IHttpRequest request);
    }
}
