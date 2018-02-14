using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PluralSightCoreDemo.Migrations
{
    public partial class AddManyToManyRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "RestaurantCity",
                columns: table => new
                {
                    CityId = table.Column<int>(nullable: false),
                    ReataurantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantCity", x => new { x.CityId, x.ReataurantId });
                    table.ForeignKey(
                        name: "FK_RestaurantCity_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RestaurantCity_Restourants_ReataurantId",
                        column: x => x.ReataurantId,
                        principalTable: "Restourants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantCity_ReataurantId",
                table: "RestaurantCity",
                column: "ReataurantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RestaurantCity");

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
    }
}
