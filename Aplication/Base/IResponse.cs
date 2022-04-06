using System.Net;

namespace Aplication
{
    public interface IResponse<T>
    {
        HttpStatusCode Code { get; set; }
        T Data { get; set; }
    }
}
