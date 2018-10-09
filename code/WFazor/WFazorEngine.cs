using RazorEngine;
using RazorEngine.Configuration;
using RazorEngine.Templating;
using RazorEngine.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFazor
{
    /// <summary>
    /// This class is engine for WFazor framework execute all function using singleton
    /// </summary>
    public class WFazorEngine
    {
        private static WFazorEngine _Instance = null;
        private string _RuntimePath = string.Empty;

        public Form Form = null;
        public WFazorBrowser Browser = null;
        public IController CurrentController = null;
        public string CurrentAction = string.Empty;
        public Setting Setting = null;
        public Route Route = null;
        public WFazorDictionary<string, object> Session;

        /// <summary>
        /// Singleton
        /// </summary>
        public static WFazorEngine Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new WFazorEngine(new Setting());
                }
                return _Instance;
            }
            set => _Instance = value;
        }

        private WFazorEngine(Setting setting)
        {
            Setting = setting;

            ResolvePathTemplateManager templateManager = new ResolvePathTemplateManager(new string[] { "cshtml" });
            TemplateServiceConfiguration config = new TemplateServiceConfiguration();
            config.TemplateManager = templateManager;
            config.Language = Language.CSharp;
            config.EncodedStringFactory = new HtmlEncodedStringFactory();

            config.BaseTemplateType = typeof(HtmlSupportTemplateBase<>);

            Engine.Razor = RazorEngineService.Create(config);

            _RuntimePath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
        }

        /// <summary>
        /// Init WFazor engine by form and rout
        /// </summary>
        /// <param name="mainForm">Windows Form</param>
        /// <param name="route">Route</param>
        public void Initialize(Form mainForm, Route route)
        {
            Form = mainForm;
            if (Browser == null)
            {
                Browser = new WFazorBrowser();
                Browser.Dock = DockStyle.Fill;
                Browser.BringToFront();
                Browser.ObjectForScripting = new ScriptInterface();
                mainForm.Controls.Add(Browser);
                Route = route;
                Session = new WFazorDictionary<string, object>();
                Route.Default.Execute<Func<ActionResult>>(Route.Default.DefaultAction);
            }
        }

        /// <summary>
        /// Get html render by using Razor Engine
        /// </summary>
        /// <param name="filePath">filePath</param>
        /// <param name="modelType">modelType</param>
        /// <param name="model">model</param>
        /// <param name="viewBag">viewBag</param>
        /// <returns></returns>
        public string GetHtml(string filePath, Type modelType = null, object model = null, DynamicViewBag viewBag = null)
        {
            var result = Engine.Razor.RunCompile(filePath, modelType, model, viewBag);
            return result;
        }

        public string GetRuntimePath()
        {
            return _RuntimePath;
        }
    }

    /// <summary>
    /// This class help font-end call action in controller
    /// </summary>
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    public class ScriptInterface
    {
        public object CallAction(string actionName, string controllerName, object data = null)
        {
            // Check wrong in here
            List<object> parameters = new List<object>();
            parameters.Add(data);
            IController controller = WFazorEngine.Instance.Route.GetController(controllerName);
            return controller.Execute<Func<ActionResult>>(actionName, parameters.ToArray());
        }
    }
}
