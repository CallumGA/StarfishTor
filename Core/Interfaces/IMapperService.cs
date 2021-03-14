using System;
using System.Collections.Generic;
using Core.DTO;
using Core.DTO.Aggregates;
using Core.Entities;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Reviews;
using TMDbLib.Objects.Search;

namespace Core.Interfaces
{
    public interface IMapperService
    {
        IList<LocalTorrent> MapSearchMovieToLocalTorrent(IEnumerable<SearchMovie> movieList, string folderName);

        IList<LocalTorrent> MapSearchTvToLocalTorrent(IEnumerable<SearchTv> tvList, string folderName);

        IEnumerable<FolderDTO> MapLocalTorrentToLocalTorrentDTO(IEnumerable<LocalTorrent> localTorrentList);

        IEnumerable<LocalTorrent> MapLocalTorrentDTOToLocalTorrent(IEnumerable<LocalTorrentDTO> localTorrentList);

        IEnumerable<SuggestionTorrentDTO> MapSearchMovieToSuggestionTorrentDTO(SearchContainer<SearchMovie> suggestionTorrentList);

        IEnumerable<SuggestionTorrentDTO> MapSearchTvToSuggestionTorrentDTO(SearchContainer<SearchTv> suggestionTorrentList);

        SelectedTorrentDTO MapSingleSearchMovieToSelectedTorrentDTO(SearchMovie suggestionTorrent);

        SelectedTorrentDTO MapSingleSearchTvToSelectedTorrentDTO(SearchTv suggestionTorrent);

        ReviewTorrentDTO MapReviewToSuggestionTorrentDTO(SearchContainerWithId<ReviewBase> reviewList);

        TrailerTorrent MapTrailerToTrailerTorrentDTO(IEnumerable<Video> trailerList);
    }
}
