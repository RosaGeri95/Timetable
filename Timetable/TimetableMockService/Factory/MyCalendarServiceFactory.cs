using System;
using System.Collections.Generic;
using System.Text;
using TimetableInterfaces.Interfaces;
using TimetableInterfaces.Models;
using TimetableMockService.MockServices;
using TimetableService.Service;

namespace TimetableMockService.Factory
{
    public class MyCalendarServiceFactory : ACalendarServiceFactory
    {
        public override ICalendarService CreateCalendarService(string type)
        {
            switch (type)
            {

                case "MCS":
                    return  new MockCalendarService();//TODO: Ezt vissza kell írni sima new-ra 
                case "CS":
                    return new CalendarService();
                default:
                    throw new Exception(string.Format("Calendar service '{0}' cannot be created", type));

            }
        }
    }
}
