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
            return new RedirectToAction(App.Login, "Index");
        }
    }
}
