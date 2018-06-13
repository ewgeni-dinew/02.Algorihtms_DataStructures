namespace EventManager.Models
{
    using System;
    using System.Linq;

    public class Event
    {
        private int id;

        public int Id
        {
            get { return id; }
            private set { id = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(Exceptions.invalidNameString);
                }
                else if (value.Length < 3)
                {
                    throw new ArgumentException(Exceptions.invalidNameLength);
                }
                else if (value.All(c => !char.IsLetter(c)) || value.Where(c => char.IsLetter(c)).Count() < 3)
                {
                    throw new ArgumentException(Exceptions.invalidNameSymbols);
                }
                name = value;
            }
        }

        private string location;

        public string Location
        {
            get { return location; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(Exceptions.invalidLocationString);
                }
                else if (value.Length < 3)
                {
                    throw new ArgumentException(Exceptions.invalidLocationLength);
                }

                location = value;
            }
        }

        private DateTime startDate;

        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }

        private DateTime endDate;

        public DateTime EndDate
        {
            get { return endDate; }
            set
            {
                if (value <= this.StartDate)
                {
                    throw new ArgumentException(Exceptions.invalidEndDate);
                }
                endDate = value;
            }
        }
    }
}
