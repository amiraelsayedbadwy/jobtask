using System;
using System.Collections.Generic;
using System.Text;

namespace task2.Communication.ResponseModel
{
  public  class JobemployerModel
    {
        public int id { get; set; }
        public string fullAddress { get; set; }
        public string contactPerson { get; set; }
        public string contactMobile { get; set; }
        public string email { get; set; }
        public string companyName { get; set; }
        public string companyLogo { get; set; }
        public float latitude { get; set; }
        public float longitude { get; set; }
       
    }
}
