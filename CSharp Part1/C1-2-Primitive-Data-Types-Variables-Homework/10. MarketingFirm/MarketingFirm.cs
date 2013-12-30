using System;

class MarketingFirm
{
    static void Main()
    {
        string firstName = "Pesho";
        string familyName = "Georgiev";
        byte age = 34;
        char gender ='m';
        ulong ID = 8610234953;  //too big for an int
        int UEN = 27564985;
        Console.WriteLine("Employee Name is {0} {1} .He is {2} years old. His gender is {3}. His ID is {4} and his Unique Employee Number is {5}",
            firstName,familyName,age,gender,ID,UEN);
    }
}

