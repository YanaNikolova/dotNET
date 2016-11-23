using ND21_LogServer.Models.Events;
using ND21_LogServer.Models.Projects;
using ND21_LogServer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ND21_LogServer.Controllers
{
    public class EventsController : Controller
    {
        private IProjectServices projectServices;
        private IEventServices eventServices;

        public EventsController(IProjectServices projectServices, IEventServices eventServices)
        {
            this.projectServices = projectServices;
            this.eventServices = eventServices;
        }

        [HttpGet]
        public ActionResult Index()
        {
            DateTime fromDate = DateTime.Today.AddDays(-30);
            DateTime toDate = DateTime.Today.AddDays(1);

            EventViewModel model = new EventViewModel
            {
                Projects = projectServices.GetProjects(),
                ExtendedEvents = eventServices.GetEvents(fromDate, toDate, 0, false)
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(EventViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            model.Projects = projectServices.GetProjects();
            model.ExtendedEvents = eventServices.GetEvents(model.fromDate, model.toDate.AddDays(1), model.FilterByProject, model.ErrorsOnly);
            return View(model);
        }

        [HttpGet]
        public ActionResult ProjectEvents()
        {
            DateTime fromDate = DateTime.Today.AddDays(-30);
            DateTime toDate = DateTime.Today.AddDays(1);

            EventViewModel model = new EventViewModel
            {
                Projects = projectServices.GetProjects(),
                ExtendedEvents = eventServices.GetEvents(fromDate, toDate, 1, false)
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult ProjectEvents(EventViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            model.project.Add(projectServices.GetProject(model.FilterByProject));
            model.Projects = model.project;
            model.ExtendedEvents = eventServices.GetEvents(model.fromDate, model.toDate.AddDays(1), model.FilterByProject, model.ErrorsOnly);
            return View(model);
        }
    }
}