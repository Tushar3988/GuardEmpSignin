using GuardEmpSignin.Models;

namespace GuardEmpSignin.Services.Guard
{
    public interface IGService
    {
        public IQueryable<GuardQueue> BadgeQueue();
        public int AssignBadge(int UId, string badge, DateTime assignT);

        public IQueryable<GuardQueue> s_OutList();

        public IQueryable<EmployeeTempBadge> GetReport(DateTime sDate, DateTime eDate,
        string? fName, string? lName);
    }
}
