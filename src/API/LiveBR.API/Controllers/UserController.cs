using System;
using System.Threading.Tasks;
using AutoMapper;
using LiveBR.API.ViewModels;
using LiveBR.Application.ViewModels;
using LiveBR.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace LiveBR.API.Controllers
{
    [Route("api/users")]
    public class UserController: MainController
    {
        private readonly IUserService _userService;
        private IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
            
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> ListUsers()
        {
            var result = await _userService.Users();
            return Ok(result);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            var user = await _userService.GetById(id);
            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post(CreateUserViewModel request)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            
            var user = _mapper.Map<CreateUserDto>(request); 
            await _userService.AddUser(user);
            return CustomResponse();
        }
        
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> RemoveUser(Guid id)
        {
            var userExists = await _userService.GetById(id);

            if (userExists == null)
            {
                AddError("Usuário não encontrado");
                return CustomResponse();
            }

            await _userService.RemoveUser(userExists);
            return CustomResponse();
        }
    }
}