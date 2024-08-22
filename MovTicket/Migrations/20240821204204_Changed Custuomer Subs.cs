using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovTicket.Migrations
{
    /// <inheritdoc />
    public partial class ChangedCustuomerSubs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Subscription",
                table: "Customers",
                newName: "c_subscription");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "c_subscription",
                table: "Customers",
                newName: "Subscription");
        }
    }
}
