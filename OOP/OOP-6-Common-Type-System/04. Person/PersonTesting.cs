using System;

class PersonTesting
{
    static void Main()
    {
        Person personOne = new Person("Bai ivan");
        Console.WriteLine(personOne);

        personOne.Age = 7;
        Console.WriteLine(personOne);
    }
}

