using RazorEngine.Text;
using Newtonsoft.Json;

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

    /// <summary>
    /// Return a componel view with model
    /// </summary>
    /// <typeparam name="T">Model object</typeparam>
    public class ComponentView<T> : IEncodedString where T : class
    {
        public string ComponentViewPath { get; set; }
        public T Model { get; set; }
        public ComponentView(string componentViewPath, T model = null)
        {
            ComponentViewPath = componentViewPath;
            Model = model;
        }

        public string ToEncodedString()
        {
            string html = WFazorEngine.Instance.GetHtml(ComponentViewPath, typeof(T), Model);
            return new RawString(html).ToEncodedString();
        }
    }

    public class JsonResult
    {
        public object Data { get; set; }
        public bool HasError { get; set; }
        public string ErrorMessage { get; set; }

        public JsonResult(object data, bool hasError = false, string errorMessage = "")
        {
            Data = data;
            HasError = hasError;
            ErrorMessage = errorMessage;
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
