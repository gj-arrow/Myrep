using System.Web.Mvc;
using Task.BLL.Interfaces;
using Task.BLL.DTO;
using AutoMapper;
using Task.Web.Models;
using Task.App_Start;
using MvcSiteMapProvider.Web.Mvc.Filters;

namespace Task.Web.Controllers
{
    public class SongController : Controller
    {
        ISongService SongServices;
        IMapper _mapper;
        public SongController(ISongService songServ)
        {
            SongServices = songServ;
            _mapper = AutoMapperConfigWeb.MapperConfiguration.CreateMapper();
        }

        [SiteMapTitle("Name")]
        [SiteMapTitle("Performer.Name", Target = AttributeTarget.ParentNode)]
        public ActionResult InfoSong(int idPerformer, int? idSong, string sort ="ascName")
        {
            SongDTO songDto = SongServices.GetById(idSong);
            var song = _mapper.Map<SongDTO, SongViewModel>(songDto);
            ViewBag.Sort = sort;
            return View(song);
        }

        [HttpGet]
        public JsonResult GetRangeId(int idSong, string sort)
        {
            var range = SongServices.GetRangeById(idSong, sort);
            return Json(range, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            SongServices.Dispose();
            base.Dispose(disposing);
        }
    }
}