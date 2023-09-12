using DocumentFormat.OpenXml.Office2010.ExcelAc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using System.Collections.Generic;
using System.Linq;
using WebUI.Areas.Admin.Models;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WriterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult WriterList()
        {
            var JsonWriters = JsonConvert.SerializeObject(writers);
            return Json(JsonWriters);
        }
        public IActionResult GetWriterByID(int writerid)
        {
            var findwriter=writers.FirstOrDefault(x=>x.Id == writerid);
            var jsonwriters=JsonConvert.SerializeObject(findwriter);
            return Json(jsonwriters);

        }
        [HttpPost]
        public IActionResult AddWriter(WriterClass w)
        {
            writers.Add(w);
            var jsonwriter= JsonConvert.SerializeObject(w);
            return Json(jsonwriter);

        }
        public IActionResult DeleteWriter(int id)
        {
            var writer=writers.FirstOrDefault(x=>x.Id == id);
            writers.Remove(writer);
            return Json(writer);

        }
        public IActionResult UpdateWriter(WriterClass w)
        {
            var writer = writers.FirstOrDefault(x => x.Id == w.Id);
            writer.Name=w.Name;
            var jsonwriter = JsonConvert.SerializeObject(w);
            return Json(jsonwriter);

        }
        public static List<WriterClass> writers = new List<WriterClass>
        {
            new WriterClass
            {
                Id = 1,
                Name="zeynep",
            },
             new WriterClass
            {
                Id = 2,
                Name="muhammet",
            },
              new WriterClass
            {
                Id = 3,
                Name="nezaket",
            },
               new WriterClass
            {
                Id = 4,
                Name="burak",
            }
        };
    }
}
