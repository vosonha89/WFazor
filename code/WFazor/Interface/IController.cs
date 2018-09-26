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
        void Execute(string actionName, object[] parameters = null);
    }
}
