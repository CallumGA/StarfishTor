using System;
namespace Core
{
    public static class Constants
    {
        public static string OmdbUrl => "http://api.themoviedb.org/3/search/movie?api_key=";

        public static string OmdbKey => "50a8f194e0c4550fdf5302efcb0f7752";

        public static string PosterUrl => "https://image.tmdb.org/t/p/w500/";

        public static string OmdbQuery => "&query=";

        public static string MostPopMovie => "https://api.themoviedb.org/3/discover/movie?api_key=50a8f194e0c4550fdf5302efcb0f7752&language=en-US//discover/movie?sort_by=popularity.desc";

        public static string MostPopTv => "https://api.themoviedb.org/3/discover/movie?api_key=50a8f194e0c4550fdf5302efcb0f7752&language=en-US//discover/movie?sort_by=popularity.desc";


        // watch providers - https://api.themoviedb.org/3/movie/238/watch/providers?api_key=50a8f194e0c4550fdf5302efcb0f7752

        public static string VideoMp4Ext => ".mp4";
        public static string VideoAviExt => ".avi";
        public static string VideoMkvExt => ".mkv";

        public static string MediaTypeMovie => "Movie";
        public static string MediaTypeTv => "Tv";

        public static string DeviceTypeDesktop => "desktop";
        public static string DeviceTypeMobile => "mobile";


        public static string Error => "Error";

    }
}
