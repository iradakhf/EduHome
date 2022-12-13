using Microsoft.EntityFrameworkCore.Migrations;

namespace EduHomeBack.Migrations
{
    public partial class AddedOneTOManyRelationToTestimonialSpeakerAndPositio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PositionId",
                table: "Speakers",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
