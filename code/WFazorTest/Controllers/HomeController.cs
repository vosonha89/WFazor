using RazorEngine.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFazor;
using WFazorTest.Models;

namespace WFazorTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            object info = WFazorEngine.Instance.Session["info"];
            if (info == null)
            {
                return new RedirectToAction(AppRoute.Login, "Index");
            }
            else
            {
                return new View();
            }
        }

        public string GetListData(string componentViewPath, object data)
        {
            return new ComponentView<Models.MyComponentModel>(componentViewPath, new Models.MyComponentModel()).ToEncodedString();
        }

        public string GetJson()
        {
            LoginModel model = new LoginModel
            {
                Username = "Vo Son Ha"
            };
            return new JsonResult(model).ToJson();
        }
    }
}
