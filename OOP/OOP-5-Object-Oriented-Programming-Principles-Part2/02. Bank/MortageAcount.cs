public class MortageAcount : Acount, IAcountMoneyDepositable
{
    public MortageAcount(Customer customer, decimal balance, decimal interestRate)
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
            periodInMonths -= 6;
        }
        else if (this.Customer is Company)
        {
            if (periodInMonths <= 12)
            {
                periodInMonths /= 2;
            }
            else
            {
                periodInMonths -= 6;
            }
        }
        if (periodInMonths < 0)
        {
            return 0m;
        }
        return periodInMonths * ((this.InterestRate / 100) * this.Balance);
    }
}