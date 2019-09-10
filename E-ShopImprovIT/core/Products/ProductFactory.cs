using System;
using System.Collections.Generic;
using System.Text;

namespace E_ShopImprovIT.core.Components
{
    public class ProductFactory
    {
        public  Product CreateProduct(String productType)
        {
            if (String.IsNullOrEmpty(productType))
            {
                return null;
            }

            if(productType.Equals("PCScreen"))
            {
                return new PCScreen();
            }
            else if( productType.Equals("PCTower"))
            {
                return new PCTower();
            }
            else if( productType.Equals("PersonalComputer"))
            {
                return new PersonalComputer();
            }
            else if(productType.Equals("Workstation"))
            {
                return new Workstation();
            }
            return null;
        }
    }
}
