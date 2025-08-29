using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalogue.Migrations
{
    /// <inheritdoc />
    public partial class PopulateCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into Categories(Name, ImageUrl) Values('Beverages','beverages.png')");
            migrationBuilder.Sql("Insert into Categories(Name, ImageUrl) Values('Toys','toys.png')");
            migrationBuilder.Sql("Insert into Categories(Name, ImageUrl) Values('Desserts','desserts.png')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from Categories");
        }
    }
}
