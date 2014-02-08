namespace _18_19.StudentByGroup
{
    using System;

    public class Student
    {
        private string name;
        private string groupName;

        public Student(string StudentName, string StudentGroupName)
        {
            this.Name = StudentName;
            this.GroupName = StudentGroupName;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name can not be null or empty!");
                }
                this.name = value;
            }
        }

        public string GroupName
        {
            get
            {
                return this.groupName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name can not be null or empty!");
                }
                this.groupName = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} is in group {1}", this.Name, this.GroupName);
        }
    }
}
