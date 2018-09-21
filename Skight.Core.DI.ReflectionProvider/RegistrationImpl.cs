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
        private readonly Container container;

        public RegistrationImpl(IDictionary<Type, DiscreteItemResolver> resolvers)
        {
            item_resolvers = resolvers;
            container=new ContainerImpl(item_resolvers);
        }


        public void register(Type contract_type, Type implement_type)
        {
            if(!implement_type.is_inherited_from(contract_type))
                throw new ApplicationException(
                    $"Registering implement type {implement_type} is not inherited from contract type {contract_type}");
            register_resolver(contract_type, new RecursiveResolver(container,implement_type));
        }


        private void register_resolver(Type type, DiscreteItemResolver resolver)
        {
             if(item_resolvers.ContainsKey(type))
                 throw new ApplicationException($"Trying to register existed type {type}." );
             item_resolvers.Add(type, resolver);            
        }      
    }
}