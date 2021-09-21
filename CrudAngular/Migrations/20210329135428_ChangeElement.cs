using Microsoft.EntityFrameworkCore.Migrations;

namespace CrudAngular.Migrations
{
    public partial class ChangeElement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Number",
                table: "PeriodicElements",
                newName: "Position");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Position",
                table: "PeriodicElements",
                newName: "Number");
        }
    }
}
