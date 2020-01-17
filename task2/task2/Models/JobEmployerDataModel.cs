using System;
using System.Collections.Generic;
using System.Text;

namespace task2.Models
{
  public  class JobEmployerDataModel
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
        public bool isFavourite { get; set; }
        public bool ishare { get; set; }
        public DateTime createdDate { get; set; }
    }
}
