using System.Collections.Generic;
using System.Linq;
using WorkNotes.Business.Interfaces;
using WorkNotes.Common;
using WorkNotes.Core;
using WorkNotes.DataAccess.Interfaces;
using WorkNotes.Entities;
using WorkNotes.Models.RequestModel;

namespace WorkNotes.Business.Services
{
    public class ApplicationService : IApplicationService
    {
        public Application Create(AddApplicationRequestModel model)
        {
            var app = AppServiceProvider.Instance.Get<IApplicationDataAccess>().FilterBy(x => x.Name == model.Name.SafeTrim() && x.IsDbMigration.Equals(model.IsDbMigration)).FirstOrDefault();

            if (app != null)
            {
                return app;
            }

            Application newApp = new()
            {
                IsDbMigration = model.IsDbMigration,
                Name = model.Name.SafeTrim()
            };

            return AppServiceProvider.Instance.Get<IApplicationDataAccess>().InsertOne(newApp);
        }

        public void Delete(string id)
        {
            AppServiceProvider.Instance.Get<IApplicationDataAccess>().DeleteById(id);
        }

        public List<Application> GetAll()
        {
            return AppServiceProvider.Instance.Get<IApplicationDataAccess>().GetAll();
        }
    }
}
