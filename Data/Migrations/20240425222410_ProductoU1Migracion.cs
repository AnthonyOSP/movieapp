using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace movieappauth.Data.Migrations
{
    /// <inheritdoc />
    public partial class ProductoU1Migracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "t_producto",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "t_producto");
        }
    }
}
