using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeaklyCookingAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddingQuantity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instruction_Recipe_RecipeId",
                table: "Instruction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Instruction",
                table: "Instruction");

            migrationBuilder.RenameTable(
                name: "Instruction",
                newName: "Instructions");

            migrationBuilder.RenameIndex(
                name: "IX_Instruction_RecipeId",
                table: "Instructions",
                newName: "IX_Instructions_RecipeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Instructions",
                table: "Instructions",
                column: "InstructionId");

            migrationBuilder.CreateTable(
                name: "Quantities",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngredientId = table.Column<int>(type: "int", nullable: true),
                    Metric = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quantities", x => x.id);
                    table.ForeignKey(
                        name: "FK_Quantities_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Quantities_IngredientId",
                table: "Quantities",
                column: "IngredientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructions_Recipe_RecipeId",
                table: "Instructions",
                column: "RecipeId",
                principalTable: "Recipe",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructions_Recipe_RecipeId",
                table: "Instructions");

            migrationBuilder.DropTable(
                name: "Quantities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Instructions",
                table: "Instructions");

            migrationBuilder.RenameTable(
                name: "Instructions",
                newName: "Instruction");

            migrationBuilder.RenameIndex(
                name: "IX_Instructions_RecipeId",
                table: "Instruction",
                newName: "IX_Instruction_RecipeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Instruction",
                table: "Instruction",
                column: "InstructionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Instruction_Recipe_RecipeId",
                table: "Instruction",
                column: "RecipeId",
                principalTable: "Recipe",
                principalColumn: "Id");
        }
    }
}
