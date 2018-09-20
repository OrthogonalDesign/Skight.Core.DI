using System;
using System.Collections.Generic;
using System.Threading;
using Machine.Specifications;
using Skight.Core.DI;
using Skight.Core.DI.ReflectionProvider;

namespace Skight.Core.DI.ReflectionProvider.Specs
{
    public class RegisterClassSpecs
    {
       

        private Establish context = () =>
        {
            var resolvers = new Dictionary<Type, DiscreteItemResolver>();
            registration = new RegistrationImpl(resolvers);
            container =new ContainerImpl(resolvers);
        };
        
        Because of = ()=>  registration.register<DumbInterface, DumbClass>();
        
        private It should = () => container.get<DumbInterface>().ShouldBeOfExactType<DumbClass>();
        
        private static Registration registration;
        private static Container container;

        private interface DumbInterface{}
        private class DumbClass :DumbInterface {}
    }
}