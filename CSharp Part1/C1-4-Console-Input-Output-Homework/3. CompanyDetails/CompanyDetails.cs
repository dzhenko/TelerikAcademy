//A company has name, address, phone number, fax number, web site and manager. 
//The manager has first name, last name, age and a phone number. 
//Write a program that reads the information about a company and its manager and prints them on the console.


using System;

class CompanyDetails
{
    static void Main()
    {
        //addins
        Console.WriteLine();
        Console.WriteLine(new string ('-',15));
        Console.WriteLine("Company Details");
        Console.WriteLine(new string ('-',15));
        //info
        Console.WriteLine("Company name :");
        string companyName = Console.ReadLine();
        Console.WriteLine("Company address :");
        string companyAddress = Console.ReadLine();
        Console.WriteLine("Company phone Number :");
        string companyPhone = Console.ReadLine();
        Console.WriteLine("Company fax number :");
        string companyFax = Console.ReadLine();
        Console.WriteLine("Company web site :");
        string companyWeb = Console.ReadLine();
        Console.WriteLine("Company manager :");
        string companyManager = Console.ReadLine();
        //addins
        Console.WriteLine();
        Console.WriteLine(new string ('-',15));
        Console.WriteLine("Manager Details");
        Console.WriteLine(new string ('-',15));
        //info
        Console.WriteLine("Manager's first name :");
        string managerFName = Console.ReadLine();
        Console.WriteLine("Manager's last name :");
        string managerLName = Console.ReadLine();
        Console.WriteLine("Manager's age :");
        string managerAge = Console.ReadLine();
        Console.WriteLine("Manager's phone number :");
        string managerPhone = Console.ReadLine();
        //addins
        Console.WriteLine();
        Console.WriteLine(new string('-', 15));
        Console.WriteLine("Summary : ");
        Console.WriteLine(new string('-', 15));
        Console.WriteLine("The company's name is {0}. It is located at {1}. For contacts use the phone number"+
            " {2} or the fax {3}. {0}'s website is {4}. The manager is {5}. His first name is {6} and his "+
            "last name is {7}. He is {8} years old and his phone number is {9}",companyName,companyAddress,
            companyPhone,companyFax,companyWeb,companyManager,managerFName,managerLName,managerAge,managerPhone);
    }
}