using System;

public abstract class Acount
{
    private Customer customer;
    private decimal balance;
    private decimal interestRate;

    public Acount(Customer AcountCustomer, decimal AcountBalance, decimal AcountInterestRate)
    {
        this.Customer = AcountCustomer;
        this.Balance = AcountBalance;
        this.InterestRate = AcountInterestRate;
    }

    public Customer Customer
    {
        get
        {
            return this.customer;
        }
        private set
        {
            if (value == null)
            {
                throw new ArgumentException("Customer can not be null");
            }
            this.customer = value;
        }
    }

    public decimal Balance { get { return this.balance; } set { this.balance = value; } }
    public decimal InterestRate { get { return this.interestRate; } set { this.interestRate = value; } }


    public virtual decimal CalculateInterestAmount(decimal periodInMonths)
    {
        if (periodInMonths < 0)
        {
            throw new System.ArgumentException("Period in months can not be a negative number!");
        }
        return periodInMonths * ((this.InterestRate / 100) * this.Balance);
    }
}