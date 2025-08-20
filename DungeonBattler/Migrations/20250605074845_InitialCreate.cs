using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DungeonBattler.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NonPlayerChar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Health = table.Column<int>(type: "INTEGER", nullable: false),
                    Attack = table.Column<int>(type: "INTEGER", nullable: false),
                    BaseHealth = table.Column<int>(type: "INTEGER", nullable: false),
                    BaseAttack = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NonPlayerChar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlayerChar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Health = table.Column<int>(type: "INTEGER", nullable: false),
                    Attack = table.Column<int>(type: "INTEGER", nullable: false),
                    Strength = table.Column<int>(type: "INTEGER", nullable: false),
                    Dexterity = table.Column<int>(type: "INTEGER", nullable: false),
                    Inteligence = table.Column<int>(type: "INTEGER", nullable: false),
                    BaseHealth = table.Column<int>(type: "INTEGER", nullable: false),
                    BaseAttack = table.Column<int>(type: "INTEGER", nullable: false),
                    BaseStrength = table.Column<int>(type: "INTEGER", nullable: false),
                    BaseDexterity = table.Column<int>(type: "INTEGER", nullable: false),
                    BaseInteligence = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerChar", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NonPlayerChar");

            migrationBuilder.DropTable(
                name: "PlayerChar");
        }
    }
}
