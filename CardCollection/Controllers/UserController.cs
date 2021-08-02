using CardCollection.Models;
using CardCollection.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using CardCollection.Helpers;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using CardCollection.Entities;
using System;

namespace CardCollection.Controllers
{
    [Authorize]
    [ApiController]
    [Route("/User")]
    public class UserController : ControllerBase
    {

        private IUserService _userService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public UserController(IUserService userService, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _userService = userService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }


        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticateModel model)
        {
            var user = _userService.Authenticate(model.Username, model.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            // return basic user info and authentication token
            return Ok(new
            {
                Id = user.Id,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Token = tokenString
            });
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterModel model)
        {
            // map model to entity
            var user = _mapper.Map<Entities.User>(model);

            try
            {
                // create user
                _userService.Create(user, model.Password);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpGet("All")]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            var model = _mapper.Map<IList<User>>(users);
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _userService.GetById(id);
            var model = _mapper.Map<User>((object)user);
            return Ok(model);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateModel model)
        {
            // map model to entity and set id
            var user = _mapper.Map<Entities.User>(model);
            user.Id = id;

            try
            {
                // update user 
                _userService.Update(user, model.Password);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userService.Delete(id);
            return Ok();
        }

        [AllowAnonymous]
        [HttpGet("{id}/Collection")]
        public IActionResult GetUserCollection(int id)
        {
            List<Card> collection = _userService.GetUserCollection(id);
            return Accepted(collection);
        }

        [AllowAnonymous]
        [HttpPost("{id}/Collection/Add/{cardId}")]
        public IActionResult AddToCollection(int id, string cardId)
        {
            _userService.AddToCollection(id, cardId);
            return Accepted();
        }

        [AllowAnonymous]
        [HttpDelete("{id}/Collection/Remove/{cardId}")]
        public IActionResult RemoveFromCollection(int id, string cardId)
        {
            _userService.RemoveFromCollection(id, cardId);
            return Accepted();
        }

        [AllowAnonymous]
        [HttpGet("{id}/Collection/{setId}/Max")]
        public IActionResult GetSetTotal(int id, string setId)
        {
            int max = _userService.GetSetTotal(id, setId);
            return Accepted(max);
        }

        [AllowAnonymous]
        [HttpGet("{id}/Collection/{setId}/Count")]
        public IActionResult GetSetCount(int id, string setId)
        {
            int count = _userService.GetSetCount(id, setId );
            return Accepted(count);
        }

        

    }
}
