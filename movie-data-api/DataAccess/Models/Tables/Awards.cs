using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models.Tables;

public class Awards
{
    [Required]
    public int AwardId { get; set; }
    [Required]
    public string AwardTitle { get; set; } = null!;
    public virtual ICollection<Movies> Movies { get; set; } = null!;
}
