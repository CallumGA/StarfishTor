using System;
using System.Text.Json.Serialization;

namespace Core.Entities.Aggregates
{

    public class WatchProviderRoot
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("results")]
        public Results Results { get; set; }
    }
}
