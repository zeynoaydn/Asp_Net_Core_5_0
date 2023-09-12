using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    public class EmployeeTestController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:44372/api/Default");
            var jsonString=await responseMessage.Content.ReadAsStringAsync();
            var values=JsonConvert.DeserializeObject<List<Class1>>(jsonString);
            return View(values);
        }
        public IActionResult AddEmpoyee()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddEmpoyee(Class1 p)
        {
            var httpClient = new HttpClient();
            var jsonemplo=JsonConvert.SerializeObject(p);
            StringContent content=new StringContent(jsonemplo,Encoding.UTF8,"application/json");
            var responseMessage= await httpClient.PostAsync("https://localhost:44372/api/Default",content);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(p);
        }
        [HttpGet]
        public async Task<IActionResult> EditEmployee(int id)
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:44372/api/Default/"+id);
            if( responseMessage.IsSuccessStatusCode )
            {
                var jsonString=await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<Class1>>(jsonString);
                return View(values);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> EditEmployee(Class1 p)
        {
            var httpClient = new HttpClient();
            var jsonemplo = JsonConvert.SerializeObject(p);
            var content = new StringContent(jsonemplo, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PutAsync("https://localhost:44372/api/Default/" ,content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(p);
        }
    }
    public class Class1
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
