using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace bookbooking.Data.Migrations
{
    public partial class cardUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_AspNetUsers_UserId1",
                table: "Cards");

            migrationBuilder.DropIndex(
                name: "IX_Cards_UserId1",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "FinishReservationTime",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Cards");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Cards",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Cards_UserId",
                table: "Cards",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_AspNetUsers_UserId",
                table: "Cards",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_AspNetUsers_UserId",
                table: "Cards");

            migrationBuilder.DropIndex(
                name: "IX_Cards_UserId",
                table: "Cards");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Cards",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FinishReservationTime",
                table: "Cards",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "Cards",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Cards",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cards_UserId1",
                table: "Cards",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_AspNetUsers_UserId1",
                table: "Cards",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
