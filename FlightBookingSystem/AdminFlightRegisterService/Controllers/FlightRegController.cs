using AdminFlightRegisterService.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedClassModels.DataModels;
using SharedClassModels.ViewModels;
using System.Transactions;

namespace AdminFlightRegisterService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightRegController : ControllerBase
    {
        private readonly IFlightRegRepository _flightRegRepository;
        private readonly IAirlineRegRepository _airlineRegRepository;
        private readonly IJWTManagerRepository _iJWTManager;
        public FlightRegController(IFlightRegRepository flightRegRepository, IAirlineRegRepository airlineRegRepository,IJWTManagerRepository iJWTManager)
        {
            _flightRegRepository=flightRegRepository;
            _airlineRegRepository=airlineRegRepository; 
            _iJWTManager=iJWTManager;
        }
        /// <summary>
        /// POST: api/FlightDetails
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("FlightRegister")]
        public IActionResult Post([FromBody] TblFlightdetail flDetails)
        {
            using (var scope = new TransactionScope())
            {
                _flightRegRepository.InsertFlightDetails(flDetails);
                scope.Complete();
                return Ok(flDetails);
            }
        }

        [HttpPost]
        [Route("AirlineRegister")]
        public IActionResult Post([FromBody] TblAirlineRegister airline)
        {
            using (var scope = new TransactionScope())
            {
               _airlineRegRepository.InsertAirline(airline);
                scope.Complete();
                return Ok(airline);
            }
        }
        [HttpGet]
        [Route("getint")]
        public int getint()
        {
            return 1;
        }

        [HttpPut]
        
        public IActionResult Put([FromBody] TblAirlineRegister airline)
        {
            if (airline != null)
            {
                using (var scope = new TransactionScope())
                {
                    _airlineRegRepository.UpdateAirlineStatus(airline);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate(TblAdminDetail userdata)
        {
            var token = _iJWTManager.AdminAuthenticate(userdata);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }

    }
}
