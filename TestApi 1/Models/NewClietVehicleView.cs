using System;
using System.Collections.Generic;

namespace TestApi_1.Models;

public partial class NewClietVehicleView
{
    public string? ClientName { get; set; }

    public string? ClientSurename { get; set; }

    public string? ClientPhoneNumber { get; set; }

    public string Description { get; set; } = null!;

    public string? LicenseNumber { get; set; }
}
