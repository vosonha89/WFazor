using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFazor;
using WFazorTest.Models;

namespace WFazorTest.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return new View();
        }

        public ActionResult DoLogin(LoginModel model)
        {
            WFazorEngine.Instance.Session.Add("info", model);
            return new RedirectToAction(AppRoute.Home, "Index");
        }
    }
}
