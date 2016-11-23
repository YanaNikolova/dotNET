using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TVSeriesCalendar_3.Controllers
{
    public class EventController : Controller
    {
        // GET: Event
        public ActionResult Index()
        {
            return View();
        }

        /*public ActionResult GetEvents(double start, double end)
        {
            var fromDate;
            var toDate;

        }*/
    }
}