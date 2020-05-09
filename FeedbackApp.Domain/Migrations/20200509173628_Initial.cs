using Microsoft.EntityFrameworkCore.Migrations;

namespace FeedbackApp.Domain.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    TeacherId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.TeacherId);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    ShortDescription = table.Column<string>(nullable: true),
                    LongDescription = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    TeacherId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                    table.ForeignKey(
                        name: "FK_Courses_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "TeacherId",
                        onDelete: ReferentialAction.Cascade);
                });

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
                values: new object[] { 1, "/images/englishCourse.jpg", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam in mi erat. Nam id dui vel felis imperdiet posuere.", 200.00m, "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", 1, "English Course" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "ImageUrl", "LongDescription", "Price", "ShortDescription", "TeacherId", "Title" },
                values: new object[] { 2, "/images/frenchCourse.jpg", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam in mi erat. Nam id dui vel felis imperdiet posuere.", 250.00m, "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", 2, "French Course" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "ImageUrl", "LongDescription", "Price", "ShortDescription", "TeacherId", "Title" },
                values: new object[] { 3, "/images/italianCourse.jpg", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam in mi erat. Nam id dui vel felis imperdiet posuere.", 250.00m, "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", 3, "Italian Course" });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_TeacherId",
                table: "Courses",
                column: "TeacherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
