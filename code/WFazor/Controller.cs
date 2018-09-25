using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFazor
{
    public abstract class Controller
    {
        private WFazorBrowser _Browser { get; set; }

        public virtual void RedirectTo(string action, string controller, object model)
        {
            _Browser.RedirectTo(action, controller, model);
        }


    }
}
