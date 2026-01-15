using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

internal class FishingVessel
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = null!;

    public string? Captain {get; set;}

    // FK
    [ForeignKey("FishingCompanyId")]
    public int FishingCompanyId { get; set; }

    [Required]
    public ICollection<FishingTrip> FishingTrips { get; set; } = null!;


}
