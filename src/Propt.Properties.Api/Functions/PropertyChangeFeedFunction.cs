using System;
using System.Collections.Generic;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Propt.Properties.Application.Messaging;
using Propt.Properties.Domain.Events.V1;

namespace Propt.Properties.Api.Functions
{
    public class PropertyChangeFeedFunction
    {
        private readonly ILogger _logger;
        private readonly IEventPublisher _eventPublisher;

        public PropertyChangeFeedFunction(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<PropertyChangeFeedFunction>();
        }

        [Function("PropertyChangeFeedFunction")]
        [ServiceBusOutput("propt.properties.propterycreated.v1",  Connection = "EventServiceBus", EntityType = EntityType.Topic)]
        public PropertyCreatedV1 Run([CosmosDBTrigger(
            databaseName: "Properties",
            collectionName: "Properties",
            ConnectionStringSetting = "Cosmos",
            LeaseCollectionName = "leases")] IReadOnlyList<PropertyDocument> input)
        {
            foreach(var property in input)
            {
                return new PropertyCreatedV1(
                    property.Id,
                    property.NameNumber,
                    property.Street,
                    property.City,
                    property.Country,
                    property.Postcode
                );
            }

            return null;
        }

        public class PropertyDocument
        {
            [JsonProperty("id")]
            public Guid Id { get; set; }
            public string NameNumber { get; set; }
            public string Street { get; set; }
            public string City { get; set; }
            public string Country { get; set; }
            public string Postcode { get; set; }
        }
    }    
}
