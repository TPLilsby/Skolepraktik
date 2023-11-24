using Microsoft.AspNetCore.Mvc;

using MusicLibrary;

namespace MusicLibrary.Controllers
{
    // Attribute to mark the class as an API controller
    [ApiController]

    //Attribute to specify the base route for action methods
    [Route("[action]")]

    //APIController class
    public class AlbumController : ControllerBase
    {
        //Private variable logger instance for logging purposes
        private readonly ILogger<ArtistController> _logger;

        //Private variable to store database manager instance
        private readonly DALManager _database;

        //Constructor for the APIController class
        public AlbumController(ILogger<ArtistController> logger, DALManager database)
        {
            //Assigning the provided ILogger instance to _logger
            _logger = logger;

            //Assigning the provided DALManager instance to _database
            _database = database;
        }

        [HttpGet(Name = "GetAlbum")]

        public IEnumerable<Album> GetAllAlbum()
        {
            return _database.GetAllAlbum();
        }
    }
}