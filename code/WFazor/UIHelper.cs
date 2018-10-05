using RazorEngine.Templating;
using RazorEngine.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFazor
{
    public class HtmlHelper
    {
        /// <summary>
        /// Render real content file in view
        /// </summary>
        /// <param name="absolutePath">Content absolute path</param>
        /// <returns>HTML</returns>
        public IEncodedString Content(string absolutePath)
        {
            string runtimePath = WFazorEngine.Instance.GetRuntimePath();
            string filePath = System.IO.Path.Combine(runtimePath, absolutePath.Replace("/", @"\"));
            return new RawString(filePath);
        }

        /// <summary>
        /// Render component inside of any view
        /// </summary>
        /// <typeparam name="T">Model type</typeparam>
        /// <param name="componentViewPath">Component view absolute path</param>
        /// <param name="model">Model</param>
        /// <returns>HTML</returns>
        public IEncodedString RenderComponent<T>(string componentViewPath, T model)
        {
            string html = WFazorEngine.Instance.GetHtml(componentViewPath, typeof(T), model);
            return new RawString(html);
        }

        /// <summary>
        /// Render component by using action in controller
        /// </summary>
        /// <param name="componentViewPath">Component view absolute path</param>
        /// <param name="actionName"></param>
        /// <param name="controllerName"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public IEncodedString RenderComponentWithAction(string componentViewPath, string actionName, string controllerName, object data)
        {
            IController controller = null;
            if (string.IsNullOrEmpty(controllerName))
            {
                controller = WFazorEngine.Instance.Route.Default;
            }
            else
            {
                controller = WFazorEngine.Instance.Route.GetController(controllerName);
            }
            List<object> parameters = new List<object>();
            parameters.Add(componentViewPath);
            parameters.Add(data);
            IEncodedString htmlRaw = new RawString(controller.Execute<string>(actionName, parameters.ToArray()));
            return htmlRaw;
        }

        /// <summary>
        /// Get runtime path of application
        /// </summary>
        /// <returns></returns>
        public IEncodedString RuntimePath()
        {
            string runtimePath = WFazorEngine.Instance.GetRuntimePath();
            return new RawString(runtimePath);
        }
    }

    public abstract class HtmlSupportTemplateBase<T> : TemplateBase<T>
    {
        public HtmlSupportTemplateBase()
        {
            Html = new HtmlHelper();
        }

        public HtmlHelper Html { get; set; }
    }
}