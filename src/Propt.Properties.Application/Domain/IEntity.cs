namespace Propt.Properties.Application.Domain
{
    public interface IEntity<TKey>
    {
        TKey Id { get; }
    }
}