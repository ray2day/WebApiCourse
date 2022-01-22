using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataStore.EF.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectId);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Owner = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ReportDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketId);
                    table.ForeignKey(
                        name: "FK_Tickets_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectId", "Name" },
                values: new object[] { 1, "Project 1" });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectId", "Name" },
                values: new object[] { 2, "Project 2" });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "TicketId", "Description", "DueDate", "Owner", "ProjectId", "ReportDate", "Title" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Raymond van Hoorn", 1, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bug #1" },
                    { 2, null, new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Raymond van Hoorn", 1, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bug #2" },
                    { 5, null, new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maartje Huijink", 1, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Swagger bug" },
                    { 3, null, null, null, 2, null, "Bug #3" },
                    { 4, "A new bug", null, null, 2, null, "Another bug" },
                    { 6, null, new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ton Huijink", 2, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Another Swagger bug" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ProjectId",
                table: "Tickets",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
