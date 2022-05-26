using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WeddingPlanner.Models
{
    public class WeddingPlannerContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public WeddingPlannerContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get;set; }
        public DbSet<Wedding> Weddings { get;set; }
        public DbSet<RSVP> RSVPs { get;set; }


        // method to get Users' RSVPed weddings
        public List<Wedding> getRSVPedWeddings(int UserId){
            List<Wedding> weddings = new List<Wedding>();

            weddings = Weddings.Include(w => w.GuestList)
            .ThenInclude(r => r.User)
            .ToList();
            for (var i = weddings.Count-1; i >=0; i--){
                Wedding currentWedding = weddings[i];
                bool UserAttendingWedding = false;
                for (var j = 0; j < currentWedding.GuestCount; j++){
                    if (currentWedding.GuestList[j].UserId == UserId){
                        UserAttendingWedding = true;
                        break;
                    }
                }
                //we should know if they're attending or not
                if(!UserAttendingWedding){
                    weddings.Remove(currentWedding);
                }
            }
            return weddings;
        }
    }
}