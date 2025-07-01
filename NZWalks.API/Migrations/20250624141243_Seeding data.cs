using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class Seedingdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("949a1506-5b6a-4242-8bf9-0ad053ece225"), "Easy" },
                    { new Guid("deb1e3f2-e4e4-4d8e-ad2b-04a5e6859da7"), "Medium" },
                    { new Guid("f7d3ad4c-47f2-4773-8ac2-731a6da82bdb"), "Hard" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("00220bee-b7d6-4dc1-80f2-c968325cc30d"), "WGN", "Wellington", "https://www.pexels.com/photo/brown-hanging-bridge-surrounded-by-trees-403781/" },
                    { new Guid("7dd441bc-6edd-40f8-a21c-15a908621e99"), "NSN", "Nelson", "https://www.pexels.com/photo/view-of-a-countryside-3396854/" },
                    { new Guid("80393ee4-c338-4b54-a3c9-64c6f2e104f8"), "STL", "Southland", "https://www.pexels.com/photo/calm-lake-1353248/" },
                    { new Guid("add7dacc-8e4f-499c-859a-81f550e66ff0"), "NTL", "Northland", "https://www.pexels.com/photo/cape-reinga-lighthouse-at-sunset-north-island-new-zealand-17824120/" },
                    { new Guid("bc0172df-33e1-4b24-b10c-5795bba96147"), "BOP", "Bay Of Plenty", "https://www.pexels.com/photo/crescent-shaped-coastline-of-mount-maunganui-in-new-zealand-21047861/" },
                    { new Guid("e5ae10b1-653f-4d97-bde8-70c71258b480"), "AKL", "Auckland", "https://www.pexels.com/photo/auckland-city-with-a-view-of-the-sky-tower-new-zealand-17824133/" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("949a1506-5b6a-4242-8bf9-0ad053ece225"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("deb1e3f2-e4e4-4d8e-ad2b-04a5e6859da7"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("f7d3ad4c-47f2-4773-8ac2-731a6da82bdb"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("00220bee-b7d6-4dc1-80f2-c968325cc30d"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("7dd441bc-6edd-40f8-a21c-15a908621e99"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("80393ee4-c338-4b54-a3c9-64c6f2e104f8"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("add7dacc-8e4f-499c-859a-81f550e66ff0"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("bc0172df-33e1-4b24-b10c-5795bba96147"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("e5ae10b1-653f-4d97-bde8-70c71258b480"));
        }
    }
}
