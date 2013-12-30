public class DepositAcount : Acount,IAcountMoneyDepositable,IAcountMoneyDrawable
{
    public DepositAcount(Customer customer, decimal balance , decimal interestRate)
        : base(customer, balance, interestRate) 
    {
        if (this.Balance > 0 && this.Balance < 1000)
        {
            this.InterestRate = 0;
        }
    }

    public void DepositMoney(decimal ammount)
    {
        this.Balance += ammount;
    }

    public void DrawMoney(decimal ammount)
    {
        this.Balance -= ammount;
    }
}