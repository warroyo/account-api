using Microsoft.EntityFrameworkCore.Migrations;

namespace account_api.Migrations
{
    public partial class moreuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 3,
                column: "Email",
                value: "alison.jacobs@ao.com");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 3,
                column: "Email",
                value: "alison.jacobs@aol.com");
        }
    }
}
