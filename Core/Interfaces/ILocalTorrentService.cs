using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.DTO;
using TMDbLib.Objects.Search;

namespace Core.Interfaces
{
    public interface ILocalTorrentService
    {
        Task<bool> AddTv(IEnumerable<SearchTv> tvList, string folderName);

        Task<bool> AddMovie(IEnumerable<SearchMovie> movieList, string folderName);


        Task<IEnumerable<FolderDTO>> RetrieveMoviesAsync();

        Task<IEnumerable<FolderDTO>> RetrieveTvsAsync();

        Task<IEnumerable<FolderDTO>> RetrieveAllAsync();


        void DeleteMoviesFolder(string folderName);

        void DeleteTvFolder(string folderName);


        Task<int> Save();
    }
}
