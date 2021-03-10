using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.CustomAttributes;
using Core.DTO;
using Core.Interfaces;
using TMDbLib.Objects.Search;

namespace Core.Services
{
    [Service]
    public class LocalTorrentService : ILocalTorrentService
    {
        private readonly ILocalTorrentRepository _localTorrentRepository;
        private readonly IMapperService _mapper;


        public LocalTorrentService(ILocalTorrentRepository localTorrentRepository, IMapperService mapper)
        {
            _localTorrentRepository = localTorrentRepository;
            _mapper = mapper;
        }




        public async Task<bool> AddMovie(IEnumerable<SearchMovie> movieList, string folderName)
        {
            return await _localTorrentRepository.Add(_mapper.MapSearchMovieToLocalTorrent(movieList, folderName));
        }

        public async Task<bool> AddTv(IEnumerable<SearchTv> tvList, string folderName)
        {
            return await _localTorrentRepository.Add(_mapper.MapSearchTvToLocalTorrent(tvList, folderName));
        }




        public async Task<IEnumerable<FolderDTO>> RetrieveMoviesAsync()
        {
            return _mapper.MapLocalTorrentToLocalTorrentDTO(await _localTorrentRepository.RetrieveMovies());
        }

        public async Task<IEnumerable<FolderDTO>> RetrieveTvsAsync()
        {
            return _mapper.MapLocalTorrentToLocalTorrentDTO(await _localTorrentRepository.RetrieveTvs());
        }

        public async Task<IEnumerable<FolderDTO>> RetrieveAllAsync()
        {
            return _mapper.MapLocalTorrentToLocalTorrentDTO(await _localTorrentRepository.RetrieveAll());
        }




        public void DeleteMoviesFolder(string folderName)
        {
            _localTorrentRepository.DeleteMoviesFolder(folderName);
        }

        public void DeleteTvFolder(string folderName)
        {
            _localTorrentRepository.DeleteTvFolder(folderName);
        }




        public async Task<int> Save()
        {
            return await _localTorrentRepository.Save();
        }
    }
}
