
namespace _09._16.Students
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Group
    {
        private int groupNumber;
        private string departmentName;

        public Group(int currentGroupNumber, string currentDepartmentName)
        {
            this.GroupNumber = currentGroupNumber;
            this.DepartmentName = currentDepartmentName;
        }

        public int GroupNumber
        {
            get
            {
                return this.groupNumber;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ApplicationException("Group number must be > 0!");
                }
                this.groupNumber = value;
            }
        }

        public string DepartmentName
        {
            get
            {
                return this.departmentName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ApplicationException("Department name can not be null or empty !");
                }
                this.departmentName = value;
            }
        }
    }
}
