using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Core;
using Core.DTO.Aggregates;
using Core.Interfaces;
using TMDbLib.Client;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Reviews;
using TMDbLib.Objects.Search;

namespace Infrastructure.Data
{
    public class OmdbApiRepository : IOmdbApiRepository
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private static readonly TMDbClient client = new TMDbClient(Constants.OmdbKey);

        public SearchMovie RequestOmdb(string torrentName)
        {
            SearchContainer<SearchMovie> movies = client.SearchMovieAsync(torrentName).Result;

            if (movies.Results.Count <= 0) return null;

            return movies.Results[0];
        }



        public SearchTv RequestTv(string torrentName)
        {
            SearchContainer<SearchTv> tvShows = client.SearchTvShowAsync(torrentName).Result;

            if (tvShows.Results.Count <= 0) return null;

            return tvShows.Results[0];
        }



        public SearchContainerWithId<ReviewBase> RequestMovieReviews(int id)
        {
            return client.GetMovieReviewsAsync(id).Result;
        }



        public SearchContainerWithId<ReviewBase> RequestTvReviews(int id)
        {
            return client.GetTvShowReviewsAsync(id).Result;
        }



        public SearchContainer<SearchMovie> RequestMovieSuggestions()
        {
            return client.DiscoverMoviesAsync()
                .WhereVoteAverageIsAtLeast(7)
                .WherePrimaryReleaseDateIsBefore(DateTime.Today.AddMonths(1))
                .WherePrimaryReleaseDateIsAfter(DateTime.Today.AddMonths(-2)).Query().Result;
        }



        public SearchContainer<SearchTv> RequestTvSuggestions()
        {
            return client.DiscoverTvShowsAsync()
                .WhereVoteAverageIsAtLeast(7)
                .WhereAirDateIsBefore(DateTime.Today.AddMonths(1))
                .WhereFirstAirDateIsAfter(DateTime.Today.AddMonths(-2)).Query().Result;
        }



        public SearchContainer<SearchMovie> RequestMovieSuggestionsTopRated()
        {
            return client.GetMovieTopRatedListAsync().Result;
        }



        public SearchContainer<SearchTv> RequestTvSuggestionsTopRated()
        {
            return client.GetTvShowTopRatedAsync().Result;
        }



        public SearchContainer<SearchMovie> RequestMovieSuggestionsTrending()
        {
            return client.GetTrendingMoviesAsync(TMDbLib.Objects.Trending.TimeWindow.Day).Result;
        }



        public SearchContainer<SearchTv> RequestTvSuggestionsTrending()
        {
            return client.GetTrendingTvAsync(TMDbLib.Objects.Trending.TimeWindow.Day).Result;
        }



        public SearchContainer<SearchMovie> RequestMovieSuggestionsUpcoming()
        {
            return client.DiscoverMoviesAsync()
                .WherePrimaryReleaseDateIsAfter(DateTime.Today).Query().Result;
        }



        public SearchContainer<SearchTv> RequestTvSuggestionsUpcoming()
        {
            return client.DiscoverTvShowsAsync()
                .WhereFirstAirDateIsAfter(DateTime.Today).Query().Result;
        }



        //TMDBLib does not currently have an async method for requesting watch providers. Use http client instead
        public async Task<WatchProviderRoot> RequestWatchProvidersAsync(int id, string media)
        {
            var streamTask = httpClient.GetStreamAsync("https://api.themoviedb.org/3/" + media.ToLower() + "/" + id + "/watch/providers?api_key=" + Constants.OmdbKey);
            var watchProviders = await JsonSerializer.DeserializeAsync<WatchProviderRoot>(await streamTask);

            return watchProviders;
        }


    }
}
