using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GoHunter.Data.Migrations
{
    public partial class IMPLEMENT_JOBOFFER_PROPS_IMPORTANT : Migration
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

            migrationBuilder.AddColumn<string>(
                name: "ContractCode",
                table: "JobOffers",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "OccupationId",
                table: "JobOffers",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobOffers_Occupations_OccupationId",
                table: "JobOffers");

            migrationBuilder.DropIndex(
                name: "IX_JobOffers_OccupationId",
                table: "JobOffers");

            migrationBuilder.DropColumn(
                name: "ContractCode",
                table: "JobOffers");

            migrationBuilder.DropColumn(
                name: "OccupationId",
                table: "JobOffers");

            migrationBuilder.AddColumn<Guid>(
                name: "JobOfferId",
                table: "Occupations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Occupations_JobOfferId",
                table: "Occupations",
                column: "JobOfferId",
                unique: true);

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
