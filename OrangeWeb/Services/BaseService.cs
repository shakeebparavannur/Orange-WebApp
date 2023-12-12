using Newtonsoft.Json;
using OrangeWeb.Mode;
using OrangeWeb.Models;
using OrangeWeb.Services.IServices;
using System.Net;
using System.Text;
using static OrangeWeb.Utility.SD;

namespace OrangeWeb.Services
{
    public class BaseService : IBaseService
    {
        public ResponseDto responseModel { get; set ; }
        public IHttpClientFactory httpClient { get;set ; }
        public BaseService(IHttpClientFactory httpClient)
        {
            this.responseModel = new ResponseDto();
            this.httpClient = httpClient;
        }
        /// <summary>
        /// Method to send and API request
        /// </summary>
        /// <param name="request">ApiRequest model </param>
        /// <returns> an Response Dto which contains the datas if success and error messages if its fails</returns>
        public async Task<ResponseDto> SendAsync(ApiRequest request)
        {
            try
            {


                HttpClient client = httpClient.CreateClient("OrangeAPI");
                HttpRequestMessage message = new();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(request.Url);
                if (request.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(request.Data), Encoding.UTF8, "application/json");
                }
                HttpResponseMessage response = null;

                switch (request.ApiType)
                {
                    case ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    case ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }
                response = await client.SendAsync(message);

                switch (response.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        return new() { IsSuccess = false, Message = "Not found" };
                    case HttpStatusCode.Forbidden:
                        return new() { IsSuccess = false, Message = "Access Denied" };
                    case HttpStatusCode.Unauthorized:
                        return new() { IsSuccess = false, Message = "Unauthorized" };
                    case HttpStatusCode.InternalServerError:
                        return new() { IsSuccess = false, Message = "Internal server Error" };
                    default:
                        var apiContent = await response.Content.ReadAsStringAsync();
                        var apiResposeDto = JsonConvert.DeserializeObject<ResponseDto>(apiContent);
                        return apiResposeDto;
                }
            }
            catch (Exception ex)
            {
                var dto = new ResponseDto()
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
                return dto;
            }
        }

        public void Dispose()
        {
            throw new Exception();
        }
    }
}
