using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoTrack.PL.Migrations
{
    /// <inheritdoc />
    public partial class enviromentalthreshold : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EnviromentalThresholds",
                columns: table => new
                {
                    EnviromentalThresholdId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    EnviromentalReportsTopicId = table.Column<long>(type: "bigint", nullable: false),
                    Value = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnviromentalThresholds", x => x.EnviromentalThresholdId);
                    table.ForeignKey(
                        name: "FK_EnviromentalThresholds_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnviromentalThresholds_enviromentalReportsTopics_Enviromenta~",
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
                value: new DateTime(2023, 11, 30, 19, 29, 19, 936, DateTimeKind.Local).AddTicks(8975));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -9L,
                column: "BirthDate",
                value: new DateTime(2023, 11, 30, 19, 29, 19, 936, DateTimeKind.Local).AddTicks(9010));

            migrationBuilder.CreateIndex(
                name: "IX_EnviromentalThresholds_EnviromentalReportsTopicId",
                table: "EnviromentalThresholds",
                column: "EnviromentalReportsTopicId");

            migrationBuilder.CreateIndex(
                name: "IX_EnviromentalThresholds_UserId",
                table: "EnviromentalThresholds",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnviromentalThresholds");

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
