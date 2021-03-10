using System;
using System.Collections.Generic;
using Core.DTO;
using TMDbLib.Objects.Search;

namespace Core.Interfaces
{
    public interface IOmdbApiService
    {
        List<SearchMovie> RequestOmdb(string torrentNames);

        List<SearchTv> RequestTv(string torrentNames);

        SuggestionTorrentDTO RequestSuggestion(string mediaType, string title);

        ReviewTorrentDTO RequestReviews(int id, string mediaType);

        IEnumerable<SuggestionTorrentDTO> RequestMovieSuggestions();

        IEnumerable<SuggestionTorrentDTO> RequestTvSuggestions();

        IEnumerable<SuggestionTorrentDTO> RequestMovieSuggestionsTopRated();

        IEnumerable<SuggestionTorrentDTO> RequestTvSuggestionsTopRated();

        IEnumerable<SuggestionTorrentDTO> RequestMovieSuggestionsTrending();

        IEnumerable<SuggestionTorrentDTO> RequestTvSuggestionsTrending();

        IEnumerable<SuggestionTorrentDTO> RequestMovieSuggestionsUpcoming();

        IEnumerable<SuggestionTorrentDTO> RequestTvSuggestionsUpcoming();
    }
}
