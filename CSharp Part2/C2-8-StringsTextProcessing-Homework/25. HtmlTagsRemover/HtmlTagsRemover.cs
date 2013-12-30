
namespace _25.HtmlTagsRemover
{
    using System;
    using System.Text;

    class HtmlTagsRemover
    {
        static void Main(string[] args)
        {
            string source = @"<html>
  <head><title>News</title></head>
  <body><p><a href=""http://academy.telerik.com"">Telerik
    Academy</a>aims to provide free real-world practical
    training for young people who want to turn into
    skillful .NET software engineers.</p></body>
</html>";
            StringBuilder answer = new StringBuilder();
            for (int i = 0; i < source.Length; i++)
            {
                if (source[i] == '<')
                {
                    while (source[i] != '>')
                    {
                        i++;
                    }
                    continue;
                }
                answer.Append(source[i]);
            }
            Console.WriteLine(answer.ToString().Trim());
            Console.WriteLine();
        }
    }
}
