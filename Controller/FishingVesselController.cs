using System.Runtime;
using CoreEF.Data;
using CoreEF.Modules;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreEF.Controllers;

[ApiController]
[Route("[controller]")]
public class FishingVesselController : ControllerBase
{
    private readonly AppDbContext _db;
    
    public FishingVesselController(AppDbContext db)  => _db = db;


    [HttpPost]
    [Route("")]
    public async Task<ActionResult<FishingVessel>> Create(FishingVessel fishingVessel)
    {
        await _db.FishingVessels.AddAsync(fishingVessel);

        await _db.SaveChangesAsync();

        return Ok();
    }


    [HttpPut]
    public async Task<ActionResult> Update(FishingVessel fishingVessel)
    {
            

        var vessel = await _db.FishingVessels.FindAsync(fishingVessel.Id);
        if (vessel is null)
            return NotFound();

        vessel.Name             = fishingVessel.Name;
        vessel.Captain          = fishingVessel.Captain;
        vessel.FishingCompanyId = fishingVessel.FishingCompanyId;

            
        await _db.SaveChangesAsync();

        return NoContent();
    }

    [HttpGet]
    [Route("")]
    public async Task<ActionResult<IEnumerable<FishingVessel>>> GetAll()
    {
        var records = await _db.FishingVessels.ToListAsync();

        if (records.Count == 0)
            return NotFound();

        return Ok(records);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<FishingVessel>> GetById(int id)
    {
        var vessel = await _db.FishingVessels.FindAsync(id);

        if (vessel is null) return NotFound();

        return Ok(vessel);
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult> DeleteCompany(int id)
    {
        var vessel = await _db.FishingVessels.FindAsync(id);

        if (vessel is null)
            return NotFound();

        _db.FishingVessels.Remove(vessel);
        await _db.SaveChangesAsync();

        return NoContent();
    }

    

}