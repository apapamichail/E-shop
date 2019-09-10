using System;
using System.Collections.Generic;
using System.Text;

namespace E_ShopImprovIT.core.Components
{
    public interface Component
    {
        string GetComponentDescription();
        bool SetValue(string value);
        bool IsValueValid();
    }
}
