using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NeoFilm.Backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserEn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategorieSnacksId",
                table: "Snacks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CategorieSnacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorieSnacks", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Snacks_CategorieSnacksId",
                table: "Snacks",
                column: "CategorieSnacksId");

            migrationBuilder.CreateIndex(
                name: "IX_CategorieSnacks_Name",
                table: "CategorieSnacks",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Snacks_CategorieSnacks_CategorieSnacksId",
                table: "Snacks",
                column: "CategorieSnacksId",
                principalTable: "CategorieSnacks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Snacks_CategorieSnacks_CategorieSnacksId",
                table: "Snacks");

            migrationBuilder.DropTable(
                name: "CategorieSnacks");

            migrationBuilder.DropIndex(
                name: "IX_Snacks_CategorieSnacksId",
                table: "Snacks");

            migrationBuilder.DropColumn(
                name: "CategorieSnacksId",
                table: "Snacks");
        }
    }
}
