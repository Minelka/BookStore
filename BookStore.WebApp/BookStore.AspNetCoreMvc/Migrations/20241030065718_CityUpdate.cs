using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.AspNetCoreMvc.Migrations
{
    /// <inheritdoc />
    public partial class CityUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Creted",
                table: "Cities",
                newName: "Created");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Created",
                table: "Cities",
                newName: "Creted");
        }
    }
}
