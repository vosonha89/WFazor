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
    public class AppRoute : Route
    {
        public static HomeController Home { get; set; }
        public static LoginController Login { get; set; }
        public override IController Default => Home;

        public AppRoute()
        {
            Home = new HomeController();
            Login = new LoginController();
        }
    }
}
