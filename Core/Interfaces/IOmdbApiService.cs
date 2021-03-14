using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.DTO;
using Core.DTO.Aggregates;
using TMDbLib.Objects.Search;

namespace Core.Interfaces
{
    public interface IOmdbApiService
    {
        List<SearchMovie> RequestOmdb(string torrentNames);

        List<SearchTv> RequestTv(string torrentNames);

        ReviewTorrentDTO RequestReviews(int id, string mediaType);

        Task<TrailerTorrent> RequestTrailerAsync(int id, string mediaType);

        SelectedTorrentDTO RequestSelected(string title, string mediaType);

        IEnumerable<SuggestionTorrentDTO> RequestMovieSuggestions();

        IEnumerable<SuggestionTorrentDTO> RequestTvSuggestions();

        IEnumerable<SuggestionTorrentDTO> RequestMovieSuggestionsTopRated();

        IEnumerable<SuggestionTorrentDTO> RequestTvSuggestionsTopRated();

        IEnumerable<SuggestionTorrentDTO> RequestMovieSuggestionsTrending();

        IEnumerable<SuggestionTorrentDTO> RequestTvSuggestionsTrending();

        IEnumerable<SuggestionTorrentDTO> RequestMovieSuggestionsUpcoming();

        IEnumerable<SuggestionTorrentDTO> RequestTvSuggestionsUpcoming();

        Task<WatchProviderRoot> RequestWatchProvidersAsync(int id, string media);
    }
}
