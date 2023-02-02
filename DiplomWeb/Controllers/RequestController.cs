using DiplomWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DiplomWeb.Controllers
{
    
    public class RequestController : Controller
    {
       
        public RequestController()
        {
           
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}