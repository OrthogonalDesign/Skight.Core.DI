﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Skight.BuildBlocks.BasicTypeExtensions;

namespace Skight.Core.DI.ReflectionProvider
{
    public class RecursiveResolver
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
            IEnumerable<object> parameters = get_parameters(param_types);
            return Activator.CreateInstance(type, parameters.ToArray());
        }

       

        private IEnumerable<object> get_parameters(ParameterInfo[] param_types)
        {
            return param_types.Select(x => container.get(x.ParameterType));
        }
    }
}