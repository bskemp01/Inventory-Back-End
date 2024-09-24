using Microsoft.EntityFrameworkCore;
using year_end_inventory_backend.Models;

namespace year_end_inventory_backend.Models;
public class UnrestrictedTicketDbContext : DbContext
{
    public UnrestrictedTicketDbContext(DbContextOptions<UnrestrictedTicketDbContext> options) : base(options)
    { }

    public DbSet<UnrestrictedTicketModel> UNRESTRICTED_TICKETS { get; set; }
    public DbSet<ActiveListData> ACTIVE_LIST_DATA { get; set; }

    // DbSet for ZMM tables
    public DbSet<UnrestrictedZmmModel> ZMM_ALL { get; set; }
    //public DbSet<UnrestrictedZmmModel2811> ZMM_2811 { get; set; }
    //public DbSet<UnrestrictedZmmModel2820> ZMM_2820 { get; set; }
    //public DbSet<UnrestrictedZmmModel2830> ZMM_2830 { get; set; }
    //public DbSet<UnrestrictedZmmModel2835> ZMM_2835 { get; set; }
    //public DbSet<UnrestrictedZmmModel2845> ZMM_2845 { get; set; }
    //public DbSet<UnrestrictedZmmModel2855> ZMM_2855 { get; set; }
    //public DbSet<UnrestrictedZmmModel2865> ZMM_2865 { get; set; }
    //public DbSet<UnrestrictedZmmModel2875> ZMM_2875 { get; set; }
    //public DbSet<UnrestrictedZmmModel2885> ZMM_2885 { get; set; }
}