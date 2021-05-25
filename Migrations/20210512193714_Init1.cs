using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SanriJP.API.Migrations
{
    public partial class Init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Auctions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParkingPrice1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParkingPrice2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParkingPrice3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParkingPrice4 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auctions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Service = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AtWhatPrice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SizeFOB = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Confirm = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    AuctionId = table.Column<int>(type: "int", nullable: false),
                    LotNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarModel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VINNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Price10Percent = table.Column<int>(type: "int", nullable: false),
                    Recycle = table.Column<int>(type: "int", nullable: false),
                    AuctionFees = table.Column<int>(type: "int", nullable: false),
                    Transport = table.Column<int>(type: "int", nullable: false),
                    FOB = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    TransportationCommission = table.Column<int>(type: "int", nullable: false),
                    Parking = table.Column<byte>(type: "tinyint", nullable: false),
                    CarNumber = table.Column<bool>(type: "bit", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false),
                    Total_FOB = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarOrders_Auctions_AuctionId",
                        column: x => x.AuctionId,
                        principalTable: "Auctions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarOrders_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarResales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerClientId = table.Column<int>(type: "int", nullable: true),
                    StartingPrice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewClientId = table.Column<int>(type: "int", nullable: true),
                    SalePrice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Income = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarResales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarResales_Clients_NewClientId",
                        column: x => x.NewClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CarResales_Clients_OwnerClientId",
                        column: x => x.OwnerClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CarSales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    AuctionId = table.Column<int>(type: "int", nullable: false),
                    CarModel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VINNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Price10Percent = table.Column<int>(type: "int", nullable: false),
                    Recycle = table.Column<int>(type: "int", nullable: false),
                    AuctionFees = table.Column<int>(type: "int", nullable: false),
                    SalesFees = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarSales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarSales_Auctions_AuctionId",
                        column: x => x.AuctionId,
                        principalTable: "Auctions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarSales_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Auctions",
                columns: new[] { "Id", "Name", "ParkingPrice1", "ParkingPrice2", "ParkingPrice3", "ParkingPrice4" },
                values: new object[] { 1, "USS Osaka", "11000", "12000", "11000", "13000" });

            migrationBuilder.InsertData(
                table: "CarModels",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Mersedes Benz" },
                    { 2, "Audi" },
                    { 3, "Nissan" }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "AtWhatPrice", "Confirm", "Country", "CreatedAt", "Email", "FullName", "Login", "Password", "PhoneNumber", "Service", "SizeFOB" },
                values: new object[] { 1, "default", false, "Kyrgyzstan", new DateTime(2021, 5, 12, 19, 37, 13, 101, DateTimeKind.Utc).AddTicks(7845), "qweyn.qwe@gmail.com", "Rysbekov Chekhton", "CHEKHTON", "123qwe", "996996996996", "default", "2000" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CreatedAt", "FullName", "Login", "Password", "Role" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 5, 12, 19, 37, 13, 92, DateTimeKind.Utc).AddTicks(6170), "Adminio", "ADMIN", "Admin123!@#", "Admin" },
                    { 2, new DateTime(2021, 5, 12, 19, 37, 13, 96, DateTimeKind.Utc).AddTicks(779), "Managereto", "MANAGER", "Manager123!@#", "Manager" }
                });

            migrationBuilder.InsertData(
                table: "CarOrders",
                columns: new[] { "Id", "Amount", "AuctionFees", "AuctionId", "CarModel", "CarNumber", "ClientId", "CreatedAt", "FOB", "LotNumber", "Parking", "Price", "Price10Percent", "Recycle", "Total", "Total_FOB", "Transport", "TransportationCommission", "VINNumber", "Year" },
                values: new object[] { 1, 150000, 7700, 1, "Mersedes Benz", false, 1, new DateTime(2021, 5, 12, 19, 37, 13, 108, DateTimeKind.Utc).AddTicks(6809), 65000, "00521", (byte)1, 145000, 14500, 11550, 198750, 380000, 20000, 19000, "q1w2e3", "2020" });

            migrationBuilder.CreateIndex(
                name: "IX_CarOrders_AuctionId",
                table: "CarOrders",
                column: "AuctionId");

            migrationBuilder.CreateIndex(
                name: "IX_CarOrders_ClientId",
                table: "CarOrders",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_CarResales_NewClientId",
                table: "CarResales",
                column: "NewClientId");

            migrationBuilder.CreateIndex(
                name: "IX_CarResales_OwnerClientId",
                table: "CarResales",
                column: "OwnerClientId");

            migrationBuilder.CreateIndex(
                name: "IX_CarSales_AuctionId",
                table: "CarSales",
                column: "AuctionId");

            migrationBuilder.CreateIndex(
                name: "IX_CarSales_ClientId",
                table: "CarSales",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarModels");

            migrationBuilder.DropTable(
                name: "CarOrders");

            migrationBuilder.DropTable(
                name: "CarResales");

            migrationBuilder.DropTable(
                name: "CarSales");

            migrationBuilder.DropTable(
                name: "EmployeeRoles");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Auctions");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
