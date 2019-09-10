using System;
using System.Collections.Generic;
using System.Text;

namespace E_ShopImprovIT.core.Components
{
    public class MemoryRam : Component
    {

        public MemoryRam()
        {

        }

        public MemoryRam(double memorySizeInGB)
        {
            this.MemorySizeInGB = memorySizeInGB;
        }

        public double MemorySizeInGB { get; private set; }

        public string GetComponentDescription()
        {
            if (MemorySizeInGB > 0)
            {
                return "The Memory Ram size is " + MemorySizeInGB + " GB";
            }
            else
            {
                return "Memory Ram size is not setted";
            }
        }

        public bool IsValueValid()
        {
            if (MemorySizeInGB <= 0)
            {
                return false;
            }
            return true;
        }

        public bool SetValue(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return false;
            }
            int gb;
            if (!int.TryParse(value, out gb))
            {
                return false;
            }

            this.MemorySizeInGB = gb;
            return true;
        }


    }
}
