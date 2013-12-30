//Write a program that removes from a text file all words listed in given another text file. 
//Handle all possible exceptions in your methods.

using System.IO;
using System;
using System.Collections.Generic;
using System.Text;

class RemoveWordsInAFileFromAnotherFile
{
    static StreamReader originalText = new StreamReader(@"..\..\input.txt");
    static StreamReader wordsToRemove = new StreamReader(@"..\..\remove.txt");
    static List<string> removeWords = new List<string>();
    static StringBuilder answer = new StringBuilder();

    static void Main()
    {
        GenerateWordsToRemove();

        RemoveWordsInANewList();

        WriteAnswerOnFile();
    }

    private static void WriteAnswerOnFile()
    {
        StreamWriter writeAnswer = new StreamWriter(@"..\..\input.txt");
        string answerToWrite = answer.ToString();
        try
        {
            writeAnswer.WriteLine(answerToWrite);
        }
        catch (FileNotFoundException)
        {
            throw new ArgumentException("File was not found!");
        }
        catch
        {
            Console.WriteLine("Something Else is wrong!");
        }
        finally
        {
            writeAnswer.Close();
        }
    }

    private static void RemoveWordsInANewList()
    {
        string removeLine = null;
        try
        {
            removeLine = originalText.ReadLine();
        }
        catch (FileNotFoundException)
        {
            throw new ArgumentException("File was not found!");
        }
        catch
        {
            Console.WriteLine("Something Else is wrong!");
        }
        finally
        {
            originalText.Close();
        }

        while (removeLine != null)
        {
            string[] wordsInLine = removeLine.Split();
            foreach (string word in wordsInLine)
            {
                if (!removeWords.Contains(word))
                {
                    answer.Append(word);
                    answer.Append(" ");
                }
            }
            removeLine = originalText.ReadLine();
        }

        originalText.Close();
    }

    private static void GenerateWordsToRemove()
    {
        string removeLine = null;
        try
        {
            removeLine = wordsToRemove.ReadLine();
        }
        catch (FileNotFoundException)
        {
            throw new ArgumentException("File was not found!");
        }
        catch
        {
            Console.WriteLine("Something Else is wrong!");
        }
        finally
        {
            wordsToRemove.Close();
        }

        while (removeLine != null)
        {
            removeWords.Add(removeLine);
            removeLine = wordsToRemove.ReadLine();
        }
        wordsToRemove.Close();
    }
}

