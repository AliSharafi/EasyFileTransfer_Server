using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyFileTransfer.Utils
{
    public class Helper
    {
        public static string GetCurrentEmployeeIpAddress()
        {
            AppConfigs conf = AppConfigs.Load();
            string Username = System.Security.Principal.WindowsIdentity.GetCurrent().Name.ToLower();

            List<Employee> emp = conf.Employees;
            Employee CurrentEmployee = emp.Where(e => e.Username.ToLower() == Username).FirstOrDefault();
            if (CurrentEmployee != null)
            {
                return CurrentEmployee.IPAddress;
            }

            return null;
        }
    }
}
