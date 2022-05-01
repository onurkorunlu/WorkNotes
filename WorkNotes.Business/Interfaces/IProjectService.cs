using System.Collections.Generic;
using WorkNotes.Entities.Enums;
using WorkNotes.Models.RequestModel;
using WorkNotes.Models.ViewModel;

namespace WorkNotes.Business.Interfaces
{
    public interface IProjectService
    {
        ICollection<ProjectViewModel> GetAll();

        ProjectViewModel GetById(string id);

        ProjectViewModel Create(AddProjectRequestModel model);

        ProjectViewModel Update(UpdateProjectRequestModel model);

        ProjectViewModel UpdateStatus(string id, ProjectStatus status);

        ProjectViewModel Delete(string id);

        ProjectViewModel AddCheckIn(AddCheckInRequestModel model);

        ProjectViewModel DeleteCheckIn(string id, string projectId);
        ProjectViewModel UpdateDeployPackageId(UpdateDeployPackageIdRequestModel model);
        ProjectViewModel UpdateIsDeployedStatus(UpdateIsDeployedStatusRequestModel model);
    }
}
