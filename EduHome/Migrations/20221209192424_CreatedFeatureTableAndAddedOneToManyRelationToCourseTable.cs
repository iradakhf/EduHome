using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduHome.Migrations
{
    public partial class CreatedFeatureTableAndAddedOneToManyRelationToCourseTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FeatureId",
                table: "Courses",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Features",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    Starts = table.Column<DateTime>(nullable: true),
                    Duration = table.Column<string>(maxLength: 99, nullable: true),
                    ClassDuration = table.Column<string>(maxLength: 99, nullable: true),
                    SkillLevel = table.Column<string>(maxLength: 500, nullable: true),
                    Language = table.Column<string>(maxLength: 40, nullable: true),
                    StudentsCount = table.Column<int>(nullable: false),
                    Assesments = table.Column<string>(maxLength: 500, nullable: true),
                    Fee = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_FeatureId",
                table: "Courses",
                column: "FeatureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Features_FeatureId",
                table: "Courses",
                column: "FeatureId",
                principalTable: "Features",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Features_FeatureId",
                table: "Courses");

            migrationBuilder.DropTable(
                name: "Features");

            migrationBuilder.DropIndex(
                name: "IX_Courses_FeatureId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "FeatureId",
                table: "Courses");
        }
    }
}
