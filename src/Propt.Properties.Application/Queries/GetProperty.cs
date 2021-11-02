using MediatR;
using Propt.Properties.DataModels;

namespace Propt.Properties.Application.Queries
{
    public class GetProperty : IRequest<GetPropertyResponseModel>
    {
        public Guid Id { get; }

        public GetProperty(Guid id)
        {
            Id = id;
        }
    }
}
