using E_ShopImprovIT.core.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_ShopImprovIT.core
{
    public class PersonalComputer : Product
    {
        public PCTower PCTower { get; private set; }
        public PCScreen PCScreen { get; private set; }
        public HardDrive HardDrive { get; private set; }

        public PersonalComputer(PCTower pcTower, PCScreen pcScreen, HardDrive hardDrive)
        {
            PCTower = pcTower;
            PCScreen = pcScreen;
            HardDrive = hardDrive;
        }

        public PersonalComputer()
        {
        }

        public string GetProductDescription()
        {
            return PCTower.GetProductDescription() +"\n"+
                    PCScreen.GetProductDescription() + "\n" +
                    HardDrive.GetComponentDescription();

        }

        public bool IsValidProduct()
        {
            if (IsAnyObjectNull())
            {
                return false;
            }
            return true;
        }

        private bool IsAnyObjectNull()
        {
            return PCTower == null || PCScreen == null || HardDrive == null;
        }

        public bool SetScreen(PCScreen pcScreen)
        {
            PCScreen = pcScreen;
            return true;
        }

        public bool SetPCTower(PCTower pcTower)
        {
            PCTower = pcTower;
            return true;
            
        }

        public bool SetHardDrive(HardDrive hardDrive)
        {
            HardDrive = hardDrive;
            return true;
        }
    }
}
