using ND21_LogServer.Models.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ND21_LogServer.Controllers
{
    public class ProjectsController : Controller
    {
        private IProjectServices projectServices;

        public ProjectsController(IProjectServices projectServices)
        {
            this.projectServices = projectServices;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var result = projectServices.GetProjects();
            return View(result);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult Create([Bind(Exclude = "ID")]Project model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (!projectServices.SaveProject(model))
            {
                ModelState.AddModelError("Name", "This name already exists! Please enter another name.");
                return View(model);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id = 0)
        {
            var project = projectServices.GetProject(id);
           
            if (project == null)
            {
                return RedirectToAction("Index");
            }
            return View(project);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Project model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (!projectServices.SaveProject(model))
            {
                return View(model);
            }
            return RedirectToAction("Edit", new { id = model.ID });
        }

        [HttpGet]
        public ActionResult Locations()
        {
            var result = projectServices.GetLocations();
            return View(result);
        }

        [HttpGet]
        public ActionResult CreateLocation()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult CreateLocation([Bind(Exclude = "Id")]Location model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (!projectServices.SaveLocation(model))
            {
                ModelState.AddModelError("Name", "This name already exists! Please enter another name.");
                return View(model);
            }
            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public ActionResult EditLocation(int id)
        {
            var location = projectServices.GetLocation(id);

            if (location == null)
            {
                return RedirectToAction("Index");
            }
            return View(location);
        }

        [HttpPost]
        public ActionResult EditLocation(Location model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (!projectServices.SaveLocation(model))
            {
                return View(model);
            }
            return RedirectToAction("Edit", new { id = model.Id });
        }
    }
}