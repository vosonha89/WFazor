using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFazor;

namespace WFazorTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            object info = null;
            bool run = WFazorEngine.Instance.Session.TryGetValue("info", out info);
            if (info == null)
            {
                return new RedirectToAction(AppRoute.Login, "Index");
            }
            else
            {
                return new View();
            }
        }
    }
}
