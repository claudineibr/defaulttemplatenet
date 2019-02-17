using ProjetoPadrao.Domain.IApplicationService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoPadrao.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMeuServicoApplicationService _servicoApplicationService;

        public HomeController(IMeuServicoApplicationService servicoApplicationService)
        {
            this._servicoApplicationService = servicoApplicationService;
        }

        public ActionResult Index()
        {
            var response = this._servicoApplicationService.GetServicos();

            return View();
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