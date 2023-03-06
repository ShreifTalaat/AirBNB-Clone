using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AirBNB.Models.Reviews;

public class Review
{
    public int Id { get; set; }
    [Range(1,5)]
    public int Rating { get; set; }
    [MaxLength(500),MinLength(1),Required]
    public string Content { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
    //Property Foriegnkey
    [ForeignKey("Property")]
    public int PropertyId { get; set; }
    public virtual Property Property { get; set; }
    //User foriegnkey
    [ForeignKey("User")]
    public string UserId { get; set; }
    public virtual AplicationUser User { get; set; }

}
