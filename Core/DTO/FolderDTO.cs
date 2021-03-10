using System;
using System.Collections.Generic;

namespace Core.DTO
{
    public class FolderDTO
    {
        public int Id { get; set; }

        public string Folder_name { get; set; }

        public IEnumerable<LocalTorrentDTO> Torrents { get; set; }
    }
}
