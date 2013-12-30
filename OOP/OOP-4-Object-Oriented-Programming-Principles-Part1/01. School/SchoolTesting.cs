using System;

class SchoolTesting
{
    static void Main()
    {
        School hogwards = new School();

        Class blackMagic = new Class("Black Magic");

        Teacher snape = new Teacher("Snape");

        snape.Comments = "brrrrr";

        Discipline blackStuffPractise = new Discipline("Black stuff and dark stuff",1,200);
        blackStuffPractise.Comments = "brr";

        snape.AddDiscipline(blackStuffPractise);

        blackMagic.AddTeacher(snape);

        hogwards.AddClass(blackMagic);

        foreach (var clas in hogwards.Classes)
        {
            foreach (var teach in clas.Teachers)
            {
                foreach (var disc in teach.Disciplines)
                {
                    Console.WriteLine(disc.Name);
                }
            }
        }




    }
}

