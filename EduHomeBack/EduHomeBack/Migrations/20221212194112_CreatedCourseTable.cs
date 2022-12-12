using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduHomeBack.Migrations
{
    public partial class CreatedCourseTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
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
                    Name = table.Column<string>(maxLength: 500, nullable: true),
                    Image = table.Column<string>(maxLength: 500, nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    About = table.Column<string>(maxLength: 1000, nullable: true),
                    HowToApply = table.Column<string>(maxLength: 1000, nullable: true),
                    Certification = table.Column<string>(maxLength: 1000, nullable: true),
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
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
