using System.Web.Mvc;
using Task.BLL.Interfaces;
using Task.BLL.DTO;
using AutoMapper;
using Task.Web.Models;


namespace Task.Web.Controllers
{
    public class SongController : Controller
    {
        IServices<SongDTO> Services;
        public SongController(IServices<SongDTO> serv)
        {
            Services = serv;
        }

        public ActionResult InfoSong(int? idSong)
        {
            SongDTO songDto = Services.GetById(idSong);
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<SongDTO, SongViewModel>();
                cfg.CreateMap<PerformerDTO, PerformerViewModel>();
                cfg.CreateMap<AccordDTO, AccordViewModel>();
            });
            var song = Mapper.Map<SongDTO, SongViewModel>(songDto);
            return View(song);
        }

        protected override void Dispose(bool disposing)
        {
            Services.Dispose();
            base.Dispose(disposing);
        }
    }
}