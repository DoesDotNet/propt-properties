namespace Propt.Properties.Application.Domain
{
    public class Property : IEntity<Guid>
    {
        public Guid Id { get; }
        public string NameNumber { get; }
        public string Street { get; }
        public string City { get; }
        public string Country { get; }
        public string Postcode { get; }


        private Property(Guid id, string nameNumber, string street, string city, string country, string postcode) =>
            (Id, NameNumber, Street, City, Country, Postcode) = (id, nameNumber, street, city, country, postcode);

        public static Property Create(Guid id, string nameNumber, string street, string city, string country, string postcode)
        {
            return new Property(id, nameNumber, street, city, country, postcode);
        }
    }
}
