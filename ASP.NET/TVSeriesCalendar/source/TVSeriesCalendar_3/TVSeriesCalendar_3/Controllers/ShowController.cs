using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TVSeriesCalendar_3.Models;

namespace TVSeriesCalendar_3.Controllers
{
    public class ShowController : Controller
    {
        private IShow showServices;

        public ShowController(IShow ShowServices)
        {
            this.showServices = ShowServices;
        }

        // GET: Show
        [HttpGet]
        public ActionResult Index()
        {
            ShowViewModel model = new ShowViewModel { AllResults = new List<Show>() };
            return View("Index", model);
        }

        [HttpPost]
        public ActionResult Index(ShowViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            ShowViewModel showView = new ShowViewModel { AllResults = showServices.FindAllShowsByName(model.Name) };
            return View(showView);
        }

        [HttpGet]
        public ActionResult TVShowDetails(int id = 0)
        {
            var show = showServices.FindShowById(id);
            Show newShow = new Show
            {
                ID = show.ID,
                Name = show.Name,
                OriginalName = show.OriginalName,
                FirstAirDate = show.FirstAirDate,
                Popularity = show.Popularity,
                PosterPath = show.PosterPath,
                SimilarTVShows = show.SimilarTVShows,
                Overview = show.Overview,
                OriginCountry = show.OriginCountry,
                VoteAverage = show.VoteAverage,
                VoteCount = show.VoteCount,
                SeasonsAndEpisodes = show.SeasonsAndEpisodes
            };
            return View(newShow);
        }

        [HttpPost]
        public ActionResult TVShowDetails(ShowViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            Show newModel = showServices.FindShowByName(model.Name);
            return View(newModel);
        }

        [HttpGet]
        public ActionResult AddToFavorites(int id)
        {
            Show show = new Show { ID = id };
            showServices.AddToFavorites(id);
            return View(show);
        }

        [HttpPost]
        public ActionResult AddToFavorites(Show model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (model.ID == 0)
            {
                return View(model.Name);
            }
            showServices.AddToFavorites(model.ID);
            return View();
        }

        [HttpGet]
        public ActionResult GetUserFavoriteShows()
        {
            var listOfIds = showServices.GetUserFavoriteShows();
            List<Show> favShows = new List<Show>();
            foreach(var id in listOfIds)
            {
                var show = showServices.FindShowById(id);
                favShows.Add(new Show { ID = id, Name = show.Name, PosterPath = show.PosterPath });
            }
            return View(favShows);
        }

        [HttpGet]
        public ActionResult ViewSeason()
        {
            return View();
        }


        [HttpGet]
        public ActionResult LoadEventsIntoCalendar()
        {
            return View();
        }
        /*[HttpPost]
        public ActionResult GetUserFavoriteShows(Show model)
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetPopularShows()
        {
            var list = showServices.GetPopularTvShows();
            return PartialView("_GetPopularShows", list);
        }*/
    }
}