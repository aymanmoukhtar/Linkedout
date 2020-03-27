using Linkedout.Domain.Interfaces.Repository;
using Linkedout.Domain.Users.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Linkedout.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IReadonlyRepository<User> _userReadonlyRepository;


        public WeatherForecastController(
            IReadonlyRepository<User> userReadonlyRepository
            )
        {
            _userReadonlyRepository = userReadonlyRepository;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return _userReadonlyRepository.GetAll().Select(_ => _.FirstName);
        }
    }
}
