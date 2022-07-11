using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormBuilder.Migrations
{
    public partial class add_VocabularieId_To_FieldTb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "VocabularieId",
                table: "Fields",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fields_VocabularieId",
                table: "Fields",
                column: "VocabularieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fields_Vocabularies_VocabularieId",
                table: "Fields",
                column: "VocabularieId",
                principalTable: "Vocabularies",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fields_Vocabularies_VocabularieId",
                table: "Fields");

            migrationBuilder.DropIndex(
                name: "IX_Fields_VocabularieId",
                table: "Fields");

            migrationBuilder.DropColumn(
                name: "VocabularieId",
                table: "Fields");
        }
    }
}
