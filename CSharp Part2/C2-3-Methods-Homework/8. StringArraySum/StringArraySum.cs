//Write a method that adds two positive integer numbers represented as arrays of digits 
//(each array element arr[i] contains a digit; the last digit is kept in arr[0]). 
//Each of the numbers that will be added could have up to 10 000 digits.



using System;

class StringArraySum
{
    static void arrayInput(int[] array, int whicharray,int size)
    {

        for (int i = 0; i < size; i++)
        {
            Console.Write("Enter digit {1} of Array {0} : ", whicharray,i);
            array[i] = int.Parse(Console.ReadLine());
        }
    }

    static void Main()
    {
        Console.Write("Enter array1 size: ");
        int size1 = int.Parse(Console.ReadLine());

        Console.Write("Enter array2 size: ");
        int size2 = int.Parse(Console.ReadLine());

        int[] arr1;
        int[] arr2;
        int bigger = 0;
        
        if (size1 >= size2)
        {
            arr1 = new int[size1];
            arr2 = new int[size1];
            bigger = size1;
        }
        else
        {
            arr1 = new int[size2];
            arr2 = new int[size2];
            bigger = size2;
        }

        arrayInput(arr1, 1, size1);
        arrayInput(arr2, 2, size2);

        int[] answer = new int[bigger + 1];
        bool carry = false;
        int curSum = 0;

        ArraySummer(arr1, arr2, bigger, answer, ref carry, ref curSum);

        PrintAnswer(arr1, arr2, answer);
    }

    private static void PrintAnswer(int[] arr1, int[] arr2, int[] answer)
    {
        foreach (var digit in arr1)
        {
            Console.Write(digit);
        }
        Console.WriteLine();
        foreach (var digit in arr2)
        {
            Console.Write(digit);
        }
        Console.WriteLine();
        foreach (var digit in answer)
        {
            Console.Write(digit);
        }
        Console.WriteLine();
    }

    private static void ArraySummer(int[] arr1, int[] arr2, int bigger, int[] answer, ref bool carry, ref int curSum)
    {
        for (int i = 0; i < bigger; i++)
        {
            curSum = arr1[i] + arr2[i];

            if (curSum > 9)
            {
                if (carry)
                {
                    answer[i] = curSum - 10 + 1;
                }
                else
                {
                    answer[i] = curSum - 10;
                    carry = true;
                }
            }
            else
            {
                if (carry)
                {
                    curSum++;
                    carry = false;
                    if (curSum == 10)
                    {
                        answer[i] = 0;
                        carry = true;
                    }
                    else
                    {
                        answer[i] = curSum;
                    }
                }
                else
                {
                    answer[i] = curSum;
                }
            }
        }
        if (carry)
        {
            answer[answer.Length - 1] = 1;
        }
    }
}