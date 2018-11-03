using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Skight.BuildBlocks.BasicTypeExtensions;

namespace Skight.Core.DI.ReflectionProvider
{
    public class ConstructorResolver 
    {
        private readonly Container container;

        public ConstructorResolver(Container container)
        {
            this.container = container;
        }

        public object resolve(Type type)
        {
            ParameterInfo[] param_types = type.greediest_constructor().GetParameters();
            IEnumerable<object> parameters = get_parameters(param_types);
            return Activator.CreateInstance(type, parameters.ToArray());
        }
        
        private IEnumerable<object> get_parameters(ParameterInfo[] param_types)
        {
            var result= param_types.Select(x => container.get(x.ParameterType));
            return result;
        }
    }
}