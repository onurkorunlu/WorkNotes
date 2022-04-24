using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WorkNotes.Common
{
    public class MyJsonResult
    {
        public static JsonResult Success(bool showNotification = false)
        {
            return new JsonResult(new { IsSuccess = true, ErrorCode = ReturnMessages.SUCCESSFUL.Key, Message = ReturnMessages.SUCCESSFUL.Value, ShowNotification = showNotification });
        }
        public static JsonResult Success(string? message, object? data = null, bool showNotification = false)
        {
            return new JsonResult(new { IsSuccess = true, ErrorCode = ReturnMessages.SUCCESSFUL.Key, Message = string.IsNullOrWhiteSpace(message) ? ReturnMessages.SUCCESSFUL.Value : message, Data = data, ShowNotification = showNotification });
        }
        public static JsonResult Success(object? data = null, bool showNotification = false)
        {
            return new JsonResult(new { IsSuccess = true, ErrorCode = ReturnMessages.SUCCESSFUL.Key, Message = ReturnMessages.SUCCESSFUL.Value, Data = data, ShowNotification = showNotification });
        }

        public static JsonResult Error(bool showNotification = false)
        {
            return new JsonResult(new { IsSuccess = false, ErrorCode = ReturnMessages.GENERIC_ERROR.Key, Message = ReturnMessages.GENERIC_ERROR.Value, ShowNotification = showNotification });
        }
        public static JsonResult Error(string errorCode, string message, object? data = null, bool showNotification = false)
        {
            return new JsonResult(new { IsSuccess = false, ErrorCode = errorCode, Message = message, Data = data, ShowNotification = showNotification });
        }

        public static JsonResult Error(KeyValuePair<string, string> returnMessage, string? message, object? data = null, bool showNotification = false)
        {
            return new JsonResult(new { IsSuccess = false, ErrorCode = returnMessage.Key, Message = string.IsNullOrWhiteSpace(message) ? returnMessage.Value : message, Data = data, ShowNotification = showNotification });
        }
    }
}
