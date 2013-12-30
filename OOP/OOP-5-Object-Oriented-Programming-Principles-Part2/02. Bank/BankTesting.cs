using System;

class BankTesting
{
    static void Main()
    {
        Individual ivan = new Individual("Ivan");
        Company tech = new Company("Tech OOD");

        MortageAcount firstAcc = new MortageAcount(ivan, 1000, 3);

        MortageAcount mortAcc = new MortageAcount(tech, 20000, 10);

        Console.WriteLine(mortAcc.CalculateInterestAmount(10)); //10 months * 10% / 2 = 10months * 5% from 20 000 = 10 000

        Console.WriteLine(mortAcc.CalculateInterestAmount(24)); //12m * 5% from 20000 and 12m * 10 % from 20000 = 12*1000 + 12*2000 = 36 000 

        Console.WriteLine(firstAcc.CalculateInterestAmount(7)); //only 1 month (first 6 are no rate) * 3% from 1000 = 30

        DepositAcount depAcc = new DepositAcount(ivan, 700, 20);

        Console.WriteLine(depAcc.CalculateInterestAmount(99999)); // 0 - amount is 700 which is positive and less than 1000

        LoanAcount loanIndivid = new LoanAcount(ivan, 10000, 10);
        LoanAcount loanCompany = new LoanAcount(tech, 100000, 15);

        Console.WriteLine(loanIndivid.CalculateInterestAmount(3)); // 0 - free 3 months
        Console.WriteLine(loanIndivid.CalculateInterestAmount(4)); // free 3 months --> 1 * 10% from 10000 = 1000

        Console.WriteLine(loanCompany.CalculateInterestAmount(2)); // 0 - free 3 months
        Console.WriteLine(loanCompany.CalculateInterestAmount(4)); // free 2 months --> 2 * 15% from 100000 = 30000
    }
}

