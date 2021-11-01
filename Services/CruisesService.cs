using System.Collections.Generic;
using VacationBaby.Models;
using VacationBaby.Repositories;

namespace VacationBaby.Services
{
  public class CruisesService
  {

    private readonly CruisesRepository _cr;

    public CruisesService(CruisesRepository cr)
    {
      _cr = cr;
    }

    public Cruise Create(Cruise data)
    {
      return _cr.Create(data);
    }

    public void Delete(string userId, int cruiseId)
    {
      Cruise cruise = _cr.Get(cruiseId);
      if(cruise.CreatorId != userId)
      {
        throw new System.Exception("YOU CAN'T DO THAT");
      }
      _cr.Delete(cruiseId);
    }

    public Cruise Edit(int cruiseId, string userId, Cruise data)
    {
      Cruise cruise = _cr.Get(cruiseId);
      if(cruise.CreatorId != userId)
      {
        throw new System.Exception("YOU CAN'T DO THAT");
      }
      cruise.Destination = data.Destination ?? cruise.Destination;
      cruise.Price = data.Price;
      cruise.Nights = data.Nights;
      return _cr.Edit(data);
    }

    public List<Cruise> Get()
    {
      return _cr.Get();
    }

    public Cruise Get(int cruiseId)
    {
      Cruise cruise = _cr.Get(cruiseId);
      if(cruise == null)
      {
        throw new System.Exception("No Cruise Found");
      }
      return cruise;
    }
  }
}