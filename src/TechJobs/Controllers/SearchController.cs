using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        // TODO #1 - Create a Results action method to process 
        // search request and display results
        [HttpPost]
        public IActionResult Results(string searchType, string searchTerm)
        {
            if (searchType.Equals("all"))
            {
                List<Dictionary<string, string>> jobs = JobData.FindByValue(searchTerm);
                return View("Index");

            }


            else
            {

                List<Dictionary<string, string>> Jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
                ViewBag.columns = ListController.columnChoices;
                ViewBag.jobs = Jobs;
                return View("Index");
            }








        }
    }
}
