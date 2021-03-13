using System;
using System.Collections.Generic;
using Core.DTO.Aggregates;

namespace Core.DTO
{
    public class SelectedTorrentDTO
    {
        public int Id { get; set; }

        public string Media_type { get; set; }

        public string Backdrop_path { get; set; }

        public string Original_language { get; set; }

        public string Original_title { get; set; }

        public string Overview { get; set; }

        public double popularity { get; set; }

        public string Poster_path { get; set; }

        public DateTime? Release_date { get; set; }

        public string Title { get; set; }

        public double Vote_average { get; set; }

        public int Vote_count { get; set; }

        public double Popularity { get; set; }

        public IEnumerable<Rent> Watch_providers_rent { get; set; }

        public IEnumerable<Buy> Watch_providers_buy { get; set; }

        public IEnumerable<Flatrate> Watch_providers_flatrate { get; set; }

    }
}
