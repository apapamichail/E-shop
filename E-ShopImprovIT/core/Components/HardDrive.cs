using System;
using System.Collections.Generic;
using System.Text;

namespace E_ShopImprovIT.core.Components
{
    public class HardDrive : Component
    {
        public double SizeInGB { get; private set; }

        public string GetComponentDescription()
        {
            if (SizeInGB > 0)
            {
                return "The Hard Drive size is " + SizeInGB + " GB";
            }
            else
            {
                return "Hard Drive size is not setted";
            }
        }

        public bool IsValueValid()
        {
            if (SizeInGB <= 0)
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

            this.SizeInGB = gb;
            return true;

        }
    }
}
