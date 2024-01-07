using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zabota.Migrations
{
    /// <inheritdoc />
    public partial class AddedWebhookToTicket : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Webhook",
                table: "Tickets",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Webhook",
                table: "Tickets");
        }
    }
}
