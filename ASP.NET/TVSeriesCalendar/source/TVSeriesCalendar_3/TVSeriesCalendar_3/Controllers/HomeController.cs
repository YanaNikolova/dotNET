using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TVSeriesCalendar_3.Models;

namespace TVSeriesCalendar_3.Controllers
{
    public class HomeController : Controller
    {
        private IShow showServices;

        public HomeController(IShow ShowServices)
        {
            this.showServices = ShowServices;
        }

        public ActionResult Index()
        {
            showServices.GetPopularTvShows();
            return View();
        }

        [HttpPost]
        public ActionResult Index(ShowViewModel show)
        {
            ShowViewModel showView = new ShowViewModel { AllResults = showServices.FindAllShowsByName(show.Name) };
            return View(showView);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Hello, dear TV/Movie freak.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contacts";

            return View();
        }
        
        public ActionResult GetPopularShows(ShowViewModel model)
        {
            var popularShows = showServices.GetPopularTvShows();
            model.PopularShows = popularShows;
            return View(model);
        }

        public ActionResult GetTopRatedShows(ShowViewModel model)
        {
            var topRatedShows = showServices.GetTopRatedTvShows();
            model.TopRatedShows = topRatedShows;
            return View(model);
        }

        public ActionResult GetAiringTodayShows(ShowViewModel model)
        {
            var airingTodayShows = showServices.GetAiringTodayShows();
            model.AiringTodayShows = airingTodayShows;
            return View(model);
        }
    }
}