
namespace Propt.Properties.Application.Messaging
{
    public interface IEventPublisher
    {
        Task PublishAsync(IEvent eventToPublish);
    }

    public interface IEvent
    {

    }
}
