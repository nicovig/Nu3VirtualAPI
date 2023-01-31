using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NuVirtualApi.Database.Migrations
{
    public partial class FavoriteMeal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.CreateTable(
                name: "FavoriteMeals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Carbohydrate = table.Column<int>(type: "int", nullable: false),
                    Lipid = table.Column<int>(type: "int", nullable: false),
                    Protein = table.Column<int>(type: "int", nullable: false),
                    Calorie = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    MealId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteMeals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavoriteMeals_Meals_MealId",
                        column: x => x.MealId,
                        principalTable: "Meals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavoriteMeals_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteMeals_MealId",
                table: "FavoriteMeals",
                column: "MealId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteMeals_UserId",
                table: "FavoriteMeals",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavoriteMeals");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Birthday", "Email", "FirstName", "Gender", "Height", "IsAdmin", "LastName", "Password", "Pseudo", "Weight" },
                values: new object[] { 1, new DateTime(1994, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "koalaviril@gmail.com", "Nicolas", 1, 168, false, "Vigouroux", "nuvirtual@01", "koalaviril", 76.099999999999994 });
        }
    }
}
