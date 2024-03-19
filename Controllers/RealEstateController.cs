using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateAPI.Models;
using RealEstateAPI.Services;

namespace RealEstateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RealEstateController : ControllerBase
    {
        private readonly RealEstateService _realEstateService;

        public RealEstateController(RealEstateService realEstateService) =>
            _realEstateService = realEstateService;

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<List<RealEstate>>> Get()
        {
            var realEstateList = await _realEstateService.GetAsync();

            if (realEstateList is null) return NotFound();

            return Ok(realEstateList);
        }

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<RealEstate>> Get(string id)
        {
            var realEstate = await _realEstateService.GetAsync(id);

            if (realEstate is null) return NotFound();

            return Ok(realEstate);
        }

        [HttpPost]
        public async Task<IActionResult> Post(RealEstate newRealEstate)
        {
            await _realEstateService.CreateAsync(newRealEstate);

            return CreatedAtAction(nameof(Get), new {id = newRealEstate.Id}, newRealEstate);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, RealEstate updatedRealEstate)
        {
            var realEstate = await _realEstateService.GetAsync(id);

            if (realEstate is null) return NotFound();

            updatedRealEstate.Id = realEstate.Id;

            await _realEstateService.UpdateAsync(id, updatedRealEstate);

            return Ok(updatedRealEstate);
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var realEstate = await _realEstateService.GetAsync(id);

            if (realEstate is null) return NotFound();

            await _realEstateService.RemoveAsync(id);

            return Ok(realEstate);
        }
    }
}
