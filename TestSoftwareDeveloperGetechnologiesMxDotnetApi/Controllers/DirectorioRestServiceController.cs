using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestSoftwareDeveloperGetechnologiesMxDotnetApi.Business;
using TestSoftwareDeveloperGetechnologiesMxDotnetApi.Models;

namespace TestSoftwareDeveloperGetechnologiesMxDotnetApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DirectorioRestServiceController : Controller
    {
        private readonly ILogger<DirectorioRestServiceController> _logger;
        private readonly IDirectoryBusiness _directoryBusiness;

        public DirectorioRestServiceController(ILogger<DirectorioRestServiceController> logger, IDirectoryBusiness directoryBusiness)
        {
            _logger = logger;
            _directoryBusiness = directoryBusiness;
        }

        [HttpGet(Name = "DirectorioRestService")]
        public async Task<IActionResult> Get()
        {
            var result = await _directoryBusiness.getAllPersons();
            return Ok(result);
        }

    }
}
