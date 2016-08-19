using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleApp.Models;

namespace SimpleApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Color color)
        {
            Color? oldColor = Session["color"] as Color?;
            if (oldColor != null)
            {
                Votes.ChangeVote(color, (Color)oldColor);
            }
            else
            {
                Votes.RecordVote(color);
            }
            ViewBag.SelectedColor = Session["color"] = color;
            return View();
        }

        public ActionResult Modules()
        {
            var modules = HttpContext.ApplicationInstance.Modules;
            Tuple<string, string>[] data =
            modules.AllKeys
            .Select(x => new Tuple<string, string>(
            x.StartsWith("__Dynamic") ? x.Split('_', ',')[3] : x,
           modules[x].GetType().Name))
            .OrderBy(x => x.Item1)
            .ToArray();
            return View(data);
        }

        private List<string> GetTimeStamps()
        {
            return new List<string>
            {
                $"App timestamp: {HttpContext.Application["app_timestamp"]}",
                $"Request timestamp: {Session["request_timestamp"]}",
            };
        }
    }
}