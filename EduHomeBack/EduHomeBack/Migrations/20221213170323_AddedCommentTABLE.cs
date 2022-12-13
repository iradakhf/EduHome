using Microsoft.EntityFrameworkCore.Migrations;

namespace EduHomeBack.Migrations
{
    public partial class AddedCommentTABLE : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Profession",
                table: "Teachers");

            migrationBuilder.AlterColumn<string>(
                name: "VideoLink",
                table: "VideoTour",
                maxLength: 400,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(400)",
                oldMaxLength: 400,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Email = table.Column<string>(maxLength: 200, nullable: false),
                    Subject = table.Column<string>(maxLength: 200, nullable: true),
                    Message = table.Column<string>(maxLength: 3000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.AlterColumn<string>(
                name: "VideoLink",
                table: "VideoTour",
                type: "nvarchar(400)",
                maxLength: 400,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 400);

            migrationBuilder.AddColumn<string>(
                name: "Profession",
                table: "Teachers",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);
        }
    }
}
