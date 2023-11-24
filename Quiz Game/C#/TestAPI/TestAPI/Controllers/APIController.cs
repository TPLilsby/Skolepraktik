namespace TestAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Portofolio_hjemmesideCSharp;
    using System.Net.Mail;

    namespace Portofolio_hjemmesideCSharp.Controllers
    {
        // Attribute to mark the class as an API controller
        [ApiController]

        //Attribute to specify the base route for action methods
        [Route("[action]")]

        //APIController class
        public class APIController : ControllerBase
        {
            //Private variable logger instance for logging purposes
            private readonly ILogger<APIController> _logger;

            //Private variable to store database manager instance
            private readonly DALManager _database;

            //Constructor for the APIController class
            public APIController(ILogger<APIController> logger, DALManager database)
            {
                //Assigning the provided ILogger instance to _logger
                _logger = logger;

                //Assigning the provided DALManager instance to _database
                _database = database;
            }

            //HTTP GET action method with the name GetCv
            [HttpGet(Name = "GetCv")]

            //Retrieve a list of Cv objects
            public IEnumerable<Cv> GetCv()
            {
                //Call the corresponding method in the _database instance to fetch the cv data
                return _database.GetCv();

            }

            //HTTP GET action method with the name GetProject
            [HttpGet(Name = "GetProject")]

            //Retrieve a list of Project objects
            public IEnumerable<Project> GetProject()
            {
                //Call the corresponding method in the _database instance to fetch the project data
                return _database.GetProject();

            }

        }
    }
}
