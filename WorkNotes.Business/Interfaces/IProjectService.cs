using System.Collections.Generic;
using WorkNotes.Entities;
using WorkNotes.Entities.Enums;
using WorkNotes.Models.RequestModel;

namespace WorkNotes.Business.Interfaces
{
    public interface IProjectService
    {
        ICollection<Project> GetAll();

        Project GetById(string id);


        Project Create(AddProjectRequestModel model);


        Project Update(UpdateProjectRequestModel model);

        Project UpdateStatus(string id, ProjectStatus status);


        Project Delete(string id);
    }
}
