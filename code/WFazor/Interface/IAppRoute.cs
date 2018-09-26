using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFazor
{
    public interface IAppRoute
    {
        IController Default { get;}
        IController GetController(string controllerName);
    }
}
