using System;
using System.Linq;
using TimetableInterfaces.Models;

namespace TimeTableASP.Data
{
    public class DbInitializer
    {
        public static void Initialize(TimeTableContext context)
        {
            context.Database.EnsureCreated();

           
            if (context.Users.Any())
            {
                return;  
            }

            var users = new User[]
           {
            new User{Username="Adrian",Password="p4jk",ParitySourceDate=DateTime.Parse("2005-09-01")}

           };
            foreach (User s in users)
            {
                context.Users.Add(s);
            }
            context.SaveChanges();

            var categories = new Category[]
            {
            new Category{Name="Lecture",Colour=1},
            new Category{Name="Exam",Colour=2},
            new Category{Name="Other",Colour=0}
            };
            
            context.Categories.AddRange(categories);

            context.SaveChanges();

            var events = new Event[]
            {
                new Event{EventOwner=users[0],Category = categories[0],EventName="Témalabor",Description="konzultáció",Location="QB202",
                          Priority =1,Parity=0,Day=1,
                          StartDate= new TimeSpan(11,0,0),EndDate=new TimeSpan(12,30,0) },

                new Event{EventOwner=users[0],Category = categories[1],EventName="Mobil",Description="Mobil és webes szoftverek",Location="IB028",
                          Priority =1,Parity=1,Day=3,
                          StartDate= new TimeSpan(8,0,0),EndDate=new TimeSpan(11,30,0) },

                new Event{EventOwner=users[0],Category = categories[2],EventName="Adatbázisok",Description="Laboratóriumi foglalkozás",Location="R4P",
                          Priority =1,Parity=2,Day=5,
                          StartDate= new TimeSpan(14,0,0),EndDate=new TimeSpan(18,0,0) }
            };

          
            context.Events.AddRange(events);

            context.SaveChanges();

            
            
        }
    }
}

