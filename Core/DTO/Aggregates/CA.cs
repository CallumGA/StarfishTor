using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Core.DTO.Aggregates
{
    public class CA
    {
        [JsonPropertyName("link")]
        public string Link { get; set; }

        [JsonPropertyName("rent")]
        public List<Rent> Rent { get; set; }

        [JsonPropertyName("flatrate")]
        public List<Flatrate> Flatrate { get; set; }

        [JsonPropertyName("buy")]
        public List<Buy> Buy { get; set; }
    }
}
