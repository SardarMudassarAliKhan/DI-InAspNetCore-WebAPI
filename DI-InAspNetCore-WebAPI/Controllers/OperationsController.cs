using DI_InAspNetCore_WebAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DI_InAspNetCore_WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OperationsController : ControllerBase
    {
        private readonly ISingletonService _singletonService;
        private readonly ITransientService _transientService;
        private readonly IScopedService _scopedService;

        public OperationsController(ISingletonService singletonService,
                                    ITransientService transientService,
                                    IScopedService scopedService)
        {
            _singletonService = singletonService;
            _transientService = transientService;
            _scopedService = scopedService;
        }

        [HttpGet]
        public IActionResult Get()
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
