using Microsoft.EntityFrameworkCore.Migrations;

namespace SoftJail.Migrations
{
    public partial class InitialCreateNick : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NickName",
                table: "Prisoners",
                newName: "Nickname");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nickname",
                table: "Prisoners",
                newName: "NickName");
        }
    }
}
