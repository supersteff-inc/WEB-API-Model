using System.Linq;
using Microsoft.AspNetCore.Mvc;
using try5000rpg.Models;
using System.Collections.Generic;
using try5000rpg.Services.CharacterService;
using System.Threading.Tasks;
using try5000rpg.DTOs.Characters;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace try5000rpg.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CharController : ControllerBase   
    {
        private readonly iCharService _charService;
        public CharController(iCharService charService)
        {
            _charService = charService;
        }
        [AllowAnonymous]
        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDTO>>>> Get()
        {
            int id =int.Parse (User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            return Ok(await _charService.GetAllCharacters(id));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDTO>>> GetSingle(int id)
        {
            
            return Ok(await _charService.GetSingle(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDTO>>>> AddChar(AddCharacterDTO newCharacter)
        {
            return Ok(await _charService.CreateSingle(newCharacter));
        }

        [HttpPut]

        public async Task<ActionResult<ServiceResponse<GetCharacterDTO>>> UpdateChar (UpdateCharacterDTO updateCharacter)
        {
            var srResponse = await _charService.UpdateCharacter(updateCharacter);
            if (srResponse.Data == null)
            {
                return NotFound(srResponse);
            }
            return Ok(srResponse);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDTO>>>> Delete(int id)
        {
             var srResponse = await _charService.DeleteCharacter(id);
            if (srResponse.Data == null)
            {
                return NotFound(srResponse);
            }
            return Ok(srResponse);
        }

    }
}