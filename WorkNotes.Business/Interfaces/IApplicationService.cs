using System.Collections.Generic;
using WorkNotes.Entities;

namespace WorkNotes.Business.Interfaces
{
    public interface IApplicationService
    {
        List<Application> GetAll();
    }
}
