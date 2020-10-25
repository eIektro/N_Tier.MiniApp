using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using N_Tier.MiniApp.Core.Models;
using N_Tier.MiniApp.Core.Services;
using N_Tier.MiniApp.WebAPI.DTO;
using N_Tier.MiniApp.WebAPI.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace N_Tier.MiniApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SirketController : ControllerBase
    {
        private readonly ISirketService _sirketService;

        private readonly IMapper _mapper;

        public SirketController(ISirketService sirketService,IMapper mapper )
        {
            this._mapper = mapper;
            this._sirketService = sirketService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<SirketDTO>>> GetAllSirkets()
        {
            var sirkets = await _sirketService.GetAllSirkets();
            var sirketResources = _mapper.Map<IEnumerable<Sirket>, IEnumerable<SirketDTO>>(sirkets);
            return Ok(sirketResources);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SirketDTO>> GetSirketById(int id)
        {
            var sirket = await _sirketService.GetSirketById(id);
            var sirketResource = _mapper.Map<Sirket, SirketDTO>(sirket);
            return Ok(sirketResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSirket(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var sirket = await _sirketService.GetSirketById(id);
            if (sirket == null)
            {
                return NotFound();
            }

            await _sirketService.DeleteSirket(sirket);

            return Ok();
        }


        [HttpPost("")]
        public async Task<ActionResult<SirketDTO>> CreateSirket([FromBody] CreateSirketDTO createSirketResource)
        {
            var validator = new CreateSirketValidator();
            var validationResult = await validator.ValidateAsync(createSirketResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);


            var sirketToCreate = _mapper.Map<CreateSirketDTO, Sirket>(createSirketResource);
            var newSirket = await _sirketService.CreateSirket(sirketToCreate);
            var sirket = await _sirketService.GetSirketById(newSirket.Id);
            var sirketResource = _mapper.Map<Sirket, SirketDTO>(sirket);

            return Ok(sirketResource);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<SirketDTO>> UpdateSirket(int id, [FromBody] Sirket updateSirketResource)
        {
            
            var sirketToBeUpdate = await _sirketService.GetSirketById(id);

            if (sirketToBeUpdate == null)
                return NotFound();

            await _sirketService.UpdateSirket(sirketToBeUpdate, updateSirketResource);

            var updatedSirket = await _sirketService.GetSirketById(id);


            return Ok(updatedSirket);

           
        }

    }
}
