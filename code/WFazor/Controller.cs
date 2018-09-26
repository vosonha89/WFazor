using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WFazor
{
    public abstract class Controller : IController
    {
        public string DefaultAction
        {
            get => "Index";
        }

        public Controller()
        {
        }

        public virtual bool BeforeExecute()
        {
            return true;
        }

        public void Execute(string actionName, object[] parameters = null)
        {
            WFazorEngine.Instance.CurrentController = this;
            WFazorEngine.Instance.CurrentAction = actionName;
            if (BeforeExecute())
            {
                Type type = this.GetType();
                MethodInfo method = type.GetMethod(actionName);
                method.Invoke(this, parameters);
            }
        }
    }
}
