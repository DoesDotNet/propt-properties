using Propt.Properties.Application.Messaging;

namespace Propt.Properties.Domain.Events.V1
{
    public class PropertyCreatedV1 : IEvent
    {
        public Guid Id { get; }

        public string NameNumber { get; }
        public string Street { get; }
        public string City { get; }
        public string County { get; }
        public string Postcode { get; }

        public PropertyCreatedV1(Guid id, string nameNumber, string street, string city, string county, string postcode) =>
            (Id, NameNumber, Street, City, County, Postcode) = (id, nameNumber, street, city, county, postcode);

    }
}