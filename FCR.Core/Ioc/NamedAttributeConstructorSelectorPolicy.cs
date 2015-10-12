//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection;
//using Microsoft.Practices.ObjectBuilder2;
//using Microsoft.Practices.Unity.ObjectBuilder;
//using Ninject;

//namespace FCR.Core.Ioc
//{
//    public class NamedAttributeConstructorSelectorPolicy
//         : Microsoft.Practices.Unity.ObjectBuilder.DefaultUnityConstructorSelectorPolicy
//    {
//        protected override IDependencyResolverPolicy
//            CreateResolver(ParameterInfo parameter)
//        {
//            List<NamedAttribute> attributes =
//                parameter.GetCustomAttributes(false)
//                    .OfType<NamedAttribute>()
//                    .ToList();

//            if (attributes.Count > 0)
//            {
//                string name = attributes[0].Name;
//                return new NamedTypeDependencyResolverPolicy(
//                    parameter.ParameterType, name);
//            }

//            return base.CreateResolver(parameter);
//        }
//    }
//}