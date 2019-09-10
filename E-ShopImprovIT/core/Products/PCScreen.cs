using System;
using System.Collections.Generic;
using System.Text;

namespace E_ShopImprovIT.core
{
    public class PCScreen : Product
    {
        public double ScreenSizeInInches { get; private set; }

        public PCScreen(int screenSizeInInches)
        {
            ScreenSizeInInches = screenSizeInInches;

        }

        public PCScreen()
        {
        }

        public string GetProductDescription()
        {
            if (ScreenSizeInInches <= 0)
            {
                return "Screen size is not setted";
            }
            else
            {
                return "The size of the screen is : " + ScreenSizeInInches + " inches";
            }
        }

        public bool IsValidProduct()
        {
            if (ScreenSizeInInches <= 0)
            {
                return false;
            }
            return true;
        }

        internal bool SetScreenSize(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return false;
            }
            int size;
            if (!int.TryParse(value, out size))
            {
                return false;
            }

            this.ScreenSizeInInches = size;
            return true;
        }
    }
}
