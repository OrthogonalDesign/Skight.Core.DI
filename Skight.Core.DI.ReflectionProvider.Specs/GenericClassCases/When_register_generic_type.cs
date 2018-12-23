using Machine.Specifications;
using Skight.Core.DI;
using Skight.Core.DI.ReflectionProvider.Specs;

namespace TestShell.GenericClassCases
{
    public class When_register_generic_type :SetupContainer
    {
        private Because of = () => 
            registration.self_register(typeof(GenericeType<>));

        private It container_get_concrete_type_should_get_success = () =>
            container.get<GenericeType<int>>()
                .ShouldNotBeOfExactType <GenericeType<int>>();
        
        
        private class GenericeType<T>{}
    }
}