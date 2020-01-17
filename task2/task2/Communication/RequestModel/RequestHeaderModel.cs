using System;
using System.Collections.Generic;
using System.Text;

namespace task2.Communication.RequestModel
{
   public  class RequestHeaderModel
    {

        public int userId { get; set; }
        public int userType { get; set; }
        public string deviceSerial { get; set; }
        public int appLanguage { get; set; }
        public int countryId { get; set; }
        public int deviceType { get; set; }
        public bool isWeb { get; set; }
        public int currencyId { get; set; }
        public string osversion { get; set; }
        public string ip { get; set; }
        public string appversion { get; set; }
    }
}
