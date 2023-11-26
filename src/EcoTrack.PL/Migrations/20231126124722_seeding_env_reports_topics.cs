using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EcoTrack.PL.Migrations
{
    /// <inheritdoc />
    public partial class seedingenvreportstopics : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -10L,
                column: "BirthDate",
                value: new DateTime(2023, 11, 26, 14, 47, 22, 528, DateTimeKind.Local).AddTicks(3776));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -9L,
                column: "BirthDate",
                value: new DateTime(2023, 11, 26, 14, 47, 22, 528, DateTimeKind.Local).AddTicks(3818));

            migrationBuilder.InsertData(
                table: "enviromentalReportsTopics",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { -3L, "Temperature" },
                    { -2L, "Air quality" },
                    { -1L, "Water quality" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "enviromentalReportsTopics",
                keyColumn: "Id",
                keyValue: -3L);

            migrationBuilder.DeleteData(
                table: "enviromentalReportsTopics",
                keyColumn: "Id",
                keyValue: -2L);

            migrationBuilder.DeleteData(
                table: "enviromentalReportsTopics",
                keyColumn: "Id",
                keyValue: -1L);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -10L,
                column: "BirthDate",
                value: new DateTime(2023, 11, 25, 19, 25, 36, 570, DateTimeKind.Local).AddTicks(1488));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -9L,
                column: "BirthDate",
                value: new DateTime(2023, 11, 25, 19, 25, 36, 570, DateTimeKind.Local).AddTicks(1536));
        }
    }
}
