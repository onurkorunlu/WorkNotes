﻿using Microsoft.AspNetCore.Mvc;
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
            ViewBag.Applications = new List<Application>() { new Application { Name = "Test1" }, new Application { Name = "Test2" } };
            TempData["Codes"] = getCodes();

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

        #endregion

        #region Add

        public ActionResult Add()
        {
            TempData["Codes"] = getCodes();
            return View(new AddProjectRequestModel());
        }

        [HttpPost]
        public JsonResult Add(AddProjectRequestModel model)
        {
            TempData["Codes"] = getCodes();

            try
            {
                CheckModelState(model);
                var project = AppServiceProvider.Instance.Get<IProjectService>().Create(model);
                return PrepareSuccessJsonResult(project, true);
            }
            catch (AppException e)
            {
                return PrepareErrorJsonResult(e, true, model);
            }
            catch (Exception ex)
            {
                AppException appException = new(ReturnMessages.GENERIC_ERROR, ex);
                return PrepareErrorJsonResult(appException, true, model);
            }

        }
        #endregion

        #region Update

        public ActionResult Update()
        {
            TempData["Codes"] = getCodes();
            return View(new UpdateProjectRequestModel());
        }


        [HttpPost]
        public JsonResult Update(UpdateProjectRequestModel model)
        {
            try
            {
                CheckModelState(model);
                var project = AppServiceProvider.Instance.Get<IProjectService>().Update(model);
                return PrepareSuccessJsonResult(project, true);
            }
            catch (AppException e)
            {
                return PrepareErrorJsonResult(e, true, model);
            }
            catch (Exception ex)
            {
                AppException appException = new(ReturnMessages.GENERIC_ERROR, ex);
                return PrepareErrorJsonResult(appException, true, model);
            }
        }

        [HttpPost]
        public JsonResult UpdateStatus(ProjectStatus status, string id)
        {
            try
            {
                var project = AppServiceProvider.Instance.Get<IProjectService>().UpdateStatus(id, status);
                return PrepareSuccessJsonResult(project, true);
            }
            catch (AppException e)
            {
                return PrepareErrorJsonResult(e, true, new { status = status, id = id });
            }
            catch (Exception ex)
            {
                AppException appException = new(ReturnMessages.GENERIC_ERROR, ex);
                return PrepareErrorJsonResult(appException, true, new { status = status, id = id });
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

        #region Methods
        public string getCodes()
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                List<string> respcodes = new List<string>();
                var codes = AppServiceProvider.Instance.Get<IProjectService>().GetAll()?.Select(x => x.Code);

                if (codes != null && codes.Any())
                {
                    foreach (var code in codes)
                    {
                        var splittedCode = code.Split('-');
                        respcodes.Add(splittedCode.FirstOrDefault());
                    }
                    if (respcodes.Any())
                    {
                        foreach (var item in respcodes.Distinct())
                        {
                            var code = string.Concat("\'", item, "-\'");
                            sb.Append(code);
                            if (item != respcodes.Distinct().Last())
                            {
                                sb.Append(",");
                            }
                        }
                    }
                }
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

            return sb.ToString();
        }

        #endregion

    }
}