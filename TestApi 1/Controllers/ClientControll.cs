using BookingSytem;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using Npgsql;
using System.Data;
using TestApi_1.Models;

namespace TestApi_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientControll : ControllerBase
    {
        DataTable datatable;
        SqlDataAdapter sqladapter;


        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        public ClientControll(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }


            [HttpGet]
        [Route("Cleintall")]
        public string Cleintall()
        {
            SQL_Conntios SQl = new SQL_Conntios();
            SQl.Conntion();
            SQl.con.Open();
            string Query = "select * from Client_table";

            SqlCommand com = new SqlCommand(Query, SQl.con);
            sqladapter = new SqlDataAdapter();
            datatable = new DataTable();
            sqladapter.SelectCommand = com;
            sqladapter.Fill(datatable);
            List<ClientTable> clientTablelist = new List<ClientTable>();
            if (datatable.Rows.Count > 0)
            {
                for (int i = 0; i < datatable.Rows.Count; i++)
                {
                    ClientTable clientTable = new ClientTable();
                    clientTable.ClientId = Convert.ToInt32(datatable.Rows[i]["Client_id"]);
                    clientTable.ClientName = Convert.ToString(datatable.Rows[i]["Client_Name"]);
                    clientTable.ClientSurename = Convert.ToString(datatable.Rows[i]["Client_Surename"]);
                    clientTable.ClientPhoneNumde = Convert.ToString(datatable.Rows[i]["Client_PhoneNumde"]);
                    clientTablelist.Add(clientTable);
                }
            }
            if (clientTablelist.Count > 0)
            {
                return JsonConvert.SerializeObject(clientTablelist);
            }
            else { return JsonConvert.SerializeObject(NotFound()); }

        }

        [HttpGet("ClientName={name}")]
        public string GetName(string name)
        {
            SQL_Conntios SQl = new SQL_Conntios();
            SQl.Conntion();
            SQl.con.Open();
            string Query = "select * from Client_table where Client_Name Like '%" + name + "%'";

            SqlCommand com = new SqlCommand(Query, SQl.con);
            sqladapter = new SqlDataAdapter();
            datatable = new DataTable();
            sqladapter.SelectCommand = com;
            sqladapter.Fill(datatable);
            List<ClientTable> clientTablelist = new List<ClientTable>();
            if (datatable.Rows.Count > 0)
            {
                for (int i = 0; i < datatable.Rows.Count; i++)
                {
                    ClientTable clientTable = new ClientTable();
                    clientTable.ClientId = Convert.ToInt32(datatable.Rows[i]["Client_id"]);
                    clientTable.ClientName = Convert.ToString(datatable.Rows[i]["Client_Name"]);
                    clientTable.ClientSurename = Convert.ToString(datatable.Rows[i]["Client_Surename"]);
                    clientTable.ClientPhoneNumde = Convert.ToString(datatable.Rows[i]["Client_PhoneNumde"]);
                    clientTablelist.Add(clientTable);
                }
            }
            if (clientTablelist.Count > 0)
            {
                return JsonConvert.SerializeObject(clientTablelist);
            }
            else { return JsonConvert.SerializeObject(NotFound()); }

        }
        [HttpGet("ClientSurname={surename}")]
        public string GetSurname(string surename)
        {
            SQL_Conntios SQl = new SQL_Conntios();
            SQl.Conntion();
            SQl.con.Open();
            string Query = "select * from Client_table where Client_Surename Like '%" + surename + "%'";

            SqlCommand com = new SqlCommand(Query, SQl.con);
            sqladapter = new SqlDataAdapter();
            datatable = new DataTable();
            sqladapter.SelectCommand = com;
            sqladapter.Fill(datatable);
            List<ClientTable> clientTablelist = new List<ClientTable>();
            if (datatable.Rows.Count > 0)
            {
                for (int i = 0; i < datatable.Rows.Count; i++)
                {
                    ClientTable clientTable = new ClientTable();
                    clientTable.ClientId = Convert.ToInt32(datatable.Rows[i]["Client_id"]);
                    clientTable.ClientName = Convert.ToString(datatable.Rows[i]["Client_Name"]);
                    clientTable.ClientSurename = Convert.ToString(datatable.Rows[i]["Client_Surename"]);
                    clientTable.ClientPhoneNumde = Convert.ToString(datatable.Rows[i]["Client_PhoneNumde"]);
                    clientTablelist.Add(clientTable);
                }
            }
            if (clientTablelist.Count > 0)
            {
                return JsonConvert.SerializeObject(clientTablelist);
            }
            else { return JsonConvert.SerializeObject(NotFound()); }

        }

        // POST api/<Testapi>
        [HttpPost()]
        [Route("ClientAdd")]
        public IActionResult Postadd(string name,string surename,string phonenumber)
        {
            SQL_Conntios SQl = new SQL_Conntios();
            SQl.Conntion();
            SQl.con.Open();
            string Cadd = "insert into Client_table(Client_Name,Client_Surename,Client_PhoneNumde) values('" + name + "','" + surename + "','" +phonenumber + "')";
            SqlCommand com1 = new SqlCommand(Cadd, SQl.con);
            com1.ExecuteNonQuery();
            return Ok("Clients has been added.");
        }
        [HttpPut("ClientId={id}")]
        public IActionResult Put([FromBody] ClientTable client ,int id)
        {

            SQL_Conntios SQl = new SQL_Conntios();
            SQl.Conntion();
            SQl.con.Open();
            string Cadd = "update Client_table set Client_Name='" +client.ClientName + "',Client_Surename='" + client.ClientSurename + "',Client_PhoneNumde='" + client.ClientPhoneNumde + "'where Client_Id = '" +id + "'";
            SqlCommand com1 = new SqlCommand(Cadd, SQl.con);
            com1.ExecuteNonQuery();
            return Ok("Clients has been Update.");


        }
        [HttpDelete("ClientDel={id}")]
        public IActionResult Delete(int id)
        {
            SQL_Conntios SQl = new SQL_Conntios();
            SQl.Conntion();
            SQl.con.Open();
            string Cadd = "DELETE FROM Client_table WHERE Client_Id = '"+ id+"'";
            SqlCommand com1 = new SqlCommand(Cadd, SQl.con);
            com1.ExecuteNonQuery();
            return Ok("Clients has been Delete.");
        }
        // Post Gress Stuff//

        [HttpGet]
        [Route("Cleintallpost")]
        public string Cleintallpost()
        {

            string query = @"select * from""MBooking"".""Client_table""";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();

                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }

            return JsonConvert.SerializeObject(table);
        }

        [HttpGet]
        [Route("CleintSearchpost={clientname}")]
        public string CleintSearchpost( string clientname)
        {

            string query = @"select * from ""MBooking"".""Client_table"" where ""Client_Name"" like '%" + clientname + "%' or \"Client_Surname\" like '%" + clientname + "%' ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();

                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }

            return JsonConvert.SerializeObject(table);
        }

        [HttpPost()]
        [Route("ClientAddPost")]
        public IActionResult CleintPostadd(string name, string surename, string phonenumber)
        {
            string query = @"insert into ""MBooking"".""Client_table""(""Client_Name"", ""Client_Surname"", ""Client_PhoneNumber"") values(@ClientName,@ClientSurname,@ClientPhoneNumber)";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                 
                    myCommand.Parameters.AddWithValue("@ClientName",name);
                    myCommand.Parameters.AddWithValue("@ClientSurname", surename);
                    myCommand.Parameters.AddWithValue("@ClientPhoneNumber", phonenumber);
                
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }
            return new JsonResult("Added Successfully");
        }

        [HttpPut("ClientIdPost={id}")]
        public IActionResult ClientUpdate( int id , string name, string surename, string phonenumber)
        {
            string query = @"UPDATE ""MBooking"".""Client_table"" SET ""Client_Name"" = @ClientName, ""Client_Surname"" = @ClientSurname, ""Client_PhoneNumber"" = @ClientPhoneNumber  WHERE ""Client_Id"" = @Client_Id";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@Client_Id",id);
                    myCommand.Parameters.AddWithValue("@ClientName", name);
                    myCommand.Parameters.AddWithValue("@ClientSurname", surename);
                    myCommand.Parameters.AddWithValue("@ClientPhoneNumber", phonenumber);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }
            return new JsonResult("Updated Successfully "+table+"");
        }

        [HttpDelete("ClientDelPost={id}")]
        public IActionResult ClientDelPost(int id )
        {
            string query = @"DELETE FROM ""MBooking"".""Client_table"" WHERE ""Client_Id"" = @Client_Id";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {

                    myCommand.Parameters.AddWithValue("@Client_Id", id);
                

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }
            return new JsonResult("Deleted Successfully ");
        }


    }
}   
