using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Assignment4.Entities.Migrations
{
    public partial class Fith : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Task_User_AssignedToIdid",
                table: "Task");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Task",
                table: "Task");

            migrationBuilder.RenameTable(
                name: "Task",
                newName: "Tasks");

            migrationBuilder.RenameIndex(
                name: "IX_Task_AssignedToIdid",
                table: "Tasks",
                newName: "IX_Tasks_AssignedToIdid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Tags = table.Column<List<string>>(type: "text[]", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_User_AssignedToIdid",
                table: "Tasks",
                column: "AssignedToIdid",
                principalTable: "User",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_User_AssignedToIdid",
                table: "Tasks");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks");

            migrationBuilder.RenameTable(
                name: "Tasks",
                newName: "Task");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_AssignedToIdid",
                table: "Task",
                newName: "IX_Task_AssignedToIdid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Task",
                table: "Task",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Task_User_AssignedToIdid",
                table: "Task",
                column: "AssignedToIdid",
                principalTable: "User",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
