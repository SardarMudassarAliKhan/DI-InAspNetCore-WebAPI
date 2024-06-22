using DI_InAspNetCore_WebAPI.Interfaces;

namespace DI_InAspNetCore_WebAPI.Services
{
    public class OperationService : ISingletonService, ITransientService, IScopedService
    {
        private readonly Guid _operationId;

        public OperationService()
        {
            _operationId = Guid.NewGuid();
        }

        public Guid GetOperationId()
        {
            return _operationId;
        }
    }
}
