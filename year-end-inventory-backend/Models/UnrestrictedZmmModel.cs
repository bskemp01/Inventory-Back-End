using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace year_end_inventory_backend.Models;


public class UnrestrictedZmmModel
{
    [Key]
    public string Material { get; set; }

    [Column("Material Description")]
    public string MaterialDescription { get; set; }

    public string Plant { get; set; }

    [Column("Storage Location")]
    public double StorageLocation { get; set; }

    public double Unrestricted { get; set; }

    [Column("Base Unit of Measure")]
    public string BaseUnitOfMeasure { get; set; }

    [Column("Supplying Plant")]
    public string SupplyingPlant { get; set; }

    [Column("Special Stock")]
    public string SpecialStock { get; set; }

    [Column("Sales Document")]
    public string SalesDocument { get; set; }

    [Column("Item (SD)")]
    public int ItemSD { get; set; }

    [Column("Order Quantity")]
    public int OrderQuantity { get; set; }

    [Column("In Quality Insp.")]
    public int InQualityInsp { get; set; }

    public int Blocked { get; set; }

    public int Returns { get; set; }

    [Column("Quantity Received")]
    public int QuantityReceived { get; set; }

    [Column("Issued Quantity")]
    public int IssuedQuantity { get; set; }

    [Column("Purchasing Document")]
    public string PurchasingDocument { get; set; }

    public int Item { get; set; }

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
