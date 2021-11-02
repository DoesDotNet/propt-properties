using System;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace Propt.Properties.Api
{
    public class CreatePropertyFunction
    {
        private readonly ILogger _logger;
        private readonly IMediator _mediator;

        public CreatePropertyFunction(ILoggerFactory loggerFactory, IMediator mediator)
        {
            _logger = loggerFactory.CreateLogger<CreatePropertyFunction>();
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [Function("CreateProperty")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "/")] HttpRequestData req)
        {
            _logger.LogInformation("Creating Property");

            CreatePropertyRequestModel createPropertyModel = await req.ReadFromJsonAsync<CreatePropertyRequestModel>();

            var command = createPropertyModel.ToCommand();
            var response = req.CreateResponse(HttpStatusCode.Created);

            try
            {
                await _mediator.Send(command);

                var responseModel = new CreatePropertyResponseModel { Id = command.Id };
                await response.WriteAsJsonAsync(responseModel);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error createing property", ex);
                response = req.CreateResponse(HttpStatusCode.InternalServerError);
            }
            
            return response;
        }
    }
}
