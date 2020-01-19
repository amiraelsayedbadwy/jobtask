using Refit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using task2.Communication.RequestModel;
using task2.Communication.ResponseModel;
using task2.Communication.Services;
using task2.Models;
using Xamarin.Forms;
using Xamarin.Forms.Extended;

namespace task2.ViewModels
{
    public class TaskPageModel : BaseEntity
    {
        public string textSearch { get; set; }
        public ICommand PerformSearch { get; set; }
        
        public string SearchText { get; set; }
        private bool _nodata;
        public bool Nodata
        {
            get
            {
                return _nodata;
            }
            set
            {
                _nodata = value;
                OnPropertyChanged("Nodata");
                  
            }
        }
        private bool _show;
        public bool showlist
        {
            get
            {
                return _show;
            }
            set
            {
                _show = value;
                OnPropertyChanged("showlist");

            }
        }
        public bool thereisnodata { get; set; }
        public ICommand RefreshCommand { get; }
        public bool canLoadMore { get; set; }
        public bool IsLoadingIndicator { get; set; }
        public int pagenumber { get; set; }
        public InfiniteScrollCollection<JobEmployerDataModel> JobsList { get; set; }
        public ObservableCollection<JobEmployerDataModel> GetJobList { get; set; }
        public ObservableCollection<JobEmployerDataModel> TempjobList { get; set; }
        public TaskPageModel()
        {
            canLoadMore = true;
            PerformSearch = new Command(PerformSearchExcute);
            JobsList = new InfiniteScrollCollection<JobEmployerDataModel>();
            GetJobList = new ObservableCollection<JobEmployerDataModel>();
            TempjobList = new ObservableCollection<JobEmployerDataModel>();
            showlist = true;
            thereisnodata = false;
            Device.BeginInvokeOnMainThread(async () =>
            {
               
               
                await GetInfintyData(pagenumber);
            });
        }

        private void PerformSearchExcute()
        {

            if (string.IsNullOrEmpty(SearchText))
            {
                JobsList = new InfiniteScrollCollection<JobEmployerDataModel>(TempjobList);
            }
            else
            {
                JobsList = new InfiniteScrollCollection<JobEmployerDataModel>(TempjobList);
                List<JobEmployerDataModel> result = JobsList.Where(x => !string.IsNullOrEmpty(x.companyName) && x.companyName.ToLower().Contains(SearchText.ToLower())).ToList();
                if (result.Count > 0)
                {
                    showlist = true;
                    thereisnodata = false;
                    JobsList = new InfiniteScrollCollection<JobEmployerDataModel>(result);
                   
                }
                else
                {
                    showlist = false;
                    thereisnodata = true;

                }
            }


        }

        public void OnSearchTextChanged()
        {
            if (string.IsNullOrEmpty(SearchText))
            {
                JobsList=new InfiniteScrollCollection<JobEmployerDataModel>(TempjobList);
            }
            else
            {
                JobsList = new InfiniteScrollCollection<JobEmployerDataModel>(TempjobList);
                List<JobEmployerDataModel> result = JobsList.Where(x => !string.IsNullOrEmpty(x.companyName) && x.companyName.ToLower().Contains(SearchText.ToLower())).ToList();
                if (result.Count>0)
                    JobsList = new InfiniteScrollCollection < JobEmployerDataModel >( result);
                else
                {
                    showlist = false;
                    thereisnodata = true;

                }
            }
        }
        public async Task<ObservableCollection<JobEmployerDataModel>> GetData(int pagenumber)
        {
            GetJobList = new ObservableCollection<JobEmployerDataModel>();
            PageSourceModel data = new PageSourceModel
            {
                pageSource = 1,
                jobVacancyIndustry = new List<string>(),
                keyword = "",
                jobVacancyPreferredDegree = new List<string>(),
                jobVacancyCarrerLevels = new List<string>(),
                jobVacancyLocation = new List<string>(),
                jobVacancySkills = new List<string>(),
                pagging = pagenumber,
                yearExperienceTo = 0,
                id = 0,
                yearExperienceFrom = 0,
                jobVacancyPreferredNatinality = new List<string>(),
                employmentTypeId = 0,
                salaryFrom = 0,
                lastRow = 0,
                jobVacancyPreferredLanguage = new List<string>(),
                paging = 0,
                salaryTo = 0,
                employeerId = 0,
                requestHeader = new RequestHeaderModel
                {
                    userId = 150,
                    userType = 1,
                    deviceSerial = "zatona",
                    appLanguage = 1,
                    countryId = 1,
                    deviceType = 1,
                    isWeb = false,
                    currencyId = 0,
                    osversion = "13.3",
                    ip = "",
                    appversion = "1.0"
                }

            };
            var Response = RestService.For<ITaskApi>("http://108.60.209.97/JobShop/api");

            var result = await Response.JobVacancy(data);
            if (result.data.Count > 0)
            {
                foreach (var item in result.data)
                {

                    GetJobList.Add(new JobEmployerDataModel
                    {

                        id = item.id,
                        createdDate = item.createdDate,
                        contactPerson = item.jobEmployer.contactPerson,
                        companyLogo = item.jobEmployer.companyLogo,
                        companyName = item.jobEmployer.companyName,
                        fullAddress = item.jobEmployer.fullAddress,
                        isFavourite = item.isFavorit,

                    });

                }
                TempjobList = GetJobList;
            }
            return GetJobList;

        }
        public async Task GetInfintyData(int pagenumber)
        {
            try
            {
               // IsBusy = true;

                if (JobsList.Count == 0)
                {
                    pagenumber = 0;
                    var newresult = await GetData(pagenumber);
                    //JobsList = new InfiniteScrollCollection<JobEmployerDataModel>(newresult);

                    foreach (var item in newresult)
                    {
                        JobsList.Add(item);
                    }
                }
                JobsList.OnLoadMore = async () =>
                {
                    IsLoadingIndicator = true;
                    pagenumber += 5;
                    var list = await GetData(pagenumber);

                 

                    IsLoadingIndicator = false;

                    return list;
                };
               




            }
            catch (Exception e)
            {
                throw e;
            }
            
        }
    }
}
