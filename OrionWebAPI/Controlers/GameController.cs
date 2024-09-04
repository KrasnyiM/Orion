using Microsoft.AspNetCore.Mvc;
using DbGame;
using AutoMapper;

namespace OrionWebAPI.Controlers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : Controller
    {
        private ApplicationContext _context;
        private readonly IMapper _mapper;

        public GameController(ApplicationContext applicationContext, IMapper mapper)
        {
            _context = applicationContext;
            _mapper = mapper;
        }

        [HttpPost("add-game")]
        public IActionResult AddGame(GameDto gameDto)
        {
            if(gameDto == null)
            {
                return BadRequest();
            }

            var game = new Game()
            {
                Name = gameDto.Name,
                Genre = gameDto.Genre,
                Description = gameDto.Description,
                SystemRequirements = gameDto.SystemRequirements,
                Price = gameDto.Price
            };

            _context.Games.Add(game);
            _context.SaveChanges();

            return Ok();
        }

        [HttpGet("get-game")]
        public IActionResult GetGame(int id)
        {
            var game = _context.Games.Where(game => game.Id == id).FirstOrDefault();

            if (game == null)
            {
                return BadRequest();
            }
            
            return Ok(_mapper.Map<GameDto>(game));
        }

        [HttpGet("get-games")]
        public IActionResult GetGames()
        {         
            return Ok(_context.Games.Select(game => _mapper.Map<GameDto>(game)));
        }

        [HttpPost("update-game")]
        public IActionResult UpdateGame(int id, GameDto gameDto)
        {
            var game = _context.Games.Where(game => game.Id == id).FirstOrDefault();

            if(game == null)
            {
                return BadRequest();
            }

            game.Name = gameDto.Name;
            game.Genre = gameDto.Genre;
            game.Description = gameDto.Description;
            game.SystemRequirements = gameDto.SystemRequirements;
            game.Price = gameDto.Price;

            _context.Games.Update(game);
            _context.SaveChanges();

            return Ok(gameDto);
        }

        [HttpDelete("delete-game")]
        public IActionResult DeleteGame(int id)
        {
            var game = _context.Games.Where(game => game.Id == id).FirstOrDefault();

            if(game == null)
            {
                return BadRequest();
            }

            _context.Games.Remove(game);
            _context.SaveChanges();

            return Ok();
        }
    }
}
