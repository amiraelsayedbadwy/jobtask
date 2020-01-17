using System;
using System.Collections.Generic;
using System.Text;

namespace task2.Communication.RequestModel
{
 
    public class PageSourceModel
    {
        public int pageSource { get; set; }
        public List<string> jobVacancyIndustry { get; set; }
        public string keyword { get; set; }
        public List<string> jobVacancyPreferredDegree { get; set; }
        public List<string> jobVacancyCarrerLevels { get; set; }
        public List<string> jobVacancyLocation { get; set; }
        public List<string> jobVacancySkills { get; set; }
        public int pagging { get; set; }
        public int yearExperienceTo { get; set; }
        public int id { get; set; }
        public int yearExperienceFrom { get; set; }
        public List<string> jobVacancyPreferredNatinality { get; set; }
        public int employmentTypeId { get; set; }
        public int salaryFrom { get; set; }
        public int lastRow { get; set; }
        public List<string> jobVacancyPreferredLanguage { get; set; }
        public int paging { get; set; }
        public int salaryTo { get; set; }
        public int employeerId { get; set; }
        public RequestHeaderModel requestHeader { get; set; }
    }


}
