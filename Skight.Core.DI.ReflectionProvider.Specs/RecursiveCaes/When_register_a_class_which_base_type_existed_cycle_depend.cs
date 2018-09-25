using System;
using Machine.Specifications;

namespace Skight.Core.DI.ReflectionProvider.Specs
{
    public class When_register_a_class_which_base_type_existed_cycle_depend : SetupContainer
    {
        private Establish that = () =>
        {
            registration.self_register<ClassA>();
            registration.self_register<ClassB>();
            registration.self_register<ClassC>();
        };

        private Because of = () => exception = Catch.Exception(() =>container.get<ClassA>());

        private It should = () => exception.ShouldBeAssignableTo<ApplicationException>();
        private static Exception exception;

        class ClassA
        {
            public ClassA(ClassB b)
            {
                
            }
        }

        class ClassB
        {
            public ClassB(ClassC c)
            {
                
            }
        }

        class ClassC
        {
            public ClassC(ClassB b)
            {
                
            }
        }
    }
}