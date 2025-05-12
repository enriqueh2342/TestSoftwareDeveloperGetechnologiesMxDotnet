using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TestSoftwareDeveloperGetechnologiesMxDotnet.Models
{
    public class GenericResponse
    {
        public HttpStatusCode Code { get; set; }
        public string Message { get; set; }
        public int? Data { get; set; }
    }
}
