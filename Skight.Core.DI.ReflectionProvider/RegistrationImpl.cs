using System;
using System.Collections.Generic;
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


        public void register<Contract, Implementation>() where Implementation : Contract
        {
            register_resolver(typeof (Contract), new RecursiveResolver(container,typeof(Implementation)));
        }


        private void register_resolver(Type type, DiscreteItemResolver resolver)
        {
             if(item_resolvers.ContainsKey(type))
                 throw new ApplicationException($"Trying to register existed type {type}." );
             item_resolvers.Add(type, resolver);            
        }      
    }
}