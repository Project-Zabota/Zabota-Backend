using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zabota.Migrations
{
    /// <inheritdoc />
    public partial class AddedDepartmentToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Department",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Department",
                table: "Users");
        }
    }
}
