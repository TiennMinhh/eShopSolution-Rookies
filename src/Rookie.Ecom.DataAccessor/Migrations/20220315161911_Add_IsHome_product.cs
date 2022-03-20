using Microsoft.EntityFrameworkCore.Migrations;

namespace Rookie.Ecom.DataAccessor.Migrations
{
    public partial class Add_IsHome_product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsHome",
                table: "Product",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsHome",
                table: "Product");
        }
    }
}
