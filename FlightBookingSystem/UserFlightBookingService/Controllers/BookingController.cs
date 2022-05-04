using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SharedClassModels.DataModels;
using SharedClassModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Transactions;

namespace UserFlightBookingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IJWTManagerRepository _iJWTManager;
        private readonly IAdminNUserRegister _adminNUserRegister;
        private readonly IBus _bus;
        public BookingController(IBookingRepository bookingRepository, IJWTManagerRepository iJWTManager, IAdminNUserRegister adminNUserRegister,IBus bus)
        {
            _bookingRepository=bookingRepository;
            _iJWTManager=iJWTManager;
            _adminNUserRegister=adminNUserRegister; 
            _bus=bus;
        }

        //[HttpPost]
        //[Route("BookTicketsQueue")]
        //public async Task<IActionResult> BookTicketsQueue([FromBody] TblBookingdetail bookingdetail)
        //{
        //    //var bookingdetail = stuff["bookingdetail"].ToObject<TblBookingdetail>();
        //    //var passengerlist = stuff["passengerlist"].ToObject<TblPassengerList>();
        //    using (var scope = new TransactionScope())
        //    {
        //        _bookingRepository.InsertBookings(bookingdetail);
        //        scope.Complete();
        //        return Ok(bookingdetail);
        //    }
        //    //if (bookingdetail != null)
        //    //{              
        //    //    Uri uri = new Uri("rabbitmq://localhost/ticketQueue");
        //    //    var endPoint = await _bus.GetSendEndpoint(uri);
        //    //    await endPoint.Send(bookingdetail);
        //    //    return Ok();
        //    //}
        //    //return BadRequest();
        //}

        [HttpPost]
        [Route("BookTickets")]
        public IActionResult BookTickets([FromBody] TblBookingdetail bookingdetail)
        {
            //var bookingdetail = stuff["bookingdetail"].ToObject<TblBookingdetail>();
            //var passengerlist = stuff["passengerlist"].ToObject<TblPassengerList>();
            using (var scope = new TransactionScope())
            {
                _bookingRepository.InsertBookings(bookingdetail);
                scope.Complete();
                return Ok(bookingdetail);
            }
        }
        [HttpPost]
        [Route("UserRegister")]
        public IActionResult Post([FromBody] TblUserName userdet)
        {
            //var bookingdetail = stuff["bookingdetail"].ToObject<TblBookingdetail>();
            //var passengerlist = stuff["passengerlist"].ToObject<TblPassengerList>();
            using (var scope = new TransactionScope())
            {
                _adminNUserRegister.InsertUser(userdet);
                scope.Complete();
                return Ok(userdet);
            }
        }

        [HttpPost]
        [Route("Addpassengers")]
        public IActionResult Post([FromBody] TblPassengerList passengerList)
        {
            //var bookingdetail = stuff["bookingdetail"].ToObject<TblBookingdetail>();
            //var passengerlist = stuff["passengerlist"].ToObject<TblPassengerList>();
            using (var scope = new TransactionScope())
            {
                _bookingRepository.InsertPassengerDetails(passengerList);
                scope.Complete();
                return Ok(passengerList);
            }
        }
        [HttpGet]
        [Route("ViewbyPnr")]
        public IActionResult Get(int pnr)
        {
            return new OkObjectResult(_bookingRepository.ViewBookings(pnr));
        }

        [HttpGet]
        [Route("Viewbymail")]
        public IActionResult Get(string mailid)
        {
            return new OkObjectResult(_bookingRepository.ViewBookings(mailid ));
        }
        [HttpDelete]
        public IActionResult delete(string emailid)
        {
            _bookingRepository.CancelBookings(emailid);
            return Ok();
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate(TblUserName userdata)
        {
            var token = _iJWTManager.Authenticate(userdata);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }
    }
}
