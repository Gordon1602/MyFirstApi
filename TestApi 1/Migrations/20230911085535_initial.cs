using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestApi_1.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Booking_Tabel",
                columns: table => new
                {
                    Booking_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Client_Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Vehicle_Make = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Booking_Date = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Booking_Time = table.Column<TimeSpan>(type: "time(5)", precision: 5, nullable: true),
                    Booking_Notes = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Clietn_Car = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking_Tabel", x => x.Booking_Id);
                });

            migrationBuilder.CreateTable(
                name: "Client_table",
                columns: table => new
                {
                    Client_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Client_Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Client_Surename = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Client_PhoneNumde = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client_table", x => x.Client_id);
                });

            migrationBuilder.CreateTable(
                name: "Client_Vehicle",
                columns: table => new
                {
                    Client_Vehicle_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vehicle_Model = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Vehicle_Make = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Vehicle_Registration = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client_Vehicle", x => x.Client_Vehicle_Id);
                });

            migrationBuilder.CreateTable(
                name: "login",
                columns: table => new
                {
                    Login_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Password = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_login", x => x.Login_Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking_Tabel");

            migrationBuilder.DropTable(
                name: "Client_table");

            migrationBuilder.DropTable(
                name: "Client_Vehicle");

            migrationBuilder.DropTable(
                name: "login");
        }
    }
}
