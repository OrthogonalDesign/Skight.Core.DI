using System;
using System.Collections.Generic;
using System.Text;
using Machine.Specifications;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Skight.Core.DI.ReflectionProvider.Specs.ResolveFromFactoryCases
{
    class When_registered_interface_implementation_and_its_factory : SetupContainer
    {
        private Establish context = () =>
        {
            registration.register<ExampleInterface, ExampleImpl>();
            registration.register<Factory<ExampleInterface>, ExampleFactory>();
        };

        private Because of = () => result = container.get<ExampleInterface>();

        private It should_get_implemented_class = () =>
            result.ShouldBeOfExactType<ExampleImpl>();

        private static ExampleInterface result;

        interface ExampleInterface
        {

        }

        class ExampleImpl : ExampleInterface
        {

        }
        class ExampleFactory : Factory<ExampleInterface>
        {
            public ExampleInterface create()
            {
                return new FactoryExampleImpl();
            }

            public class FactoryExampleImpl : ExampleInterface
            {
            }
        }
    }
}
