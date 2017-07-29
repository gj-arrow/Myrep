using System.Web.Mvc;
using Task.BLL.Interfaces;
using Task.BLL.DTO;
using AutoMapper;
using Task.Web.Models;
using Task.App_Start;


namespace Task.Web.Controllers
{
    public class SongController : Controller
    {
        ISongService Services;
        IMapper _mapper;
        public SongController(ISongService serv)
        {
            Services = serv;
            _mapper = AutoMapperConfigWeb.MapperConfiguration.CreateMapper();
        }

        public ActionResult InfoSong(int? idSong, string sort ="ascName")
        {
            SongDTO songDto = Services.GetById(idSong);
            var song = _mapper.Map<SongDTO, SongViewModel>(songDto);
            ViewBag.Sort = sort;
            return View(song);
        }

        [HttpGet]
        public JsonResult GetRangeId(int idSong, string sort)
        {
            var range = Services.GetRangeById(idSong, sort);
            return Json(range, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            Services.Dispose();
            base.Dispose(disposing);
        }
    }
}