using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using BancaApi.DbContexts;
using BancaApi.Dtos;
using BancaApi.Entities;
using BancaApi.Helpers;
using BancaApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace BancaApi.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminRepository _adminRepository;
        private readonly BancaInfoContext _bancaDb;
        private readonly IMapper _mapper;

        public AdminController(IAdminRepository adminRepository, BancaInfoContext bancaDb, IMapper mapper)
        {
            _adminRepository = adminRepository;
            _bancaDb = bancaDb;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAdminsAsync()
        {
            var admins = await _adminRepository.GetAdminsAsync();
            var adminDtos = _mapper.Map<List<AdminDto>>(admins);
            return Ok(adminDtos);
        }

        [HttpGet("{id}", Name = nameof(GetAdminByIdAsync))]
        public async Task<IActionResult> GetAdminByIdAsync(int id)
        {
            var admin = await _adminRepository.GetAdminByIdAsync(id);

            if (admin == null)
                return NotFound($"Admin with ID {id} not found.");

            var adminDto = _mapper.Map<AdminDto>(admin);
            return Ok(adminDto);
        }

        [HttpPost("register")]
        public async Task<IActionResult> AddAdminAsync([FromBody] AdminDto adminDto)
        {
            if (adminDto == null)
                return BadRequest("Invalid admin data.");

            //var adminEntity = _mapper.Map<AdminEntity>(adminDto);
            var newAdmin = await _adminRepository.AddAdminAsync(adminDto);
            var newAdminDto = _mapper.Map<AdminDto>(newAdmin);

            return CreatedAtRoute(nameof(GetAdminByIdAsync), new { id = newAdminDto.Id }, newAdminDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAdminAsync(int id, [FromBody] AdminDto adminDto)
        {
            if (adminDto == null)
                return BadRequest("Invalid admin data.");

            //var adminEntity = _mapper.Map<AdminEntity>(adminDto);
            var result = await _adminRepository.UpdateAdminAsync(id, adminDto);

            if (!result)
                return NotFound($"Admin with ID {id} not found.");

            return NoContent();
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AdminDto adminDto)
        {
            if (adminDto == null)
                return BadRequest("Invalid authentication data.");

            var adminEntity = _mapper.Map<AdminEntity>(adminDto);

            var authenticatedUser = await _bancaDb.Admins
                .FirstOrDefaultAsync(x => x.Username == adminEntity.Username);

            if (authenticatedUser == null)
                return Unauthorized(new { Message = "Authentication failed. User not found or invalid credentials." });

            if (!PasswordHasher.VerifyPassword(adminEntity.Password, authenticatedUser.Password))
            {
                return BadRequest(new { Message = "Password is incorrect" });
            }

            authenticatedUser.Token = CreateJwt(adminDto);
            return Ok(new {
                idBanca = authenticatedUser.IdBanca,
                Token = authenticatedUser.Token,
                Message = "Login success"              
            });


        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdminAsync(int id)
        {
            var result = await _adminRepository.DeleteAdminAsync(id);

            if (!result)
                return NotFound($"Admin with ID {id} not found.");

            return NoContent();
        }

        private string CreateJwt(AdminDto admin)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("veryverysceret.....");

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, admin.Username)
            };

            if (!string.IsNullOrEmpty(admin.Role))
            {
                claims.Add(new Claim(ClaimTypes.Role, admin.Role));
            }

            var identity = new ClaimsIdentity(claims);

            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = DateTime.Now.AddSeconds(10),
                SigningCredentials = credentials
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            return jwtTokenHandler.WriteToken(token);

        }

        //private string CreateRefreshToken()
        //{
        //    var tokenBytes = RandomNumberGenerator.GetBytes(64);
        //    var refreshToken = Convert.ToBase64String(tokenBytes);

        //    var tokenInUser = _bancaDb.Admins
        //        .Any(a => a.RefreshToken == refreshToken);
        //    if (tokenInUser)
        //    {
        //        return CreateRefreshToken();
        //    }
        //    return refreshToken;
        //}

    }
}
