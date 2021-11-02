using Newtonsoft.Json;

namespace Propt.Properties.Cosmos.Repository.Documents
{
    internal class PropertyDocument
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        public string NameNumber { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Postcode { get; set; }
    }
}
