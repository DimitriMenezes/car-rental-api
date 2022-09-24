using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Car.Rental.Domain.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "auth");

            migrationBuilder.CreateTable(
                name: "Address",
                schema: "auth",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(maxLength: 100, nullable: false),
                    ZipCode = table.Column<string>(maxLength: 8, nullable: false),
                    ReferenceNumber = table.Column<string>(maxLength: 10, nullable: false),
                    Complement = table.Column<string>(maxLength: 100, nullable: true),
                    City = table.Column<string>(maxLength: 100, nullable: false),
                    State = table.Column<string>(maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "auth",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    UserRole = table.Column<string>(nullable: false),
                    Cpf = table.Column<string>(nullable: true),
                    Birthday = table.Column<DateTime>(nullable: true),
                    AddressId = table.Column<int>(nullable: true),
                    EnrollmentCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Address_AddressId",
                        column: x => x.AddressId,
                        principalSchema: "auth",
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_AddressId",
                schema: "auth",
                table: "User",
                column: "AddressId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User",
                schema: "auth");

            migrationBuilder.DropTable(
                name: "Address",
                schema: "auth");
        }
    }
}
