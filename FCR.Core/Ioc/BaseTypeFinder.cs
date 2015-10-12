using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Reflection;

namespace FCR.Core.Ioc
{
    public class BaseTypeFinder : ITypeFinder
    {
        public string ConfigSection { get; set; }
        public virtual Type[] GetTypes()
        {
            List<Type> typesToReturn = new List<Type>();
            NameValueCollection assemblyList = ConfigurationManager.GetSection(ConfigSection) as NameValueCollection;
            var names = from item in assemblyList.AllKeys
                        select assemblyList[item];

            foreach (string name in names)
            {
                Type[] types = Assembly.Load(name).GetTypes();
                typesToReturn.AddRange(types);
            }

            return typesToReturn.ToArray();
        }
    }
}
