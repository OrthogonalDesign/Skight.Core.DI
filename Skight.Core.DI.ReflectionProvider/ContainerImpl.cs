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

        public T get<T>()
        {
            return (T) item_resolvers[typeof(T)].resolve();
        }
    }
}