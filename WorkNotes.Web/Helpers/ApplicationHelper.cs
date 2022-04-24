using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using WorkNotes.Business.Interfaces;
using WorkNotes.Core;

namespace WorkNotes.Common.Helpers
{
    public class ApplicationHelper
    {
        public static List<SelectListItem> GetApplications(bool IsDbMigration = false)
        {
            List<SelectListItem> listItems = new List<SelectListItem>();

            var applications = AppServiceProvider.Instance.Get<IApplicationService>().GetAll();

            if (applications != null && applications.Any())
            {
                foreach (var app in applications.Where(x => x.IsDbMigration == IsDbMigration).ToList())
                {
                    listItems.Add(new SelectListItem
                    {
                        Text = app.Name,
                        Value = app.Id.ToString()
                    });
                }
            }

            return listItems;
        }
    }
}
