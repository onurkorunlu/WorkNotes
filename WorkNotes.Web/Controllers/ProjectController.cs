using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkNotes.Business.Interfaces;
using WorkNotes.Common;
using WorkNotes.Core;
using WorkNotes.Entities;
using WorkNotes.Entities.Enums;
using WorkNotes.Models.RequestModel;

namespace WorkNotes.Web.Controllers
{
    public class ProjectController : WorkNotesController
    {
        #region Get

        public ActionResult Index()
        {
            try
            {
                return View(AppServiceProvider.Instance.Get<IProjectService>().GetAll());
            }
            catch (AppException e)
            {
                ShowError(e);
                return View();
            }
            catch (Exception ex)
            {
                AppException appException = new(ReturnMessages.GENERIC_ERROR, ex);
                ShowError(appException);
                return View();
            }
        }

        public ActionResult ITSMList()
        {
            try
            {
                return View("Index", AppServiceProvider.Instance.Get<IProjectService>().GetAll()?.Where(x => x.Type == ProjectType.ITSM && x.RecordStatus));
            }
            catch (AppException e)
            {
                ShowError(e);
                return View();
            }
            catch (Exception ex)
            {
                AppException appException = new(ReturnMessages.GENERIC_ERROR, ex);
                ShowError(appException);
                return View();
            }
        }

        public ActionResult Detail(string id)
        {
            try
            {
                var project = AppServiceProvider.Instance.Get<IProjectService>().GetById(id);
                return View(project);
            }
            catch (AppException e)
            {
                ShowError(e);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                AppException appException = new(ReturnMessages.GENERIC_ERROR, ex);
                ShowError(appException);
                return RedirectToAction("Index");
            }
        }

        public JsonResult GetCodes()
        {
            try
            {
                List<string> respcodes = new List<string>();
                var codes = AppServiceProvider.Instance.Get<IProjectService>().GetAll()?.Select(x => x.Code);

                if (codes != null && codes.Any())
                {
                    foreach (var code in codes)
                    {
                        var splittedCode = code.Split('-');
                        respcodes.Add(splittedCode.FirstOrDefault() + "-");
                    }
                    if (respcodes.Any())
                    {
                        respcodes = respcodes.Distinct().ToList();
                    }
                }

                return PrepareSuccessJsonResult(respcodes, false);
            }
            catch (AppException e)
            {
                return PrepareErrorJsonResult(e);
            }
            catch (Exception ex)
            {
                AppException appException = new(ReturnMessages.GENERIC_ERROR, ex);
                return PrepareErrorJsonResult(appException);
            }
        }


        #endregion

        #region Add

        public ActionResult Add()
        {
            return View(new AddProjectRequestModel());
        }

        [HttpPost]
        public ActionResult Add(AddProjectRequestModel model)
        {

            try
            {
                CheckModelState(model);
                var project = AppServiceProvider.Instance.Get<IProjectService>().Create(model);
                return RedirectToAction("Detail", "Project", new { id = project.Id.ToString() });
            }
            catch (AppException e)
            {
                ShowError(e);
            }
            catch (Exception ex)
            {
                AppException appException = new(ReturnMessages.GENERIC_ERROR, ex);
                ShowError(appException);
            }

            return View(model);

        }
        #endregion

        #region Update

        public ActionResult Update()
        {
            return View(new UpdateProjectRequestModel());
        }


        [HttpPost]
        public ActionResult Update(UpdateProjectRequestModel model)
        {
            try
            {
                CheckModelState(model);
                var project = AppServiceProvider.Instance.Get<IProjectService>().Update(model);
                return RedirectToAction("Detail", new { id = model.Id.ToString() });
            }
            catch (AppException e)
            {
                ShowError(e);
                return RedirectToAction("Detail", new { id = model.Id.ToString() });
            }
            catch (Exception ex)
            {
                AppException appException = new(ReturnMessages.GENERIC_ERROR, ex);
                ShowError(appException);
                return RedirectToAction("Detail", new { id = model.Id.ToString() });
            }
        }

        public ActionResult UpdateStatus(ProjectStatus status, string id)
        {
            try
            {
                var project = AppServiceProvider.Instance.Get<IProjectService>().UpdateStatus(id, status);
                return RedirectToAction("Detail", new { id = id });
            }
            catch (AppException e)
            {
                ShowError(e);
                return RedirectToAction("Detail", new { id = id});
            }
            catch (Exception ex)
            {
                AppException appException = new(ReturnMessages.GENERIC_ERROR, ex);
                ShowError(appException);
                return RedirectToAction("Detail", new { id = id});
            }
        }


        #endregion

        #region Delete
        public ActionResult Delete(string id)
        {
            try
            {
                AppServiceProvider.Instance.Get<IProjectService>().Delete(id);
                return RedirectToAction("Index", "Home", null);
            }
            catch (AppException e)
            {
                ShowError(e);
                return View();
            }
            catch (Exception ex)
            {
                AppException appException = new(ReturnMessages.GENERIC_ERROR, ex);
                ShowError(appException);
                return View();
            }

        }

        #endregion

        #region CheckIn

        public ActionResult AddCheckIn(AddCheckInRequestModel model)
        {
            try
            {
                CheckModelState(model);
                var project = AppServiceProvider.Instance.Get<IProjectService>().AddCheckIn(model);
                return RedirectToAction("Detail", new { id = model.ProjectId.ToString() });
            }
            catch (AppException e)
            {
                ShowError(e);
                return RedirectToAction("Detail", new { id = model.ProjectId.ToString() });
            }
            catch (Exception ex)
            {
                AppException appException = new(ReturnMessages.GENERIC_ERROR, ex);
                ShowError(appException);
                return RedirectToAction("Detail", new { id = model.ProjectId.ToString() });
            }
        }

        public ActionResult DeleteCheckIn(DeleteCheckInRequestModel model)
        {
            try
            {
                CheckModelState(model);
                var project = AppServiceProvider.Instance.Get<IProjectService>().DeleteCheckIn(model.ProjectId, model.CheckInId, model.ApplicationId);
                return RedirectToAction("Detail", new { id = model.ProjectId.ToString() });
            }
            catch (AppException e)
            {
                ShowError(e);
                return RedirectToAction("Detail", new { id = model.ProjectId.ToString() });
            }
            catch (Exception ex)
            {
                AppException appException = new(ReturnMessages.GENERIC_ERROR, ex);
                ShowError(appException);
                return RedirectToAction("Detail", new { id = model.ProjectId.ToString() });
            }
        }

        #endregion
    }
}
