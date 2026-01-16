using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreEF.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FishingTrips");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FishingTrips",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FishingVesselId = table.Column<int>(type: "int", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FishingTrips", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FishingTrips_FishingVessels_FishingVesselId",
                        column: x => x.FishingVesselId,
                        principalTable: "FishingVessels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FishingTrips_FishingVesselId",
                table: "FishingTrips",
                column: "FishingVesselId");
        }
    }
}
