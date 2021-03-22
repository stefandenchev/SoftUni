using Microsoft.EntityFrameworkCore.Migrations;

namespace SoftJail.Migrations
{
    public partial class Final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "Cells");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Mails",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Mails",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                table: "Cells",
                nullable: false,
                defaultValue: 0);
        }
    }
}
