using AutoMapper;

namespace Propt.Properties.Cosmos.Repository.Mappings
{
    public static class CosmosMappingConfigurator
    {
        public static void Configure(IMapperConfigurationExpression config)
        {
            config.AddProfile<CosmosPropertyMappingProfile>();
        }
    }
}
