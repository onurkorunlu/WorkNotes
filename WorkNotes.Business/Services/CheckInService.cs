using MongoDB.Bson;
using WorkNotes.Business.Interfaces;
using WorkNotes.Core;
using WorkNotes.DataAccess.Interfaces;
using WorkNotes.Entities;

namespace WorkNotes.Business.Services
{
    public class CheckInService : ICheckInService
    {
        public void Create(CheckIn checkIn, string projectId)
        {
            var project = AppServiceProvider.Instance.Get<IProjectDataAccess>().GetById(projectId);
            project.CheckIns.Add(checkIn);
            AppServiceProvider.Instance.Get<IProjectDataAccess>().ReplaceOne(project, projectId);
        }

        public void Delete(string checkInId, string projectId)
        {
            var project = AppServiceProvider.Instance.Get<IProjectDataAccess>().GetById(projectId);
            project.CheckIns.RemoveAll(x=>x.Id == ObjectId.Parse(projectId));
            AppServiceProvider.Instance.Get<IProjectDataAccess>().ReplaceOne(project, projectId);
        }

        public void Update(CheckIn checkIn, string projectId)
        {
            var project = AppServiceProvider.Instance.Get<IProjectDataAccess>().GetById(projectId);
            var modifiedCheckin = project.CheckIns.Find(x => x.Id == checkIn.Id);
            modifiedCheckin.Application = checkIn.Application;
            modifiedCheckin.DeployPackageId = checkIn.DeployPackageId;
            modifiedCheckin.CheckinId = checkIn.CheckinId;
            modifiedCheckin.Description = checkIn.Description;
            modifiedCheckin.Enviroment = checkIn.Enviroment;
            modifiedCheckin.IsDbMigration = checkIn.IsDbMigration;
            modifiedCheckin.IsDeployed = checkIn.IsDeployed;
            AppServiceProvider.Instance.Get<IProjectDataAccess>().ReplaceOne(project, projectId);
        }
    }
}
