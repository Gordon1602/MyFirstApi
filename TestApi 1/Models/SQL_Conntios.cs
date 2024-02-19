using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;
namespace BookingSytem
{
    class SQL_Conntios
    {
        public  SqlConnection con;

        public void Conntion()
        {
            con = new SqlConnection("Server=192.168.1.158\\GORDONNEWDB,30120; Initial Catalog=MBooking; User Id=User; Password=Password;TrustServerCertificate=True;");
        }

    }
}
