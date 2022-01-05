using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineMarket.Migrations
{
    public partial class updatedatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CatID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CatName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentID = table.Column<int>(type: "int", nullable: true),
                    Levels = table.Column<int>(type: "int", nullable: true),
                    Ordering = table.Column<int>(type: "int", nullable: true),
                    Published = table.Column<bool>(type: "bit", nullable: false),
                    Thumb = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Alias = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MetaDesc = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MetaKey = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Cover = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SchemaMarkup = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CatID);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Slug = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NameWithType = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ParentCode = table.Column<int>(type: "int", nullable: true),
                    Levels = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationID);
                });

            migrationBuilder.CreateTable(
                name: "Pages",
                columns: table => new
                {
                    PageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PageName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Contents = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Thumb = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Published = table.Column<bool>(type: "bit", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MetaDesc = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MetaKey = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Alias = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Ordering = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pages", x => x.PageID);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PostID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Scontents = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Contents = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Thumb = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Published = table.Column<bool>(type: "bit", nullable: false),
                    Alias = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Author = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    AccountID = table.Column<int>(type: "int", nullable: true),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CatID = table.Column<int>(type: "int", nullable: true),
                    isHot = table.Column<bool>(type: "bit", nullable: false),
                    isNewFeed = table.Column<bool>(type: "bit", nullable: false),
                    MetaKey = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MetaDesc = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Views = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "Shippers",
                columns: table => new
                {
                    ShipperID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShipperName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Phone = table.Column<string>(type: "varchar(12)", unicode: false, maxLength: 12, nullable: true),
                    Company = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    ShipDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shippers", x => x.ShipperID);
                });

            migrationBuilder.CreateTable(
                name: "TransactStatus",
                columns: table => new
                {
                    TransactStatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactStatus", x => x.TransactStatusID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ShortDesc = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CatID = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: true),
                    Discount = table.Column<int>(type: "int", nullable: true),
                    Thumb = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Video = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime", nullable: true),
                    BestSeller = table.Column<bool>(type: "bit", nullable: false),
                    HomeTag = table.Column<bool>(type: "bit", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Alias = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MetaDesc = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MetaKey = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UnitslnStock = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_Products_Categories",
                        column: x => x.CatID,
                        principalTable: "Categories",
                        principalColumn: "CatID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    BirthDay = table.Column<DateTime>(type: "datetime", nullable: true),
                    Avatar = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Email = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable: true),
                    Phone = table.Column<string>(type: "varchar(12)", unicode: false, maxLength: 12, nullable: true),
                    LocationID = table.Column<int>(type: "int", nullable: true),
                    District = table.Column<int>(type: "int", nullable: true),
                    Ward = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Salt = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    LastLogin = table.Column<DateTime>(type: "datetime", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                    table.ForeignKey(
                        name: "FK_Customers_Locations",
                        column: x => x.LocationID,
                        principalTable: "Locations",
                        principalColumn: "LocationID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Phone = table.Column<string>(type: "varchar(12)", unicode: false, maxLength: 12, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Salt = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    RoleID = table.Column<int>(type: "int", nullable: true),
                    LastLogin = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountID);
                    table.ForeignKey(
                        name: "FK_Accounts_Roles",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(type: "int", nullable: true),
                    OrderDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ShipDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    TransactStatusID = table.Column<int>(type: "int", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Paid = table.Column<bool>(type: "bit", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    PaymentID = table.Column<int>(type: "int", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalMoney = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationID = table.Column<int>(type: "int", nullable: true),
                    District = table.Column<int>(type: "int", nullable: true),
                    Ward = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Orders_Customers",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_TransactStatus",
                        column: x => x.TransactStatusID,
                        principalTable: "TransactStatus",
                        principalColumn: "TransactStatusID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderDetailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderID = table.Column<int>(type: "int", nullable: true),
                    ProductID = table.Column<int>(type: "int", nullable: true),
                    OrderNumber = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    Discount = table.Column<int>(type: "int", nullable: true),
                    TotalMoney = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.OrderDetailID);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_RoleID",
                table: "Accounts",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_LocationID",
                table: "Customers",
                column: "LocationID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderID",
                table: "OrderDetails",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductID",
                table: "OrderDetails",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerID",
                table: "Orders",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_TransactStatusID",
                table: "Orders",
                column: "TransactStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CatID",
                table: "Products",
                column: "CatID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Pages");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Shippers");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "TransactStatus");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
