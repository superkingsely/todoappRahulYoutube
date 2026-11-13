
using Microsoft.AspNetCore.Mvc;


    [Route("api/[controller]")]
    [ApiController]
    public class TokenController(
        ITokenService tokenService
         ) : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> Get(TokenRequestDto requestDto)
        {
            var response =
                await tokenService.GetTokenAsync(requestDto);

            return Ok(response);
        }

    }

      
       
    
