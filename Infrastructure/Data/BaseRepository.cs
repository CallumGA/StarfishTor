using System;
using Wangkanai.Detection.Models;
using Wangkanai.Detection.Services;

namespace Infrastructure.Data
{
    public class BaseRepository
    {
        protected DatabaseContext _dbContext { get; set; }
        private IDetectionService _detectionService { get; set; }
        protected string DetectedDevice { get; set; }

        public BaseRepository(DatabaseContext dbContext, IDetectionService detectionService)
        {
            _dbContext = dbContext;
            _detectionService = detectionService;
            DetectedDevice = _detectionService.Device.Type == Device.Desktop ? "desktop" : "mobile";
        }


    }
}
