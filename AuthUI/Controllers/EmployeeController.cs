using System.Text.Json.Serialization;
using AuthUI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AuthUI.Controllers
{
    public class EmployeeController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7122/api");

        private readonly HttpClient _client;
        public EmployeeController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<EmployeeViewModel> employeeList = new List<EmployeeViewModel>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Employee/Get").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                employeeList = JsonConvert.DeserializeObject<List<EmployeeViewModel>>(data);
            }
            return View(employeeList);
        }
    }
}
