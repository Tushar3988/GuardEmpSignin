using GuardEmpSignin.Models;
using GuardEmpSignin.Repository.Guard;
using System.Net;
namespace GuardEmpSignin.Services.Guard
{
    public class GService : IGService
    {
        private readonly IGuardDBrep _db;
        public GService(IGuardDBrep dbService)
        {
            _db = dbService;
        }
        public IQueryable<GuardQueue> BadgeQueue()
        {
            var queue = _db.getBadgeQueue();
            return queue;
        }
        public int AssignBadge(int UId, string badge, DateTime assignT)
        {
            var q = _db.AddBadge(UId, badge, assignT);
            if (!q)
            {
                return (int)HttpStatusCode.Conflict;
            }
            return (int)HttpStatusCode.Accepted;
        }
        public IQueryable<GuardQueue> s_OutList()
        {
            var q = _db.getOutList();
            return q;
        }
        public IQueryable<EmployeeTempBadge> GetReport(DateTime sDate, DateTime eDate,
        string? fName, string? lName)
        {
            var q = _db.getReport(sDate, eDate, fName, lName);
            return q;
        }
    }
}