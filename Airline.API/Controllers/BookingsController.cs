using Airline.API.Models;
using Airline.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Airline.API.Controllers;

[ApiController]
[Route("[controller]")]
public class BookingsController : Controller
{
    private readonly IMessageProducer _messageProducer;
    private static readonly List<Booking> _bookings = new();

    public BookingsController(ILogger<BookingsController> logger, IMessageProducer messageProducer)
    {
        _messageProducer = messageProducer;
    }

    [HttpPost]
    public IActionResult CreateBooking(Booking booking)
    {
        if (!ModelState.IsValid) return BadRequest();

        _bookings.Add(booking);

        _messageProducer.SendingMessage(booking, "bookings");

        return Ok();
    }
}