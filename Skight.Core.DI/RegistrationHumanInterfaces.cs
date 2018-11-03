using System;
using System.Diagnostics.Contracts;
using Microsoft.AspNetCore.Authentication;

namespace Skight.Core.DI
{
    public static class RegistrationHumanInterfaces
    {
        public static void register<Contract>(
            this Registration registration, Func<Contract> func)
        {
            registration.register(
                typeof(Contract), 
                new FuncResolver(() => func()));
        }
        
        public static void register<Contract, Implementation>(
            this Registration registration)
            where Implementation : Contract 
        {
            registration.register(typeof(Contract), typeof(Implementation));
        }

        public static void self_register<T>(
            this Registration registration)
        {
            registration.register<T,T>();
        }
        
        public static void self_register(
            this Registration registration,
            Type type)
        {
            registration.register(type, type);
        }
    }
}