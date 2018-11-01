using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Skight.BuildBlocks.BasicTypeExtensions;

namespace Skight.Core.DI.ReflectionProvider
{
    public class TypeResolver : DiscreteItemResolver
    {
        private readonly ConstructorResolver constructor_resolver;
        private readonly Type type;

        public TypeResolver(
            ConstructorResolver constructor_resolver, 
            Type type)
        {
            this.constructor_resolver = constructor_resolver;
            this.type = type;
        }

        public object resolve()
        {
            return constructor_resolver.resolve(type);
        }
    }
}