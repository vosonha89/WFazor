using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFazor
{
    public class ActionResult
    {
        public ActionResult()
        {

        }
    }

    public class View : ActionResult
    {
        public View(object model = null)
        {
            string controllerName = WFazorEngine.Instance.CurrentController.GetType().Name.Replace("Controller", string.Empty);
            WFazorEngine.Instance.Browser.RedirectTo(WFazorEngine.Instance.CurrentAction, controllerName, model);
        }
    }

    public class RedirectToView : ActionResult
    {
        public RedirectToView(IController controller, string action, object model = null)
        {
            string controllerName = controller.GetType().Name.Replace("Controller", string.Empty);
            WFazorEngine.Instance.Browser.RedirectTo(action, controllerName, model);
        }
    }

    public class RedirectToAction : ActionResult
    {
        public RedirectToAction(IController controller, string action, object[] parameters = null)
        {
            controller.Execute(action, parameters);
        }
    }
}
