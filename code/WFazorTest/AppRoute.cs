using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WFazor;
using WFazorTest.Controllers;

namespace WFazorTest
{
    public class AppRoute : IAppRoute
    {
        public static HomeController Home { get; set; }
        public static LoginController Login { get; set; }
        public IController Default
        {
            get => Home;
        }

        public AppRoute()
        {
            Home = new HomeController();
            Login = new LoginController();
        }

        public IController GetController(string controllerName)
        {
            string name = controllerName.Replace("Controller", string.Empty);
            PropertyInfo prop = this.GetType().GetProperties().FirstOrDefault(a => a.Name == name);

            return prop.GetValue(this) as IController;
        }
    }
}
