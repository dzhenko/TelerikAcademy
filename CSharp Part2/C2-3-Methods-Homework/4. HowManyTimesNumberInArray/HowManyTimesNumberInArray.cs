//Write a method that counts how many times given number appears in given array. 
//Write a test program to check if the method is working correctly.


using System;

class HowManyTimesNumberInArray
{
    static int Counter(int number, params int[] array)
    {
        int counter = 0;
        for (int i = 0; i < array.Length; i++)
		{
			 if (array[i] == number)
	         {
                 counter++;
	         }
		}
        return counter;
    }

    static int[] ArrayReader()
    {
        Console.Write("Enter array length: ");
        int arrayLength = int.Parse(Console.ReadLine());
        int[] arrayInput = new int[arrayLength];
        for (int i = 0; i < arrayLength; i++)
        {
            Console.Write("Enter "+(i+1)+" element : ");
            arrayInput[i] = int.Parse(Console.ReadLine());
        }
        return arrayInput;
    }

    static void Main()
    {
        Console.Write("Enter number: ");
        int inputNumber = int.Parse(Console.ReadLine());
        
        int[] arrayInput = ArrayReader();
        int counter = Counter(inputNumber, arrayInput);

        Console.WriteLine(counter);
        
    }
}

