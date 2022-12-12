using Microsoft.EntityFrameworkCore.Migrations;

namespace EduHomeBack.Migrations
{
    public partial class CreatedOneToManyRelationBetweenTeacherAndPosition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PositionId",
                table: "Teachers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_PositionId",
                table: "Teachers",
                column: "PositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Positions_PositionId",
                table: "Teachers",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Positions_PositionId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_PositionId",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "PositionId",
                table: "Teachers");
        }
    }
}
