using Microsoft.EntityFrameworkCore;
using year_end_inventory_backend.Models;

namespace year_end_inventory_backend.Models;
public class SosTicketDbContext : DbContext
{
    public SosTicketDbContext(DbContextOptions<SosTicketDbContext> options) : base(options)
    { }

    public DbSet<SosTicketModel> SOS_TICKETS { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SosTicketModel>().HasNoKey();
    }

    // DbSet for ZMM tables
    public DbSet<SosZmmModel> ZMM_ALL { get; set; }
    //public DbSet<SosZmmModel2811> ZMM_2811 { get; set; }
    //public DbSet<SosZmmModel2820> ZMM_2820 { get; set; }
    //public DbSet<SosZmmModel2830> ZMM_2830 { get; set; }
    //public DbSet<SosZmmModel2835> ZMM_2835 { get; set; }
    //public DbSet<SosZmmModel2845> ZMM_2845 { get; set; }
    //public DbSet<SosZmmModel2855> ZMM_2855 { get; set; }
    //public DbSet<SosZmmModel2865> ZMM_2865 { get; set; }
    //public DbSet<SosZmmModel2875> ZMM_2875 { get; set; }
    //public DbSet<SosZmmModel2885> ZMM_2885 { get; set; }
}
