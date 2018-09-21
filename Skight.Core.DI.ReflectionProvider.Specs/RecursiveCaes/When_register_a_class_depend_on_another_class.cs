using Machine.Specifications;

namespace Skight.Core.DI.ReflectionProvider.Specs
{
    public class When_register_a_class_depend_on_another_class : SetupContainer
    {
        private Establish context = () =>
        {
            registration.self_register<Service>();
            registration.self_register<DumbClass>();
        };

        private Because of = () => resolved_object= container.get<DumbClass>();

        It should_throw_exception = () => resolved_object.Service.ShouldNotBeNull();
        
        private static DumbClass resolved_object;

        class Service {}

        class DumbClass
        {
            public DumbClass(Service service)
            {
                Service = service;                
            }
            public Service Service { get; set; }
        }
    }
}