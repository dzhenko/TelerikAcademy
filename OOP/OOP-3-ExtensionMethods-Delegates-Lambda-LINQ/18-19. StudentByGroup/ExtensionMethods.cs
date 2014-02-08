namespace _18_19.StudentByGroup
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class ExtensionMethods
    {
        public static Student[] OrderByGroupName(this IEnumerable<Student> listOfStudents)
        {
            return listOfStudents.OrderBy(x => x.GroupName).ToArray();
        }
    }
}
