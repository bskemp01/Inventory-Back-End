using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace year_end_inventory_backend.Models;

[Keyless]
public class SosZmmModel
{
    [Column("Base Unit of Measure")]
    public string BaseUnitOfMeasure { get; set; }

    [Column("Material")]
    public string Material { get; set; }

    [Column("Material Description")]
    public string MaterialDescription { get; set; }

    [Column("Sales Document")]
    public decimal SalesDocument { get; set; }

    [Column("Item")]
    public decimal Item { get; set; }

    [Column("Storage Location")]
    public decimal StorageLocation { get; set; }

    [Column("Unrestricted")]
    public double Unrestricted { get; set; }

    [Column("Supplying Plant")]
    public string SupplyingPlant { get; set; }

    [Column("Plant")]
    public int Plant { get; set; }

    [Column("Special Stock")]
    public string SpecialStock { get; set; }

    [Column("Item (SD)")]
    public int? ItemSD { get; set; }

    [Column("Order Quantity")]
    public int OrderQuantity { get; set; }

    [Column("In Quality Insp.")]
    public int InQualityInsp { get; set; }

    [Column("Blocked")]
    public int Blocked { get; set; }

    [Column("Returns")]
    public int Returns { get; set; }

    [Column("Quantity Received")]
    public int QuantityReceived { get; set; }

    [Column("Issued Quantity")]
    public int IssuedQuantity { get; set; }

    [Column("Purchasing Document")]
    public string PurchasingDocument { get; set; }

    [Column("Material Document")]
    public string MaterialDocument { get; set; }

    [Column("Material Doc.Item")]
    public int MaterialDocItem { get; set; }

    [Column("Delivery date")]
    public string DeliveryDate { get; set; }

    [Column("Load / Schedule Number")]
    public string LoadScheduleNumber { get; set; }

    [Column("Delivery status")]
    public string DeliveryStatus { get; set; }
}
