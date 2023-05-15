using Mango.Web.Models;

namespace Mango.Web.Services.IServices
{
    public interface IServiceBase : IDisposable
    {
        ResponseDto responseModel { get; set; }
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
