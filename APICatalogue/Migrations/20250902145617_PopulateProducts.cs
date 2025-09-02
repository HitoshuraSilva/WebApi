using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalogue.Migrations
{
    /// <inheritdoc />
    public partial class PopulateProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into Products(Name, Description, Price, ImageUrl, Stock, Created, CategoryId)" +
                   "Values('Diet Coke','350ml Coca-Cola Can',5.45,'cocacola.jpg',50,now(),1)");
            migrationBuilder.Sql("Insert into Products(Name, Description, Price, ImageUrl, Stock, Created, CategoryId)" +
                                 "Values('Mr.Beast Gun','Mr.Beast and Nerf toy gun.',69.99,'beastgun.jpg',10,now(),2)");
            migrationBuilder.Sql("Insert into Products(Name, Description, Price, ImageUrl, Stock, Created, CategoryId)" +
                                 "Values('Sugarstone','One big rock with a little bit of sugar on top',1,'sugarstone.jpg',500,now(),3)");
            migrationBuilder.Sql("Insert into Products(Name, Description, Price, ImageUrl, Stock, Created, CategoryId)" +
                                 """Values('Crack','It\'s just crack',3,'crack.jpg',500,now(),3)""");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from Products");
        }
    }
}
