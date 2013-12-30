//Write a program that replaces in a HTML document given as string all the tags <a href="…">…</a> with corresponding tags [URL=…]…/URL]. 
//Sample HTML fragment:
//<p>Please visit <a href="http://academy.telerik.com">our site</a> to choose a training course. 
//Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p>

//<p>Please visit [URL=http://academy.telerik.com]our site[/URL] to choose a training course. 
//Also visit [URL=www.devbg.org]our forum[/URL] to discuss the courses.</p>


namespace _15.ReplacingHrefTags
{

    using System;
    using System.Text;

    class ReplacingHrefTags
    {
        static void Main()
        {
            string originalText = "<p>Please visit <a href=\"http://academy.telerik.com\">our site</a> to choose a training course. Also visit <a href=\"www.devbg.org\">our forum</a> to discuss the courses.</p>";

            StringBuilder answer = new StringBuilder();

            string[] messages = originalText.Split(new string[] {"<a href","</a>"}, StringSplitOptions.None) ;

            foreach (var item in messages)
            {
                int indexOfLink = item.IndexOf("=\"");

                if (indexOfLink>=0)
                {
                    int endIndex = item.IndexOf("\">");
                    answer.Append("[URL=");
                    answer.Append(item.Substring(indexOfLink+2,endIndex-indexOfLink-2));
                    answer.Append("]");
                }
                else
                {
                    answer.Append(item);
                }
            }

            
            if (answer.Length == 0)
            {
                Console.WriteLine(originalText);
            }
            else
            {
                Console.WriteLine(answer.ToString());
            }
        }
    }
}
