using AutoMapper;

namespace Propt.Properties.Application.Mappings
{
    public static class DomainMappingConfigurator
    {
        public static void Configure(IMapperConfigurationExpression config)
        {
            config.AddProfile<DomainPropertyMappingProfile>();
        }
    }
}
