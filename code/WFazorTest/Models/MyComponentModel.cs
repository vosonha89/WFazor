using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFazorTest.Models
{
    public class MyComponentModel
    {
        public List<string> ListInfo { get; set; }

        public MyComponentModel()
        {
            ListInfo = new List<string>();
            ListInfo.Add("10 users included");
            ListInfo.Add("2 GB of storage");
            ListInfo.Add("Email support");
            ListInfo.Add("Help center access");
        }
    }
}
