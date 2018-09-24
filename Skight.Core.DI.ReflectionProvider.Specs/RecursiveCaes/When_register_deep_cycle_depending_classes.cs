using System;
using Machine.Specifications;

namespace Skight.Core.DI.ReflectionProvider.Specs
{
    public class When_register_deep_cycle_depending_classes : SetupContainer
    {
        private Establish context = () =>
        {
            registration.self_register<ClassA>();
            registration.self_register<ClassB>();
            registration.self_register<ClassC>();
        };

        private Because of = () => exception = Catch.Exception(() =>container.get<ClassA>());

        It should = () => exception.ShouldBeAssignableTo<ApplicationException>();
               
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
            public ClassC(ClassA a)
            {
                
            }
        }
    }
}