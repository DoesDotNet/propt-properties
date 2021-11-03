using AutoMapper;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Options;
using Propt.Properties.Application.Data;
using Propt.Properties.Application.Domain;
using Propt.Properties.Cosmos.Repository.Documents;

namespace Propt.Properties.Cosmos.Repository
{
    public class CosmosRepository : IRepository
    {
        private readonly Container _container;
        private readonly IMapper _mapper;

        public CosmosRepository(IOptions<CosmosSettings> settings, IMapper mapper)
        {
            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            if (settings.Value.ConnectionString == null)
                throw new ArgumentNullException(nameof(settings.Value.ConnectionString));

            if (settings.Value.ContainerName == null)
                throw new ArgumentNullException(nameof(settings.Value.ContainerName));

            if (settings.Value.DatabaseName == null)
                throw new ArgumentNullException(nameof(settings.Value.DatabaseName));


            CosmosClient client = new CosmosClient(settings.Value.ConnectionString);
            Database database = client.GetDatabase(settings.Value.DatabaseName);

            _container = database.GetContainer(settings.Value.ContainerName);
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Property?> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            var propertyDocumentResponse = await _container.ReadItemAsync<PropertyDocument>(id.ToString(), new PartitionKey(id.ToString()));
            var property = _mapper.Map<Property>(propertyDocumentResponse.Resource);
            return property;    
        }

        public Task SaveAsync(Property property, CancellationToken cancellationToken)
        {
            var propertyDocument = _mapper.Map<PropertyDocument>(property);
            return _container.UpsertItemAsync(propertyDocument, cancellationToken: cancellationToken);
        }
    }
}