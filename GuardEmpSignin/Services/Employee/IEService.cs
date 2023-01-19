using GuardEmpSignin.Models;

namespace GuardEmpSignin.Services.Employee
{
    public interface IEService
    {
        public int s_SignOut(string badge);
        IQueryable<EmpDetail> SignIn(string? FirstName, string? LastName);
        public bool s_ApproveReq(int id);
    }
}
