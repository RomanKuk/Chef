using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Chef.DAL.Migrations
{
    public partial class AddUserProductListRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_ProductLists_ProductListId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_ProductListId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ProductListId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "ProductLists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 20, 14, 34, 35, 482, DateTimeKind.Utc).AddTicks(563));

            migrationBuilder.CreateIndex(
                name: "IX_ProductLists_UserId",
                table: "ProductLists",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductLists_Users_UserId",
                table: "ProductLists",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductLists_Users_UserId",
                table: "ProductLists");

            migrationBuilder.DropIndex(
                name: "IX_ProductLists_UserId",
                table: "ProductLists");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ProductLists");

            migrationBuilder.AddColumn<int>(
                name: "ProductListId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 19, 14, 11, 26, 471, DateTimeKind.Utc).AddTicks(7872));

            migrationBuilder.CreateIndex(
                name: "IX_Users_ProductListId",
                table: "Users",
                column: "ProductListId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_ProductLists_ProductListId",
                table: "Users",
                column: "ProductListId",
                principalTable: "ProductLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
