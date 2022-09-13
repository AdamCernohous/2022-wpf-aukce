using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aukce.Migrations
{
    public partial class UserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Password", "Username" },
                values: new object[] { 1, "adacern019@pslib.cz", "1234", "adamcernohous" });

            migrationBuilder.InsertData(
                table: "Auctions",
                columns: new[] { "Id", "AuthorId", "Description", "LastBuyerId", "Price", "Title", "UserId" },
                values: new object[] { 1, 1, "Drahý obraz!", 1, 69, "Mona Lisa", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
