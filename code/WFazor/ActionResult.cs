namespace WFazor
{
    public abstract class ActionResult
    {
    }

    /// <summary>
    /// Return a View
    /// </summary>
    public class View : ActionResult
    {
        public View(object model = null)
        {
            string controllerName = WFazorEngine.Instance.CurrentController.GetType().Name.Replace("Controller", string.Empty);
            WFazorEngine.Instance.Browser.RedirectTo(WFazorEngine.Instance.CurrentAction, controllerName, model);
        }
    }

    /// <summary>
    /// Redirect to Action
    /// </summary>
    public class RedirectToAction : ActionResult
    {
        public RedirectToAction(IController controller, string action, object model = null)
        {
            string controllerName = controller.GetType().Name.Replace("Controller", string.Empty);
            WFazorEngine.Instance.Browser.RedirectTo(action, controllerName, model);
        }
    }
}
