using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EduHomeBack.Migrations
{
    public partial class AddedBaseEntityToManyToManyTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "TeacherSkills",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "TeacherSkills",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "TeacherSkills",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "TeacherSkills",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "TeacherSkills",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "TeacherSkills",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "TeacherSkills",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "EventTags",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "EventTags",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "EventTags",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "EventTags",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "EventTags",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "EventTags",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "EventTags",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "EventSpeakers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "EventSpeakers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "EventSpeakers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "EventSpeakers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "EventSpeakers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "EventSpeakers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "EventSpeakers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "CourseTags",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "CourseTags",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "CourseTags",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "CourseTags",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CourseTags",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "CourseTags",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "CourseTags",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "BlogTags",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "BlogTags",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "BlogTags",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "BlogTags",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "BlogTags",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "BlogTags",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "BlogTags",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "TeacherSkills");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "TeacherSkills");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "TeacherSkills");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "TeacherSkills");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "TeacherSkills");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "TeacherSkills");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "TeacherSkills");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "EventTags");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "EventTags");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "EventTags");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "EventTags");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "EventTags");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "EventTags");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "EventTags");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "EventSpeakers");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "EventSpeakers");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "EventSpeakers");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "EventSpeakers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "EventSpeakers");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "EventSpeakers");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "EventSpeakers");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "CourseTags");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "CourseTags");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "CourseTags");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "CourseTags");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CourseTags");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "CourseTags");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "CourseTags");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "BlogTags");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "BlogTags");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "BlogTags");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "BlogTags");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "BlogTags");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "BlogTags");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "BlogTags");
        }
    }
}
