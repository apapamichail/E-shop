using System;
using System.Collections.Generic;
using System.Text;

namespace E_ShopImprovIT.core.Components
{
    public class CPU : Component
    {
        public CPU()
        {

        }

        public CPU(int cpuFreqInGHz)
        {
            this.FrequencyInGHz = cpuFreqInGHz;
        }

        public int FrequencyInGHz { get; private set; }

        public bool SetValue(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return false;
            }
            int freq;
            if(!int.TryParse(value, out freq))
            {
                return false;
            }

            this.FrequencyInGHz = freq;
            return true;
        }

        public string GetComponentDescription()
        {
            if (FrequencyInGHz <= 0)
            {
                return "CPU Frequency is not setted";
            }

            return "The CPU frequency is " + FrequencyInGHz + " GHz";
        }

        public bool IsValueValid()
        {
            if (FrequencyInGHz <= 0)
            {
                return false;
            }
            return true;
        }
    }
}
