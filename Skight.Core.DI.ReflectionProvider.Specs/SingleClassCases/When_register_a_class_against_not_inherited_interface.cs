using System;
using Machine.Specifications;

namespace Skight.Core.DI.ReflectionProvider.Specs
{
    public class When_register_a_class_against_not_inherited_interface : SetupContainer
    {
        Because of = ()=> exception = Catch.Exception(() =>
            registration.register(typeof(DumbInterface), typeof(DumbClass)));
        
        private It should_throw_exception = () => exception.ShouldBeAssignableTo<ApplicationException>();    
        
        private static Exception exception;
        private class DumbClass{}
        private class DumbInterface {}
        
        
    }
}