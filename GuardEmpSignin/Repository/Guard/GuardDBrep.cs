using GuardEmpSignin.Models;
using GuardEmpSignin.Repository.Employee;

namespace GuardEmpSignin.Repository.Guard
{
    public class GuardDBrep : IGuardDBrep
    {
        private readonly GuardDbContext _db;

        public GuardDBrep(GuardDbContext dbContext)
        {
            _db = dbContext;
        }
        public IQueryable<GuardQueue> getBadgeQueue()
        {

            var q = _db.EmployeeTempBadges.Join(_db.EmpDetails,
                                s => s.EmpContainer, t => t.Id,
                                (s, t) => new GuardQueue
                                {
                                    TempEmployee = s,
                                    TempEmpImg = t.Photo!
                                }
                                ).Where(e => e.TempEmployee.AssignT == null);
            return q;
        }
        private bool isValid_Badge(string badge)
        {

            var q = _db.EmployeeTempBadges.Where(e => e.SignOutT == null && e.TempBadge == badge);
            Console.WriteLine($"Employees with similar badge: {q.Count()}");
            if (q.Count() > 0)
            {
                Console.WriteLine("Badge Already Assigned!");
                return false;
            }
            return true;
        }
        public bool AddBadge(int id, string badge, DateTime assignT)
        {

            if (!isValid_Badge(badge)) return false;
            var temp_record = _db.EmployeeTempBadges.Find(id);
            if (temp_record == null) { return false; }
            temp_record.AssignT = assignT;
            temp_record.TempBadge = badge; 
            _db.SaveChanges();
            return true;
        }
        public IQueryable<GuardQueue> getOutList()
        {
            var q = _db.EmployeeTempBadges.Join(_db.EmpDetails,
                   s => s.EmpContainer, t => t.Id,
            (s, t) => new GuardQueue
            {
                TempEmployee = s,
                TempEmpImg = t.Photo
            }
               );
            q = q.Where(e => e.TempEmployee.AssignT != null && e.TempEmployee.SignOutT == null); return q;
        }
        public IQueryable<EmployeeTempBadge> getReport(DateTime sDate, DateTime eDate,
        string? fName, string? lName)
        {


            IQueryable<EmployeeTempBadge> q = _db.EmployeeTempBadges.Where(x => x.EmployeeFirstName != null); if (!string.IsNullOrEmpty(fName))
            {
                q = q.Where(e => e.EmployeeFirstName.Contains(fName));
            }
            if (!string.IsNullOrEmpty(lName))
            {
                q = q.Where(e => e.EmployeeLastName.Contains(lName));
            }
            if (!(sDate == DateTime.MinValue))
            {
                q = q.Where(e => e.SignInT.Date >= sDate.Date);
            }
            if (!(eDate == DateTime.MinValue))
            {
                q = q.Where(e => e.SignInT.Date <= eDate.Date);
            }

            return q;
        }

    }
}
