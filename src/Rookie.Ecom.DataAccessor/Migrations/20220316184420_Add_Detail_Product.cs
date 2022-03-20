using Microsoft.EntityFrameworkCore.Migrations;

namespace Rookie.Ecom.DataAccessor.Migrations
{
    public partial class Add_Detail_Product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Detail",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Detail",
                table: "Product");
        }
    }
}
