using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFazor
{
    public interface IController
    {
        string DefaultAction { get; }
        T Execute<T>(string actionName, object[] parameters = null) where T : class;
    }
}
