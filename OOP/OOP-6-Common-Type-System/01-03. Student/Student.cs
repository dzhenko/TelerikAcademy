using System;
using System.Text;
using System.Reflection;

public class Student : ICloneable, IComparable<Student>
{
    private string firstName;
    private string secondName;
    private string familyName;
    private string adress;
    private ulong ssn;
    private string mobilePhone;
    private string email;
    private string course;
    private Speciality speciality;
    private Faculty faculty;
    private University university;

    public Student(string fname, string sname, string lname, string adress, ulong ssn, string mphone, string email
                            , string course, Speciality spec, Faculty fac, University uni)
    {
        this.FirstName = fname;
        this.SecondName = sname;
        this.FamilyName = lname;
        this.Adress = adress;
        this.SSN = ssn;
        this.MobilePhone = mphone;
        this.Email = email;
        this.Course = course;
        this.Speciality = spec;
        this.Faculty = fac;
        this.University = uni;
    }

    public string FirstName 
    { 
        get
        {
            return this.firstName;
        }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("First Name can not be null or empty!");
            }
            this.firstName = value;
        }
    }

    public string SecondName
    {
        get
        {
            return this.secondName;
        }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Second Name can not be null or empty!");
            }
            this.secondName = value;
        }
    }

    public string FamilyName
    {
        get
        {
            return this.familyName;
        }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Family Name can not be null or empty!");
            }
            this.familyName = value;
        }
    }

    public string Adress
    {
        get
        {
            return this.adress;
        }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Address can not be null or empty!");
            }
            this.adress = value;
        }
    }
    public ulong SSN
    {
        get
        {
            return this.ssn;
        }
        set
        {
            if (value.ToString().Length != 10 || value < 0)
            {
                throw new ArgumentException("SSN Must be a valid 10digit positive number!");
            }
            this.ssn = value;
        }
    }
    public string MobilePhone
    {
        get
        {
            return this.mobilePhone;
        }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Mobile Phone can not be null or empty!");
            }
            this.mobilePhone = value;
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
                throw new ArgumentException("Email can not be null or empty!");
            }
            this.email = value;
        }
    }

    public string Course
    {
        get
        {
            return this.course;
        }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Course can not be null or empty!");
            }
            this.course = value;
        }
    }

    public Speciality Speciality
    {
        get
        {
            return this.speciality;
        }
        set
        {
            if (value == null)
            {
                throw new ArgumentException("Speciality can not be null!");
            }
            this.speciality = value;
        }
    }

    public Faculty Faculty
    {
        get
        {
            return this.faculty;
        }
        set
        {
            if (value == null)
            {
                throw new ArgumentException("Faculty can not be null!");
            }
            this.faculty = value;
        }
    }

    public University University
    {
        get
        {
            return this.university;
        }
        set
        {
            if (value == null)
            {
                throw new ArgumentException("University can not be null!");
            }
            this.university = value;
        }
    }
    
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine(new string('-',45));

        var properties = this.GetType().GetProperties();

        foreach (var prop in properties)
        {
            sb.AppendFormat("{0} : {1}",prop.Name.PadLeft(15),prop.GetValue(this));
            sb.AppendLine();
        }

        sb.Append(new string('-', 45));

        return sb.ToString();
    }

    public override bool Equals(object obj)
    {
        if (obj as Student == null)
        {
            return false;
        }
        Student stud = obj as Student;
        if (! Object.Equals(this.FirstName,stud.FirstName))
        {
            return false;
        }
        if (!Object.Equals(this.SecondName, stud.SecondName))
        {
            return false;
        }
        if (!Object.Equals(this.FamilyName, stud.FamilyName))
        {
            return false;
        }
        if (!Object.Equals(this.SSN, stud.SSN))
        {
            return false;
        }
        if (!Object.Equals(this.Adress, stud.Adress))
        {
            return false;
        }
        if (!Object.Equals(this.MobilePhone, stud.MobilePhone))
        {
            return false;
        }
        if (!Object.Equals(this.Email, stud.Email))
        {
            return false;
        }
        if (!Object.Equals(this.Course, stud.Course))
        {
            return false;
        }
        if (!Object.Equals(this.University, stud.University))
        {
            return false;
        }
        if (!Object.Equals(this.Faculty, stud.Faculty))
        {
            return false;
        }
        if (!Object.Equals(this.Speciality, stud.Speciality))
        {
            return false;
        }
        return true;
    }

    public static bool operator ==(Student student1, Student student2)
    {
        return Student.Equals(student1, student2);
    }

    public static bool operator !=(Student student1, Student student2)
    {
        return !(Student.Equals(student1, student2));
    }

    public override int GetHashCode()
    {
        return this.SSN.GetHashCode() ^ this.FirstName.GetHashCode();
    }

    public object Clone()
    {
        return new Student(this.FirstName, this.SecondName, this.FamilyName, this.Adress, this.SSN, this.MobilePhone, this.Email
            , this.Course, this.Speciality, this.Faculty, this.University);
    }

    public int CompareTo(Student other)
    {
        if (this.FirstName != other.FirstName)
        {
            return this.FirstName.CompareTo(other.FirstName);
        }
        return this.SSN.CompareTo(other.SSN);
    }
}