using System;
using System.Collections.Generic;
using System.Text;

namespace task2.Communication.ResponseModel
{
   
    public class JobEmployerModelResponse
    {
        public List<Datum> data { get; set; }
        public Responseheader responseHeader { get; set; }
    }

    public class Datum
    {
        public int id { get; set; }
        public string reference { get; set; }
        public string jobTitle { get; set; }
        public string description { get; set; }
        public DateTime createdDate { get; set; }
        public int pagging { get; set; }
        public bool isConfidential { get; set; }
        public int preferredAgeFrom { get; set; }
        public int noOfEmployee { get; set; }
        public int preferredAgeTo { get; set; }
        public int yearExperienceFrom { get; set; }
        public int yearExperienceTo { get; set; }
        public float salaryFrom { get; set; }
        public float salaryTo { get; set; }
        public string additionalSalaryDetails { get; set; }
        public object requirement { get; set; }
        public string emails { get; set; }
        public object shareMessage { get; set; }
        public bool hideCompanyProfile { get; set; }
        public bool isFollow { get; set; }
        public bool isFavorit { get; set; }
        public bool hasQuestion { get; set; }
        public Salarytype salaryType { get; set; }
        public Employmenttype employmentType { get; set; }
        public JobemployerModel jobEmployer { get; set; }
        public object[] preferredDegree { get; set; }
        public object[] preferredCountry { get; set; }
        public object[] preferredNationality { get; set; }
        public object[] preferredGender { get; set; }
        public object[] preferredMiliteryStatus { get; set; }
        public object[] preferredLanguage { get; set; }
        public object[] preferredVisaStatus { get; set; }
        public Skill[] skills { get; set; }
        public Jobindustry[] jobIndustry { get; set; }
        public object[] preferredcarrerLevel { get; set; }
    }

    public class Salarytype
    {
        public int id { get; set; }
        public string name { get; set; }
        public int jobvacancycount { get; set; }
        public object image { get; set; }
    }

    public class Employmenttype
    {
        public int id { get; set; }
        public string name { get; set; }
        public int jobvacancycount { get; set; }
        public object image { get; set; }
    }

   

    public class Skill
    {
        public int id { get; set; }
        public string name { get; set; }
        public int jobvacancycount { get; set; }
        public object image { get; set; }
    }

    public class Jobindustry
    {
        public int id { get; set; }
        public string name { get; set; }
        public int jobvacancycount { get; set; }
        public object image { get; set; }
    }

}
