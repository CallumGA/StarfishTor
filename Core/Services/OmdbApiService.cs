using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Core.CustomAttributes;
using Core.DTO;
using Core.DTO.Aggregates;
using Core.Interfaces;
using TMDbLib.Objects.Search;

namespace Core.Services
{
    [Service]
    public class OmdbApiService : IOmdbApiService
    {
        private readonly IOmdbApiRepository _omdbApiRepository;
        private List<string> torrentTally = new List<string>();
        private readonly IMapperService _mapper;

        public OmdbApiService(IOmdbApiRepository omdbApiRepository, IMapperService mapper)
        {
            _omdbApiRepository = omdbApiRepository;
            _mapper = mapper;
        }



        public List<SearchMovie> RequestOmdb(string torrentNames)
        {

            List<SearchMovie> omdbTorrents = new List<SearchMovie>();

            if (torrentNames != null)
            {
                string[] omdbArray = torrentNames.Split(", ");

                foreach (string torrent in omdbArray)
                {
                    if (torrent != "")
                        if (Path.GetExtension(torrent).ToString() == Constants.VideoMp4Ext
                        || Path.GetExtension(torrent).ToString() == Constants.VideoAviExt
                        || Path.GetExtension(torrent).ToString() == Constants.VideoMkvExt)
                        {
                            var conflicts = torrentTally.Where(x => x.Contains(Path.GetFileNameWithoutExtension(torrent)));

                            if (conflicts.Count() == 0)
                                omdbTorrents.Add(_omdbApiRepository.RequestOmdb(Path.GetFileNameWithoutExtension(torrent)));
                        }
                }
            }

            return omdbTorrents;
        }



        public List<SearchTv> RequestTv(string torrentNames)
        {

            List<SearchTv> omdbTorrents = new List<SearchTv>();

            if (torrentNames != null)
            {
                string[] omdbArray = torrentNames.Split(", ");

                foreach (string torrent in omdbArray)
                {
                    if (torrent != "")
                        if (Path.GetExtension(torrent).ToString() == Constants.VideoMp4Ext
                        || Path.GetExtension(torrent).ToString() == Constants.VideoAviExt
                        || Path.GetExtension(torrent).ToString() == Constants.VideoMkvExt)
                        {
                            var conflicts = torrentTally.Where(x => x.Contains(Path.GetFileNameWithoutExtension(torrent)));

                            if (conflicts.Count() == 0)
                                omdbTorrents.Add(_omdbApiRepository.RequestTv(Path.GetFileNameWithoutExtension(torrent)));
                        }
                }
            }

            return omdbTorrents;
        }



        public SuggestionTorrentDTO RequestSuggestion(string title, string mediaType)
        {
            if (mediaType == "Movie")
            {
                return _mapper.MapSingleSearchMovieToSuggestionTorrentDTO(_omdbApiRepository.RequestOmdb(title));
            }
            else
            {
                return _mapper.MapSingleSearchTvToSuggestionTorrentDTO(_omdbApiRepository.RequestTv(title));
            }
        }



        public ReviewTorrentDTO RequestReviews(int id, string mediaType)
        {
            if (mediaType == "Movie")
            {
                return _mapper.MapReviewToSuggestionTorrentDTO(_omdbApiRepository.RequestMovieReviews(id));
            }
            else
            {
                return _mapper.MapReviewToSuggestionTorrentDTO(_omdbApiRepository.RequestTvReviews(id));
            }
        }



        public async Task<WatchProviderRoot> RequestWatchProvidersAsync(int id, string media)
        {
           return await _omdbApiRepository.RequestWatchProvidersAsync(id, media);
        }



        public IEnumerable<SuggestionTorrentDTO> RequestMovieSuggestions()
        {
            return _mapper.MapSearchMovieToSuggestionTorrentDTO(_omdbApiRepository.RequestMovieSuggestions());
        }

        public IEnumerable<SuggestionTorrentDTO> RequestTvSuggestions()
        {
            return _mapper.MapSearchTvToSuggestionTorrentDTO(_omdbApiRepository.RequestTvSuggestions());
        }

        public IEnumerable<SuggestionTorrentDTO> RequestMovieSuggestionsTopRated()
        {
            return _mapper.MapSearchMovieToSuggestionTorrentDTO(_omdbApiRepository.RequestMovieSuggestionsTopRated());
        }

        public IEnumerable<SuggestionTorrentDTO> RequestTvSuggestionsTopRated()
        {
            return _mapper.MapSearchTvToSuggestionTorrentDTO(_omdbApiRepository.RequestTvSuggestionsTopRated());
        }

        public IEnumerable<SuggestionTorrentDTO> RequestMovieSuggestionsTrending()
        {
            return _mapper.MapSearchMovieToSuggestionTorrentDTO(_omdbApiRepository.RequestMovieSuggestionsTrending());
        }

        public IEnumerable<SuggestionTorrentDTO> RequestTvSuggestionsTrending()
        {
            return _mapper.MapSearchTvToSuggestionTorrentDTO(_omdbApiRepository.RequestTvSuggestionsTrending());
        }

        public IEnumerable<SuggestionTorrentDTO> RequestMovieSuggestionsUpcoming()
        {
            return _mapper.MapSearchMovieToSuggestionTorrentDTO(_omdbApiRepository.RequestMovieSuggestionsUpcoming());
        }

        public IEnumerable<SuggestionTorrentDTO> RequestTvSuggestionsUpcoming()
        {
            return _mapper.MapSearchTvToSuggestionTorrentDTO(_omdbApiRepository.RequestTvSuggestionsUpcoming());
        }
    }
}
