using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoTrack.PL.Migrations
{
    /// <inheritdoc />
    public partial class enviromentalreportsandtopics : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "enviromentalReportsTopics",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_enviromentalReportsTopics", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EnviromentalReports",
                columns: table => new
                {
                    EnviromentalReportId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    EnviromentalReportsTopicId = table.Column<long>(type: "bigint", nullable: false),
                    Value = table.Column<double>(type: "double", nullable: false),
                    ReportDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnviromentalReports", x => x.EnviromentalReportId);
                    table.ForeignKey(
                        name: "FK_EnviromentalReports_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnviromentalReports_enviromentalReportsTopics_EnviromentalRe~",
                        column: x => x.EnviromentalReportsTopicId,
                        principalTable: "enviromentalReportsTopics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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

            migrationBuilder.CreateIndex(
                name: "IX_EnviromentalReports_EnviromentalReportsTopicId",
                table: "EnviromentalReports",
                column: "EnviromentalReportsTopicId");

            migrationBuilder.CreateIndex(
                name: "IX_EnviromentalReports_UserId",
                table: "EnviromentalReports",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnviromentalReports");

            migrationBuilder.DropTable(
                name: "enviromentalReportsTopics");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -10L,
                column: "BirthDate",
                value: new DateTime(2023, 11, 21, 13, 28, 19, 135, DateTimeKind.Local).AddTicks(3414));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -9L,
                column: "BirthDate",
                value: new DateTime(2023, 11, 21, 13, 28, 19, 135, DateTimeKind.Local).AddTicks(3463));
        }
    }
}
