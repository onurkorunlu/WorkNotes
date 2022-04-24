using System.Collections.Generic;
using WorkNotes.Business.Interfaces;
using WorkNotes.Core;
using WorkNotes.DataAccess.Interfaces;
using WorkNotes.Entities;

namespace WorkNotes.Business.Services
{
    public class ApplicationService : IApplicationService
    {
        public List<Application> GetAll()
        {
            return AppServiceProvider.Instance.Get<IApplicationDataAccess>().GetAll();
        }
    }
}
