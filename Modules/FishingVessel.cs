using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreEF.Modules;

public class FishingVessel
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = null!;

    public string? Captain {get; set;}

    // FK
    [ForeignKey("FishingCompanyId")]
    public int FishingCompanyId { get; set; }

   
}
