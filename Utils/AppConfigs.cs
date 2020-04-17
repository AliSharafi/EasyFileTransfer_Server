using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.ComponentModel;
using System.Collections;
using System.ComponentModel.Design;
using System.Web.Script.Serialization;

namespace EasyFileTransfer.Utils
{
    public class AppConfigs
    {
        JavaScriptSerializer serializer = new JavaScriptSerializer();

        [Category("Client Settings")]
        [DisplayName("Save Path")]
        [Description("Where to save files that server sends to me?")]
        public string SavePath
        {
            get
            {
                return ConfigurationManager.AppSettings["SavePath"];
            }
            set
            {
                AddOrUpdateAppSettings("SavePath", value);
            }
        }
        [Category("Client Settings")]
        [DisplayName("Server IP")]
        [Description("Server IP address ")]
        public string ServerIP
        {
            get
            {
                return ConfigurationManager.AppSettings["ServerIP"];
            }
            set
            {
                AddOrUpdateAppSettings("ServerIP", value);
            }
        }


        EmployeeCollection _e = new EmployeeCollection();

        [Editor(typeof(EmployeeCollectionEditor),
                   typeof(System.Drawing.Design.UITypeEditor))]
        [Category("Organization")]
        [DisplayName("Employees")]
        [Description("A collection of the employees within the organization")]
        public EmployeeCollection Employees
        {

            get
            {
                return Properties.Settings1.Default.Employees;
            }
            set
            {
                Properties.Settings1.Default.Employees = value;
            }

        }

        void AddOrUpdateAppSettings(string key, string value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error writing app settings");
            }
        }
    }

    public class Employee
    {
        #region Private Variables
        private string _userName;
        private string _savePath;
        #endregion

        #region Public Properties
        [Category("Employee")]
        [DisplayName("Username")]
        [Description("Domain user name eg Mabna\\Sharafi")]
        public string Username
        {
            get { return _userName; }
            set { _userName = value; }
        }

        [Category("Employee")]
        [DisplayName("Save Path")]
        [Description("Where to store files sent by this employee? eg D:\\Users\\Sharafi")]
        public string SavePath
        {
            get { return _savePath; }
            set { _savePath = value; }
        }
        #endregion
    }

    public class EmployeeCollection : CollectionBase
    {
        public Employee this[int index]
        {
            get { return (Employee)List[index]; }
        }
        public void Add(Employee emp)
        {
            List.Add(emp);
        }
        public void Remove(Employee emp)
        {
            List.Remove(emp);
        }
    }

    public class EmployeeCollectionEditor : CollectionEditor
    {
        public EmployeeCollectionEditor(Type type)
            : base(type)
        {

        }
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            object result = base.EditValue(context, provider, value);

            // assign the temporary collection from the UI to the property
            ((AppConfigs)context.Instance).Employees = (EmployeeCollection)result;

            return result;
        }
        protected override string GetDisplayText(object value)
        {
            Employee item = new Employee();
            item = (Employee)value;

            return base.GetDisplayText(string.Format("{0}", item.Username));
        }

    }
}
