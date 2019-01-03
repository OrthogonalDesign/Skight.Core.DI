using System;
using System.Collections.Generic;
using System.Text;
using Machine.Specifications;

namespace Skight.Core.DI.ReflectionProvider.Specs.ResolveFromFactoryCases
{
    public class When_registered_factory_implementation :SetupContainer
    {
        private Establish context = () =>
            registration.register<Factory<ExampleInterface>, ExampleFactory>();

        private Because of = () => result = container.get<ExampleInterface>();

        private It should_get_implemented_class = () =>
            result.ShouldBeOfExactType<ExampleFactory.FactoryExampleImpl>();

        private static ExampleInterface result;

        public interface ExampleInterface
        {

        }

        public class ExampleFactory : Factory<ExampleInterface>
        {
            public ExampleInterface create()
            {
                return  new FactoryExampleImpl();
            }

            public class FactoryExampleImpl : ExampleInterface
            {
            }
        }
    }
}
