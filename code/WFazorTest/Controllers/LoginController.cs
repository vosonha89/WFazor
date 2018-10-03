using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFazor;

namespace WFazorTest.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return new View();
        }

        public ActionResult DoLogin(string model)
        {
            WFazorEngine.Instance.Session.Add("info", model);
            System.Windows.Forms.MessageBox.Show(model.ToString());
            return new RedirectToAction(AppRoute.Home, "Index");
        }
    }
}
