using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SanriJP.API.Migrations
{
    public partial class Init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarOrderId",
                table: "CarResales",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "CarOrders",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 12, 21, 10, 19, 310, DateTimeKind.Utc).AddTicks(6696));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 12, 21, 10, 19, 309, DateTimeKind.Utc).AddTicks(6629));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 12, 21, 10, 19, 306, DateTimeKind.Utc).AddTicks(4067));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 12, 21, 10, 19, 307, DateTimeKind.Utc).AddTicks(9684));

            migrationBuilder.CreateIndex(
                name: "IX_CarResales_CarOrderId",
                table: "CarResales",
                column: "CarOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarResales_CarOrders_CarOrderId",
                table: "CarResales",
                column: "CarOrderId",
                principalTable: "CarOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarResales_CarOrders_CarOrderId",
                table: "CarResales");

            migrationBuilder.DropIndex(
                name: "IX_CarResales_CarOrderId",
                table: "CarResales");

            migrationBuilder.DropColumn(
                name: "CarOrderId",
                table: "CarResales");

            migrationBuilder.UpdateData(
                table: "CarOrders",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 12, 19, 37, 13, 108, DateTimeKind.Utc).AddTicks(6809));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 12, 19, 37, 13, 101, DateTimeKind.Utc).AddTicks(7845));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 12, 19, 37, 13, 92, DateTimeKind.Utc).AddTicks(6170));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 12, 19, 37, 13, 96, DateTimeKind.Utc).AddTicks(779));
        }
    }
}
