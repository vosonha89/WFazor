using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFazor
{
    public class Setting
    {
        public string ModelFolder { get; set; }
        public string ViewFolder { get; set; }
        public string ControllerFolder { get; set; }
        public string RuntimeFolder { get; set; }

        public Setting(string modelFolder = "Models", string viewFolder = "Views", string controllerFolder = "Controllers", string runtimeFolder = "Runtime")
        {
            ModelFolder = modelFolder;
            ViewFolder = viewFolder;
            ControllerFolder = controllerFolder;
            RuntimeFolder = runtimeFolder;
        }
    }
}
