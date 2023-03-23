using Elastic.Clients.Elasticsearch;
using Elastic.Transport;

namespace NolekStuff
{
    public class ElasticClient
    {
        private static readonly ElasticClient _instance = new ElasticClient();

        private ElasticClient() {
            if (_client == null)
            {
                var settings = new ElasticsearchClientSettings(new Uri("http://localhost:9200"));

                _client = new ElasticsearchClient(settings);
            }
        }
        

        public static ElasticClient Instance { get { return _instance; } }

        public ElasticsearchClient _client { get; set; }


        public async void FullIndex()
        {
            var Dogs = new List<Dog>()
            {
                new Dog()
                {
                    Id = 1,
                    Name = "Søren",
                    Photo = new DogPhoto()
                    {
                        Id = 1,
                        Url = "https://www.cdc.gov/healthypets/images/pets/cute-dog-headshot.jpg?_=42445",
                        Description = "Very cute dog",
                        Tags = new List<string>()
                    {
                        "New York",
                        "Big Apple",
                        "USA",
                        "Tourist Dog"
                    }
        }
                }
            };

            var response = _client.Index(Dogs, "dog-index");

            if (response.IsValidResponse)
            {
                Console.WriteLine($"Index document with ID {response.Id} succeeded.");
            }
        }

        public async void DocumentIndex()
        {
            var document = new TestDocument
            {
                StringProperty = "value123"
            };

            var Response = await _client
                .IndexAsync(document, "my-document-index");

            //if (Response.IsValidResponse)
            //{
            //    Console.WriteLine($"Index document with ID {indexResponse.Id} succeeded.");
            //}
        }
    }
}