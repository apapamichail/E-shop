using System;
using System.Collections.Generic;
using System.Text;

namespace E_ShopImprovIT.core.Components
{
    public class SoftwareTypes
    {
        public Dictionary<string, string> Types { get; private set; } =
            new Dictionary<string, string>(){
                { "WINDOWS","Windows" },
                { "LINUX","Linux" }
            };

        public string GetSoftware(string softwareType)
        {
            string software;

            if (Types.TryGetValue(softwareType.ToUpper(), out software))
            {
                return software;
            }
            else
            {
                return String.Empty;
            }
        }
    }
}




