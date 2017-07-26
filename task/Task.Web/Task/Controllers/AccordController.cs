using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Task.BLL.Interfaces;
using Task.BLL.DTO;
using AutoMapper;
using Task.Web.Models;
using System.Linq;
using Task.App_Start;


namespace Task.Web.Controllers
{
    public class AccordController : Controller
    {
        IAccordServices Services;
        IMapper _mapper;
        public AccordController(IAccordServices serv)
        {
            Services = serv;
            _mapper = AutoMapperConfigWeb.MapperConfiguration.CreateMapper();
        }

        public ActionResult SaveAccords(int idSong, string strAccords)
        {
            string[] arrAccords = strAccords.Split(',');
            SongDTO updateSong = Services.SaveAccords(arrAccords, idSong);
            var song = _mapper.Map<SongDTO, SongViewModel>(updateSong);
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