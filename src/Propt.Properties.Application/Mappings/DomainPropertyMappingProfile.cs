using AutoMapper;
using Propt.Properties.Application.Domain;
using Propt.Properties.DataModels;

namespace Propt.Properties.Application.Mappings
{
    internal class DomainPropertyMappingProfile : Profile
    {
        public DomainPropertyMappingProfile()
        {
            CreateMap<Property, GetPropertyResponseModel>();
        }
    }
}
