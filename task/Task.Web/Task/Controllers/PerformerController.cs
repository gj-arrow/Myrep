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
    public class PerformerController : Controller
    {
        IPerformerService PerformerServices;
        ISongService SongServices;
        IMapper _mapper;
        public int pageSize = 15;

        public PerformerController(IPerformerService servPerf, ISongService servSong)
        {
            PerformerServices = servPerf;
            SongServices = servSong;
            _mapper = AutoMapperConfigWeb.MapperConfiguration.CreateMapper();
        }

        public ActionResult Index(int page = 1, string sort = "")
        {
            IEnumerable<PerformerDTO> performDtos = PerformerServices.GetAll();
            IEnumerable<PerformerDTO> performDtosFilter = PerformerServices.Sort(sort, performDtos).Skip((page - 1) * pageSize).Take(pageSize);
            var performers = _mapper.Map<IEnumerable<PerformerDTO>, IEnumerable<PerformerViewModel>>(performDtosFilter);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = performDtos.Count() };
            PerformerPageViewModel model = new PerformerPageViewModel { PageInfo = pageInfo, Performers = performers, CurrentSort = sort };
            return View(model);
        }

        public ActionResult PerformerProfile(int? idPerformer, int page = 1, string sort = "")
        {
            IEnumerable<SongViewModel> songsPerPage;
            PerformerDTO performDto = PerformerServices.GetById(idPerformer);
            performDto.Songs = SongServices.Sort(sort , performDto.Songs);
            var performer = _mapper.Map<PerformerViewModel>(performDto);
            songsPerPage = performer.Songs.Skip((page - 1) * pageSize).Take(pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = performer.Songs.Count() };
            ListSongViewModel model = new ListSongViewModel { PageInfo = pageInfo, Songs = songsPerPage, Performer = performer, CurrentSort = sort };
            return View(model);
        }


        public ActionResult BiographyProfile(int? idPerformer)
        {
            PerformerDTO performDto = PerformerServices.GetById(idPerformer);
            var performer = _mapper.Map<PerformerDTO, PerformerViewModel>(performDto);
            return View(performer);
        }

        protected override void Dispose(bool disposing)
        {
            PerformerServices.Dispose();
            base.Dispose(disposing);
        }
    }
}