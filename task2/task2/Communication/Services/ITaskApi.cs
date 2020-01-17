using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using task2.Communication.RequestModel;
using task2.Communication.ResponseModel;

namespace task2.Communication.Services
{
    public interface ITaskApi
    {
        [Post("/JobVacancy/GetAvailableJob")]
        Task <JobEmployerModelResponse>JobVacancy([Body] PageSourceModel user);
    }
}
