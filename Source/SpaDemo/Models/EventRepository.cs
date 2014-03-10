using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaDemo.Models
{
    public class EventRepository
    {
        public List<Event> events = new List<Event>();
        private int _nextId = 1;

        public EventRepository()
        {
            Add(new Event
            {
                Title = "To build a modern SPA!",
                Description = "What a SPA is? How to quickly build it with open source frameworks? Let's see! ",
                Start = DateTime.Parse("03/10/2014 10:00:00"),
                End = DateTime.Parse("03/10/2014 11:30:00"),
                Owner = "Jesse Liu",
                Status = EventStatus.Openning,
            });
            Add(new Event
            {
                Title = "Let's have dinner together!",
                Description = "",
                Start = DateTime.Parse("03/11/2014 18:30:00"),
                End = DateTime.Parse("03/11/2014 20:00:00"),
                Owner = "Lei Zhang",
                Status = EventStatus.Openning,
            });
            Add(new Event
            {
                Title = "Script sharing",
                Description = "There is no sharing at all!",
                Start = DateTime.Parse("03/13/2014 10:00:00"),
                End = DateTime.Parse("03/13/2014 11:30:00"),
                Owner = "Chloe Cheng",
                Status = EventStatus.Openning,
            });
            Add(new Event
            {
                Title = "Go Shopping!",
                Description = "Go GO GO !",
                Start = DateTime.Parse("03/16/2014 10:00:00"),
                End = DateTime.Parse("03/16/2014 11:30:00"),
                Owner = "Carol Cao",
                Status = EventStatus.Openning,
            });
        }

        public IEnumerable<Event> GetAll()
        {
            return events;
        }

        public Event Get(int id)
        {
            return events.Find(p => p.Id == id);
        }

        public Event Add(Event item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            item.Id = _nextId++;
            events.Add(item);
            return item;
        }

        public void Remoev(int id)
        {
            events.RemoveAll(p => p.Id == id);
        }

        public bool Update(Event item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            int index = events.FindIndex(e => e.Id == item.Id);
            if (index == -1)
            {
                return false;
            }

            events.RemoveAt(index);
            events.Add(item);
            return true;
        }



    }
}