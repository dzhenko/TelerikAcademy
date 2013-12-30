using System;

public static class Extensions
{
    public static void WriteBlueLine(this string str)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine(str);
        Console.ResetColor();
    }
}
public class Program
{
    public static void Main()
    {
        string testMeIfYouCan = "Damn I went blue";
        testMeIfYouCan.WriteBlueLine();
    }
}

