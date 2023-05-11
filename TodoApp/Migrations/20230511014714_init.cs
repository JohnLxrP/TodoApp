using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoApp.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    First_Name = table.Column<string>(type: "ntext", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Todos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Todos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Todos_People_UserId",
                        column: x => x.UserId,
                        principalTable: "People",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "DOB", "Email", "First_Name" },
                values: new object[] { 1, new DateTime(2003, 5, 11, 9, 47, 14, 113, DateTimeKind.Local).AddTicks(7948), null, "Administrator" });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "Id", "Description", "DueDate", "Status", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, "For Birthday", new DateTime(2023, 5, 12, 9, 47, 14, 113, DateTimeKind.Local).AddTicks(8028), false, "Shopping", null },
                    { 2, "In Jump Trainin", new DateTime(2023, 5, 13, 9, 47, 14, 113, DateTimeKind.Local).AddTicks(8036), false, "Learn C#", null },
                    { 3, "In Jump Trainin", new DateTime(2023, 5, 13, 9, 47, 14, 113, DateTimeKind.Local).AddTicks(8037), false, "Learn MSSQL", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Todos_UserId",
                table: "Todos",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Todos");

            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
