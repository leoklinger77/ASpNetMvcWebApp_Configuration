using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetCoreMvc.Client.Infrastructure.Migrations
{
    public partial class ini : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    Email = table.Column<string>(type: "varchar(256)", nullable: true),
                    Discriminator = table.Column<string>(type: "varchar(256)", nullable: false),
                    CompanyName = table.Column<string>(type: "varchar(256)", nullable: true),
                    FantasyName = table.Column<string>(type: "varchar(256)", nullable: true),
                    Cnpj = table.Column<string>(type: "varchar(256)", nullable: true),
                    Name = table.Column<string>(type: "varchar(256)", nullable: true),
                    Cpf = table.Column<string>(type: "varchar(256)", nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    ClientId = table.Column<Guid>(nullable: false),
                    ZipCode = table.Column<string>(type: "varchar(256)", nullable: true),
                    Street = table.Column<string>(type: "varchar(256)", nullable: true),
                    Number = table.Column<string>(type: "varchar(256)", nullable: true),
                    Complement = table.Column<string>(type: "varchar(256)", nullable: true),
                    Reference = table.Column<string>(type: "varchar(256)", nullable: true),
                    Neighborhood = table.Column<string>(type: "varchar(256)", nullable: true),
                    City = table.Column<string>(type: "varchar(256)", nullable: true),
                    State = table.Column<string>(type: "varchar(256)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Phone",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    ClientId = table.Column<Guid>(nullable: false),
                    Ddd = table.Column<string>(type: "varchar(256)", nullable: true),
                    Number = table.Column<string>(type: "varchar(256)", nullable: true),
                    PhoneType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phone", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Phone_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_ClientId",
                table: "Address",
                column: "ClientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Phone_ClientId",
                table: "Phone",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Phone");

            migrationBuilder.DropTable(
                name: "Client");
        }
    }
}
