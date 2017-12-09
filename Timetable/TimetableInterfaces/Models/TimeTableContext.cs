using Microsoft.EntityFrameworkCore;
using TimetableInterfaces.Models;

namespace TimeTableASP
{
    public class TimeTableContext:DbContext
    {
        public TimeTableContext(DbContextOptions<TimeTableContext> options) : base(options) {}

        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
