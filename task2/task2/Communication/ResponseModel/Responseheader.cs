using System;
using System.Collections.Generic;
using System.Text;

namespace task2.Communication.ResponseModel
{
   public class Responseheader
    {
        public int responseCode { get; set; }
        public string responseMessage { get; set; }
        public string responseRemark { get; set; }
    }
}
