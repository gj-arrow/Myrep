using System.Collections.Generic;
using System.Web.Mvc;
using Task.BLL.Interfaces;
using Task.BLL.DTO;
using AutoMapper;
using Task.Web.Models;
using PagedList.Mvc;
using PagedList;
using System.Linq;


namespace Task.WEB.Controllers
{
    public class HomeController : Controller
    {
        IServices Services;
        public int pageSize = 2;

        public HomeController(IServices serv)
        {
            Services = serv;
        }

        public ActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);
            // Services.ParsingData();
            IEnumerable<PerformerDTO> performDtos = Services.GetPerformers();
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<PerformerDTO, PerformerViewModel>();
                cfg.CreateMap<SongDTO, SongViewModel>();
            });
            var performers = Mapper.Map<IEnumerable<PerformerDTO>, List<PerformerViewModel>>(performDtos);
            return View(performers.ToPagedList(pageNumber, pageSize));
        }


        public ActionResult PerformerProfile(int? idPerformer, int page = 1)
        {
            PerformerDTO performDto = Services.GetPerformer(idPerformer);
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<PerformerDTO, PerformerViewModel>();
                cfg.CreateMap<SongDTO, SongViewModel>();
            });
            var performer = Mapper.Map<PerformerDTO, PerformerViewModel>(performDto);

            IEnumerable<SongViewModel> songsPerPage = performer.Songs.Skip((page - 1) * pageSize).Take(pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = performer.Songs.Count() };
            ListSongViewModel model = new ListSongViewModel { PageInfo = pageInfo, Songs = songsPerPage , Performer = performer };
            return View(model);
        }

        public ActionResult BiographyProfile(int? idPerformer)
        {
            PerformerDTO performDto = Services.GetPerformer(idPerformer);
            Mapper.Initialize(cfg =>
            {
                 cfg.CreateMap<SongDTO, SongViewModel>();
                cfg.CreateMap<PerformerDTO, PerformerViewModel>();
            });
            var performer = Mapper.Map<PerformerDTO, PerformerViewModel>(performDto);
            return View(performer);
        }

        public ActionResult InfoSong(int? idSong)
        {
            SongDTO songDto = Services.GetSong(idSong);
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