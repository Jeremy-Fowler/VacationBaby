using System.ComponentModel.DataAnnotations;

namespace VacationBaby.Models
{
  public class Trip : Vacation<int>
  {
    [Required]
    public bool RoundTrip { get; set; }
  }
}