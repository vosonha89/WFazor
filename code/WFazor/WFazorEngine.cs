using RazorEngine;
using RazorEngine.Configuration;
using RazorEngine.Templating;
using RazorEngine.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFazor
{
    public class WFazorEngine
    {
        private static WFazorEngine _Instance = null;
        private string _RuntimePath = string.Empty;

        public WFazorBrowser Browser = null;
        public IController CurrentController = null;
        public string CurrentAction = string.Empty;
        public Setting Setting = null;

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

        public void Initialize(Form mainForm, Controller defaultController)
        {
            if (Browser == null)
            {
                Browser = new WFazorBrowser();
                Browser.Dock = DockStyle.Fill;
                Browser.BringToFront();
                mainForm.Controls.Add(Browser);

                defaultController.Execute(defaultController.DefaultAction);
            }
        }

        public string GetHtml(string filePath)
        {
            var result = Engine.Razor.RunCompile(filePath);
            return result;
        }

        public string GetRuntimePath()
        {
            return _RuntimePath;
        }
    }
}
