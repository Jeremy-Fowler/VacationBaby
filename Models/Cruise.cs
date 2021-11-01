using System.ComponentModel.DataAnnotations;

namespace VacationBaby.Models
{
  public class Cruise : Vacation<float>
  {
    [Required]
    public int Nights { get; set; }
  }
}