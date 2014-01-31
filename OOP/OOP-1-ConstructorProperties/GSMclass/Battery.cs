namespace GsmClass
{
    using System;

    public class Battery
    {
        //fields
        private string model;
        private uint hoursTalk;
        private uint hoursIdle;
        private Type batteryType;

        //preset values
        private const string defaultModel = "UnnamedModel";
        private const uint defaultHoursTalk = 100;
        private const uint defaultHoursIdle = 200;
        private const Type defaultBatteryType = Type.AlienTech;

        //enum for BatteryTypes // not in a seperate class because only this class uses it
        public enum Type
        {
            LiIon, NiMH, NiCd, LiPo, AlienTech
        }


        //empty constructor with preset values
        public Battery()
            : this(defaultModel, defaultHoursTalk, defaultHoursIdle, defaultBatteryType) { }

        //full constructor
        public Battery(string model, uint hoursTalk, uint hoursIdle, Type batteryType)
        {
            this.Model = model;
            this.HoursTalk = hoursTalk;
            this.HoursIdle = hoursIdle;
            this.BatteryType = batteryType;
        }

        //propertiy model
        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ApplicationException("Battery model can NOT be null or empty!");
                }
                this.model = value;
            }
        }

        //propertiy hoursTalk
        public uint HoursTalk
        {
            get
            {
                return this.hoursTalk;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ApplicationException("Hours of talk time must be > 0!");
                }
                this.hoursTalk = value;
            }
        }

        //propertiy hoursIdle
        public uint HoursIdle
        {
            get
            {
                return this.hoursIdle;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ApplicationException("Hours of talk time must be > 0!");
                }
                this.hoursIdle = value;
            }
        }

        //propertiy BatteryType
        public Type BatteryType
        {
            get
            {
                return this.batteryType;
            }
            set
            {
                this.batteryType = value;
            }
        }
    }
}
