using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogPost_userpost_.Migrations
{
    public partial class initial6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Blog",
                keyColumn: "Id",
                keyValue: 1,
                column: "CategoryId",
                value: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Blog",
                keyColumn: "Id",
                keyValue: 1,
                column: "CategoryId",
                value: null);
        }
    }
}
