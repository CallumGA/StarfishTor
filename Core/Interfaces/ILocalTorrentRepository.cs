using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface ILocalTorrentRepository
    {
        Task<bool> Add(IEnumerable<LocalTorrent> localTorrentsEntity);


        Task<IEnumerable<LocalTorrent>> RetrieveMovies();

        Task<IEnumerable<LocalTorrent>> RetrieveTvs();

        Task<IEnumerable<LocalTorrent>> RetrieveAll();


        void DeleteMoviesFolder(string folderName);

        void DeleteTvFolder(string folderName);


        Task<int> Save();
    }
}
