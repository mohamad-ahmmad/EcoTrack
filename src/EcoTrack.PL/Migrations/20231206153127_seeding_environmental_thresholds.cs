using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EcoTrack.PL.Migrations
{
    /// <inheritdoc />
    public partial class seedingenvironmentalthresholds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "EnviromentalThresholds",
                columns: new[] { "EnviromentalThresholdId", "EnviromentalReportsTopicId", "UserId", "Value" },
                values: new object[,]
                {
                    { -3L, -3L, -10L, 90.0 },
                    { -2L, -2L, -9L, 80.0 },
                    { -1L, -3L, -9L, 20.0 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -10L,
                column: "BirthDate",
                value: new DateTime(2023, 12, 6, 17, 31, 27, 51, DateTimeKind.Local).AddTicks(7531));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -9L,
                column: "BirthDate",
                value: new DateTime(2023, 12, 6, 17, 31, 27, 51, DateTimeKind.Local).AddTicks(7568));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EnviromentalThresholds",
                keyColumn: "EnviromentalThresholdId",
                keyValue: -3L);

            migrationBuilder.DeleteData(
                table: "EnviromentalThresholds",
                keyColumn: "EnviromentalThresholdId",
                keyValue: -2L);

            migrationBuilder.DeleteData(
                table: "EnviromentalThresholds",
                keyColumn: "EnviromentalThresholdId",
                keyValue: -1L);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -10L,
                column: "BirthDate",
                value: new DateTime(2023, 11, 30, 19, 29, 19, 936, DateTimeKind.Local).AddTicks(8975));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -9L,
                column: "BirthDate",
                value: new DateTime(2023, 11, 30, 19, 29, 19, 936, DateTimeKind.Local).AddTicks(9010));
        }
    }
}
