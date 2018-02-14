using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PluralSightCoreDemo.Migrations
{
    public partial class CityAdjustments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Restourants_RestaurantsId",
                table: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_Cities_RestaurantsId",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "RestaurantsId",
                table: "Cities");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Restourants",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Restourants_CityId",
                table: "Restourants",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Restourants_Cities_CityId",
                table: "Restourants",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restourants_Cities_CityId",
                table: "Restourants");

            migrationBuilder.DropIndex(
                name: "IX_Restourants_CityId",
                table: "Restourants");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Restourants");

            migrationBuilder.AddColumn<int>(
                name: "RestaurantsId",
                table: "Cities",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cities_RestaurantsId",
                table: "Cities",
                column: "RestaurantsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Restourants_RestaurantsId",
                table: "Cities",
                column: "RestaurantsId",
                principalTable: "Restourants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
