using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace amir_apparel_demo_api_dotnet_5.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Material = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    AvailableQuantity = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AvailableQuantity", "Description", "Material", "Name", "Price", "Status", "Type" },
                values: new object[,]
                {
                    { 1, 10, "Description", "Random Material", "Random Name", 12.11m, true, "Random Type" },
                    { 2, 10, "Description", "Random Material", "Random Name", 12.11m, true, "Random Type" },
                    { 3, 10, "Description", "Random Material", "Random Name", 12.11m, true, "Random Type" },
                    { 4, 10, "Description", "Random Material", "Random Name", 12.11m, true, "Random Type" },
                    { 5, 10, "Description", "Random Material", "Random Name", 12.11m, true, "Random Type" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
