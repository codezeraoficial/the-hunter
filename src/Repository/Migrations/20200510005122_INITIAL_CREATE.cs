using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class INITIAL_CREATE : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Removed = table.Column<bool>(nullable: false),
                    CretedAt = table.Column<DateTime>(nullable: false),
                    LastModifyAt = table.Column<DateTime>(nullable: true),
                    Street = table.Column<string>(type: "varchar(200)", nullable: false),
                    Number = table.Column<string>(type: "varchar(50)", nullable: false),
                    Complement = table.Column<string>(type: "varchar(250)", nullable: false),
                    Cep = table.Column<string>(type: "varchar(8)", nullable: false),
                    Neighborhood = table.Column<string>(type: "varchar(100)", nullable: false),
                    City = table.Column<string>(type: "varchar(100)", nullable: false),
                    Country = table.Column<string>(type: "varchar(50)", nullable: false),
                    State = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsersCombine",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Removed = table.Column<bool>(nullable: false),
                    CretedAt = table.Column<DateTime>(nullable: false),
                    LastModifyAt = table.Column<DateTime>(nullable: true),
                    JobOfferId = table.Column<Guid>(nullable: true),
                    EmployeeId = table.Column<Guid>(nullable: true),
                    Gotcha = table.Column<DateTime>(nullable: true),
                    Dropped = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersCombine", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Removed = table.Column<bool>(nullable: false),
                    CretedAt = table.Column<DateTime>(nullable: false),
                    LastModifyAt = table.Column<DateTime>(nullable: true),
                    Document = table.Column<string>(type: "varchar(20)", nullable: false),
                    Image = table.Column<string>(type: "varchar(100)", nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    KindPlan = table.Column<int>(nullable: false),
                    AddressId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    KindOfCompany = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Companies_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Removed = table.Column<bool>(nullable: false),
                    CretedAt = table.Column<DateTime>(nullable: false),
                    LastModifyAt = table.Column<DateTime>(nullable: true),
                    Document = table.Column<string>(type: "varchar(14)", nullable: false),
                    Image = table.Column<string>(type: "varchar(100)", nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    KindPlan = table.Column<int>(nullable: false),
                    AddressId = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(type: "varchar(50)", nullable: false),
                    LastName = table.Column<string>(type: "varchar(100)", nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JobOffers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Removed = table.Column<bool>(nullable: false),
                    CretedAt = table.Column<DateTime>(nullable: false),
                    LastModifyAt = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    Description = table.Column<string>(type: "varchar(1000)", nullable: false),
                    ContractCode = table.Column<string>(type: "varchar(50)", nullable: false),
                    ContractTime = table.Column<int>(nullable: false),
                    KindOccupation = table.Column<int>(nullable: false),
                    Occupation = table.Column<string>(type: "varchar(100)", nullable: false),
                    CompanyId = table.Column<Guid>(nullable: false),
                    CompanyName = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobOffers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobOffers_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Occupations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Removed = table.Column<bool>(nullable: false),
                    CretedAt = table.Column<DateTime>(nullable: false),
                    LastModifyAt = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(50)", nullable: false),
                    Description = table.Column<string>(type: "varchar(1000)", nullable: false),
                    EmployeeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Occupations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Occupations_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Removed = table.Column<bool>(nullable: false),
                    CretedAt = table.Column<DateTime>(nullable: false),
                    LastModifyAt = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    Description = table.Column<string>(type: "varchar(1000)", nullable: false),
                    Link = table.Column<string>(type: "varchar(100)", nullable: false),
                    EmployeeId = table.Column<Guid>(nullable: false),
                    JobOfferId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skills_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Skills_JobOffers_JobOfferId",
                        column: x => x.JobOfferId,
                        principalTable: "JobOffers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Techs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Removed = table.Column<bool>(nullable: false),
                    CretedAt = table.Column<DateTime>(nullable: false),
                    LastModifyAt = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    Description = table.Column<string>(type: "varchar(1000)", nullable: false),
                    Level = table.Column<string>(type: "varchar(100)", nullable: false),
                    EmployeeId = table.Column<Guid>(nullable: true),
                    JobOfferId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Techs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Techs_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Techs_JobOffers_JobOfferId",
                        column: x => x.JobOfferId,
                        principalTable: "JobOffers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Companies_AddressId",
                table: "Companies",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_AddressId",
                table: "Employees",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobOffers_CompanyId",
                table: "JobOffers",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Occupations_EmployeeId",
                table: "Occupations",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_EmployeeId",
                table: "Skills",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_JobOfferId",
                table: "Skills",
                column: "JobOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_Techs_EmployeeId",
                table: "Techs",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Techs_JobOfferId",
                table: "Techs",
                column: "JobOfferId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Occupations");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Techs");

            migrationBuilder.DropTable(
                name: "UsersCombine");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "JobOffers");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
