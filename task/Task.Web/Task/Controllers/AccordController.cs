using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Task.BLL.Interfaces;
using Task.BLL.DTO;
using AutoMapper;
using Task.Web.Models;
using System.Linq;


namespace Task.Web.Controllers
{
    public class AccordController : Controller
    {
        IAccordServices Services;
        public AccordController(IAccordServices serv)
        {
            Services = serv;
        }

        public ActionResult SaveAccords(int idSong, string strAccords)
        {
            string[] arrAccords = strAccords.Split(',');
            SongDTO updateSong = Services.SaveAccords(arrAccords, idSong);
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<SongDTO, SongViewModel>();
                cfg.CreateMap<PerformerDTO, PerformerViewModel>();
                cfg.CreateMap<AccordDTO, AccordViewModel>();
            });
            var song = Mapper.Map<SongDTO, SongViewModel>(updateSong);
            return View("InfoSong",song);
        }

        [HttpGet]
        public JsonResult DataAccords()
        {
            IEnumerable<string> ls = Services.GetNameAccrods();
            return Json(ls.Distinct(), JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            Services.Dispose();
            base.Dispose(disposing);
        }
    }
}