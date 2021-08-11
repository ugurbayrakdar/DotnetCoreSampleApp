using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DotnetCoreSampleApp.Migrations
{
    public partial class First_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Todo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    IsDone = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false),
                    DoneAt = table.Column<DateTimeOffset>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Todo", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Todo");
        }
    }
}
