using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TVSeriesCalendar.Models;

namespace TVSeriesCalendar.Controllers
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
            return View(model);
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
            Show newShow = new Show {
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
                VoteCount = show.VoteCount
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
            if(model.ID == 0)
            {
                return View(model.Name);
            }
            showServices.AddToFavorites(model.ID);
            return View();
        }
    }
}