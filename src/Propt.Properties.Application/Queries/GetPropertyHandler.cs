using AutoMapper;
using MediatR;
using Propt.Properties.Application.Data;
using Propt.Properties.DataModels;

namespace Propt.Properties.Application.Queries
{
    public class GetPropertyHandler : IRequestHandler<GetProperty, GetPropertyResponseModel>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;  

        public GetPropertyHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<GetPropertyResponseModel> Handle(GetProperty request, CancellationToken cancellationToken)
        {
            var property = await _repository.GetAsync(request.Id, cancellationToken);
            if( property == null)
                return null;

            var propertyModel = _mapper.Map<GetPropertyResponseModel>(property);
            return propertyModel;
        }
    }
}
