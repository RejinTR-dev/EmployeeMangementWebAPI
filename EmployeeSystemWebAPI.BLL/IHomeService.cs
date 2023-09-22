using EmployeeSystemWebAPI.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystemWebAPI.BLL
{
    using EmployeeSystemWebAPI.Model;
    public interface IHomeService
    {
       public List<RoleAccess> GetRoleAccessCheck(string email, string password);
       public OutPutModel SaveEmployeeDetails(EmployeeDetails employeeDetails);
    }
}
