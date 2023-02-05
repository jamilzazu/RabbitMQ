namespace Airline.API.Models;

public class Booking
{
    private Guid Id { get; }
    public string PassengerName { get; set; }
    public string From { get; set; }
    public string To { get; set; }
}