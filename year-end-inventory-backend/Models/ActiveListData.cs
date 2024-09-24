using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace year_end_inventory_backend.Models;

[Keyless]
public class ActiveListData
{
    public string Material { get; set; }

    [Column("Material Description")]
    public string MaterialDescription { get; set; }

    [Column("Base UoM")]
    public string BaseUoM { get; set; }

    [Column("Alt Unit Of Measure")]
    public string AltUnitOfMeasure { get; set; }

    public double Counter { get; set; }

    public double Denom { get; set; }

    public double Conversion { get; set; }
}