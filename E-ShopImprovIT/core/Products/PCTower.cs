using E_ShopImprovIT.core.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_ShopImprovIT.core
{
    public class PCTower : Product
    {
        public CPU CPU { get; private set; }
        public MemoryRam MemoryRam { get; private set; }
        public PCTower(CPU cpu, MemoryRam memoryRam)
        {
            CPU = cpu;
            MemoryRam = MemoryRam;

        }

        public PCTower()
        {
        }

        public string GetProductDescription()
        {
            return CPU.GetComponentDescription() +"\n"+ MemoryRam.GetComponentDescription();
        }

        public bool IsValidProduct()
        {
            if(CPU==null || MemoryRam == null)
            {
                return false;
            }

            if (!CPU.IsValueValid() || !MemoryRam.IsValueValid())
            {
                return false;
            }
            return true;
        }

        internal bool SetMemoryRam(MemoryRam memoryRam)
        {
            MemoryRam = memoryRam;
            return true;
        }

        internal bool SetCPU(CPU cpu)
        {
            CPU = cpu;
            return true;
        }
    }
}
