using System.Collections.Generic;
using System.Web.Mvc;
using Task.BLL.Interfaces;
using Task.BLL.DTO;
using AutoMapper;
using Task.Web.Models;
using PagedList;
using System.Linq;
using Task.App_Start;

namespace Task.Web.Controllers
{
    public class PerformerController : Controller
    {
        IServices<PerformerDTO> Services;
        IMapper _mapper;
        public int pageSize = 15;

        public PerformerController(IServices<PerformerDTO> serv)
        {
            Services = serv;
            _mapper = AutoMapperConfigWeb.MapperConfiguration.CreateMapper();
        }

        public ActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);
            IEnumerable<PerformerDTO> performDtos = Services.GetAll();
            var performers = _mapper.Map<IEnumerable<PerformerDTO>, List<PerformerViewModel>>(performDtos);
            return View(performers.ToPagedList(pageNumber, pageSize));
        }


        public ActionResult PerformerProfile(int? idPerformer, int page = 1)
        {
            PerformerDTO performDto = Services.GetById(idPerformer);
            var performer = _mapper.Map<PerformerViewModel>(performDto);
            IEnumerable<SongViewModel> songsPerPage = performer.Songs.Skip((page - 1) * pageSize).Take(pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = performer.Songs.Count() };
            ListSongViewModel model = new ListSongViewModel { PageInfo = pageInfo, Songs = songsPerPage, Performer = performer };
            return View(model);
        }


        public ActionResult BiographyProfile(int? idPerformer)
        {
            PerformerDTO performDto = Services.GetById(idPerformer);
            var performer = _mapper.Map<PerformerDTO, PerformerViewModel>(performDto);
            return View(performer);
        }

        protected override void Dispose(bool disposing)
        {
            Services.Dispose();
            base.Dispose(disposing);
        }
    }
}