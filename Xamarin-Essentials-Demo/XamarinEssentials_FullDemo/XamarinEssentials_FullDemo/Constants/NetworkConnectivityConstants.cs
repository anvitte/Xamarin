using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinEssentials_FullDemo.Constants
{
    public static class NetworkConnectivityConstants
    {
        public const string Internet = "Local and internet access";
        public const string ConstrainedInternet  = "Limited internet access. Indicates captive portal connectivity, where local access to a web portal is provided, but access to the Internet requires that specific credentials are provided via a portal.";
        public const string Local = "Local and internet access";
        public const string None = " No connectivity is available";
        public const string Unknown = "Unable to determine internet connectivity";
 
    }
}
