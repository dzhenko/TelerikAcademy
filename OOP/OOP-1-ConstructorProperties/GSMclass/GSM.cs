using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public class GSM
{
    //private constant callPrice
    private const decimal callPricePerSecond = 0.006m;

    //private constants
    private const decimal defaultPrice = 1800;
    private const string defaultOwner = "JCorp";

    //private fields
    private string model;
    private string manufacturer;
    private decimal price;
    private string owner;
    private Battery battery;
    private Display display;

    //iphone4S private field
    private static readonly GSM iphone4S = new GSM("Iphone 4S", "Apple", 1300.00m, "Globul",
                                                new Battery("Apple", 8, 200, Battery.Type.LiPo),
                                                new Display(960, 640, 16000000));

    //default constructor with only model and manufacturer (can not be empty)
    public GSM(string model, string manufacturer)
        : this(model, manufacturer, defaultPrice, defaultOwner, new Battery(), new Display()) { }

    //constructor with full arguments
    public GSM(string model, string manufacturer, decimal price, string owner, Battery battery, Display display)
    {
        this.Model = model;
        this.Manufacturer = manufacturer;
        this.Price = price;
        this.Owner = owner;
        this.Battery = battery;
        this.Display = display;
    }

    //property model
    public string Model
    {
        get { return model; }
        set 
        {
            if (string.IsNullOrEmpty(value))
	        {
                throw new ArgumentException("Model can NOT be null or empty!");
	        }
            this.model = value; 
        }
    }

    //property manufacturer
    public string Manufacturer
    {
        get { return manufacturer; }
        set 
        {
            if (string.IsNullOrEmpty(value))
	        {
                throw new ArgumentException("Manufacturer can NOT be null or empty!");
	        }
            this.manufacturer = value; 
        }
    }

    //property price
    public decimal Price
    {
        get { return price; }
        set 
        {
            if (value < 0)
            {
                throw new ArgumentException("Price can NOT be a negative number!");
            }
            this.price = value; 
        }
    }

    //property owner
    public string Owner
    {
        get { return owner; }
        set 
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Owner can NOT be null or empty!");
            }
            this.owner = value; 
        }
    }

    //property battery
    public Battery Battery
    {
        get { return battery; }
        set { this.battery = value; } //data validity checked in battery class
    }

    //property display
    public Display Display
    {
        get { return display; }
        set { this.display = value; } //data validity checked in display class
    }
        
    //static IPhone4S getter
    public static GSM IPhone4S
    {
        get
        {
            return iphone4S;
        }
    }

    //ToString override
    public override string ToString()
    {
        StringBuilder stringCreator = new StringBuilder();
        stringCreator.Append("GSM Specifications:");
        stringCreator.Append(" ");
        stringCreator.AppendLine(new string ('-',90));
        stringCreator.AppendFormat("GSM Model - {0}",this.model);
        stringCreator.AppendLine();
        stringCreator.AppendFormat("GSM Manufacturer - {0}", this.manufacturer);
        stringCreator.AppendLine();
        stringCreator.AppendFormat("GSM Price - {0}", this.price);
        stringCreator.AppendLine();
        stringCreator.AppendFormat("GSM Owner - {0}", this.owner);
        stringCreator.AppendLine();
        stringCreator.AppendFormat("GSM Battery Specifications : Model - {1} , Type - {0} , talk time - {2} , idle time - {3}"
                      , this.Battery.BatteryType,this.Battery.Model, this.Battery.HoursTalk, this.Battery.HoursIdle);
        stringCreator.AppendLine();
        stringCreator.AppendFormat("GSM Display Specifications : Height - {0} , Width - {1} , Number of Colors - {2}",
                        this.Display.Height,this.Display.Width,this.Display.NumberOfColors);
        stringCreator.AppendLine();
        stringCreator.AppendLine(new string('-', 110));

        return stringCreator.ToString();
    }

    //callhistory list
    private List<Call> CallHistory = new List<Call>();

    //add call method (takes number as a string and duaration - dateTime is always NOW)
    public void AddCall(string currPhoneNumber, ulong currDuaration)
    {
        this.CallHistory.Add(new Call(currPhoneNumber, currDuaration));
    }

    //remove call - takes a position from the ShowCallHistoryMethod - starts count from 1 not 0 for more user friendly interface
    public void DeleteCall(int position)
    {
        if ((this.CallHistory.Count <= position - 1) || (position - 1 < 0))
        {
            throw new ArgumentException("Such call history log does not exist!");
        }
        this.CallHistory.RemoveAt(position - 1);
    }

    //adds an index so users can choose which call to delete
    public void ShowCallHistory()
    {
        int indexer = 1;
        foreach (var call in this.CallHistory)
        {
            Console.Write(indexer++);
            Console.Write(" ---> ");
            Console.WriteLine(call.ToString());
        }
    }

    //clears the list
    public void ClearCallHistory()
    {
        this.CallHistory.Clear();
    }

    //itterates trough all the calls and sums them
    public decimal TotalCallPrice()
    {
        ulong allDuaration = 0;
        foreach (var call in this.CallHistory)
        {
            allDuaration += call.Duaration;
        }

        return allDuaration * callPricePerSecond;
    }
}
