using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignalR.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_menutable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_moneyCases",
                table: "moneyCases");

            migrationBuilder.RenameTable(
                name: "moneyCases",
                newName: "MoneyCases");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MoneyCases",
                table: "MoneyCases",
                column: "MoneyCaseID");

            migrationBuilder.CreateTable(
                name: "MenuTables",
                columns: table => new
                {
                    MenuTableID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuTables", x => x.MenuTableID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuTables");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MoneyCases",
                table: "MoneyCases");

            migrationBuilder.RenameTable(
                name: "MoneyCases",
                newName: "moneyCases");

            migrationBuilder.AddPrimaryKey(
                name: "PK_moneyCases",
                table: "moneyCases",
                column: "MoneyCaseID");
        }
    }
}
