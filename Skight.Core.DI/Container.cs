using System;
using System.Collections.Generic;
using System.Text;

namespace Skight.Core.Container
{
    public interface Container
    {
        IEnumerable<Dependency> get_all<Dependency>();
        IEnumerable<object> get_all(Type dependency);
        Dependency get_an<Dependency>();
        object get_an(Type dependency);
        bool has(Type dependency);

        T resolve<T>();
    }
}
