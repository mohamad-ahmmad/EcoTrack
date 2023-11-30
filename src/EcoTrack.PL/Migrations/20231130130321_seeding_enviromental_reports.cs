using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EcoTrack.PL.Migrations
{
    /// <inheritdoc />
    public partial class seedingenviromentalreports : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "EnviromentalReports",
                columns: new[] { "EnviromentalReportId", "EnviromentalReportsTopicId", "IsDeleted", "ReportDate", "UserId", "Value" },
                values: new object[,]
                {
                    { -10L, -3L, false, new DateTime(2023, 11, 30, 13, 3, 21, 400, DateTimeKind.Utc).AddTicks(4164), -9L, 80.0 },
                    { -9L, -2L, false, new DateTime(2023, 11, 30, 13, 3, 21, 400, DateTimeKind.Utc).AddTicks(4166), -9L, 81.400000000000006 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -10L,
                column: "BirthDate",
                value: new DateTime(2023, 11, 30, 15, 3, 21, 400, DateTimeKind.Local).AddTicks(4093));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -9L,
                column: "BirthDate",
                value: new DateTime(2023, 11, 30, 15, 3, 21, 400, DateTimeKind.Local).AddTicks(4136));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EnviromentalReports",
                keyColumn: "EnviromentalReportId",
                keyValue: -10L);

            migrationBuilder.DeleteData(
                table: "EnviromentalReports",
                keyColumn: "EnviromentalReportId",
                keyValue: -9L);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -10L,
                column: "BirthDate",
                value: new DateTime(2023, 11, 27, 21, 12, 0, 967, DateTimeKind.Local).AddTicks(5223));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -9L,
                column: "BirthDate",
                value: new DateTime(2023, 11, 27, 21, 12, 0, 967, DateTimeKind.Local).AddTicks(5278));
        }
    }
}
