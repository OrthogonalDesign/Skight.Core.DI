using System.Diagnostics.Contracts;

namespace Skight.Core.DI
{
    public static class RegistrationHumanInterfaces
    {
        public static void register<Contract, Implementation>(
            this Registration registration)
            where Implementation : Contract 
        {
            registration.register(typeof(Contract), typeof(Implementation));
        }
    }
}