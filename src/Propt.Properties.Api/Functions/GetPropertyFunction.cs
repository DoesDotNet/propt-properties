using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Propt.Properties.Application.Queries;

namespace Propt.Properties.Api.Functions
{
    public class GetPropertyFunction
    {
        private readonly ILogger _logger;
        private readonly IMediator _mediator;

        public GetPropertyFunction(ILoggerFactory loggerFactory, IMediator mediator)
        {
            _logger = loggerFactory.CreateLogger<GetPropertyFunction>();
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [Function("GetPropertyFunction")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "{id}")] HttpRequestData req, Guid id)
        {
            _logger.LogInformation($"Getting Property '{id}'");

            var response = req.CreateResponse(HttpStatusCode.OK);

            var query = new GetProperty(id);

            try
            {
                var model = await _mediator.Send(query);
                await response.WriteAsJsonAsync(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting Property");
                response = req.CreateResponse(HttpStatusCode.InternalServerError);
            }

            return response;
        }
    }
}
