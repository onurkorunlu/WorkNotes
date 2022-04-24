using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WorkNotes.Entities;

namespace WorkNotes.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(new List<Project>());
        }
    }
}
