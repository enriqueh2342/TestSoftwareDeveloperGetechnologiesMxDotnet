using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestSoftwareDeveloperGetechnologiesMxDotnetApi.Business;
using TestSoftwareDeveloperGetechnologiesMxDotnetApi.Models;

namespace TestSoftwareDeveloperGetechnologiesMxDotnetApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FacturaRestService : Controller
    {
        private readonly ILogger<DirectorioRestServiceController> _logger;
        private readonly IVentasBusiness _ventasBusiness;
        public FacturaRestService(ILogger<DirectorioRestServiceController> logger, IVentasBusiness ventasBusiness)
        {
            _logger = logger;
            _ventasBusiness = ventasBusiness;
        }

        [HttpGet(Name = "FacturaRestService")]
        public async Task<IActionResult> Get(string identificationPerson)
        {
            var result = await _ventasBusiness.findBillsByPersonAsync(identificationPerson);
            return Ok(result);
        }

        [HttpPost(Name = "FacturaRestService")]
        public async Task<IActionResult> Post(Bill bill, string identificationPerson)
        {
            var result = await _ventasBusiness.storeBillAsync(bill, identificationPerson);
            return new ObjectResult(result)
            {
                StatusCode = (int)result.Code,
            };
        }

    }
}
