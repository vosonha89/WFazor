using System;
using System.Reflection;

namespace WFazor
{
    /// <summary>
    /// This class is base controller
    /// </summary>
    public abstract class Controller : IController
    {
        /// <summary>
        /// Default action in any controller. Default is "Index"
        /// </summary>
        public string DefaultAction
        {
            get => "Index";
        }

        /// <summary>
        /// This method will be execute before invoke to action. If return false, action will be not execute
        /// </summary>
        /// <returns>True or False</returns>
        public virtual bool BeforeExecute()
        {
            return true;
        }

        /// <summary>
        /// Invoke action in current controller
        /// </summary>
        /// <param name="actionName">actionName</param>
        /// <param name="parameters">parameters</param>
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
