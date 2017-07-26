using System.Web.Mvc;
using Task.BLL.Interfaces;

namespace Task.Web.Controllers
{
    public class HomeController : Controller
    {
        ICommon Services;
        public HomeController(ICommon serv)
        {
            Services = serv;
        }

        public ActionResult ParsingData()
        {
            Services.ParsingData();
            return View();
        }

    }
}