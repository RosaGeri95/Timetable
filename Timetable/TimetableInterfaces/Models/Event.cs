﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TimetableInterfaces.Models
{
    public class Event
    {
        private string eventName;
        private int priority;

        public int EventId { get; set; }

        //Ezt azért vettem fel, hogy tudjuk melyik felhasználóhoz tartozik az event
        //A MockCalendarService listEvents függvényéhez kell
        public User EventOwner { get; set; }

        public string EventName
        {
            get
            {
                return eventName;
            }
            set
            {
                if (value.Length > 20)
                {
                    throw new Exception("Name of event is too long!");
                }
                else if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Name of event cannot be empty!");
                }
                else
                {
                    eventName = value;
                }
            }
        }
        public string Description { get; set; }
        public string Location { get; set; }
        public int Priority
        {
            get { return priority; }
            set
            {
                //prioritás 1, 2, 3 lehessen?
                if (value >= 1 && value <= 3)
                {
                    priority = value;
                }
                else
                {
                    throw new Exception("Priority can be only between 1 and 3!");
                }
            }
        }
        public Category Category { get; set; }
        public List<EventDate> EventDates { get; set; }

        public override bool Equals(object obj)
        {
            Event other = (Event) obj;
            return this.EventId == other.EventId;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}
