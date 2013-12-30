//Write a program that downloads a file from Internet (e.g. http://www.devbg.org/img/Logo-BASD.jpg) and stores 
//it the current directory. Find in Google how to download files in C#. Be sure to catch all exceptions and 
//to free any used resources in the finally block.

namespace _04.DownloadFile
{
    using System;
    using System.Net;

    class DownloadFile
    {
        static void Main()
        {
            using (WebClient webClient = new WebClient())
            {
                //string fileLocation = Console.ReadLine();
                //string fileName = Console.ReadLine();
                string fileLocation = "http://www.devbg.org/img/";
                string fileName = "Logo-BASD.jpg";
                try
                {
                    webClient.DownloadFile(fileLocation+fileName, "../../downloadedFile.jpg");
                }

                catch (WebException WE)
                {
                    throw new WebException("The address is invalid." + WE);
                }

                catch (Exception E)
                {
                    throw new Exception("" + E);
                }
            }
        }
    }
}
