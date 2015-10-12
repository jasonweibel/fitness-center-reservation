using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace FCR.WebService.Infrastructure
{
    public class CustomBehavior : IInterceptionBehavior
    {
        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            Debug.WriteLine(string.Format("Executing Method: {0}.{1}", input.MethodBase.DeclaringType.FullName, input.MethodBase.Name));

            for (int i = 0; i < input.Arguments.Count; i++)
            {
                if (input.Arguments.ParameterName(i).ToLower() == "ssn")
                    Debug.WriteLine("{0} = {1}", input.Arguments.ParameterName(i), "xxx-xx-xxxx");
                else
                    Debug.WriteLine("{0} = {1}", input.Arguments.ParameterName(i), input.Arguments[i]);
            }

            IMethodReturn returnValue = getNext()(input, getNext);

            if (returnValue.Exception != null)
                Debug.WriteLine(string.Format("An exception occured! {0}", returnValue.Exception.ToString()));
            else if (returnValue.ReturnValue != null)
                Debug.WriteLine(String.Format("Method returned successfully with value {0}", returnValue.ReturnValue.ToString()));
            else
                Debug.WriteLine(String.Format("Method returned successfully with null value"));


            return returnValue;
        }

        public bool WillExecute
        {
            get { return true; }
        }
    }
}