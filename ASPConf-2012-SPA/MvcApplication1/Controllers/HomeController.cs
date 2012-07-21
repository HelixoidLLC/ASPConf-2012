using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Home/Hello

        public ActionResult Hello()
        {
            var serverInfo = new ServerInfo {Id = "Smart Server "};

            return View(serverInfo);
        }
    }
}
