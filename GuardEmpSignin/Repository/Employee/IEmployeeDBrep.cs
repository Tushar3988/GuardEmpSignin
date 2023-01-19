using GuardEmpSignin.Models;

namespace GuardEmpSignin.Repository.Employee
{
    public interface IEmployeeDBrep
    {
        public IQueryable<EmpDetail> Fetchdata(string FirstName, string LastName);
        public void Fetchrequest(int id);
        public bool AssignSignOut(string badge);
    }
}
