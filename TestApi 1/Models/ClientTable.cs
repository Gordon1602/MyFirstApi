using System;
using System.Collections.Generic;

namespace TestApi_1.Models;

public partial class ClientTable
{
    public int ClientId { get; set; }

    public string? ClientName { get; set; }

    public string? ClientSurename { get; set; }

    public string? ClientPhoneNumde { get; set; }

    internal static void UserSqlServer()
    {
        throw new NotImplementedException();
    }
}
