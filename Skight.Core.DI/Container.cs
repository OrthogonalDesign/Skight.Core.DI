using System;
using System.Collections.Generic;
using System.Text;

namespace Skight.Core.DI
{
    public interface Container
    {
        object get(Type type);
    }
}
