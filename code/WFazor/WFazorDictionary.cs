using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFazor
{
    public class WFazorDictionary<TKey, TValue> : Dictionary<TKey, TValue>
        where TValue : class
    {
        public TValue this[TKey key]
        {
            get
            {
                TValue val;
                this.TryGetValue(key, out val);
                return val;
            }
        }
    }
}
