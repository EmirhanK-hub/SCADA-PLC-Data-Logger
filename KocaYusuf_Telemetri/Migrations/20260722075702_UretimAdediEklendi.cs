using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KocaYusuf_Telemetri.Migrations
{
    /// <inheritdoc />
    public partial class UretimAdediEklendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UretimAdedi",
                table: "MakineVerileri",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UretimAdedi",
                table: "MakineVerileri");
        }
    }
}
