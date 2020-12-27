using Microsoft.AspNetCore.Mvc;
using WatchDog.DBContexts;
using WatchDog.Models;

[ApiController]
[Route("[controller]")]
public class WatchDogController : ControllerBase
{
    private readonly WatchDogDBContext _db;
    public WatchDogController(WatchDogDBContext DBContext)
    {
        _db = DBContext;
    }


    [HttpGet]
    public ObjectResult Get()
    {
        return Ok(_db.WatchDogItems);
    }

    [HttpPost]
    public ObjectResult Post([FromBody] WatchDogItem item)
    {
        _db.Add(item);
        _db.SaveChanges();
        return Ok(item);
    }
}
