using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LiveBR.API.ViewModels;
using LiveBR.CrossCutting.Utils;
using LiveBR.CrossCutting.Utils.EncoderPassword;
using LiveBR.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace LiveBR.API.Controllers
{
    [Route("api/[controller]")]
    public class AuthController: MainController
    {
        private IUserService _service;
        private IEncoderPassword _encoderPassword;
        private IMapper _mapper;

        public AuthController(IUserService service, IEncoderPassword encoderPassword, IMapper mapper)
        {
            _service = service;
            _encoderPassword = encoderPassword;
            _mapper = mapper;
        }
        
        [AllowAnonymous]
        [HttpPost("Login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Login(UserLoginViewModel userLoginViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            
            var userExists = await _service.FindUserByEmail(x =>
                x.Email.Value == userLoginViewModel.Email);
            if (userExists == null)
            {
                AddError("Usuário não encontrado");
                return CustomResponse();
            }
            
            var passwordIsMatch = _encoderPassword.VerifyPassword(userLoginViewModel.Password, userExists.Password.Value);
            if (!passwordIsMatch)
            {
                AddError("Usuário ou senha incorreto");
                return CustomResponse();
            }

            var user = _mapper.Map<UserLoginResponseViewModel>(userExists);
            var response = GenerateToken(user);
            
            return CustomResponse(response);
        }

        private UserLoginResponseViewModel GenerateToken(UserLoginResponseViewModel user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim("System", "user")
                }),
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var response = tokenHandler.WriteToken(token);
            user.Token = response;
           
            return user;
        }
    }
}