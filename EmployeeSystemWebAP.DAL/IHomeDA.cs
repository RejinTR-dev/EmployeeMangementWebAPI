using EmployeeSystemWebAPI.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystemWebAP.DAL
{
    public interface IHomeDA
    {
       public OutPutModel SaveEmployeeDetails(EmployeeDetails employeeDetails);

       public List<RoleAccess> RoleAccessCheck(string email, string password);
    }

}