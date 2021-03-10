using System;
using Core;
using Core.Interfaces;
using TMDbLib.Client;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Reviews;
using TMDbLib.Objects.Search;

namespace Infrastructure.Data
{
    public class OmdbApiRepository : IOmdbApiRepository
    {

        public SearchMovie RequestOmdb(string torrentName)
        {
            TMDbClient client = new TMDbClient(Constants.OmdbKey);
            SearchContainer<SearchMovie> movies = client.SearchMovieAsync(torrentName).Result;

            if (movies.Results.Count <= 0) return null;

            return movies.Results[0];
        }



        public SearchTv RequestTv(string torrentName)
        {
            TMDbClient client = new TMDbClient(Constants.OmdbKey);
            SearchContainer<SearchTv> tvShows = client.SearchTvShowAsync(torrentName).Result;

            if (tvShows.Results.Count <= 0) return null;

            return tvShows.Results[0];
        }



        public SearchContainerWithId<ReviewBase> RequestMovieReviews(int id)
        {
            TMDbClient client = new TMDbClient(Constants.OmdbKey);

            return client.GetMovieReviewsAsync(id).Result;
        }



        public SearchContainerWithId<ReviewBase> RequestTvReviews(int id)
        {
            TMDbClient client = new TMDbClient(Constants.OmdbKey);

            return client.GetTvShowReviewsAsync(id).Result;
        }



        public SearchContainer<SearchMovie> RequestMovieSuggestions()
        {
            TMDbClient client = new TMDbClient(Constants.OmdbKey);

            return client.DiscoverMoviesAsync()
                .WhereVoteAverageIsAtLeast(7)
                .WherePrimaryReleaseDateIsBefore(DateTime.Today.AddMonths(1))
                .WherePrimaryReleaseDateIsAfter(DateTime.Today.AddMonths(-2)).Query().Result;
        }



        public SearchContainer<SearchTv> RequestTvSuggestions()
        {
            TMDbClient client = new TMDbClient(Constants.OmdbKey);

            return client.DiscoverTvShowsAsync()
                .WhereVoteAverageIsAtLeast(7)
                .WhereAirDateIsBefore(DateTime.Today.AddMonths(1))
                .WhereFirstAirDateIsAfter(DateTime.Today.AddMonths(-2)).Query().Result;
        }



        public SearchContainer<SearchMovie> RequestMovieSuggestionsTopRated()
        {
            TMDbClient client = new TMDbClient(Constants.OmdbKey);

            return client.GetMovieTopRatedListAsync().Result;
        }



        public SearchContainer<SearchTv> RequestTvSuggestionsTopRated()
        {
            TMDbClient client = new TMDbClient(Constants.OmdbKey);

            return client.GetTvShowTopRatedAsync().Result;
        }



        public SearchContainer<SearchMovie> RequestMovieSuggestionsTrending()
        {
            TMDbClient client = new TMDbClient(Constants.OmdbKey);

            return client.GetTrendingMoviesAsync(TMDbLib.Objects.Trending.TimeWindow.Day).Result;
        }



        public SearchContainer<SearchTv> RequestTvSuggestionsTrending()
        {
            TMDbClient client = new TMDbClient(Constants.OmdbKey);

            return client.GetTrendingTvAsync(TMDbLib.Objects.Trending.TimeWindow.Day).Result;
        }



        public SearchContainer<SearchMovie> RequestMovieSuggestionsUpcoming()
        {
            TMDbClient client = new TMDbClient(Constants.OmdbKey);

            return client.DiscoverMoviesAsync()
                .WherePrimaryReleaseDateIsAfter(DateTime.Today).Query().Result;
        }



        public SearchContainer<SearchTv> RequestTvSuggestionsUpcoming()
        {
            TMDbClient client = new TMDbClient(Constants.OmdbKey);

            return client.DiscoverTvShowsAsync()
                .WhereFirstAirDateIsAfter(DateTime.Today).Query().Result;
        }

    }
}
