//Write a method that finds the longest subsequence of equal numbers in given List<int> and returns the result as new List<int>. 
//Write a program to test whether the method works correctly.

namespace _04.LongestSubseqEqualNums
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LongestSubseqEqualNums
    {
        public static List<int> GetSubSequenceOfEqualNumbers(List<int> inputList)
        {
            List<int> answer = new List<int>();
            int indexOfStartOfSeq = 0;
            int numberOfSeqElements = 0;
            
            for (int i = 0; i < inputList.Count - 1; i++)
            {
                int currEqualElementsCount = 1;
                while (i < inputList.Count - 1 && inputList[i] == inputList[i+1])
                {
                    i++;
                    currEqualElementsCount++;
                }
                if (currEqualElementsCount > numberOfSeqElements)
                {
                    numberOfSeqElements = currEqualElementsCount;
                    indexOfStartOfSeq = i - numberOfSeqElements + 1;
                }
            }

            for (int i = indexOfStartOfSeq; i < indexOfStartOfSeq + numberOfSeqElements; i++)
            {
                answer.Add(inputList[i]);
            }

            return answer;
        }
        public static void Main()
        {
            List<int> test = new List<int>() {1,2,3,4,5,6,1,2,1,1,1,3 };

            List<int> answerr = GetSubSequenceOfEqualNumbers(test);

            Console.WriteLine(string.Join(", ",answerr));
        }
    }
}
