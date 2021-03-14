using System;
using System.Collections.Generic;
using System.Linq;
using Core.CustomAttributes;
using Core.DTO;
using Core.DTO.Aggregates;
using Core.Entities;
using Core.Interfaces;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Reviews;
using TMDbLib.Objects.Search;
using Wangkanai.Detection.Models;
using Wangkanai.Detection.Services;

namespace Core.Services
{
    [Service]
    public class MapperService : IMapperService
    {

        private readonly IDetectionService _detectionService;
        private string DetectedDevice { get; set; }


        public MapperService(IDetectionService detectionService)
        {
            _detectionService = detectionService;
            DetectedDevice = _detectionService.Device.Type == Device.Desktop ? "desktop" : "mobile";
        }



        /* MAPPING TMDB OBJECTS TO ENTITY OBJECTS IN PREPARATION FOR DATABASE INSERTION METHODS */


        IList<LocalTorrent> IMapperService.MapSearchMovieToLocalTorrent(IEnumerable<SearchMovie> movieList, string folderName)
        {
            //Filters
            movieList = movieList.Select(x => x).Where(c => c != null);

            if (movieList == null) return null;

            var localTorrentList =
             movieList
                 .Select(x => new LocalTorrent
                 {
                     id = x.Id,
                     backdrop_path = x.BackdropPath,
                     original_language = x.OriginalLanguage,
                     original_title = x.OriginalTitle,
                     overview = x.Overview,
                     poster_path = Constants.PosterUrl + x.PosterPath,
                     release_date = x.ReleaseDate,
                     title = x.Title,
                     vote_average = x.VoteAverage,
                     vote_count = x.VoteCount,
                     popularity = x.Popularity,
                     media_type = Constants.MediaTypeMovie,
                     device = DetectedDevice,
                     folder_name = folderName

                 }).ToList();


            return localTorrentList;
        }



        IList<LocalTorrent> IMapperService.MapSearchTvToLocalTorrent(IEnumerable<SearchTv> tvList, string folderName)
        {
            //Filters
            tvList = tvList.Select(x => x).Where(c => c != null).Where(c => c.PosterPath != null);

            if (tvList == null) return null;

            var localTorrentList =
             tvList
                 .Select(x => new LocalTorrent
                 {
                     id = x.Id,
                     backdrop_path = x.BackdropPath,
                     original_language = x.OriginalLanguage,
                     overview = x.Overview,
                     poster_path = Constants.PosterUrl + x.PosterPath,
                     release_date = x.FirstAirDate,
                     title = x.OriginalName,
                     vote_average = x.VoteAverage,
                     vote_count = x.VoteCount,
                     popularity = x.Popularity,
                     media_type = Constants.MediaTypeTv,
                     device = DetectedDevice,
                     folder_name = folderName

                 }).ToList();

            return localTorrentList;
        }



        public IEnumerable<LocalTorrent> MapLocalTorrentDTOToLocalTorrent(IEnumerable<LocalTorrentDTO> localTorrentList)
        {
            var torrentList =
             localTorrentList
                 .Select(x => new LocalTorrent
                 {
                     id = x.id,
                     backdrop_path = x.backdrop_path,
                     original_language = x.original_language,
                     original_title = x.original_title,
                     overview = x.overview,
                     poster_path = x.poster_path,
                     release_date = x.release_date,
                     title = x.title,
                     vote_average = x.vote_average,
                     vote_count = x.vote_count,
                     popularity = x.popularity,
                     folder_name = x.folder_name
                 }).ToList();

            return torrentList;
        }



        /* MAPPING ENTITIES IN PREPARATION FOR DISPLAY */



        //List of suggestion movies
        public IEnumerable<SuggestionTorrentDTO> MapSearchMovieToSuggestionTorrentDTO(SearchContainer<SearchMovie> suggestionTorrentList)
        {

            var torrentList =
             suggestionTorrentList.Results
                 .Select(x => new SuggestionTorrentDTO
                 {
                     Id = x.Id,
                     Media_type = x.MediaType.ToString(),
                     Original_language = x.OriginalLanguage,
                     Original_title = x.OriginalTitle,
                     Overview = x.Overview,
                     Poster_path = Constants.PosterUrl + x.PosterPath,
                     Release_date = x.ReleaseDate,
                     Title = x.Title,
                     Vote_average = x.VoteAverage,
                     Vote_count = x.VoteCount,
                     Popularity = x.Popularity,

                 });

            return torrentList;
        }



