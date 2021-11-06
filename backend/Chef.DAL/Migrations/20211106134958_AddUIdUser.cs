using Microsoft.EntityFrameworkCore.Migrations;

namespace Chef.DAL.Migrations
{
    public partial class AddUIdUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UId",
                table: "Users",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UId",
                table: "Users",
                column: "UId",
                unique: true,
                filter: "[UId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_UId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UId",
                table: "Users");
        }
    }
}
