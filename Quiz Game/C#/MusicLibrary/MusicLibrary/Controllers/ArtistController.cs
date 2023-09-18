using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace MusicLibrary.Controllers
{
    // Attribute to mark the class as an API controller
    [ApiController]

    [Route("[action]")]

    public class ArtistController : ControllerBase
    {
        private readonly ILogger<ArtistController> _logger;

        private readonly DALManager _database;

        public ArtistController(ILogger<ArtistController> logger, DALManager database)
        {
            _logger = logger;
            _database = database;
        }

        [HttpGet(Name = "GetArtist")]

        public IEnumerable<Artist> GetArtist() 
        {
            return _database.GetArtist();
        }
    }
}
