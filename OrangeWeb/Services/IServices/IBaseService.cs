using OrangeWeb.Mode;
using OrangeWeb.Models;

namespace OrangeWeb.Services.IServices
{
    public interface IBaseService
    {
       Task<ResponseDto> SendAsync(ApiRequest request);
    }
}
