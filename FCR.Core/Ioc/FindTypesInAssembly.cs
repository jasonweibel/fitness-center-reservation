using System;
using System.Reflection;

namespace FCR.Core.Ioc
{
    public class FindTypesInAssembly : ITypeFinder
    {
        private readonly Assembly assembly;

        public FindTypesInAssembly(Assembly assembly)
        {
            this.assembly = assembly;
        }

        public Type[] GetTypes()
        {
            return assembly.GetTypes();
        }
    }

}