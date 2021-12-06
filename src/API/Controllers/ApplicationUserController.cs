using Amir.Apparel.Demo.Api.Dotnet.API.DTOs;
using Amir.Apparel.Demo.Api.Dotnet.Data.Models;
using Amir.Apparel.Demo.Api.Dotnet.Providers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Amir.Apparel.Demo.Api.Dotnet.API.Controllers
{
    [Route("users")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        private readonly IApplicationUserProvider _provider;
        private readonly IMapper _mapper;

        public ApplicationUserController(IApplicationUserProvider provider, IMapper mapper)
        {
            _provider = provider;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ApplicationUserResponseDTO> saveUserAsync(
            [FromHeader(Name = "Authorization")] string bearerToken,
            [FromBody] ApplicationUserRequestDTO userRequestDTO
        )
        {
            var userToSave = _mapper.Map<ApplicationUser>(userRequestDTO);
            var savedUser = await _provider.SaveUserAsync(userToSave, bearerToken);
            var userResponseDTO = _mapper.Map<ApplicationUserResponseDTO>(savedUser);

            return userResponseDTO;
        }

        [HttpGet]
        public async Task<ApplicationUserResponseDTO> getUserByEmailAsync(
            [FromHeader(Name = "Authorization")] string bearerToken,
            [FromQuery(Name = "email")] string email
        )
        {
            var user = await _provider.GetUserByEmailAsync(email, bearerToken);
            var userResponseDTO = _mapper.Map<ApplicationUserResponseDTO>(user);

            return userResponseDTO;
        }
    }
}
