namespace VacationBaby.Models
{
  public class Profile : DBItem<string>
  {
    public string Name { get; set; }
    public string Picture { get; set; }
  }
}