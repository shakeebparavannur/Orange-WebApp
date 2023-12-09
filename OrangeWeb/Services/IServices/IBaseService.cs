using OrangeWeb.Mode;
using OrangeWeb.Models;

namespace OrangeWeb.Services.IServices
{
    public interface IBaseService:IDisposable
    {
       Task<ApiRequest>SendAsync(ApiRequest request);
    }
}
