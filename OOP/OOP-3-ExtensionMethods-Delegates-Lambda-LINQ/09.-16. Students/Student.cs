namespace _09._16.Students
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Reflection;

    public class Student
    {
        private string firstName;
        private string lastName;
        private string fn;
        private string tel;
        private string email;
        private List<int> marks;
        private int groupNumber;
        
        public Student(string fName,string lName, string fn, string tel, string email, int groupNum, params int[] inputMarks)
        {
            this.FirstName = fName;
            this.LastName = lName;
            this.FacultyNumber = fn;
            this.Telephone = tel;
            this.Email = email;
            this.GroupNumber = groupNum;
            this.marks = new List<int>(inputMarks);
        }

        public Group Group { get; set; }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("First name can not be null or empty !");
                }
                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Last name can not be null or empty !");
                }
                this.lastName = value;
            }
        }

        public string FacultyNumber
        {
            get
            {
                return this.fn;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Faculty number can not be null or empty !");
                }
                if (!Regex.IsMatch(value,@"([0-9]{8})"))
                {
                    throw new ApplicationException("Faculty number is a 8 digits number !");
                }
                this.fn = value;
            }
        }

        public string Telephone
        {
            get
            {
                return this.tel;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Telephones can not be null or empty !");
                }
                if (!Regex.IsMatch(value, @"(\+359[0-9]{9})") && !Regex.IsMatch(value, @"(0[0-9]{9})"))
                {
                    throw new ApplicationException("Telephones begin with +359 / 0 followed by 9 digits !");
                }
                this.tel = value;
            }
        }

        public string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Email can not be null or empty !");
                }
                if (!Regex.IsMatch(value, @"(\w+@\w+.\w+)"))
                {
                    throw new ApplicationException("Email must be valid !");
                }
                this.email = value;
            }
        }

        public int GroupNumber
        {
            get
            {
                return this.groupNumber;
            }
            set
            {
                if (value < 1)
                {
                    throw new ApplicationException("Group number must be > 0 !");
                }
                this.groupNumber = value;
            }
        }

        public List<int> Marks
        {
            get
            {
                return new List<int>(this.marks);
            }
        }

        public void AddMark(int currMark)
        {
            if (currMark < 1 || currMark > 6)
            {
                throw new ApplicationException("Marks are between 1 and 6 !");
            }
            this.marks.Add(currMark);
        }

        public void RemoveMarkAtPosition(int position)
        {
            if (position < 0 || position >= this.marks.Count)
            {
                throw new ApplicationException("No such position");
            }
            this.marks.RemoveAt(position);
        }

        public void RemoveMark(int currMark)
        {
            if (!this.marks.Contains(currMark))
            {
                throw new ApplicationException("No such mark");
            }
            this.marks.Remove(currMark);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            
            //using reflection to get all the properties by name and value
            var properties = this.GetType().GetProperties();

            sb.AppendLine(new string('-', 40));

            foreach (var property in properties)
            {
                if (property.Name == "Marks" || property.Name == "Group")
                {
                    continue;
                }
                sb.AppendFormat("{0}: {1}", property.Name.PadLeft(15), property.GetValue(this, null));
                sb.AppendLine();
            }

            sb.Append("Marks: ".PadLeft(17));
            sb.AppendFormat(string.Join(", ", this.Marks));

            return sb.ToString();
        }
    }
}
