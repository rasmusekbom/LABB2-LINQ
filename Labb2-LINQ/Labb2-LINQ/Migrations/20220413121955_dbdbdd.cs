using Microsoft.EntityFrameworkCore.Migrations;

namespace Labb2_LINQ.Migrations
{
    public partial class dbdbdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Classes_ClassId1",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_ClassId1",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ClassId1",
                table: "Students");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClassId1",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_ClassId1",
                table: "Students",
                column: "ClassId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Classes_ClassId1",
                table: "Students",
                column: "ClassId1",
                principalTable: "Classes",
                principalColumn: "ClassId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
