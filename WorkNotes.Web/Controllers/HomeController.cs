using Microsoft.AspNetCore.Mvc;
using System;
using WorkNotes.Business.Interfaces;
using WorkNotes.Common;
using WorkNotes.Core;

namespace WorkNotes.Web.Controllers
{
    public class HomeController : WorkNotesController
    {
        public IActionResult Index()
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
    }
}
