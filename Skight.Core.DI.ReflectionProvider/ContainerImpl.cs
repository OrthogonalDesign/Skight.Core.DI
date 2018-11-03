using System;
using System.Collections.Generic;
using Skight.Core.DI;

namespace Skight.Core.DI.ReflectionProvider
{
    public class ContainerImpl  : Container
    {
        private readonly IDictionary<Type, DiscreteItemResolver> item_resolvers;

        public ContainerImpl(IDictionary<Type, DiscreteItemResolver> itemResolvers)
        {
            item_resolvers = itemResolvers;
        }

        public object get(Type type)
        {
            if (!item_resolvers.ContainsKey(type))
            {
                throw new ApplicationException($"Cannot find type {type} resolver.");
            }
            return item_resolvers[type].resolve();
        }
    }
}