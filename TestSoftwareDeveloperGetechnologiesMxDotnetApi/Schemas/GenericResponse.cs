using System.Net;
using System.Security.Principal;

namespace TestSoftwareDeveloperGetechnologiesMxDotnetApi.Schemas
{
    public class GenericResponse
    {
        public HttpStatusCode Code { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
