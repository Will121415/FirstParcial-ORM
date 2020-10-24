using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Support",
                columns: table => new
                {
                    IdSupport = table.Column<string>(type: "nvarchar(3)", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    Modality = table.Column<string>(type: "nvarchar(15)", nullable: true),
                    Date = table.Column<string>(type: "nvarchar(15)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Support", x => x.IdSupport);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Identification = table.Column<string>(type: "nvarchar(11)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    Surnames = table.Column<string>(type: "nvarchar(11)", nullable: true),
                    Sex = table.Column<string>(type: "nvarchar(2)", nullable: true),
                    Age = table.Column<int>(nullable: false),
                    Department = table.Column<string>(nullable: true),
                    City = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    IdSupport = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Identification);
                    table.ForeignKey(
                        name: "FK_Persons_Support_IdSupport",
                        column: x => x.IdSupport,
                        principalTable: "Support",
                        principalColumn: "IdSupport",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Persons_IdSupport",
                table: "Persons",
                column: "IdSupport");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Support");
        }
    }
}
