using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
        public T Execute<T>(string actionName, object[] parameters = null) where T : class
        {
            WFazorEngine.Instance.CurrentController = this;
            WFazorEngine.Instance.CurrentAction = actionName;
            if (BeforeExecute())
            {
                Type type = this.GetType();
                MethodInfo method = type.GetMethod(actionName);

                ParameterInfo[] parameterInfos = method.GetParameters();
                List<object> parsedParams = new List<object>();
                if (parameters != null)
                {
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        object parsedItem = null;
                        try
                        {
                            Type paramType = parameterInfos[i].ParameterType;
                            if (paramType.IsValueType)
                            {
                                parsedItem = parameters[i];
                            }
                            else
                            {
                                parsedItem = JsonConvert.DeserializeObject(parameters[i].ToString(), paramType);
                            }
                        }
                        catch (Exception ex)
                        {
                            GC.Collect();
                            parsedItem = parameters[i];
                        }
                        parsedParams.Add(parsedItem);
                    }
                }
                object retunObj = method.Invoke(this, parsedParams.ToArray());
                return retunObj as T;
            }
            else
            {
                return null;
            }
        }
    }
}
