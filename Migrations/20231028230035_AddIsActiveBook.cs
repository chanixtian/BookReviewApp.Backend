using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookReviewApp.Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddIsActiveBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Books",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Books");
        }
    }
}
