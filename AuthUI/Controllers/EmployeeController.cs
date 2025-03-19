using System.Text.Json.Serialization;
using AuthUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AuthUI.Controllers
{ 

    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

