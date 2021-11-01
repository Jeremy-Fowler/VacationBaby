using System.Data;

namespace VacationBaby.Repositories
{
  public class DbContext
  {
    protected readonly IDbConnection _db;

    public DbContext(IDbConnection db)
    {
      _db = db;
    }
  }
}