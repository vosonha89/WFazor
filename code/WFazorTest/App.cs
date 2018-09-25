using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFazorTest.Controllers;

namespace WFazorTest
{
    public class App
    {
        public static HomeController Home { get; set; }
        public static LoginController Login { get; set; }

        public static void Initialize()
        {
            Home = new HomeController();
            Login = new LoginController();
        }
    }
}
