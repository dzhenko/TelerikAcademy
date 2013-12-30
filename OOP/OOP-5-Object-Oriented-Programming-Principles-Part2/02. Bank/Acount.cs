public abstract class Acount
{
    private Customer customer;
    private decimal balance;
    private decimal interestRate;

    public Customer Customer { get { return this.customer; }  }
    public decimal Balance { get { return this.balance; } set { this.balance = value; } }
    public decimal InterestRate { get { return this.interestRate; } set { this.interestRate = value; } }

    public Acount(Customer cstmr , decimal bal , decimal intr)
    {
        this.customer = cstmr;
        this.Balance = bal;
        this.InterestRate = intr;
    }

    public virtual decimal CalculateInterestAmount(decimal periodInMonths)
    {
        if (periodInMonths < 0)
        {
            throw new System.ArgumentException("Period in months can not be a negative number!");
        }
        return periodInMonths * ((this.InterestRate / 100) * this.Balance);
    }
}