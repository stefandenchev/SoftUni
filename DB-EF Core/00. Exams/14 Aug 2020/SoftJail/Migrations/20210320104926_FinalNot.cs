using Microsoft.EntityFrameworkCore.Migrations;

namespace SoftJail.Migrations
{
    public partial class FinalNot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prisoners_Cells_CellId",
                table: "Prisoners");

            migrationBuilder.AlterColumn<int>(
                name: "CellId",
                table: "Prisoners",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Prisoners_Cells_CellId",
                table: "Prisoners",
                column: "CellId",
                principalTable: "Cells",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prisoners_Cells_CellId",
                table: "Prisoners");

            migrationBuilder.AlterColumn<int>(
                name: "CellId",
                table: "Prisoners",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Prisoners_Cells_CellId",
                table: "Prisoners",
                column: "CellId",
                principalTable: "Cells",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
