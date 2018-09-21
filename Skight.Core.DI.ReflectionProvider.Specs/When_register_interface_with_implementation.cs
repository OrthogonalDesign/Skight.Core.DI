using System;
using System.Threading;
using Machine.Specifications;
using Skight.Core.DI;
using Skight.Core.DI.ReflectionProvider;

namespace Skight.Core.DI.ReflectionProvider.Specs
{
    /// <summary>
    /// 使用注册器注册一个类到他的接口时，从容器通过接口就可以取到该类的实例
    /// </summary>
    public class When_register_interface_with_implementation : SetupContainer
    {
        Because of = ()=>  registration.register<DumbInterface, DumbClass>();
        
        private It should = () => container.get<DumbInterface>().ShouldBeOfExactType<DumbClass>();

        private interface DumbInterface{}
        private class DumbClass :DumbInterface {}
    }

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