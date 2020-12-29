using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Diagnostics;
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

    [Route("{name}")]
    [HttpGet]
    public ObjectResult GetItem(string name)
    {
        IWatchDogItem item = _db.WatchDogItems.Find(name);

        if (item == null)
        {
            return NotFound(null);
        }
        else
        {
            return Ok(item);
        }
    }

    [HttpPost]
    public ObjectResult Post([FromBody] WatchDogItem item)
    {
        DateTime currentTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, "Europe/Stockholm");
        item.CreatedDate = currentTime;
        item.ModifiedDate = currentTime;

        _db.Add(item);
        _db.SaveChanges();
        return Ok(item);
    }
}
