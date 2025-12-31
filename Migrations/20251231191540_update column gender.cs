using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace divino_visual_api.Migrations
{
    /// <inheritdoc />
    public partial class updatecolumngender : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Genrer",
                table: "Users",
                newName: "Gender");

            migrationBuilder.RenameColumn(
                name: "Genrer",
                table: "Professionals",
                newName: "Gender");

            migrationBuilder.AlterColumn<int>(
                name: "SalonId",
                table: "Services",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Services",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "Users",
                newName: "Genrer");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "Professionals",
                newName: "Genrer");

            migrationBuilder.AlterColumn<int>(
                name: "SalonId",
                table: "Services",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Services",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
