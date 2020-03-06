using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GoHunter.Data.Migrations
{
    public partial class FIX_RELATIONAL_TABLES_JOBOFFER_COMPANY_004 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobOffers_Occupations_OccupationId",
                table: "JobOffers");

            migrationBuilder.DropIndex(
                name: "IX_JobOffers_OccupationId",
                table: "JobOffers");

            migrationBuilder.DropColumn(
                name: "OccupationId",
                table: "JobOffers");

            migrationBuilder.AddColumn<Guid>(
                name: "JobOfferId",
                table: "Occupations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Occupation",
                table: "JobOffers",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Occupation",
                table: "JobOffers");

            migrationBuilder.AddColumn<Guid>(
                name: "OccupationId",
                table: "JobOffers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_JobOffers_OccupationId",
                table: "JobOffers",
                column: "OccupationId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_JobOffers_Occupations_OccupationId",
                table: "JobOffers",
                column: "OccupationId",
                principalTable: "Occupations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
