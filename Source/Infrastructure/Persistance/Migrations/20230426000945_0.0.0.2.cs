using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class _0002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Providers_Locations_LocationId",
                schema: "Data",
                table: "Providers");

            migrationBuilder.DropIndex(
                name: "IX_Providers_LocationId",
                schema: "Data",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "LocationId",
                schema: "Data",
                table: "Providers");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_ProviderId",
                schema: "Data",
                table: "Locations",
                column: "ProviderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Providers_ProviderId",
                schema: "Data",
                table: "Locations",
                column: "ProviderId",
                principalSchema: "Data",
                principalTable: "Providers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Providers_ProviderId",
                schema: "Data",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Locations_ProviderId",
                schema: "Data",
                table: "Locations");

            migrationBuilder.AddColumn<Guid>(
                name: "LocationId",
                schema: "Data",
                table: "Providers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Providers_LocationId",
                schema: "Data",
                table: "Providers",
                column: "LocationId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Providers_Locations_LocationId",
                schema: "Data",
                table: "Providers",
                column: "LocationId",
                principalSchema: "Data",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
