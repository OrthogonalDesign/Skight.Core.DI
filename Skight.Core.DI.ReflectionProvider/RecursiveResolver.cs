using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Skight.BuildBlocks.BasicTypeExtensions;

namespace Skight.Core.DI.ReflectionProvider
{
    public class RecursiveResolver :DiscreteItemResolver
    {
        private readonly Container container;
        private readonly Type type;

        public RecursiveResolver(Container container, Type type)
        {
            this.container = container;
            this.type = type;
        }

        public object resolve()
        {
            ParameterInfo[] param_types = type.greediest_constructor().GetParameters();
            if(type.has_cycle_depends())
                throw new ApplicationException(
                    $"Registering implement type {type} has cycle depends with param");
            IEnumerable<object> parameters = get_parameters(param_types);
            return Activator.CreateInstance(type, parameters.ToArray());
        }

       

        private IEnumerable<object> get_parameters(ParameterInfo[] param_types)
        {
            return param_types.Select(x => container.get(x.ParameterType));
        }
    }
}