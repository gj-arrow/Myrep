using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Task.BLL.Interfaces;
using Task.BLL.DTO;
using AutoMapper;
using Task.Web.Models;

namespace Task.WEB.Controllers
{
    public class HomeController : Controller
    {
        IPerformerService performService;

        public HomeController(IPerformerService serv)
        {
            performService = serv;
        }

        public ActionResult Index()
        {
            performService.getData();
            IEnumerable<PerformerDTO> performDtos = performService.GetPerformers();
            Mapper.Initialize(cfg => cfg.CreateMap<PerformerDTO,PerformerViewModel>());
            var performers = Mapper.Map<IEnumerable<PerformerDTO>, List<PerformerViewModel>>(performDtos);
            return View();
        }

        
        protected override void Dispose(bool disposing)
        {
            performService.Dispose();
            base.Dispose(disposing);
        }
    }
}