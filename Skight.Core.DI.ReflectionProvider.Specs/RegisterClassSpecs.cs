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
        protected interface mockInterface{}
        protected class mockClass :mockInterface {}

        private Establish context = () =>
        {
            var resolvers = new Dictionary<Type, DiscreteItemResolver>();
            registration = new RegistrationImpl(resolvers);
            container =new ContainerImpl(resolvers);
        };
        
        Because of = ()=>  registration.register<mockInterface, mockClass>();
        
        private It should = () => container.get<mockInterface>().ShouldBeOfExactType<mockClass>();
        
        private static RegistrationImpl registration;
        private static ContainerImpl container;
    }
}