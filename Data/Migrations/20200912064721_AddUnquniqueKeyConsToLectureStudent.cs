using Microsoft.EntityFrameworkCore.Migrations;

namespace aspCoreTraining.Data.Migrations
{
    public partial class AddUnquniqueKeyConsToLectureStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LectureStudents_AspNetUsers_ApplicationUserId",
                table: "LectureStudents");

            migrationBuilder.DropIndex(
                name: "IX_LectureStudents_ApplicationUserId",
                table: "LectureStudents");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "LectureStudents",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "IX_Lecture_student",
                table: "LectureStudents",
                columns: new[] { "ApplicationUserId", "LectureId" });

            migrationBuilder.AddForeignKey(
                name: "FK_LectureStudents_AspNetUsers_ApplicationUserId",
                table: "LectureStudents",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LectureStudents_AspNetUsers_ApplicationUserId",
                table: "LectureStudents");

            migrationBuilder.DropUniqueConstraint(
                name: "IX_Lecture_student",
                table: "LectureStudents");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "LectureStudents",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_LectureStudents_ApplicationUserId",
                table: "LectureStudents",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_LectureStudents_AspNetUsers_ApplicationUserId",
                table: "LectureStudents",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
