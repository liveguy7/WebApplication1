using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class alterEmployeeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "empTarget",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "email", "name" },
                values: new object[] { "han@na.com", "Han" });

            migrationBuilder.InsertData(
                table: "empTarget",
                columns: new[] { "id", "department", "email", "name" },
                values: new object[] { 2, 1, "jon@na.com", "Jon" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "empTarget",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "empTarget",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "email", "name" },
                values: new object[] { "jello@na.com", "Jello" });
        }
    }
}
