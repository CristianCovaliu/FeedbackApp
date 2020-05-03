using Microsoft.EntityFrameworkCore.Migrations;

namespace FeedbackApp.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Teachers_TeacherId",
                table: "Courses");

            migrationBuilder.AlterColumn<int>(
                name: "TeacherId",
                table: "Courses",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "TeacherId", "Description", "FirstName", "LastName" },
                values: new object[] { 1, "Lorem ipsum", "Adriana", "Radulescu" });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "TeacherId", "Description", "FirstName", "LastName" },
                values: new object[] { 2, "Lorem ipsum", "Ioana", "Popescu" });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "TeacherId", "Description", "FirstName", "LastName" },
                values: new object[] { 3, "Lorem ipsum", "Georgiana", "Timofte" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "ImageUrl", "LongDescription", "Price", "ShortDescription", "TeacherId", "Title" },
                values: new object[] { 1, "~/images/englishCourse.jpg", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam in mi erat. Nam id dui vel felis imperdiet posuere.", 200.00m, "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", 1, "English Course" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "ImageUrl", "LongDescription", "Price", "ShortDescription", "TeacherId", "Title" },
                values: new object[] { 2, "~/images/frenchCourse.jpg", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam in mi erat. Nam id dui vel felis imperdiet posuere.", 250.00m, "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", 2, "French Course" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "ImageUrl", "LongDescription", "Price", "ShortDescription", "TeacherId", "Title" },
                values: new object[] { 3, "~/images/italianCourse.jpg", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam in mi erat. Nam id dui vel felis imperdiet posuere.", 250.00m, "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", 3, "Italian Course" });

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Teachers_TeacherId",
                table: "Courses",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Teachers_TeacherId",
                table: "Courses");

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "TeacherId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "TeacherId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "TeacherId",
                keyValue: 3);

            migrationBuilder.AlterColumn<int>(
                name: "TeacherId",
                table: "Courses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Teachers_TeacherId",
                table: "Courses",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
