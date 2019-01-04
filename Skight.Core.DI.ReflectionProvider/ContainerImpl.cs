using System;
using System.Collections.Generic;

namespace Skight.Core.DI.ReflectionProvider
{
    public class ContainerImpl  : Container
    {
        private readonly IDictionary<Type, DiscreteItemResolver> item_resolvers;
        private readonly ConstructorResolver constructor_resolver;

        public ContainerImpl(IDictionary<Type, DiscreteItemResolver> itemResolvers)
        {
            item_resolvers = itemResolvers;
            constructor_resolver=new ConstructorResolver(this);
        }

        public object get(Type type)
        {
            if (item_resolvers.ContainsKey(type))
            {
                return item_resolvers[type].resolve();
            }
            //When the type is not registered but is class, then can be considered as self registered.
            if (type.IsClass)
            {
                if (!type.IsGenericType || !type.ContainsGenericParameters)
                {
                   return constructor_resolver.resolve(type);
                }
            }
            //Looking for Factory
            var factory_type = typeof(Factory<>).MakeGenericType(type);
            if (item_resolvers.ContainsKey(factory_type))
            {
                dynamic  factory = item_resolvers[factory_type].resolve() ;
                return factory.create();
            }
            throw new ApplicationException($"Cannot resolve type {type}.");

        }
    }
}