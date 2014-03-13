namespace _06.PhoneBook
{
    using System;
    using System.IO;

    public class Testing
    {
        public const string PhonesPath = "phones.txt";
        public const string CommandsPath = "commands.txt";

        public static readonly PhoneBook Phonebook = new PhoneBook();

        public static void Main()
        {
            //Test();
            
            GeneratePhoneContacts(PhonesPath);

            ExecuteCommands(CommandsPath);
        }

        private static void ExecuteCommands(string commandsPath)
        {
            try
            {
                var reader = new StreamReader(commandsPath);

                using (reader)
                {
                    string currLine = reader.ReadLine();

                    while (currLine != null)
                    {
                        Console.WriteLine(currLine);
                        currLine = currLine.Substring(currLine.IndexOf('(') + 1).TrimEnd(')');

                        var commandTokens = currLine.Split(new char[] { ',',' ' }, StringSplitOptions.RemoveEmptyEntries);

                        if (commandTokens.Length == 1)
                        {
                            Console.WriteLine(Phonebook.Find(commandTokens[0]));
                        }
                        else
                        {
                            Console.WriteLine(Phonebook.Find(commandTokens[0],commandTokens[1]));
                        }

                        currLine = reader.ReadLine();
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Commands file not found!");
                Console.WriteLine("Press any key");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }

        private static void GeneratePhoneContacts(string phonesPath)
        {
            try
            {
                var reader = new StreamReader(phonesPath);

                using (reader)
                {
                    string currLine = reader.ReadLine();

                    while (currLine != null)
                    {
                        string[] entryTokens = currLine.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

                        string name = entryTokens[0].Trim();
                        string town = entryTokens[1].Trim();
                        string phone = entryTokens[2].Trim();

                        Phonebook.Add(name, town, phone);

                        currLine = reader.ReadLine();
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Phones file not found!");
                Console.WriteLine("Press any key");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }
        
        private static void Test()
        {
            var book = new PhoneBook();

            book.Add("Ivan", "1", "2");
            book.Add("Ivan Vankata", "3", "4");

            Console.WriteLine(book.Find("Ivan"));
            Console.WriteLine();
            Console.WriteLine(book.Find("Ivan", "3"));
        }
    }
}
