using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test.Generic.App.Filter;
using Test.Generic.App.Models;
using Test.Generic.Public.Models.Source;
using Test.Generic.ServiceLayer.Services;

namespace Test.Generic.App.Controllers
{
    [LoggingFilter]
    public class HomeController : Controller
    {
        private readonly IDataService _dataService;

        public HomeController(IDataService dataService)
        {
            _dataService = dataService;
        }

        public ActionResult Index(string message = "")
        {
            var response = _dataService.GetAll();
            var viewData = response.Select(x => new DataModel()
            {
                Body = x.Body,
                Id = x.Id,
                Title = x.Title,
                UserId = x.UserId
            })?.ToList();
            return View(new ViewDataModel() { ListData = viewData, Message = message });
        }

        public ActionResult Delete(int id)
        {
            var data = _dataService.Delete(id);
            if (data)
                return RedirectToAction("Index", "Home",  new { message = "Başarı ile silinmiştir" });
            else
                return RedirectToAction("Index", "Home", new { message = "Bir hata oluştu" });
        }

        public ActionResult Add(DataModel newData)
        {
            DataModel returnData = null;
            if (newData!=null && !string.IsNullOrEmpty(newData.Body))
            {
              var result=  _dataService.Add(new SourceCreateRequest()
                {
                    Body = newData.Body,
                    Title = newData.Title,
                    UserId = newData.UserId
                });

                returnData = new DataModel()
                {
                    Body = result.Body,
                    Id = result.Id,
                    Title = result.Title,
                    UserId = result.UserId
                };
            }
            
            return View(returnData);
        }



        public ActionResult Detail(int id)
        {
            var data = _dataService.GetById(id);
            var dataModel = new DataModel()
            {
                Body = data.Body,
                Id = data.Id,
                Title = data.Title,
                UserId = data.UserId
            };
            return View(dataModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}