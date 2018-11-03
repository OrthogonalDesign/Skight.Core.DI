using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Skight.BuildBlocks.BasicTypeExtensions;
using Skight.Core.DI;

namespace Skight.Core.DI.ReflectionProvider
{
    public class RegistrationImpl  : Registration
    {
        private readonly IDictionary<Type, DiscreteItemResolver> item_resolvers;
        private readonly ConstructorResolver constructor_resolver;

        public RegistrationImpl(
            IDictionary<Type, DiscreteItemResolver> resolvers)
        {
            item_resolvers = resolvers;
            constructor_resolver=
                new ConstructorResolver(
                    new ContainerImpl(item_resolvers));
        }


        public void register(Type contract_type, Type implement_type)
        {
            if (!implement_type.is_assignable_to(contract_type))
                throw new ApplicationException(
                    $"Registering implement type {implement_type} is not inherited from contract type {contract_type}");
            register(
                contract_type,
                new TypeResolver(
                    constructor_resolver, 
                    implement_type));
        }

        public void register(Type type, DiscreteItemResolver resolver)
        {
            safe_add(type, resolver);    
        }

        private void safe_add(Type type, DiscreteItemResolver resolver)
        {
            if (!item_resolvers.ContainsKey(type))
            {
                item_resolvers.Add(type,resolver);
            }
        }
    }
}