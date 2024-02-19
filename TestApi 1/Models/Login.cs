using System;
using System.Collections.Generic;

namespace TestApi_1.Models;

public partial class Login
{
    public int LoginId { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? Email { get; set; }
}
