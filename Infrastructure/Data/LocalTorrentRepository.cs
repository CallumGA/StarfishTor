using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Wangkanai.Detection.Services;

namespace Infrastructure.Data
{
    public class LocalTorrentRepository : BaseRepository, ILocalTorrentRepository
    {

        public LocalTorrentRepository(DatabaseContext dbContext, IDetectionService detectionService)
            : base(dbContext, detectionService)
        {

        }




        public async Task<bool> Add(IEnumerable<LocalTorrent> localTorrentsEntity)
        {
            var items = _dbContext.LocalTorrents.Where(item => localTorrentsEntity.Contains(item)).ToList();
            foreach (var record in items)
                _dbContext.Remove(record);

            await _dbContext.AddRangeAsync(localTorrentsEntity);

            return _dbContext.ChangeTracker.HasChanges();
        }




        public async Task<IEnumerable<LocalTorrent>> RetrieveMovies()
        {
            return await _dbContext.LocalTorrents.Where(x => x.media_type == Constants.MediaTypeMovie).Where(x => x.device == DetectedDevice).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<LocalTorrent>> RetrieveTvs()
        {
            return await _dbContext.LocalTorrents.Where(x => x.media_type == Constants.MediaTypeTv).Where(x => x.device == DetectedDevice).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<LocalTorrent>> RetrieveAll()
        {
            return await _dbContext.LocalTorrents.Where(x => x.device == DetectedDevice).AsNoTracking().ToListAsync();
        }




        public void DeleteMoviesFolder(string folderName)
        {
            _dbContext.LocalTorrents.RemoveRange(_dbContext.LocalTorrents.Where(c => c.media_type == Constants.MediaTypeMovie).Where(x => x.device == DetectedDevice).Where(x => x.folder_name == folderName));
        }

        public void DeleteTvFolder(string folderName)
        {
            _dbContext.LocalTorrents.RemoveRange(_dbContext.LocalTorrents.Where(c => c.media_type == Constants.MediaTypeTv).Where(x => x.device == DetectedDevice).Where(x => x.folder_name == folderName));
        }




        public async Task<int> Save()
        {
            return await _dbContext.SaveChangesAsync();
        }

    }
}
