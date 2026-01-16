using CoreEF.Data;
using CoreEF.Modules;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreEF.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FishingCompanyController : ControllerBase
    {
        private readonly AppDbContext _db;
        public FishingCompanyController(AppDbContext db) => _db = db;


        [HttpPost]
        [Route("")]
        public async Task<ActionResult<FishingCompany>> Create(FishingCompany fishingCompany)
        {

            _db.FishingCompanies.Add(fishingCompany);
            await _db.SaveChangesAsync();

            return Ok();
        }


        [HttpPut]
        public async Task<ActionResult> Update(FishingCompany fishingCompany)
        {
            

            var company = await _db.FishingCompanies.FindAsync(fishingCompany.Id);
            if (company is null) return NotFound();

            
            company.Name = fishingCompany.Name;
            company.Country = fishingCompany.Country;

            
            await _db.SaveChangesAsync();

            return NoContent();
        }


        [HttpGet]
        [Route("")]
        public async Task<ActionResult<IEnumerable<FishingCompany>>> GetAll()
        {
            var records = await _db.FishingCompanies.ToListAsync();

            if (records.Count == 0) return NotFound();

            return Ok(records);
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<FishingCompany>> GetById(int id)
        {
            var company = await _db.FishingCompanies.FindAsync(id);

            if (company is null) return NotFound();

            return Ok(company);
        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteCompany(int id)
        {
            var company = await _db.FishingCompanies.FindAsync(id);

            if (company is null) return NotFound();

            _db.FishingCompanies.Remove(company);
            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
}
