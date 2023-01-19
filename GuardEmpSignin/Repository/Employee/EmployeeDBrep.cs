using GuardEmpSignin.Models;
using Microsoft.IdentityModel.Tokens;

namespace GuardEmpSignin.Repository.Employee
{
    public class EmployeeDBrep:IEmployeeDBrep
    {
        private GuardDbContext _Db;

        public EmployeeDBrep(GuardDbContext db)
        {
            _Db= db;
        }

        public IQueryable<EmpDetail> Fetchdata(string FirstName,string LastName)
        {
            var Q = _Db.EmpDetails.Where(E => E.EmpFirstname.Contains(FirstName ) || E.EmpLastname.Contains(LastName));
            return Q;
        }

        public void Fetchrequest(int id)
        {
            var Q = _Db.EmpDetails.Find(id);
            EmployeeTempBadge newRec = new EmployeeTempBadge
            {
                EmpContainer = Q.Id,
                EmployeeFirstName = Q.EmpFirstname,
                EmployeeLastName = Q.EmpLastname,
                SignInT = DateTime.Now,
                AssignT = null,
                SignOutT = null
            };

            _Db.EmployeeTempBadges.Add(newRec);
            _Db.SaveChanges();
        }
        public bool AssignSignOut(string badge)
        {
            var q = _Db.EmployeeTempBadges.Where(e => e.SignOutT == null && e.TempBadge == badge).ToArray();
            if (q.IsNullOrEmpty())
            {
                Console.WriteLine("Badge not found!");
                return false;
            }
            q[0].SignOutT = DateTime.Now;
            _Db.SaveChanges();
            return true;
        }
    }
}
