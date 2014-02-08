using System;

public class Worker : Human
{
    private double workHoursPerDay;
    private double weekSalary;

    public Worker(string firstName, string secondName, double WorkHoursPerDay, double WeekSalary)
        : base(firstName, secondName)
    {
        this.WorkHoursPerDay = WorkHoursPerDay;
        this.WeekSalary = WeekSalary;
    }

    public double WorkHoursPerDay
    {
        get
        {
            return this.workHoursPerDay;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Work Hours Per Day can not be a negative number");
            }
            this.workHoursPerDay = value;
        }
    }

    public double WeekSalary
    {
        get
        {
            return this.weekSalary;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Week Salary can not be a negative number");
            }
            this.weekSalary = value;
        }
    }
    
    public double MoneyPerHour()
    {
        return this.weekSalary / this.workHoursPerDay;
    }
}

