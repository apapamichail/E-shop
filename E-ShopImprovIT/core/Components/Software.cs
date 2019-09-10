namespace E_ShopImprovIT.core.Components
{
    public class Software : Component
    {
        private SoftwareTypes SoftwareTypes = new SoftwareTypes();

        public string SoftwareType { get; private set; }
        
        public string GetComponentDescription()
        {
            if (string.IsNullOrEmpty(SoftwareType))
            {
                return "Software is no setted";
            }
            return "The software type is : "+SoftwareType;
        }

        public bool IsValueValid()
        {
            if (string.IsNullOrEmpty(SoftwareType))
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
            string software = SoftwareTypes.GetSoftware(value);

            if (string.IsNullOrEmpty(software))
            {
                return false;
            }
            this.SoftwareType = software;
            return true;

        }
    }
}