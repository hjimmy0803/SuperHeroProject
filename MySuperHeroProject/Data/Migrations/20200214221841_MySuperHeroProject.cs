using Microsoft.EntityFrameworkCore.Migrations;

namespace MySuperHeroProject.Data.Migrations
{
    public partial class MySuperHeroProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "superheroes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    alterEgo = table.Column<string>(nullable: true),
                    ability = table.Column<string>(nullable: true),
                    secondaryAbility = table.Column<string>(nullable: true),
                    catchPhrase = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_superheroes", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "superheroes");
        }
    }
}
