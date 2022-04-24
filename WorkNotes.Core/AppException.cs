using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;

namespace WorkNotes.Core
{
    public class AppException : Exception
    {
        public string ErrorCode { get; set; }

        public AppException(KeyValuePair<string,string> message, object model = null) : base(message.Value)
        {
            ErrorCode = message.Key;
            Data.Add("model", model);
            LogException(this, model);
        }

        public AppException(KeyValuePair<string, string> message, string[] args, object model = null) : base(string.Format(message.Value,args))
        {
            ErrorCode = message.Key;
            Data.Add("model", model);
            LogException(this, model);
        }

        public AppException(KeyValuePair<string, string> message, Exception innerException, object model = null) : base(message.Value, innerException)
        {
            ErrorCode = message.Key;
            Data.Add("model", model);
            LogException(this, model);
        }

        public AppException(KeyValuePair<string, string> message, Exception innerException, string[] args, object model = null) : base(string.Format(message.Value, args), innerException)
        {
            ErrorCode = message.Key;
            Data.Add("model", model);
            LogException(this, model);
        }

        public void LogException(AppException ex, object model)
        {
            if (model != null)
            {
                Log.Error("Input : {0}", JsonConvert.SerializeObject(model));
            }
            Log.Error(ex, ex.Message);
        }
    }
}
