using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Producer.API.Models;
using RabbitMQ.Producer.API.Services;

namespace RabbitMQ.Producer.API.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingsController : ControllerBase
    {
        private readonly ILogger<BookingsController> _logger;
        private readonly IMessageProducer _messageProducer;

        //In-Memory db
        public static readonly List<Booking> _bookings = new();
        public BookingsController(IMessageProducer messageProducer, ILogger<BookingsController> logger)
        {
            _logger = logger;
            _messageProducer = messageProducer;
        }

        [HttpPost]
        public IActionResult CreateBooking(Booking newBooking)
        {
            if(!ModelState.IsValid)
                return BadRequest();
            
            _bookings.Add(newBooking);

            _messageProducer.SendingMessages<Booking>(newBooking);

            return Ok();
        }
    }
}