        //List of suggestion TV
        public IEnumerable<SuggestionTorrentDTO> MapSearchTvToSuggestionTorrentDTO(SearchContainer<SearchTv> suggestionTorrentList)
        {
            var torrentList =
             suggestionTorrentList.Results
                 .Select(x => new SuggestionTorrentDTO
                 {
                     Id = x.Id,
                     Media_type = x.MediaType.ToString(),
                     Original_language = x.OriginalLanguage,
                     Overview = x.Overview,
                     Poster_path = Constants.PosterUrl + x.PosterPath,
                     Release_date = x.FirstAirDate,
                     Title = x.Name,
                     Vote_average = x.VoteAverage,
                     Vote_count = x.VoteCount,
                     Popularity = x.Popularity,

                 });

            return torrentList;
        }



        public SelectedTorrentDTO MapSingleSearchMovieToSelectedTorrentDTO(SearchMovie suggestionTorrent)
        {

            var torrentList =
                  new SelectedTorrentDTO
                  {
                      Id = suggestionTorrent.Id,
                      Media_type = suggestionTorrent.MediaType.ToString(),
                      Original_language = suggestionTorrent.OriginalLanguage,
                      Original_title = suggestionTorrent.OriginalTitle,
                      Overview = suggestionTorrent.Overview,
                      Poster_path = Constants.PosterUrl + suggestionTorrent.PosterPath,
                      Release_date = suggestionTorrent.ReleaseDate,
                      Title = suggestionTorrent.Title,
                      Vote_average = suggestionTorrent.VoteAverage,
                      Vote_count = suggestionTorrent.VoteCount,
                      Popularity = suggestionTorrent.Popularity,
                      Backdrop_path = Constants.PosterUrl + suggestionTorrent.BackdropPath

                  };

            return torrentList;
        }



        public SelectedTorrentDTO MapSingleSearchTvToSelectedTorrentDTO(SearchTv suggestionTorrent)
        {

            var torrentList =
                  new SelectedTorrentDTO
                  {
                      Id = suggestionTorrent.Id,
                      Media_type = suggestionTorrent.MediaType.ToString(),
                      Original_language = suggestionTorrent.OriginalLanguage,
                      Overview = suggestionTorrent.Overview,
                      Poster_path = Constants.PosterUrl + suggestionTorrent.PosterPath,
                      Release_date = suggestionTorrent.FirstAirDate,
                      Title = suggestionTorrent.Name,
                      Vote_average = suggestionTorrent.VoteAverage,
                      Vote_count = suggestionTorrent.VoteCount,
                      Popularity = suggestionTorrent.Popularity,
                      Backdrop_path = Constants.PosterUrl + suggestionTorrent.BackdropPath

                  };

            return torrentList;
        }



        //Map reviews to ReviewTorrentDTO()
        public ReviewTorrentDTO MapReviewToSuggestionTorrentDTO(SearchContainerWithId<ReviewBase> reviewList)
        {
            if (reviewList.TotalResults == 0) return null;

            var torrentList =
                  new ReviewTorrentDTO
                  {
                      Author = reviewList.Results[0].Author,
                      Content = reviewList.Results[0].Content
                  };

            return torrentList;
        }



        public IEnumerable<FolderDTO> MapLocalTorrentToLocalTorrentDTO(IEnumerable<LocalTorrent> localTorrentList)
        {
            var torrentList =
             localTorrentList
                 .Select(x => new LocalTorrentDTO
                 {
                     id = x.id,
                     backdrop_path = x.backdrop_path,
                     original_language = x.original_language,
                     original_title = x.original_title,
                     overview = x.overview,
                     poster_path = x.poster_path,
                     release_date = x.release_date,
                     title = x.title,
                     vote_average = x.vote_average,
                     vote_count = x.vote_count,
                     popularity = x.popularity,
                     media_type = x.media_type,
                     folder_name = x.folder_name
                 }).ToList();

            //Here we map a list of torrent entities to a nested list of objects. FolderDTO contains
            //a list of torrent objects. Each FolderDTO represents a folder containing torrents.

            var folderWithTorrents = torrentList.Select(
                i => new FolderDTO { Folder_name = i.folder_name }
            ).ToList();

            var torrentFolders = folderWithTorrents.GroupBy(x => x.Folder_name).Select(y => y.First());

            foreach (var i in torrentFolders)
                i.Torrents = torrentList.Where(n => n.folder_name == i.Folder_name).ToList();


            return torrentFolders;
        }



        //Map trailers to TrailerTorrentDTO()
        public TrailerTorrent MapTrailerToTrailerTorrentDTO(IEnumerable<Video> trailerList)
        {
            if (trailerList.Count() == 0) return null;

            var trailer = trailerList.FirstOrDefault(x => x.Type == "Trailer");

            var mappedTrailer =
                  new TrailerTorrent
                 {
                     Key = trailer.Key,
                     Name = trailer.Name,
                     Site = trailer.Site
                 };

            return mappedTrailer;
        }



    }
}
