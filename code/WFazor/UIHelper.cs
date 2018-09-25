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
            string runTimePath = WFazorEngine.Instance.GetRuntimePath();
            string filePath = System.IO.Path.Combine(runTimePath, absolutePath.Replace("/", @"\"));
            return new RawString(filePath);
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
