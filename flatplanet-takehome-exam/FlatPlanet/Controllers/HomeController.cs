using FlatPlanet.Models;
using FlatPlanet.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlatPlanet.Controllers
{
    public class HomeController : Controller
    {
        private ICounterService _counterService;

        public HomeController(ICounterService counterService) {
            this._counterService = counterService;
        }

        public ActionResult Index()
        {
            return View(new ClickCounterModel());
        }
        public ActionResult RegisterClick(ClickCounterModel model)
        {
            //call counter service to increase count from DB
            int latestCount = this._counterService.IncreaseCount();

            model.NumberOfClicks = latestCount;

            return Json(model);
        }
        public ActionResult ResetClicks(ClickCounterModel model)
        {
            //call counter service to increase count from DB
            this._counterService.ResetCount();
            model.ResetClicks();
            return Json(model);
        }
    }
}