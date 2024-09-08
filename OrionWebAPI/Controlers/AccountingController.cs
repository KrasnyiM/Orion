using DbGame;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace OrionWebAPI.Controlers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountingController : Controller
    {
        private ApplicationContext _context;
        public AccountingController(ApplicationContext applicationContext)
        {
            _context = applicationContext;
        }

        [HttpPost("add-accounting")]
        public IActionResult AddAccounting(int GameId, int UserId)
        {
            var game = _context.Games.Where(game => game.Id == GameId).FirstOrDefault();
            if (game == null)
            {
                return BadRequest("game not found");
            }

            var user = _context.Users.Where(user => user.Id == UserId).FirstOrDefault();
            if (user == null)
            {
                return BadRequest("user not found");
            }

            var accounting = new Accounting() { Game = game, User = user };
            _context.Accountings.Add(accounting);
            _context.SaveChanges();

            return Ok();
        }

        [HttpGet("get-accountings")]
        public IActionResult GetAccounting()
        {
            var accounting = _context.Accountings
                .Include(g => g.Game).Include(g => g.User).ToList();

            return Ok(accounting);
        }

        [HttpGet("get-accounting")]
        public IActionResult GetAccounting(int id)
        {
            var accounting = _context.Accountings
                .Where(a => a.Id == id).Include(a => a.Game)
                .Include(a => a.User).FirstOrDefault();

            if( accounting == null)
            {
                return BadRequest();
            }
            return Ok(accounting);
        }

        
    }
}
