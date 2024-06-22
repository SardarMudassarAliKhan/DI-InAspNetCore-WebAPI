using DI_InAspNetCore_WebAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DI_InAspNetCore_WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        private readonly ISingletonService _singletonService;
        private readonly ITransientService _transientService;
        private readonly IScopedService _scopedService;

        public HomeController(ISingletonService singletonService,
                                    ITransientService transientService,
                                    IScopedService scopedService)
        {
            _singletonService = singletonService;
            _transientService = transientService;
            _scopedService = scopedService;
        }

        [HttpGet(nameof(GetSingletonOperationId))]
        public IActionResult GetSingletonOperationId()
        {
            return Ok(new
            {
                Singleton = _singletonService.GetOperationId(),
            });
        }

        [HttpGet(nameof(GetTransientOperationId))]
        public IActionResult GetTransientOperationId()
        {
            return Ok(new
            {
                Transient = _transientService.GetOperationId(),
                Scoped = _scopedService.GetOperationId()
            });
        }
        
        [HttpGet(nameof(GetScopedOperationId))]
        public IActionResult GetScopedOperationId()
        {
            return Ok(new
            {
                Singleton = _singletonService.GetOperationId(),
                Transient = _transientService.GetOperationId(),
                Scoped = _scopedService.GetOperationId()

            });
        }

    }
}
