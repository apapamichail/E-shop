using E_ShopImprovIT.core.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_ShopImprovIT.core
{
    public class Workstation : Product
    {

        public PersonalComputer PersonalComputer { get; private set; }
        public Software Software { get; private set; }

        public Workstation(PersonalComputer personalComputer, Software software)
        {
            PersonalComputer = PersonalComputer;
            Software = Software;

        }

        public Workstation()
        {

        }

        public bool SetPersonalComputer(PersonalComputer personalComputer)
        {
            PersonalComputer = personalComputer;
            return true;
        }

        public bool SetSoftware(Software software)
        {
            Software = software;
            return true;
        }
        public string GetProductDescription()
        {
            return PersonalComputer.GetProductDescription() + "\n" + Software.GetComponentDescription();
        }

        public bool IsValidProduct()
        {

            if(!PersonalComputer.IsValidProduct() || !Software.IsValueValid())
            {
                return false;
            }

            return true;

        }
    }
}
