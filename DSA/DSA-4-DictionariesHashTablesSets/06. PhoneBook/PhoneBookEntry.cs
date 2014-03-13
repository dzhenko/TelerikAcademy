namespace _06.PhoneBook
{
    using System;

    public class PhoneBookEntry
    {
        private string name;
        private string town;
        private string phone;

        public PhoneBookEntry(string name, string town, string phone)
        {
            this.Name = name;
            this.Town = town;
            this.Phone = phone;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name can not be null or empty!");
                }

                this.name = value;
	        }
        }

        public string Town
        {
            get
            {
                return this.town;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("town can not be null or empty!");
                }

                this.town = value;
            }
        }

        public string Phone
        {
            get
            {
                return this.phone;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("phone can not be null or empty!");
                }

                this.phone = value;
            }
        }

        public override string ToString()
        {
            return string.Format(this.Name.PadLeft(14) + " | " + this.Town.PadLeft(14) + " | " + this.Phone.PadLeft(14));
        }

        public override bool Equals(object obj)
        {
            var objectAsEntry = obj as PhoneBookEntry;

            if (objectAsEntry == null)
            {
                return this == null;
            }

            if (this.Name != objectAsEntry.Name)
            {
                return false;
            }

            if (this.Town != objectAsEntry.Town)
            {
                return false;
            }

            if (this.Phone != objectAsEntry.Phone)
            {
                return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() ^ this.Phone.GetHashCode() ^ this.Town.GetHashCode();
        }
    }
}
