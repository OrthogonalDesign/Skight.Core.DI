using System;

namespace Skight.Core.DI
{
    public interface Registration
    {
        void register<Contract, Implementation>() where Implementation : Contract;
    }
}