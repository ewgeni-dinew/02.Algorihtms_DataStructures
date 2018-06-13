namespace EventManager.Engine
{
    using EventManager.Data;
    using Microsoft.EntityFrameworkCore;
    using System.Text;
    using System.Linq;
    using System;
    using EventManager.Models;

    public class Engine
    {
        private EventManagerContext db;

        public Engine()
        {
            this.db = new EventManagerContext();
            this.db.Database.EnsureCreated();
        }

        public string PrintAllEvents()
        {
            var sb = new StringBuilder();

            var events = db.Events
                .Select(e => e)
                .OrderBy(e => e.Id)
                .ToList();

            foreach (var e in events)
            {
                sb.AppendLine($"Name: {e.Name}; Location: {e.Location}; {e.StartDate} - {e.EndDate}");
            }

            return sb.ToString();
        }

        public void Create(string[] args)
        {
            var eventName = args[0];
            var eventLocation = args[1];
            var validStartDate = DateTime.TryParse(args[2], out DateTime eventStartDate);
            var validEndDate = DateTime.TryParse(args[3], out DateTime eventEndDate);

            if (DBContainsEvent(eventName))
            {
                throw new ArgumentException(Exceptions.alreadyExistingEventMsg);
            }
            else if (validStartDate == false)
            {
                throw new ArgumentException(Exceptions.invalidStartDate);
            }
            else if (validEndDate == false)
            {
                throw new ArgumentException(Exceptions.invalidEndDate);
            }
            else
            {
                var currentEvent = new Event()
                {
                    Name = eventName,
                    Location = eventLocation,
                    StartDate = eventStartDate,
                    EndDate = eventEndDate
                };

                db.Events.Add(currentEvent);
                db.SaveChanges();
            }
        }

        public void Update(string[] args)
        {
            var eventName = args[0];

            var currentEvent = DBFindEvent(eventName);

            if (currentEvent == null)
            {
                throw new ArgumentException(Exceptions.nonExistingEventMsg);
            }
            else
            {
                var eventLocation = args[1];
                var validStartDate = DateTime.TryParse(args[2], out DateTime eventStartDate);
                var validEndDate = DateTime.TryParse(args[3], out DateTime eventEndDate);

                if (validStartDate == false)
                {
                    throw new ArgumentException(Exceptions.invalidStartDate);
                }
                else if (validEndDate == false)
                {
                    throw new ArgumentException(Exceptions.invalidEndDate);
                }

                currentEvent.Location = eventLocation;
                currentEvent.StartDate = eventStartDate;
                currentEvent.EndDate = eventEndDate;

                db.SaveChanges();
            }
        }

        public void Delete(string eventName)
        {
            var currentEvent = DBFindEvent(eventName);

            if (currentEvent == null)
            {
                throw new ArgumentException(Exceptions.nonExistingEventMsg);
            }
            else
            {
                db.Remove(currentEvent);
                db.SaveChanges();
            }
        }

        private Event DBFindEvent(string eventName)
        {
            return db.Events.FirstOrDefault(e => e.Name.Equals(eventName));
        }

        private bool DBContainsEvent(string eventName)
        {
            return db.Events.Any(e => e.Name.Equals(eventName));
        }
    }
}
