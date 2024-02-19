using System;
using System.Collections.Generic;

namespace TestApi_1.Models;

public partial class ClientVehicle
{
    public int ClientVehicleId { get; set; }

    public string? VehicleModel { get; set; }

    public string? VehicleMake { get; set; }

    public string? VehicleRegistration { get; set; }
}
