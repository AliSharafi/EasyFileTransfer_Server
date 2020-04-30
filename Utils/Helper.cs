using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace EasyFileTransfer.Utils
{
    public class Helper
    {
        public static string GetCurrentEmployeeSavePath()
        {
            AppConfigs conf = AppConfigs.Load();
            string Username = System.Security.Principal.WindowsIdentity.GetCurrent().Name.ToLower();

            List<Employee> emp = conf.Employees;
            Employee CurrentEmployee = emp.Where(e => e.Username.ToLower() == Username).FirstOrDefault();
            if (CurrentEmployee != null)
            {
                return CurrentEmployee.SavePath;
            }

            return null;
        }
        public static string GetCurrentEmployeeIPaddress()
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
        public static bool IsAdministrator()
        {
            using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
            {
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
        }
    }
}
