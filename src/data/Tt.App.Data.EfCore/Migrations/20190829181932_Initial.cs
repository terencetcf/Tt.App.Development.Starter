using Microsoft.EntityFrameworkCore.Migrations;

namespace Tt.App.Data.EfCore.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ProductCategoryId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductCategories_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategoryProduct",
                columns: table => new
                {
                    ProductCategoryId = table.Column<string>(nullable: false),
                    ProductId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategoryProduct", x => new { x.ProductCategoryId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_ProductCategoryProduct_ProductCategories_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategoryProduct_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "1198eb30-79cb-42ce-a053-037596e053e7", "Category 1" },
                    { "a7f79f0d-e248-406a-9aed-aec22aeb3ac2", "Category 2" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "ProductCategoryId" },
                values: new object[,]
                {
                    { "edf6654f-3612-4914-aa86-1b09ef44e8fd", "Product 1", null },
                    { "7f78ff0f-af4d-41d7-8c6a-a836ed3025cc", "Product 2", null },
                    { "056754ca-e288-4439-b0bd-8a33afcbfcdc", "Product 3", null }
                });

            migrationBuilder.InsertData(
                table: "ProductCategoryProduct",
                columns: new[] { "ProductCategoryId", "ProductId" },
                values: new object[] { "1198eb30-79cb-42ce-a053-037596e053e7", "edf6654f-3612-4914-aa86-1b09ef44e8fd" });

            migrationBuilder.InsertData(
                table: "ProductCategoryProduct",
                columns: new[] { "ProductCategoryId", "ProductId" },
                values: new object[] { "1198eb30-79cb-42ce-a053-037596e053e7", "056754ca-e288-4439-b0bd-8a33afcbfcdc" });

            migrationBuilder.InsertData(
                table: "ProductCategoryProduct",
                columns: new[] { "ProductCategoryId", "ProductId" },
                values: new object[] { "a7f79f0d-e248-406a-9aed-aec22aeb3ac2", "7f78ff0f-af4d-41d7-8c6a-a836ed3025cc" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategoryProduct_ProductId",
                table: "ProductCategoryProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductCategoryId",
                table: "Products",
                column: "ProductCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductCategoryProduct");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ProductCategories");
        }
    }
}
