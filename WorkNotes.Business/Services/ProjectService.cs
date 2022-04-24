using System.Collections.Generic;
using WorkNotes.Business.Interfaces;
using WorkNotes.Common;
using WorkNotes.Core;
using WorkNotes.DataAccess.Interfaces;
using WorkNotes.Entities;
using WorkNotes.Entities.Enums;
using WorkNotes.Models.RequestModel;

namespace WorkNotes.Business.Services
{
    public class ProjectService : IProjectService
    {
        public ICollection<Project> GetAll()
        {
            return AppServiceProvider.Instance.Get<IProjectDataAccess>().GetAll();
        }

        public Project GetById(string id)
        {
            return AppServiceProvider.Instance.Get<IProjectDataAccess>().GetById(id);
        }

        public Project Create(AddProjectRequestModel model)
        {
            Project project = new()
            {
                Title = model.Title.SafeTrim(),
                Description = model.Description.SafeTrim(),
                Code = model.Code.SafeTrim(),
                Type = model.Code.StartsWith("ITSM") ? ProjectType.ITSM : ProjectType.PROJECT,
                Status = model.Status,
                TargetDate = model.TargetDate,
                RecordStatus = true
            };

            return AppServiceProvider.Instance.Get<IProjectDataAccess>().InsertOne(project);
        }

        public Project Update(UpdateProjectRequestModel model)
        {
            var project = AppServiceProvider.Instance.Get<IProjectDataAccess>().GetById(model.Id);
            project.Code = model.Code.SafeTrim();
            project.Title = model.Title.SafeTrim();
            project.Description = model.Description.SafeTrim();
            project.Status = model.Status;
            project.Type = model.Type;
            project.TargetDate = model.TargetDate;

            return AppServiceProvider.Instance.Get<IProjectDataAccess>().ReplaceOne(project, model.Id.ToString());
        }

        public Project UpdateStatus(string id, ProjectStatus status)
        {
            var project = AppServiceProvider.Instance.Get<IProjectDataAccess>().GetById(id);
            project.Status = status;
            return AppServiceProvider.Instance.Get<IProjectDataAccess>().ReplaceOne(project, id);
        }

        public Project Delete(string id)
        {
            return AppServiceProvider.Instance.Get<IProjectDataAccess>().DeleteById(id);
        }


    }
}
