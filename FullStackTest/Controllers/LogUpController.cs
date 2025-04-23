using Bogus;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FullStackTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogUpController : ControllerBase
    {

        public LogUpController()
        {
            
        }

        [HttpGet(Name = "Get")]
        public List<LogUp> Get()
        {
            var logUp = new Faker<LogUp>()

            .RuleFor(p => p.Id, p => Guid.NewGuid())
            .RuleFor(p => p.Title, p => p.Company.CompanyName())
            .RuleFor(p => p.CreatedOn, p => p.Date.Past())
            .RuleFor(p => p.Description, p => p.Lorem.Paragraphs())
            .RuleFor(p => p.Comments, p => p.Lorem.Paragraphs());

            var logUpList = new List<LogUp>();

            for (int i=0; i<10; i++)
            {
                logUpList.Add(logUp.Generate());
            }

            return logUpList;
        }
    }
}
