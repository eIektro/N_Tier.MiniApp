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
    public class GorevController : ControllerBase
    {
        private readonly IGorevService _gorevService;

        private readonly IMapper _mapper;

        public GorevController(IGorevService gorevservice, IMapper mapper)
        {
            this._gorevService = gorevservice;
            this._mapper = mapper;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<GorevDTO>>> GetAllGorevs()
        {
            var gorevs = await _gorevService.GetAllGorevs();
            var gorevResources = _mapper.Map<IEnumerable<Gorev>, IEnumerable<GorevDTO>>(gorevs);
            return Ok(gorevResources);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GorevDTO>> GetGorevById(int id)
        {
            var gorev = await _gorevService.GetGorevById(id);
            var gorevResource = _mapper.Map<Gorev, GorevDTO>(gorev);
            return Ok(gorevResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGorev(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var gorev = await _gorevService.GetGorevById(id);
            if (gorev == null)
            {
                return NotFound();
            }

            await _gorevService.DeleteGorev(gorev);

            return Ok();
        }


        [HttpPost("")]
        public async Task<ActionResult<GorevDTO>> CreateGorev([FromBody] CreateGorevDTO createGorevResource)
        {
            var validator = new CreateGorevValidator();
            var validationResult = await validator.ValidateAsync(createGorevResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);


            var gorevToCreate = _mapper.Map<CreateGorevDTO, Gorev>(createGorevResource);
            var newGorev = await _gorevService.CreateGorev(gorevToCreate);
            var gorev = await _gorevService.GetGorevById(newGorev.Id);
            var gorevResource = _mapper.Map<Gorev, GorevDTO>(gorev);

            return Ok(gorevResource);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<GorevDTO>> UpdateGorev(int id, [FromBody] Gorev updateGorevResource)
        {
            
            var gorevToBeUpdate = await _gorevService.GetGorevById(id);

            if (gorevToBeUpdate == null)
                return NotFound();

            await _gorevService.UpdateGorev(gorevToBeUpdate, updateGorevResource);

            var updatedGorev = await _gorevService.GetGorevById(id);


            return Ok(updatedGorev);
        }
    }
}
