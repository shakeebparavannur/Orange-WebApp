using OrangeWeb.Mode;
using OrangeWeb.Models;
using OrangeWeb.Services.IServices;

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
        public void Dispose()
        {
           GC.SuppressFinalize(true);
        }

        //public Task<T> SendAsync<T>(ApiRequest apiRequest)
        //{
        //    try
        //    {
        //        var client = httpClient.CreateClient("OrangeAPI");
        //        HttpRequestMessage message = new HttpRequestMessage();
        //        message.Headers.Add("Accept", "application/json");
        //        message.RequestUri = new Uri(apiRequest.Url);

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}
    }
}
