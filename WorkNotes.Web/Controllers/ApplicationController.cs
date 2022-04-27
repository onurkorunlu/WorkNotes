using Microsoft.AspNetCore.Mvc;
using System;
using WorkNotes.Business.Interfaces;
using WorkNotes.Core;
using WorkNotes.Models.RequestModel;

namespace WorkNotes.Web.Controllers
{
    public class ApplicationController : WorkNotesController
    {
        public IActionResult Index()
        {
            return View(AppServiceProvider.Instance.Get<IApplicationService>().GetAll());
        }

        public IActionResult Add()
        {
            return View(new AddApplicationRequestModel());
        }

        [HttpPost]
        public IActionResult Add(AddApplicationRequestModel model)
        {
            try
            {
                CheckModelState(model);
                var project = AppServiceProvider.Instance.Get<IApplicationService>().Create(model);
                return RedirectToAction("Index");
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

        public ActionResult Delete(string id)
        {
            try
            {
                AppServiceProvider.Instance.Get<IApplicationService>().Delete(id);
                return RedirectToAction("Index");
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

    }
}
