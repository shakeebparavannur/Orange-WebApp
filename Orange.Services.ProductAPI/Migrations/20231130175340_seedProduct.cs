using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Orange.Services.ProductAPI.Migrations
{
    public partial class seedProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryName", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Appetizer", "roin posuere sollicitudin odio, quis malesuada metus ornare et. Morbi quis gravida eros. Vivamus aliquam iaculis lorem, gravida lobortis est mollis sit amet. Donec ut sapien a neque luctus feugiat in at orci. Cras odio massa, elementum vitae euismod vitae, dapibus et quam. Pellentesque ex arcu, ornare non libero sed, vestibulum vehicula tortor.", "https://orangemicroservice.blob.core.windows.net/menu/samoosa.jpg", "Samosa", 15.0 },
                    { 2, "Appetizer", "roin posuere sollicitudin odio, quis malesuada metus ornare et. Morbi quis gravida eros. Vivamus aliquam iaculis lorem, gravida lobortis est mollis sit amet. Donec ut sapien a neque luctus feugiat in at orci. Cras odio massa, elementum vitae euismod vitae, dapibus et quam. Pellentesque ex arcu, ornare non libero sed, vestibulum vehicula tortor.", "https://orangemicroservice.blob.core.windows.net/menu/paneer.jpg", "Paneer Tikka", 13.99 },
                    { 3, "Desert", "roin posuere sollicitudin odio, quis malesuada metus ornare et. Morbi quis gravida eros. Vivamus aliquam iaculis lorem, gravida lobortis est mollis sit amet. Donec ut sapien a neque luctus feugiat in at orci. Cras odio massa, elementum vitae euismod vitae, dapibus et quam. Pellentesque ex arcu, ornare non libero sed, vestibulum vehicula tortor.", "https://orangemicroservice.blob.core.windows.net/menu/sweet%20pie.jpg", "Sweet Pie", 13.99 },
                    { 4, "Entree", "roin posuere sollicitudin odio, quis malesuada metus ornare et. Morbi quis gravida eros. Vivamus aliquam iaculis lorem, gravida lobortis est mollis sit amet. Donec ut sapien a neque luctus feugiat in at orci. Cras odio massa, elementum vitae euismod vitae, dapibus et quam. Pellentesque ex arcu, ornare non libero sed, vestibulum vehicula tortor.", "https://orangemicroservice.blob.core.windows.net/menu/pavbaji.jpg", "Pav Bhaji", 15.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4);
        }
    }
}
