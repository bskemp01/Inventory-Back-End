using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace year_end_inventory_backend.Models;


public class SosTicketModel
{
    [Column("Ticket Number")]
    public decimal? TicketNumber { get; set; }

    [Column("Plant Location")]
    public decimal? PlantLocation { get; set; }

    [Column("Storage Location")]
    public decimal? StorageLocation { get; set; }

    [Column("Sales Order")]
    public decimal? SalesOrder { get; set; }

    [Column("Line Item")]
    public decimal? LineItem { get; set; }

    [MaxLength(50)]
    public string? Material { get; set; }

    [MaxLength(50)]
    public string? Description { get; set; }

    public double? Quantity { get; set; }

    [MaxLength(50)]
    [Column("Area Location")]
    public string? AreaLocation { get; set; }

    [MaxLength(50)]
    [Column("User Entered")]
    public string? UserEntered { get; set; }
}