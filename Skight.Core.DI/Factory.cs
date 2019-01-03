using System;
using System.Collections.Generic;
using System.Text;

namespace Skight.Core.DI
{
    interface Factory<T>
    {
        T create();
    }
}
