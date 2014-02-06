namespace _09._16.Students
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class ExtensionMethods
    {
        public static List<Student> GetListOfStudentsInExactGroup(this List<Student> list, int groupNum)
        {
            IOrderedEnumerable<Student> studentsFromSpecificGroup =
                                                    from student in list
                                                    where student.GroupNumber == groupNum
                                                    orderby student.FirstName
                                                    select student;

            return studentsFromSpecificGroup.ToList();
        }

        public static List<Student> GetListOfStudentsWithNumberOfMarks(this List<Student> list, int mark, int number)
        {
            var studentsToReturn =
                                                    from student in list
                                                    where student.Marks.Count(x=>x==mark) == number
                                                    select student;

            return studentsToReturn.ToList();
        }
    }
}
