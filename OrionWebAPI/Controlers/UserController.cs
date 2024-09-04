using Microsoft.AspNetCore.Mvc;
using DbGame;
using AutoMapper;

namespace OrionWebAPI.Controlers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private ApplicationContext _context;
        private readonly IMapper _mapper;

        public UserController(ApplicationContext applicationContext, IMapper mapper)
        {
            _context = applicationContext;
            _mapper = mapper;
        }

        [HttpPost("add-user")]
        public IActionResult AddUser(UserRequest userRequest)
        {
            if (userRequest == null)
            {
                return BadRequest();
            }

            var user = new User
            {
                Name = userRequest.Name,
                Email = userRequest.Email,
                Surname = userRequest.Surname,
                Password = userRequest.Password,
                PhoneNumber = userRequest.PhoneNumber
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok();
        }
        [HttpGet("get-user")]
        public IActionResult GetUser(int id)
        {
            var user = _context.Users.Where(user => user.Id == id).FirstOrDefault();

            if (user == null)
            {
                return BadRequest();
            }

            return Ok(_mapper.Map<UserResponseDto>(user));
        }
        [HttpGet("get-users")]
        public IActionResult GetUsers()
        {
            return Ok(_context.Users.Select(user => _mapper.Map<UserResponseDto>(user)));
        }

        [HttpPost("update-user")]
        public IActionResult EditUser(int id, UserRequest userRequest) 
        {
            var user = _context.Users.Where(user => user.Id == id ).FirstOrDefault();
            if (user == null)
            {
                return BadRequest();
            }

            user.Name = userRequest.Name;
            user.Email = userRequest.Email;
            user.Surname = userRequest.Surname;
            user.Password = userRequest.Password;
            user.PhoneNumber = userRequest.PhoneNumber;

            _context.Users.Update(user);
            _context.SaveChanges();

            return Ok(userRequest);
        }

        [HttpDelete("delete-user")]
        public IActionResult DeleteUser(int id) 
        {
            var user = _context.Users.Where(user => user.Id == id).FirstOrDefault();
            if(user == null)
            {
                return BadRequest();
            }

            _context.Users.Remove(user);
            _context.SaveChanges();

            return Ok();
        }
    }
}
