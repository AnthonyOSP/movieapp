using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace movieappauth.Data.Migrations
{
    /// <inheritdoc />
    public partial class ContactoMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estado",
                table: "t_contacto");

            migrationBuilder.RenameColumn(
                name: "Salario",
                table: "t_contacto",
                newName: "Message");

            migrationBuilder.RenameColumn(
                name: "Puesto",
                table: "t_contacto",
                newName: "Category");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Message",
                table: "t_contacto",
                newName: "Salario");

            migrationBuilder.RenameColumn(
                name: "Category",
                table: "t_contacto",
                newName: "Puesto");

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "t_contacto",
                type: "text",
                nullable: true);
        }
    }
}
