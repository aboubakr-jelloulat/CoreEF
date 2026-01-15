using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

internal class FishingTrip
{
    [Key]
    public int Id { get; set; }

    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    public DateTime EndDate { get; set; }

    [ForeignKey("FishingVesselId")]
    public int FishingVesselId { get; set; } // FK

    public override string ToString() => $"Id : {Id} * SDate {StartDate} * EDate {EndDate}";
  
}

