using System;
using System.Text.Json.Serialization;

namespace Core.DTO.Aggregates
{
    public class Results
    {

        [JsonPropertyName("CA")]
        public CA CA { get; set; }


    }
}
