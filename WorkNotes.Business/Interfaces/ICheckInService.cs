using WorkNotes.Entities;

namespace WorkNotes.Business.Interfaces
{
    public interface ICheckInService
    {
        void Create(CheckIn checkIn, string projectId);
        void Delete(string checkInId, string projectId);
    }
}
