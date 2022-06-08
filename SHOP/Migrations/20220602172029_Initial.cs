using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SHOP.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    desc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    surname = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    adress = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    phone = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    orderTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Spate",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    shortDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    longDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    img = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<int>(type: "int", nullable: false),
                    isFavourite = table.Column<bool>(type: "bit", nullable: false),
                    available = table.Column<bool>(type: "bit", nullable: false),
                    categoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spate", x => x.id);
                    table.ForeignKey(
                        name: "FK_Spate_Category_categoryID",
                        column: x => x.categoryID,
                        principalTable: "Category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orderDetails",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    orderID = table.Column<int>(type: "int", nullable: false),
                    SpateID = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderDetails", x => x.id);
                    table.ForeignKey(
                        name: "FK_orderDetails_Order_orderID",
                        column: x => x.orderID,
                        principalTable: "Order",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orderDetails_Spate_SpateID",
                        column: x => x.SpateID,
                        principalTable: "Spate",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShopSpateItems",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    spateid = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<int>(type: "int", nullable: false),
                    ShopSpateId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopSpateItems", x => x.id);
                    table.ForeignKey(
                        name: "FK_ShopSpateItems_Spate_spateid",
                        column: x => x.spateid,
                        principalTable: "Spate",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_orderDetails_orderID",
                table: "orderDetails",
                column: "orderID");

            migrationBuilder.CreateIndex(
                name: "IX_orderDetails_SpateID",
                table: "orderDetails",
                column: "SpateID");

            migrationBuilder.CreateIndex(
                name: "IX_ShopSpateItems_spateid",
                table: "ShopSpateItems",
                column: "spateid");

            migrationBuilder.CreateIndex(
                name: "IX_Spate_categoryID",
                table: "Spate",
                column: "categoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "orderDetails");

            migrationBuilder.DropTable(
                name: "ShopSpateItems");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Spate");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
