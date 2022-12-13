using Microsoft.EntityFrameworkCore.Migrations;

namespace EduHomeBack.Migrations
{
    public partial class AddedLinkColToAboutEduHomeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Speakers_Positions_PositionId",
                table: "Speakers");

            migrationBuilder.DropIndex(
                name: "IX_Speakers_PositionId",
                table: "Speakers");

            migrationBuilder.DropColumn(
                name: "PositionId",
                table: "Speakers");

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "Speakers",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "AboutEduHomes",
                maxLength: 500,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Position",
                table: "Speakers");

            migrationBuilder.DropColumn(
                name: "Link",
                table: "AboutEduHomes");

            migrationBuilder.AddColumn<int>(
                name: "PositionId",
                table: "Speakers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Speakers_PositionId",
                table: "Speakers",
                column: "PositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Speakers_Positions_PositionId",
                table: "Speakers",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
