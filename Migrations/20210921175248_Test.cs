using Microsoft.EntityFrameworkCore.Migrations;

namespace Registracija.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Registrations_AnswerId",
                table: "Registrations",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_QuestionId",
                table: "Registrations",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Registrations_Answers_AnswerId",
                table: "Registrations",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Registrations_Questions_QuestionId",
                table: "Registrations",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Registrations_Answers_AnswerId",
                table: "Registrations");

            migrationBuilder.DropForeignKey(
                name: "FK_Registrations_Questions_QuestionId",
                table: "Registrations");

            migrationBuilder.DropIndex(
                name: "IX_Registrations_AnswerId",
                table: "Registrations");

            migrationBuilder.DropIndex(
                name: "IX_Registrations_QuestionId",
                table: "Registrations");
        }
    }
}
