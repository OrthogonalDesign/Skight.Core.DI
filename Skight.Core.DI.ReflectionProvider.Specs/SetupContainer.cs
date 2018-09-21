using System;
using System.Collections.Generic;
using Machine.Specifications;

namespace Skight.Core.DI.ReflectionProvider.Specs
{
    /// <summary>
    /// 搭建基本测试环境
    /// * 构建注册对象
    /// * 构建容器对象
    /// * 类解析器字典集合作为注册对象和容器对象的共享的数据
    /// </summary>
    public class SetupContainer
    {
        private Establish context = () =>
        {
            var resolvers = new Dictionary<Type, DiscreteItemResolver>();
            registration = new RegistrationImpl(resolvers);
            container =new ContainerImpl(resolvers);
        };

        protected static Registration registration;
        protected static Container container;
    }
}