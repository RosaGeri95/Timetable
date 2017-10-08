using System;
using System.Collections.Generic;
using System.Text;
using TimetableInterfaces.Interfaces;

namespace TimetableMockService.Factory
{
    public abstract class ACalendarServiceFactory
    {
        public abstract ICalendarService CreateCalendarService(string type);
    }
}
