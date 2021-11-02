using MediatR;
using Propt.Properties.Application.Data;
using Propt.Properties.Application.Domain;

namespace Propt.Properties.Application.Commands
{
    public class CreatePropertyHandler : AsyncRequestHandler<CreateProperty>
    {
        private readonly IRepository _repository;

        public CreatePropertyHandler(IRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        protected override async Task Handle(CreateProperty request, CancellationToken cancellationToken)
        {
            var property = Property.Create(request.Id, request.Street, request.NameNumber, request.City, request.County, request.Postcode);

            await _repository.SaveAsync(property, cancellationToken);
        }
    }
}
