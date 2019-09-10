using System;
using System.Collections.Generic;
using System.Text;

namespace E_ShopImprovIT.core.Components
{
    public class ComponentFactory
    {
        public  Component CreateComponent(String componentType)
        {
            if (String.IsNullOrEmpty(componentType))
            {
                return null;
            }

            if(componentType.Equals("CPU"))
            {
                return new CPU();
            }
            else if( componentType.Equals("MemoryRam"))
            {
                return new MemoryRam();
            }
            else if( componentType.Equals("HardDrive"))
            {
                return new HardDrive();
            }
            else if(componentType.Equals("Software"))
            {
                return new Software();
            }
            return null;
        }
    }
}
