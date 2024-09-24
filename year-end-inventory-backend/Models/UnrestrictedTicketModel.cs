using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace year_end_inventory_backend.Models;

public class UnrestrictedTicketModel
{
    [Key]
    [Column("Ticket Number")]
    public double TicketNumber { get; set; }

    [Column("Part Number")]
    [MaxLength(225)]
    public string PartNumber { get; set; }

    [Column("Storage Location")]
    public double StorageLocation { get; set; }

    [MaxLength(255)]
    public string Description { get; set; }

    [Column("Unit of Measure")]
    [MaxLength(255)]
    public string UnitOfMeasure { get; set; }

    public double Quantity { get; set; }

    //[Key]
    [Column("Plant Location")]
    public double PlantLocation { get; set; }

    [Column("Area Location")]
    [MaxLength(50)]
    public string AreaLocation { get; set; }

    [Column("User Entered")]
    [MaxLength(50)]
    public string? UserEntered { get; set; }
}

