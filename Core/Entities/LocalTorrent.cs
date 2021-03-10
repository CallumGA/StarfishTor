using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    [Table("LocalTorrent")]
    public class LocalTorrent
    {
        [Key]
        public int id { get; set; }

        public string backdrop_path { get; set; }

        public string original_language { get; set; }

        public string original_title { get; set; }

        public string overview { get; set; }

        public double popularity { get; set; }

        public string poster_path { get; set; }

        public DateTime? release_date { get; set; }

        public string title { get; set; }

        public double vote_average { get; set; }

        public int vote_count { get; set; }

        public string media_type { get; set; }

        public string device { get; set; }

        public string folder_name { get; set; }
    }
}
