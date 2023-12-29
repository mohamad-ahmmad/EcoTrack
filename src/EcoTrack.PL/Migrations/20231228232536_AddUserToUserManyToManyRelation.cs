using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoTrack.PL.Migrations
{
    /// <inheritdoc />
    public partial class AddUserToUserManyToManyRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserFollows",
                columns: table => new
                {
                    FollowersUserId = table.Column<long>(type: "bigint", nullable: false),
                    FollowsUserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFollows", x => new { x.FollowersUserId, x.FollowsUserId });
                    table.ForeignKey(
                        name: "FK_UserFollows_Users_FollowersUserId",
                        column: x => x.FollowersUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserFollows_Users_FollowsUserId",
                        column: x => x.FollowsUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -10L,
                column: "BirthDate",
                value: new DateTime(2023, 12, 29, 1, 25, 36, 156, DateTimeKind.Local).AddTicks(5058));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -9L,
                column: "BirthDate",
                value: new DateTime(2023, 12, 29, 1, 25, 36, 156, DateTimeKind.Local).AddTicks(5316));

            migrationBuilder.CreateIndex(
                name: "IX_UserFollows_FollowsUserId",
                table: "UserFollows",
                column: "FollowsUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserFollows");

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
    }
}
