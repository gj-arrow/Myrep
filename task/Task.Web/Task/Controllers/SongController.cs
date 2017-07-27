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
        IService<SongDTO> Services;
        IMapper _mapper;
        public SongController(IService<SongDTO> serv)
        {
            Services = serv;
            _mapper = AutoMapperConfigWeb.MapperConfiguration.CreateMapper();
        }

        public ActionResult InfoSong(int? idSong)
        {
            SongDTO songDto = Services.GetById(idSong);
            var song = _mapper.Map<SongDTO, SongViewModel>(songDto);
            return View(song);
        }

        protected override void Dispose(bool disposing)
        {
            Services.Dispose();
            base.Dispose(disposing);
        }
    }
}