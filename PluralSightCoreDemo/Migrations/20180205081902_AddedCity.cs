using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PluralSightCoreDemo.Migrations
{
    public partial class AddedCity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeRestourant",
                table: "Restourants");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Restourants",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TypeRestaurant",
                table: "Restourants",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Population = table.Column<int>(nullable: false),
                    RestaurantsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Restourants_RestaurantsId",
                        column: x => x.RestaurantsId,
                        principalTable: "Restourants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_RestaurantsId",
                table: "Cities",
                column: "RestaurantsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropColumn(
                name: "TypeRestaurant",
                table: "Restourants");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Restourants",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "TypeRestourant",
                table: "Restourants",
                nullable: false,
                defaultValue: 0);
        }
    }
}
