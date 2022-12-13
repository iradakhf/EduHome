using Microsoft.EntityFrameworkCore.Migrations;

namespace EduHomeBack.Migrations
{
    public partial class AddedOneTOManyRelationToTestimonialSpeakerAndPosition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorPosition",
                table: "Testimonials");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "Speakers");

            migrationBuilder.AddColumn<int>(
                name: "PositionId",
                table: "Testimonials",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PositionId",
                table: "Speakers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Testimonials_PositionId",
                table: "Testimonials",
                column: "PositionId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Testimonials_Positions_PositionId",
                table: "Testimonials",
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

            migrationBuilder.DropForeignKey(
                name: "FK_Testimonials_Positions_PositionId",
                table: "Testimonials");

            migrationBuilder.DropIndex(
                name: "IX_Testimonials_PositionId",
                table: "Testimonials");

            migrationBuilder.DropIndex(
                name: "IX_Speakers_PositionId",
                table: "Speakers");

            migrationBuilder.DropColumn(
                name: "PositionId",
                table: "Testimonials");

            migrationBuilder.DropColumn(
                name: "PositionId",
                table: "Speakers");

            migrationBuilder.AddColumn<string>(
                name: "AuthorPosition",
                table: "Testimonials",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "Speakers",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);
        }
    }
}
