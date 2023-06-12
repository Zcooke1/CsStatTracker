using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CsStatTracker.Migrations
{
    /// <inheritdoc />
    public partial class Reorganization : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MemberStats");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MemberStats",
                columns: table => new
                {
                    MemberID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ADR = table.Column<int>(type: "int", nullable: false),
                    Assists = table.Column<int>(type: "int", nullable: false),
                    Deaths = table.Column<int>(type: "int", nullable: false),
                    EffectiveFlashes = table.Column<int>(type: "int", nullable: false),
                    Elimations = table.Column<int>(type: "int", nullable: false),
                    HeadShotPercent = table.Column<double>(type: "float", nullable: false),
                    Losses = table.Column<int>(type: "int", nullable: false),
                    Rank = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UtilityDMG = table.Column<int>(type: "int", nullable: false),
                    WinRate = table.Column<double>(type: "float", nullable: false),
                    Wins = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberStats", x => x.MemberID);
                });
        }
    }
}
