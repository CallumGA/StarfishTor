using System;
using System.Collections.Generic;
using Core.DTO;

namespace Web.Models
{
    public class HomeViewModel
    {
        public IEnumerable<FolderDTO> LocalTorrents { get; set; }

    }
}
