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
        public IEncodedString Content(string absolutePath)
        {
            string runtimePath = WFazorEngine.Instance.GetRuntimePath();
            string filePath = System.IO.Path.Combine(runtimePath, absolutePath.Replace("/", @"\"));
            return new RawString(filePath);
        }

        public IEncodedString RenderComponent<T>(string componentPath, T model)
        {
            string html = WFazorEngine.Instance.GetHtml(componentPath, typeof(T), model);
            return new RawString(html);
        }

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
