using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlatformService.Models
{
    [Table("platforms")]
    public class Platform
    {
        [Key] public int Id { get; set; }
        [Required] [StringLength(255)] public string Name { get; set; }
        [Required] [StringLength(255)] public string Publisher { get; set; }
        [Required] [StringLength(255)] public string Cost { get; set; }
    }
}