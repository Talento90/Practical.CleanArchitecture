using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClassifiedAds.Migrator.Migrations.ProductDb
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Code", "Description", "Name" },
                values: new object[] { new Guid("6672e891-0d94-4620-b38a-dbc5b02da9f7"), "TEST", "Description", "Test" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Code", "Description", "Name" },
                values: new object[] { new Guid("cc9d7eca-6428-4e6d-b40b-2c8d93ab7347"), "PD001", "Iphone X", "Iphone X" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
