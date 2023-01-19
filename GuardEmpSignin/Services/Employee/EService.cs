using GuardEmpSignin.Models;
using GuardEmpSignin.Repository.Employee;
using System.Net;

namespace GuardEmpSignin.Services.Employee
{
    public class EService: IEService
    {
        private readonly IEmployeeDBrep _Db;


        public EService(IEmployeeDBrep Db)
        {
            _Db= Db;
        }
        public IQueryable<EmpDetail> SignIn(string FirstName, string LastName)
        {
            var Q = _Db.Fetchdata(FirstName, LastName);
            return Q;
        }
        
        public bool s_ApproveReq(int id)
        {
             _Db.Fetchrequest(id);
            return true;
        }
        public int s_SignOut(string badge)
        {
            var q = _Db.AssignSignOut(badge);
            if (q == false)
            {
                //throw new Exception("Badge Not Found!");
                return (int)HttpStatusCode.NotFound;
            }
            return (int)HttpStatusCode.OK;
        }
    }
}
