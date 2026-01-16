using System.ComponentModel.DataAnnotations;

namespace CoreEF.Modules;

public class FishingCompany
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = null!;

    /*
        ! null-forgiving operator It tells the compiler:“Stop warning me about null here.”

        “EF Core will initialize this property at runtime”

        null! = “trust me, I know what I’m doing”
    */

    [Required]
    public string Country { get; set; } = null!;
}
