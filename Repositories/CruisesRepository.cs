using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using VacationBaby.Interfaces;
using VacationBaby.Models;

namespace VacationBaby.Repositories
{
  public class CruisesRepository : DbContext, IVacation<Cruise>
  {
    public CruisesRepository(IDbConnection db) : base(db)
    {
    }

    public Cruise Create(Cruise data)
    {
      string sql = @"
      INSERT INTO cruises(
        destination,
        price,
        nights,
        creatorId
      )
      VALUES(
        @Destination,
        @Price,
        @Nights,
        @CreatorId
      );
      SELECT LAST_INSERT_ID();
      ";
      data.Id = _db.ExecuteScalar<int>(sql, data);
      return data;
    }

    public void Delete(int id)
    {
      throw new System.NotImplementedException();
    }

    public Cruise Edit(Cruise data)
    {
      throw new System.NotImplementedException();
    }

    public List<Cruise> Get()
    {
      string sql = "SELECT * FROM cruises;";
      return _db.Query<Cruise>(sql).ToList();
    }

    public Cruise Get(int id)
    {
      throw new System.NotImplementedException();
    }
  }
}