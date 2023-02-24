using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NuVirtualApi.Database.Migrations
{
    public partial class FavoriteMealsNulable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meals_FavoriteMeals_FavoriteMealId",
                table: "Meals");

            migrationBuilder.AlterColumn<int>(
                name: "FavoriteMealId",
                table: "Meals",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_FavoriteMeals_FavoriteMealId",
                table: "Meals",
                column: "FavoriteMealId",
                principalTable: "FavoriteMeals",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meals_FavoriteMeals_FavoriteMealId",
                table: "Meals");

            migrationBuilder.AlterColumn<int>(
                name: "FavoriteMealId",
                table: "Meals",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_FavoriteMeals_FavoriteMealId",
                table: "Meals",
                column: "FavoriteMealId",
                principalTable: "FavoriteMeals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
