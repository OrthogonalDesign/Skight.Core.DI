using System;

namespace Skight.Core.DI
{
    public interface Registration
    {
        void register(Type contract_type, Type implement_type);
    }
}