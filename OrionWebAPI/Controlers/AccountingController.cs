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
        public IActionResult GetAccountings()
        {
            var accounting = _context.Accountings
                .Include(o => o.User).Include(o => o.Game).ToList();

            return Ok(accounting);
        }

        [HttpGet("get-accounting")]
        public IActionResult GetAccounting(int id)
        {
            var user = _context.Accountings
                .Where(o => o.Id == id).Include(o => o.User).Include(o => o.Game).FirstOrDefault();

            if( user == null)
            {
                return BadRequest();
            }

            return Ok(user);
        }

        
    }
}
