using MediatR;

namespace Propt.Properties.Application.Commands
{
    public class CreateProperty : IRequest
    {
        public Guid Id { get; }
        public string NameNumber { get; }
        public string Street { get; }
        public string City { get; }
        public string County { get; }
        public string Postcode { get; }

        public CreateProperty(Guid id, string nameNumber, string street, string city, string county, string postcode)
            => (Id, NameNumber, Street, City, County, Postcode) = (id, nameNumber, street, city, county, postcode);
    }
}
