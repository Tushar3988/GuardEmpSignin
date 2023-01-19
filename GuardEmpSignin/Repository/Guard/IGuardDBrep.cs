using GuardEmpSignin.Models;


namespace GuardEmpSignin.Repository.Guard
{
    public interface IGuardDBrep
    {
        IQueryable<GuardQueue> getBadgeQueue();
        bool AddBadge(int id, string badge, DateTime assignT);
        IQueryable<GuardQueue> getOutList();
        IQueryable<EmployeeTempBadge> getReport(DateTime sDate, DateTime eDate,
        string? fName, string? lName);
    }
}