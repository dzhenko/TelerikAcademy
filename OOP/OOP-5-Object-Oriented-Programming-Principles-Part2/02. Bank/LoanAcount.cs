public class LoanAcount : Acount, IAcountMoneyDepositable
{
    public LoanAcount(Customer customer, decimal balance, decimal interestRate)
        : base(customer, balance, interestRate) { }

    public void DepositMoney(decimal ammount)
    {
        this.Balance += ammount;
    }

    public override decimal CalculateInterestAmount(decimal periodInMonths)
    {
        if (periodInMonths < 0)
        {
            throw new System.ArgumentException("Period in months can not be a negative number!");
        }
        if (this.Customer is Individual)
        {
            periodInMonths -= 3;
        }
        else if (this.Customer is Company)
        {
            periodInMonths -= 2;
        }

        if (periodInMonths < 0)
        {
            return 0m;
        }
        return periodInMonths * ((this.InterestRate / 100) * this.Balance);
    }
}