using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NzWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedingdataforDifficultiesandRegions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("c38f1745-3b69-47d1-b7c0-8ca84b559770"), "Medium" },
                    { new Guid("d032d151-9a86-4166-b42f-efd6ab034b5d"), "Easy" },
                    { new Guid("de6f2a3f-623c-4dce-bf11-01868a1d5c70"), "Hard" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("154a22b2-ba16-4b45-997d-84df1f9f5601"), "BOP", "Bay of Plenty", "https://images.pexels.com/photos/5169056/pexels-photo-5169056.jpeg" },
                    { new Guid("1a8921b8-0e47-4cf2-94c6-309b3e969799"), "AKL", "Auckland", "https://images.pexels.com/photos/5169056/pexels-photo-5169056.jpeg" },
                    { new Guid("303caa3a-37bb-45b0-8f30-f032bc3aa9b4"), "NTL", "NorthLand", "https://images.pexels.com/photos/5169056/pexels-photo-5169056.jpeg" },
                    { new Guid("f441a618-bd63-4457-8009-64f825019c80"), "STL", "Southland", "https://images.pexels.com/photos/5169056/pexels-photo-5169056.jpeg" },
                    { new Guid("fdd20847-05aa-47ca-b202-f2e5dfb83c3b"), "NSN", "Nelson", "https://images.pexels.com/photos/5169056/pexels-photo-5169056.jpeg" },
                    { new Guid("fe8e70bf-5175-44c6-90c7-71f5f4c070cc"), "WGN", "Wellington", "https://images.pexels.com/photos/5169056/pexels-photo-5169056.jpeg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("c38f1745-3b69-47d1-b7c0-8ca84b559770"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("d032d151-9a86-4166-b42f-efd6ab034b5d"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("de6f2a3f-623c-4dce-bf11-01868a1d5c70"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("154a22b2-ba16-4b45-997d-84df1f9f5601"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("1a8921b8-0e47-4cf2-94c6-309b3e969799"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("303caa3a-37bb-45b0-8f30-f032bc3aa9b4"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("f441a618-bd63-4457-8009-64f825019c80"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("fdd20847-05aa-47ca-b202-f2e5dfb83c3b"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("fe8e70bf-5175-44c6-90c7-71f5f4c070cc"));
        }
    }
}
