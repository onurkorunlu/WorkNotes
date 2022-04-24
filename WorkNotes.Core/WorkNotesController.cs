using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace WorkNotes.Core
{
    public class WorkNotesController : Controller
    {
        public void CheckModelState(object? model = null)
        {
            if (!ModelState.IsValid && ModelState.Values.Any())
            {
                var invalidFields = ModelState.Values.Where(x => x.ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid).ToList();

                string errors = string.Empty;

                foreach (var key in ModelState.Keys)
                {

                    var field = ModelState[key];
                    if (field.ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
                    {
                        errors += errors != string.Empty ? "</br>" : string.Empty;
                        errors += field.Errors[0].ErrorMessage;
                    }
                }

                throw new AppException(ReturnMessages.MODEL_VALIDATION_ERROR, new string[] { errors }, model);
            }
        }

        #region SuccessResult

        public static JsonResult PrepareSuccessJsonResult(string successMessage)
        {
            return MyJsonResult.Success(successMessage, null, true);
        }


        public static JsonResult PrepareSuccessJsonResult(object? data = null, bool showNotification = false)
        {
            return MyJsonResult.Success(data, showNotification);

        }

        public static JsonResult PrepareSuccessJsonResult(KeyValuePair<string,string> returnMessage, object? data = null, bool showNotification = false)
        {
            return MyJsonResult.Success(returnMessage.Value, data, showNotification);
        }

        #endregion

        #region ErrorResult
        public static JsonResult PrepareErrorJsonResult(string successMessage, object? data = null)
        {
            return MyJsonResult.Error(successMessage, null, data, true);
        }

        public static JsonResult PrepareErrorJsonResult(KeyValuePair<string, string> returnMessage, object? data = null)
        {
            return MyJsonResult.Error(returnMessage.Value, null, data, true);
        }

        public static JsonResult PrepareErrorJsonResult(AppException definedException, bool showNotification = false, object? data = null)
        {
            if (definedException.ErrorCode == ReturnMessages.MODEL_VALIDATION_ERROR.Key)
            {
                return MyJsonResult.Error(definedException.ErrorCode, definedException.Message, data, showNotification);
            }
            return MyJsonResult.Error(definedException.ErrorCode, definedException.Message, data, showNotification);
        }

        #endregion

        #region ViewBag Result

        public void ShowError(AppException e)
        {
            ViewBag.ErrorMessage = e.Message;
        }

        #endregion
    }
}
