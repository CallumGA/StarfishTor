using System;
using System.Collections.Generic;
using Core.DTO;

namespace Web.Models
{
    public class SuggestionViewModel
    {
        public IEnumerable<SuggestionTorrentDTO> SuggestionTorrents { get; set; }

        public IEnumerable<SuggestionTorrentDTO> SuggestionTopRated { get; set; }

        public IEnumerable<SuggestionTorrentDTO> SuggestionTrending { get; set; }

        public IEnumerable<SuggestionTorrentDTO> SuggestionUpcoming { get; set; }
    }
}
