using System;

namespace FCR.Core.Ioc
{
    /// <summary>
    /// A type finder that uses a configuration file section containing assemblies to 
    /// interrogate for types to add to the container.
    /// https://searchcode.com/codesearch/view/28825010/
    /// </summary>
    public class FindTypesInConfiguration : BaseTypeFinder
    {
        private const string CONFIG_SECTION = "IocDiscoveryAssemblies";
        /// <summary>
        /// The types found in the assemblies.
        /// </summary>
        /// <returns></returns>
        public override Type[] GetTypes()
        {
            this.ConfigSection = CONFIG_SECTION;
            return base.GetTypes();
        }

    }
}
