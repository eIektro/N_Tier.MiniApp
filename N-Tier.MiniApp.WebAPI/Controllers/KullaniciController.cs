using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Cors;
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
    
    public class KullaniciController : ControllerBase
    {
        private readonly IKullaniciService _kullaniciService;

        private readonly IMapper _mapper;

        public KullaniciController(IKullaniciService kullaniciService, IMapper mapper)
        {
            this._kullaniciService = kullaniciService;
            this._mapper = mapper;
        }


        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<KullaniciDTO>>> GetAllKullanicis()
        {
            var kullanicis = await _kullaniciService.GetAllKullanicis();
            var kullaniciResources = _mapper.Map<IEnumerable<Kullanici>, IEnumerable<KullaniciDTO>>(kullanicis);
            return Ok(kullaniciResources);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<KullaniciDTO>> GetKullaniciById(int id)
        {
            var kullanici = await _kullaniciService.GetKullaniciById(id);
            var kullaniciResource = _mapper.Map<Kullanici, KullaniciDTO>(kullanici);
            return Ok(kullaniciResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKullanici(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var kullanici = await _kullaniciService.GetKullaniciById(id);
            if(kullanici == null)
            {
                return NotFound();
            }

            await _kullaniciService.DeleteKullanici(kullanici);

            return Ok();
        }


        [HttpPost("")]
        public async Task<ActionResult<KullaniciDTO>> CreateKullanici([FromBody] CreateKullaniciDTO createKullaniciResource)
        {
            var validator = new CreateKullaniciValidator();
            var validationResult = await validator.ValidateAsync(createKullaniciResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);


            var kullaniciToCreate = _mapper.Map<CreateKullaniciDTO, Kullanici>(createKullaniciResource);
            var newKullanici = await _kullaniciService.CreateKullanici(kullaniciToCreate);
            var kullanici = await _kullaniciService.GetKullaniciById(newKullanici.Id);
            var kullaniciResource = _mapper.Map<Kullanici, KullaniciDTO>(kullanici);

            return Ok(kullaniciResource);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<KullaniciDTO>> UpdateKullanici(int id, [FromBody] Kullanici updateKullaniciResource)
        {
            /* Update metodunda validasyon gerektirecek bir alan aklıma gelmedi */
            //var validator = new UpdateKullaniciValidator();
            //var validationResult = await validator.ValidateAsync(updateKullaniciResource);

            //var requestIsInvalid = id == 0 || !validationResult.IsValid;

            //if (requestIsInvalid)
            //    return BadRequest(validationResult.Errors);

            var kullaniciToBeUpdate = await _kullaniciService.GetKullaniciById(id);

            if (kullaniciToBeUpdate == null)
                return NotFound();

            await _kullaniciService.UpdateKullanici(kullaniciToBeUpdate, updateKullaniciResource);

            var updatedKullanici = await _kullaniciService.GetKullaniciById(id);
            

            return Ok(updatedKullanici);
        }
    }
}
