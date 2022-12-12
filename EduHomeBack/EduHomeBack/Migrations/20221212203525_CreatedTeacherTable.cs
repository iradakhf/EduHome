using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduHomeBack.Migrations
{
    public partial class CreatedTeacherTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teachers",
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
                    Name = table.Column<string>(maxLength: 255, nullable: true),
                    Surname = table.Column<string>(maxLength: 255, nullable: true),
                    Image = table.Column<string>(maxLength: 50, nullable: true),
                    Profession = table.Column<string>(maxLength: 255, nullable: true),
                    About = table.Column<string>(maxLength: 500, nullable: true),
                    Degree = table.Column<string>(maxLength: 255, nullable: true),
                    Experience = table.Column<string>(maxLength: 255, nullable: true),
                    Faculty = table.Column<string>(maxLength: 255, nullable: true),
                    Hobbies = table.Column<string>(maxLength: 255, nullable: true),
                    Email = table.Column<string>(maxLength: 255, nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 255, nullable: true),
                    Skype = table.Column<string>(maxLength: 255, nullable: true),
                    FacebookUrl = table.Column<string>(maxLength: 255, nullable: true),
                    PinterestUrl = table.Column<string>(maxLength: 255, nullable: true),
                    VUrl = table.Column<string>(maxLength: 255, nullable: true),
                    TwitterUrl = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
