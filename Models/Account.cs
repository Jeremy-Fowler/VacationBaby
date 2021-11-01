using System.ComponentModel.DataAnnotations;

namespace VacationBaby.Models
{
  public class Account : Profile
    {
        [Required]
        public string Email { get; set; }
    }
}