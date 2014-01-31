namespace GsmClass
{
    using System;
    using System.Text;

    class Call
    {
        //private fields
        private DateTime dateTime;
        private string phoneNumber;
        private ulong duaration;

        //the only constructor - phonenumber and duaration needed
        public Call(string phonenumber, ulong duaration)
        {
            this.dateTime = DateTime.Now;//setting the private field (there is no setter)
            this.PhoneNumber = phonenumber;
            this.Duaration = duaration;
        }

        //property DateTime (readonly - setted in the constructor when instance is created (with DateTime.Now())
        public DateTime DateTime
        {
            get
            {
                return this.dateTime;
            }
        }

        //property PhoneNumber
        public string PhoneNumber
        {
            get
            {
                return this.phoneNumber;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ApplicationException("Phonenumber can not be null or empty!");
                }
                if ((value.Length != 10 && value.Length != 13) || (value[0] != '0' && value[0] != '+'))
                {
                    throw new ApplicationException("Phonenumber must be in format +359xxxxxxxxx OR 0xxxxxxxxx !");
                }
                this.phoneNumber = value;
            }
        }

        //property Duaration
        public ulong Duaration
        {
            get
            {
                return this.duaration;
            }
            set
            {
                if (value < 0)
                {
                    throw new ApplicationException("Duaration can not be a negative number!");
                }
                this.duaration = value;
            }
        }

        //better view for each call
        public override string ToString()
        {
            StringBuilder stringCreator = new StringBuilder();
            stringCreator.AppendFormat("{0} : Duaration - {1} , made on {2}", this.phoneNumber, this.duaration, this.dateTime);
            stringCreator.AppendLine();
            return stringCreator.ToString();
        }
    }
}
