using Microsoft.EntityFrameworkCore.Migrations;

namespace Registracija.Migrations
{
    public partial class remove_answerId_PK_from_Registrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Registrations",
                table: "Registrations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Registrations",
                table: "Registrations",
                columns: new[] { "RegId", "QuestionId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Registrations",
                table: "Registrations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Registrations",
                table: "Registrations",
                columns: new[] { "RegId", "QuestionId", "AnswerId" });
        }
    }
}
