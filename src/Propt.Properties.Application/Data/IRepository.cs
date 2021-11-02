using Propt.Properties.Application.Domain;

namespace Propt.Properties.Application.Data
{
    public interface IRepository
    {
        Task SaveAsync(Property property, CancellationToken cancellationToken);
        Task<Property?> GetAsync(Guid id, CancellationToken cancellationToken);
    }
}
