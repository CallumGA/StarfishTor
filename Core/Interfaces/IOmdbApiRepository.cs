using System;
using System.Threading.Tasks;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Reviews;
using TMDbLib.Objects.Search;

namespace Core.Interfaces
{
    public interface IOmdbApiRepository
    {
        SearchMovie RequestOmdb(string torrentName);

        SearchTv RequestTv(string torrentName);

        SearchContainerWithId<ReviewBase> RequestMovieReviews(int id);

        SearchContainerWithId<ReviewBase> RequestTvReviews(int id);

        SearchContainer<SearchMovie> RequestMovieSuggestions();

        SearchContainer<SearchTv> RequestTvSuggestions();

        SearchContainer<SearchMovie> RequestMovieSuggestionsTopRated();

        SearchContainer<SearchTv> RequestTvSuggestionsTopRated();

        SearchContainer<SearchMovie> RequestMovieSuggestionsTrending();

        SearchContainer<SearchTv> RequestTvSuggestionsTrending();

        SearchContainer<SearchMovie> RequestMovieSuggestionsUpcoming();

        SearchContainer<SearchTv> RequestTvSuggestionsUpcoming();

        Task RequestWatchProvidersAsync();

    }
}
