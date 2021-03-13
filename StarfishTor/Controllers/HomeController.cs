using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using StarfishTor.Models;
using Web.Models;

namespace StarfishTor.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOmdbApiService _omdbApiService;
        private readonly ILocalTorrentService _localTorrentService;


        public HomeController(ILogger<HomeController> logger, IOmdbApiService omdbApiService, ILocalTorrentService localTorrentService)
        {
            _logger = logger;
            _omdbApiService = omdbApiService;
            _localTorrentService = localTorrentService;
        }



        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var loadLocalTorrents = await _localTorrentService.RetrieveMoviesAsync();

            var viewModel = new HomeViewModel()
            {
                LocalTorrents = loadLocalTorrents
            };

            return View(viewModel);
        }



        [HttpGet]
        public async Task<IActionResult> Tv()
        {

            var loadLocalTorrents = await _localTorrentService.RetrieveTvsAsync();

            var viewModel = new HomeViewModel()
            {
                LocalTorrents = loadLocalTorrents
            };

            return View(viewModel);
        }



        [HttpGet]
        public async Task<IActionResult> All()
        {

            var allTorrents = await _localTorrentService.RetrieveAllAsync();

            var viewModel = new HomeViewModel()
            {
                LocalTorrents = allTorrents
            };

            return View(viewModel);
        }



        [HttpGet]
        public IActionResult Suggestion()
        {

            var suggestions = _omdbApiService.RequestMovieSuggestions().Concat(_omdbApiService.RequestTvSuggestions());
            var suggestionsTopRated = _omdbApiService.RequestMovieSuggestionsTopRated().Concat(_omdbApiService.RequestTvSuggestionsTopRated());
            var suggestionsTrending = _omdbApiService.RequestMovieSuggestionsTrending().Concat(_omdbApiService.RequestTvSuggestionsTrending());
            var suggestionsUpcoming = _omdbApiService.RequestMovieSuggestionsUpcoming().Concat(_omdbApiService.RequestTvSuggestionsUpcoming());

            var viewModel = new SuggestionViewModel()
            {
                SuggestionTorrents = suggestions,
                SuggestionTopRated = suggestionsTopRated,
                SuggestionTrending = suggestionsTrending,
                SuggestionUpcoming = suggestionsUpcoming
            };

            return View(viewModel);
        }



        [HttpGet]
        public async Task<IActionResult> Selected(int id, string title, string media)
        {
            var suggestion = _omdbApiService.RequestSuggestion(title, media);
            var watchProviders = await _omdbApiService.RequestWatchProvidersAsync(id, media);

            suggestion.Watch_providers_buy = watchProviders.Results.CA.Buy;
            suggestion.Watch_providers_rent = watchProviders.Results.CA.Rent;

            JsonResult torrentSelected = new JsonResult(JsonConvert.SerializeObject(suggestion));

            return torrentSelected;
        }



        [HttpGet]
        public IActionResult SelectedReview(int id, string media)
        {
            var reviews = _omdbApiService.RequestReviews(id, media);

            JsonResult reviewsJson = new JsonResult(JsonConvert.SerializeObject(reviews));

            return reviewsJson;
        }



        public IActionResult DeleteMoviesFolder(string folderName)
        {

            _localTorrentService.DeleteMoviesFolder(folderName);
            _localTorrentService.Save();

            return new JsonResult(folderName);
        }



        public IActionResult DeleteTvFolder(string folderName)
        {

            _localTorrentService.DeleteTvFolder(folderName);
            _localTorrentService.Save();

            return new JsonResult(folderName);
        }



        //AJAX
        public async Task<IActionResult> GetData(string concatString, string folderName)
        {

            var movieResults = _omdbApiService.RequestOmdb(concatString);

            if (await _localTorrentService.AddMovie(movieResults, folderName))
            {
                if (await _localTorrentService.Save() > 0)
                {
                    //Success popup?
                }
            }

            JsonResult resulting = new JsonResult(concatString);

            return resulting;
        }



        //AJAX
        public async Task<IActionResult> GetTv(string concatString, string folderName)
        {

            var tvResults = _omdbApiService.RequestTv(concatString);

            if (await _localTorrentService.AddTv(tvResults, folderName))
            {
                if (await _localTorrentService.Save() > 0)
                {
                    //Success popup?
                }
            }

            JsonResult resulting = new JsonResult(concatString);

            return resulting;
        }
    }
}
