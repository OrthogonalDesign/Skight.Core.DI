using Machine.Specifications;
using Skight.Core.DI;
using Skight.Core.DI.ReflectionProvider.Specs;

namespace TestShell.GenericClassCases
{
    public class When_register_generic_type_with_concrete_type : SetupContainer
    {
        private Because of = () =>
        {
            registration.register(typeof(GenericeType<int>), typeof(SpecifyType));
            registration.self_register(typeof(GenericeType<>));
        };

        private It container_get_concrete_type_should_get_success = () =>
            container.get<GenericeType<int>>()
                .ShouldBeOfExactType<SpecifyType>();

        private static object result;


        private class GenericeType<T> { }
        private class SpecifyType : GenericeType<int> { }
    }
}