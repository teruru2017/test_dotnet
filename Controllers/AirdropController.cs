using System.Linq;
using System.Net;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using octa_dotnet.Data;
using octa_dotnet.DTOs.Airdrop;
using octa_dotnet.Entities;
using octa_dotnet.Interfaces;

namespace octa_dotnet.Controllers;

[ApiController]
[Route("[controller]")]
public class AirdropController : ControllerBase
{
   private readonly IAirdropService airdropService;

    public AirdropController(IAirdropService airdropService) => this.airdropService = airdropService;



    [HttpGet]
    public async Task<ActionResult<IEnumerable<AirdropResponse>>> GetAirdrop()
    {
        return (await airdropService.FindAll())
        .Select(AirdropResponse.FromAirdrop).ToList();
    }
    [HttpGet("{AirdropId}")]
    public async Task<ActionResult<AirdropResponse>> GetAirdropById(int AirdropId)
    {
        var airdrop = await airdropService.FindById(AirdropId);
        if (airdrop == null)
        {
            return NotFound();
        }
        return airdrop.Adapt<AirdropResponse>();
    }
    [HttpGet("search")]

    public async Task<ActionResult<IEnumerable<AirdropResponse>>> SearchAirdrop([FromQuery] string account = "")
    {
       return (await airdropService.Search(account))
        
        .Select(AirdropResponse.FromAirdrop)
        .ToList();
        
    }
    [HttpPost] //https://localhost:5001/products

    public async Task<ActionResult<Airdrop>> AddAirdrop([FromForm] AirdropResponse airdropResponse)
    {
        var airdrop = airdropResponse.Adapt<Airdrop>();
        await airdropService.Create(airdrop);
        return StatusCode((int)HttpStatusCode.Created);

    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Airdrop>> UpdateAirdrop(int id, [FromForm] AirdropResponse airdropResponse)
    {
        if (id != airdropResponse.AirdropId)
        {
            return BadRequest();
        }
        var airdrop = await airdropService.FindById(id);


        if (airdrop == null)
        {
            return NotFound();
        }
        airdropResponse.Adapt(airdrop);
        await airdropService.Update(airdrop);
      
        return NoContent();
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAirdrops(int id)
    {
        var airdrop = await airdropService.FindById(id);
        if (airdrop == null)
        {
            return NotFound();
        }
        await airdropService.Delete(airdrop);

        return NoContent();
    }

}
