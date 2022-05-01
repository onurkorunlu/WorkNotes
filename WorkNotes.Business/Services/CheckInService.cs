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
            project.CheckIns.RemoveAll(x=>x.ChangesetId == checkInId);
            AppServiceProvider.Instance.Get<IProjectDataAccess>().ReplaceOne(project, projectId);
        }
    }
}
