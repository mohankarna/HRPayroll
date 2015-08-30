using System.ComponentModel.DataAnnotations;

namespace HRPayroll.Domain.Entity
{
public    class Title
    {
    public int Id { get; set; }
    [Required]
[StringLength(100)]
    public string TitleName { get; set; }
    }
}
