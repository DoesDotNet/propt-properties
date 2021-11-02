using AutoMapper;
using Propt.Properties.Application.Domain;
using Propt.Properties.Cosmos.Repository.Documents;

namespace Propt.Properties.Cosmos.Repository.Mappings
{
    internal class CosmosPropertyMappingProfile : Profile
    {
        public CosmosPropertyMappingProfile()
        {
            CreateMap<Property, PropertyDocument>()
                .ReverseMap();
        }
    }
}
