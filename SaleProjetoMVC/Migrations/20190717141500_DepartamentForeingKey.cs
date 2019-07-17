using Microsoft.EntityFrameworkCore.Migrations;

namespace SaleProjetoMVC.Migrations
{
    public partial class DepartamentForeingKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seller_Departament_Departamentid",
                table: "Seller");

            migrationBuilder.RenameColumn(
                name: "Departamentid",
                table: "Seller",
                newName: "DepartamentId");

            migrationBuilder.RenameIndex(
                name: "IX_Seller_Departamentid",
                table: "Seller",
                newName: "IX_Seller_DepartamentId");

            migrationBuilder.AlterColumn<int>(
                name: "DepartamentId",
                table: "Seller",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Seller_Departament_DepartamentId",
                table: "Seller",
                column: "DepartamentId",
                principalTable: "Departament",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seller_Departament_DepartamentId",
                table: "Seller");

            migrationBuilder.RenameColumn(
                name: "DepartamentId",
                table: "Seller",
                newName: "Departamentid");

            migrationBuilder.RenameIndex(
                name: "IX_Seller_DepartamentId",
                table: "Seller",
                newName: "IX_Seller_Departamentid");

            migrationBuilder.AlterColumn<int>(
                name: "Departamentid",
                table: "Seller",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Seller_Departament_Departamentid",
                table: "Seller",
                column: "Departamentid",
                principalTable: "Departament",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
