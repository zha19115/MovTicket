using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovTicket.Migrations
{
    /// <inheritdoc />
    public partial class AddEditList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "c_Phone",
                table: "Customers",
                newName: "c_phone");

            migrationBuilder.RenameColumn(
                name: "c_Email",
                table: "Customers",
                newName: "c_email");

            migrationBuilder.RenameColumn(
                name: "c_Adress",
                table: "Customers",
                newName: "c_address");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "c_phone",
                table: "Customers",
                newName: "c_Phone");

            migrationBuilder.RenameColumn(
                name: "c_email",
                table: "Customers",
                newName: "c_Email");

            migrationBuilder.RenameColumn(
                name: "c_address",
                table: "Customers",
                newName: "c_Adress");
        }
    }
}
