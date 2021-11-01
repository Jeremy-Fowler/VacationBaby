using System.ComponentModel.DataAnnotations;

namespace VacationBaby.Models
{
  public abstract class Vacation<T> : DBItem<int>
  {
    [Required]
    public string Destination { get; set; }
    [Required]
    public T Price { get; set; }
    public string CreatorId { get; set; }
  }
}