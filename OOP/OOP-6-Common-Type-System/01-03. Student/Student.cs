using System;

public class Student : ICloneable, IComparable<Student>
{
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public string FamilyName { get; set; }

    public string Adress { get; set; }
    public int SSN { get; set; }
    public string MobilePhone { get; set; }
    public string Email { get; set; }

    public string Course { get; set; }
    public Speciality Speciality { get; set; }
    public Faculty Faculty { get; set; }
    public University University { get; set; }

    public Student(string fname,string sname,string lname,string adress,int ssn,string mphone, string email
                            ,string course , Speciality spec , Faculty fac , University uni)
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

    public override string ToString()
    {
        return string.Format("{0} {1} {2} from {3} with SSN {4} MobilePhone {5} and Email {6} taking {7} course is currently studying {8} in the faculty of {9} in {10} University"
            ,this.FirstName,this.SecondName,this.FamilyName,this.Adress,this.SSN,this.MobilePhone,this.Email
            ,this.Course,this.Speciality,this.Faculty,this.University);
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