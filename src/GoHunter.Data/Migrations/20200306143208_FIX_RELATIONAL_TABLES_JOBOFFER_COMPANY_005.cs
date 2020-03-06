using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GoHunter.Data.Migrations
{
    public partial class FIX_RELATIONAL_TABLES_JOBOFFER_COMPANY_005 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Occupations_JobOffers_JobOfferId",
                table: "Occupations");

            migrationBuilder.DropIndex(
                name: "IX_Occupations_JobOfferId",
                table: "Occupations");

            migrationBuilder.DropColumn(
                name: "JobOfferId",
                table: "Occupations");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "JobOfferId",
                table: "Occupations",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Occupations_JobOfferId",
                table: "Occupations",
                column: "JobOfferId");

            migrationBuilder.AddForeignKey(
                name: "FK_Occupations_JobOffers_JobOfferId",
                table: "Occupations",
                column: "JobOfferId",
                principalTable: "JobOffers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
