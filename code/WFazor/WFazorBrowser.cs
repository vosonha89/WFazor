using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFazor
{
    public class WFazorBrowser : WebBrowser
    {
        public WFazorBrowser()
        {
            this.Dock = DockStyle.Fill;
            this.ScriptErrorsSuppressed = true;
        }

        public void RedirectTo(string action, string controller, object model)
        {
            string runTimePath = WFazorEngine.Instance.GetRuntimePath();
            string filePath = System.IO.Path.Combine(runTimePath, WFazorEngine.Instance.Setting.ViewFolder, controller, action + ".cshtml");
            string html = WFazorEngine.Instance.GetHtml(filePath);

            this.DocumentText = html;
        }
    }
}
