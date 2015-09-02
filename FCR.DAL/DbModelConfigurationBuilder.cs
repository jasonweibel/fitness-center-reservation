using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;

namespace FCR.DAL
{
    public class DbModelConfigurationBuilder
    {
        public DbModelBuilder LoadConfigurations<T>(DbModelBuilder modelBuilder) where T : DbContext
        {
            var types = Assembly.GetAssembly(typeof(T))
                     .GetTypes()
                     .Where(t => t.Namespace != null && t.Namespace.Contains("Configurations"))
                     .Where(i => i.BaseType != null && i.BaseType.IsGenericType && i.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));

            foreach (var type in types)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }

            return modelBuilder;
        }
    }
}
