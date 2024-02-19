using System;
using System.Collections.Generic;

namespace TestApi_1.Models;

public partial class BookingTabel
{
    public int BookingId { get; set; }

    public string? ClientName { get; set; }

    public string? VehicleMake { get; set; }

    public string? BookingDate { get; set; }

    public TimeSpan? BookingTime { get; set; }

    public string? BookingNotes { get; set; }

    public string? ClietnCar { get; set; }
}
