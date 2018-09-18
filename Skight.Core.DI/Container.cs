using System;
using System.Collections.Generic;

namespace Skight.Core.Container
{
    public class Container
    {
        private static IContainer underlying_resolver;

        public static IContainer current
        {
            get { return underlying_resolver; }
        }

        public static void initialize_with(IContainer resolver)
        {
            underlying_resolver = resolver;
        }

        public static T get<T>()
        {
            return underlying_resolver.get_an<T>();
        }
    }
}
