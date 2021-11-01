using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VacationBaby.Models;
using VacationBaby.Services;

namespace VacationBaby.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class CruisesController : ControllerBase
  {
    private readonly CruisesService _cs;

    public CruisesController(CruisesService cs)
    {
      _cs = cs;
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Cruise>> Create(Cruise data)
    {
      try
      {   
          Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
          data.CreatorId = userInfo.Id;
          Cruise cruise = _cs.Create(data);
          return Ok(cruise);
      }
      catch (System.Exception e)
      {
          
          return BadRequest(e.Message);
      }
    }

    [HttpDelete("{cruiseId}")]
    [Authorize]
    public async Task<ActionResult<string>> Delete(int cruiseId)
    {
      try
      {
           Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
           _cs.Delete(userInfo.Id, cruiseId);
           return Ok("Cruise was deleted");
      }
      catch (System.Exception e)
      {
          
          return BadRequest(e.Message);
      }
    }

    [HttpPut("{cruiseId}")]
    [Authorize]
    public async Task<ActionResult<Cruise>> Edit(int cruiseId, Cruise data)
    {
      try
      {
          Account userInfo = await HttpContext.GetUserInfoAsync<Account>();         
          Cruise cruise = _cs.Edit(cruiseId, userInfo.Id, data);
          return Ok(cruise);
      }
      catch (System.Exception e)
      {
          
          return BadRequest(e.Message);
      }
    }

    [HttpGet]
    public ActionResult<List<Cruise>> Get()
    {
      try
      {
          List<Cruise> cruises = _cs.Get();
          return Ok(cruises);
      }
      catch (System.Exception e)
      {
          
          return BadRequest(e.Message);
      }
    }

    [HttpGet("{cruiseId}")]
    public ActionResult<Cruise> Get(int cruiseId)
    {
      try
      {
        Cruise cruise = _cs.Get(cruiseId);
        return Ok(cruise);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}