using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using WorkNotes.Business.Interfaces;
using WorkNotes.Common;
using WorkNotes.Core;
using WorkNotes.DataAccess.Interfaces;
using WorkNotes.Entities;
using WorkNotes.Entities.Enums;
using WorkNotes.Models.RequestModel;
using WorkNotes.Models.ViewModel;

namespace WorkNotes.Business.Services
{
    public class ProjectService : IProjectService
    {
        private readonly CultureInfo cultureInfo = new CultureInfo("tr-TR");

        public ICollection<ProjectViewModel> GetAll()
        {
            return toViewModel(AppServiceProvider.Instance.Get<IProjectDataAccess>().GetAll());
        }

        public ProjectViewModel GetById(string id)
        {
            return toViewModel(AppServiceProvider.Instance.Get<IProjectDataAccess>().GetById(id));
        }

        public ProjectViewModel Create(AddProjectRequestModel model)
        {

            Project project = new()
            {
                Title = model.Title.SafeTrim(),
                Description = model.Description.SafeTrim(),
                Code = model.Code.SafeTrim().ToUpper(cultureInfo),
                Type = model.Code.StartsWith("ITSM") ? ProjectType.ITSM : ProjectType.PROJECT,
                Status = model.Status,
                TargetDate = model.TargetDate.HasValue ? GetTargetDate(model.TargetDate.Value) : null,
                RecordStatus = true
            };

            return toViewModel(AppServiceProvider.Instance.Get<IProjectDataAccess>().InsertOne(project));
        }

        public ProjectViewModel Update(UpdateProjectRequestModel model)
        {
            var project = AppServiceProvider.Instance.Get<IProjectDataAccess>().GetById(model.Id);
            project.Code = model.Code.SafeTrim().ToUpper(cultureInfo);
            project.Title = model.Title.SafeTrim();
            project.Description = model.Description.SafeTrim();
            project.Type = model.Type;
            project.TargetDate = model.TargetDate.GetValueOrDefault();

            return toViewModel(AppServiceProvider.Instance.Get<IProjectDataAccess>().ReplaceOne(project, model.Id.ToString()));
        }

        public ProjectViewModel UpdateStatus(string id, ProjectStatus status)
        {
            var project = AppServiceProvider.Instance.Get<IProjectDataAccess>().GetById(id);
            project.Status = status;
            return toViewModel(AppServiceProvider.Instance.Get<IProjectDataAccess>().ReplaceOne(project, id));
        }

        public ProjectViewModel Delete(string id)
        {
            return toViewModel(AppServiceProvider.Instance.Get<IProjectDataAccess>().DeleteById(id));
        }

        private DateTime GetTargetDate(DateTime targetDate)
        {
            return new DateTime(targetDate.Year, targetDate.Month, targetDate.Day, 18, 0, 0);
        }

        public ProjectViewModel AddCheckIn(AddCheckInRequestModel model)
        {
            var project = AppServiceProvider.Instance.Get<IProjectDataAccess>().GetById(model.ProjectId);
            var application = AppServiceProvider.Instance.Get<IApplicationDataAccess>().GetById(model.ApplicationId);

            if (project == null || application == null)
            {
                throw new AppException(ReturnMessages.ITEM_NOT_FOUND);
            }

            if (project.CheckIns.Any(x => x.ChangesetId == model.ChangesetId && x.Application.Id.ToString() == model.ApplicationId))
            {
                return project.ToMap<ProjectViewModel>(); ;
            }

            CheckIn checkIn = new()
            {
                Application = application,
                ChangesetId = model.ChangesetId.SafeTrim(),
                DeployPackageId = model.DeployPackageId.SafeTrim(),
                Description = model.Description.SafeTrim(),
                Enviroment = model.Enviroment,
                IsDbMigration = model.IsDbMigration,
                IsDeployed = model.IsDeployed
            };

            project.CheckIns.Add(checkIn);

            return toViewModel(AppServiceProvider.Instance.Get<IProjectDataAccess>().ReplaceOne(project, model.ProjectId));
        }

        public ProjectViewModel DeleteCheckIn(string id, string projectId)
        {
            var project = AppServiceProvider.Instance.Get<IProjectDataAccess>().GetById(projectId);

            if (project == null)
            {
                throw new AppException(ReturnMessages.ITEM_NOT_FOUND);
            }

            var checkIn = project.CheckIns.FirstOrDefault(x => x.Id == id);
            if (checkIn == null)
            {
                throw new AppException(ReturnMessages.ITEM_NOT_FOUND);
            }

            project.CheckIns.Remove(checkIn);

            return toViewModel(AppServiceProvider.Instance.Get<IProjectDataAccess>().ReplaceOne(project, projectId));
        }

        public ProjectViewModel UpdateDeployPackageId(UpdateDeployPackageIdRequestModel model)
        {
            var project = AppServiceProvider.Instance.Get<IProjectDataAccess>().GetById(model.ProjectId);
            var checkIn = project.CheckIns.First(x => x.Id == model.CheckInId);
            checkIn.DeployPackageId = model.DeployPackageId.SafeTrim();
            if (string.IsNullOrWhiteSpace(model.DeployPackageId))
            {
                checkIn.IsDeployed = false;
            }
            return toViewModel(AppServiceProvider.Instance.Get<IProjectDataAccess>().ReplaceOne(project, model.ProjectId.ToString()));
        }

        public ProjectViewModel UpdateIsDeployedStatus(UpdateIsDeployedStatusRequestModel model)
        {
            var project = AppServiceProvider.Instance.Get<IProjectDataAccess>().GetById(model.ProjectId);
            var checkIn = project.CheckIns.First(x => x.Id == model.CheckInId);
            checkIn.IsDeployed = model.IsDeployed;
            return toViewModel(AppServiceProvider.Instance.Get<IProjectDataAccess>().ReplaceOne(project, model.ProjectId.ToString()));
        }

        public static ProjectViewModel toViewModel(Project model)
        {
            if (model != null)
            {
                var project = model.ToMap<ProjectViewModel>();
                project.CheckIns.ForEach(x => x.ProjectId = project.Id);
                project.Notes.ForEach(x => x.ProjectId = project.Id);
                return project;
            }
            return null;
        }

        public static List<ProjectViewModel> toViewModel(List<Project> model)
        {
            if (model != null && model.Any())
            {
                var projectList = model.ToMap<List<ProjectViewModel>>();
                projectList.ForEach(x => x.CheckIns.ForEach(y => y.ProjectId = x.Id));
                projectList.ForEach(x => x.Notes.ForEach(y => y.ProjectId = x.Id));
                return projectList;
            }
            return null;
        }
    }
}
