using System.Collections.Generic;
using WorkNotes.Entities;
using WorkNotes.Models.RequestModel;

namespace WorkNotes.Business.Interfaces
{
    public interface IApplicationService
    {
        List<Application> GetAll();
        Application Create(AddApplicationRequestModel model);
        void Delete(string id);
    }
}
