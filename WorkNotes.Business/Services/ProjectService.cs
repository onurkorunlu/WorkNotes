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

namespace WorkNotes.Business.Services
{
    public class ProjectService : IProjectService
    {
        private readonly CultureInfo cultureInfo = new CultureInfo("tr-TR");

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
                Code = model.Code.SafeTrim().ToUpper(cultureInfo),
                Type = model.Code.StartsWith("ITSM") ? ProjectType.ITSM : ProjectType.PROJECT,
                Status = model.Status,
                TargetDate = model.TargetDate.HasValue ? GetTargetDate(model.TargetDate.Value) : null,
                RecordStatus = true
            };

            return AppServiceProvider.Instance.Get<IProjectDataAccess>().InsertOne(project);
        }

        public Project Update(UpdateProjectRequestModel model)
        {
            var project = AppServiceProvider.Instance.Get<IProjectDataAccess>().GetById(model.Id);
            project.Code = model.Code.SafeTrim().ToUpper(cultureInfo);
            project.Title = model.Title.SafeTrim();
            project.Description = model.Description.SafeTrim();
            project.Type = model.Type;
            project.TargetDate = model.TargetDate.GetValueOrDefault();

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

        private DateTime GetTargetDate(DateTime targetDate)
        {
            return new DateTime(targetDate.Year, targetDate.Month, targetDate.Day, 18, 0, 0);
        }

        public Project AddCheckIn(AddCheckInRequestModel model)
        {
            var project = AppServiceProvider.Instance.Get<IProjectDataAccess>().GetById(model.ProjectId);
            var application = AppServiceProvider.Instance.Get<IApplicationDataAccess>().GetById(model.ApplicationId);

            if (project == null || application == null)
            {
                throw new AppException(ReturnMessages.ITEM_NOT_FOUND);
            }

            if (project.CheckIns.Any(x => x.CheckinId == model.CheckinId && x.Application.Id.ToString() == model.ApplicationId))
            {
                return project;
            }

            CheckIn checkIn = new()
            {
                Application = application,
                CheckinId = model.CheckinId,
                DeployPackageId = model.DeployPackageId,
                Description = model.Description,
                Enviroment = model.Enviroment,
                IsDbMigration = model.IsDbMigration,
                IsDeployed = model.IsDeployed
            };

            project.CheckIns.Add(checkIn);

            return AppServiceProvider.Instance.Get<IProjectDataAccess>().ReplaceOne(project, model.ProjectId);
        }

        public Project DeleteCheckIn(string projectId, string checkInId, string applicationId)
        {
            var project = AppServiceProvider.Instance.Get<IProjectDataAccess>().GetById(projectId);

            if (project == null)
            {
                throw new AppException(ReturnMessages.ITEM_NOT_FOUND);
            }

            var checkIn = project.CheckIns.FirstOrDefault(x => x.CheckinId == checkInId && x.Application.Id.ToString() == applicationId);
            if (checkIn == null)
            {
                throw new AppException(ReturnMessages.ITEM_NOT_FOUND);
            }

            project.CheckIns.Remove(checkIn);

            return AppServiceProvider.Instance.Get<IProjectDataAccess>().ReplaceOne(project, projectId);
        }

    }
}
