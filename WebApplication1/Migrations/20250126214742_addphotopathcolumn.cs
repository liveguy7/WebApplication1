using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class addphotopathcolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoPath",
                table: "empTarget",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "empTarget",
                keyColumn: "id",
                keyValue: 1,
                column: "PhotoPath",
                value: null);

            migrationBuilder.UpdateData(
                table: "empTarget",
                keyColumn: "id",
                keyValue: 2,
                column: "PhotoPath",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoPath",
                table: "empTarget");
        }
    }
}
