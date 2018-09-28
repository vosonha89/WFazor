using System.Linq;
using System.Reflection;

namespace WFazor
{
    public abstract class Route
    {
        public abstract IController Default { get; }

        public virtual IController GetController(string controllerName)
        {
            string name = controllerName.Replace("Controller", string.Empty);
            PropertyInfo prop = this.GetType().GetProperties().FirstOrDefault(a => a.Name == name);

            return prop.GetValue(this) as IController;
        }
    }
}
