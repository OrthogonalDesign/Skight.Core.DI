using System;

namespace Skight.Core.DI
{
    public interface Registration
    {
        void register_dependency<Dependency>(Func<object> factory);
        void register_dependency<Dependency>() where Dependency : new();
        void register_dependency<Contract, Implementation>() where Implementation : Contract, new();
        //void register_explicitly(DiscreteItemResolver resolver, params Type[] keys);
        void register(Type type);
        void register_singleton(Type type);
        void register_singleton(Type contract_type, Type implementation_type);
        void register_singleton<Contract, Implementation>() where Implementation : Contract, new();
        void replace_dependency<Dependency>(Func<object> factory );
    }
}