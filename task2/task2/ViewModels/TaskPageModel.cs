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
    public class TaskPageModel : FreshMvvm.FreshBasePageModel
    {
        private string _searchText;
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;
                OnSearchTextChanged(_searchText);
                RaisePropertyChanged("SearchText");
            }
        }
        public ICommand RefreshCommand { get; }
        public bool canLoadMore { get; set; }
        public bool IsLoadingIndicator { get; set; }
        public bool IsBusy { get; set; }
        public int pagenumber { get; set; }
        public InfiniteScrollCollection<JobEmployerDataModel> JobsList { get; set; }
        public ObservableCollection<JobEmployerDataModel> GetJobList { get; set; }
        public ObservableCollection<JobEmployerDataModel> TempjobList { get; set; }
        public TaskPageModel()
        {
            canLoadMore = true;
            JobsList = new InfiniteScrollCollection<JobEmployerDataModel>();
            GetJobList = new ObservableCollection<JobEmployerDataModel>();
            TempjobList = new ObservableCollection<JobEmployerDataModel>();
            Device.BeginInvokeOnMainThread(async () =>
            {
                await GetInfintyData(pagenumber);
            });
        }
        public void OnSearchTextChanged(string text)
        {

            if (string.IsNullOrEmpty(SearchText) || string.IsNullOrWhiteSpace(SearchText))
            {
                if (TempjobList.Count > 0)
                {
                    JobsList = new InfiniteScrollCollection<JobEmployerDataModel>(TempjobList);
                }

                //selecetedid = 0;


            }
            else
            {
                if (JobsList.Count > 0)
                {
                    JobsList = new InfiniteScrollCollection<JobEmployerDataModel>(TempjobList);
                    var data = JobsList.Where(x => !string.IsNullOrEmpty(x.companyName) && x.companyName.ToLower().Contains(SearchText.ToLower())).ToList();
                    InfiniteScrollCollection<JobEmployerDataModel> result = new InfiniteScrollCollection<JobEmployerDataModel>(data);
                    if (result != null)
                    {
                        try
                        {
                            JobsList = new InfiniteScrollCollection<JobEmployerDataModel>(result);

                        }
                        catch (Exception exception)
                        {
                            // isBusy = false;
                            throw exception;

                        }

                    }

                }
            }
        }
        public async Task<ObservableCollection<JobEmployerDataModel>> GetData(int pagenumber)
        {
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

            return GetJobList;

        }
        public async Task GetInfintyData(int pagenumber)
        {
            try
            {
                IsBusy = true;

                if (JobsList.Count == 0)
                {
                    pagenumber = 0;
                    var newresult = await GetData(pagenumber);
                    JobsList.AddRange(newresult);
                }
                JobsList.OnLoadMore = async () =>
                {
                    IsLoadingIndicator = true;
                    pagenumber = 5;
                    var list = await GetData(pagenumber);

                    canLoadMore = list.Count() != 0 ? true : false;

                    IsLoadingIndicator = false;

                    return list;
                };
                JobsList.OnCanLoadMore = () => JobsList.Count<=15;




            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
