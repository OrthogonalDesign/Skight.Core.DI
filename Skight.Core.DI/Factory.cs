using System;
using System.Collections.Generic;
using System.Text;

namespace Skight.Core.DI
{
    public interface Factory<T>
    {
        T create();
    }
}
