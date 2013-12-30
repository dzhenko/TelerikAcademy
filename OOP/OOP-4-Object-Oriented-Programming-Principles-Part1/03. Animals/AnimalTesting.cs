using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class AnimalsTesting
{
    public static Random rnd = new Random();
    
    public static void Main()
    {
        TestCreatures();

        Cat[] catArr = FillCatArr();
        Dog[] dogArr = FillDogArr();
        Frog[] frogArr = FillFrogArr();
        Kitten[] kitArr = FillKittenArr();
        Tomcat[] tomArr = FillTomArr();

       decimal averageAgeCats = Animal.AverageAge(catArr);
       decimal averageAgeDogs = Animal.AverageAge(dogArr);
       decimal averageAgeFrogs = Animal.AverageAge(frogArr);
       decimal averageAgeKittens = Animal.AverageAge(kitArr);
       decimal averageAgeTomcats = Animal.AverageAge(tomArr);

        Console.WriteLine("---------- Average ages ----------");
        Console.WriteLine("Cats " + averageAgeCats);
        Console.WriteLine("Dogs " + averageAgeDogs);
        Console.WriteLine("Frogs " + averageAgeFrogs);
        Console.WriteLine("Kittens " + averageAgeKittens);
        Console.WriteLine("Tomcats " + averageAgeTomcats);
    }
    
    public static Tomcat[] FillTomArr()
    {
        var tomArr = new Tomcat[rnd.Next(5, 21)];
        for (int i = 0; i < tomArr.Length; i++)
        {
            tomArr[i] = new Tomcat(GetRandomName(), rnd.Next(1, 16));
        }
        return tomArr;
    }

    public static Kitten[] FillKittenArr()
    {
        var kitArr = new Kitten[rnd.Next(5, 21)];
        for (int i = 0; i < kitArr.Length; i++)
        {
            kitArr[i] = new Kitten(GetRandomName(), rnd.Next(1, 16));
        }
        return kitArr;
    }

    public static Frog[] FillFrogArr()
    {
        var frogArr = new Frog[rnd.Next(5, 21)];
        for (int i = 0; i < frogArr.Length; i++)
        {
            frogArr[i] = new Frog(GetRandomName(), rnd.Next(1, 16), rnd.Next(1, 3) == 1 ? true : false);
        }
        return frogArr;
    }

    public static Dog[] FillDogArr()
    {
        var dogArr = new Dog[rnd.Next(5, 21)];
        for (int i = 0; i < dogArr.Length; i++)
        {
            dogArr[i] = new Dog(GetRandomName(), rnd.Next(1, 16), rnd.Next(1, 3) == 1 ? true : false);
        }
        return dogArr;
    }

    public static Cat[] FillCatArr()
    {
        var catArr = new Cat[rnd.Next(5, 21)];
        for (int i = 0; i < catArr.Length; i++)
        {
            catArr[i] = new Cat(GetRandomName(), rnd.Next(1, 16), rnd.Next(1, 3) == 1 ? true : false);
        }
        return catArr;
    }

    public static void TestCreatures()
    {
        Dog charlie = new Dog("Charlie", 4, true);
        Console.WriteLine(charlie);
        charlie.ProduceSound();

        Console.WriteLine();

        Frog quackster = new Frog("Rab", 1, false);
        Console.WriteLine(quackster);
        quackster.ProduceSound();

        Console.WriteLine();

        Cat miew = new Cat("Dangleton", 3, false);
        Console.WriteLine(miew);
        miew.ProduceSound();

        Console.WriteLine();

        Kitten kitty = new Kitten("KittyCat", 3);
        Console.WriteLine(kitty);
        kitty.ProduceSound();

        Console.WriteLine();

        Tomcat tom = new Tomcat("Tom", 2);
        Console.WriteLine(tom);
        tom.ProduceSound();
    }

    public static string GetRandomName()
    {
        StringBuilder name = new StringBuilder();
        name.Append((char)rnd.Next(65, 91));
        for (int i = 0; i < rnd.Next(2, 6); i++)
        {
            name.Append((char)rnd.Next(97, 123));
        }

        return name.ToString();
    }
}

