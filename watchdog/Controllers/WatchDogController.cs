using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WatchDog.DBContexts;
using WatchDog.Models;
using WatchDog.Tools;

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
    [Route("items")]
    public ObjectResult GetItems()
    {
        return Ok(_db.WatchDogItems);
    }

    [HttpGet]
    public ObjectResult GetLateItems()
    {
        Dictionary<string, int> LateItems = new Dictionary<string, int>();
        foreach (IWatchDogItem item in _db.WatchDogItems)
        {
            if (item.IsLate())
            {
                LateItems.Add(item.Name, item.HowLate());
            }
        }
        return Ok(LateItems);
    }

    [HttpGet]
    [Route("items/{name}")]
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
    [Route("items")]
    public ObjectResult CreateItem([FromBody] WatchDogItem item)
    {
        DateTime currentTime = Tools.CurrentTime();
        item.CreatedDate = currentTime;
        item.ModifiedDate = currentTime;
        item.LastCheckin = currentTime;
        _db.Add(item);
        _db.SaveChanges();
        return Ok(item);
    }

    [HttpPost]
    [Route("items/{name}")]
    public ObjectResult Checkin(string name)
    {
        DateTime currentTime = Tools.CurrentTime();
        var item = _db.WatchDogItems.SingleOrDefault(b => b.Name == name);
        if (item != null)
        {
            item.LastCheckin = currentTime;
            _db.Update(item);
            _db.SaveChanges();
            return Ok(item);
        }
        else
        {
            var errorResponse = new Dictionary<string, string>();
            errorResponse.Add("error", "item doesn't exist");
            return NotFound(errorResponse);
        }
    }
}
