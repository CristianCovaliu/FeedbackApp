using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FeedbackApp.Domain.Migrations
{
    public partial class CourseUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageMimeType",
                table: "Courses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Courses",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PhotoFile",
                table: "Courses",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageMimeType",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "PhotoFile",
                table: "Courses");
        }
    }
}
