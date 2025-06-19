using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project1_Api.Migrations
{
    /// <inheritdoc />
    public partial class Intial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateRegistered = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShippingAddressStreet = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ShippingAddressCity = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ShippingAddressState = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ShippingAddressPostalCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ShippingAddressCountry = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ShippingAddressStreet = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ShippingAddressCity = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ShippingAddressState = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ShippingAddressPostalCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ShippingAddressCountry = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PaymentTransactionId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Sku = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPriceAtPurchase = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SessionId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItems_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ShoppingCartItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("66e46801-c588-4b87-8272-2f3bac7b7c89"), null, "Customer", "CUSTOMER" },
                    { new Guid("baa17e21-c8a7-4ce0-a6cf-525b7dc0d68c"), null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateRegistered", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "ShippingAddressCity", "ShippingAddressCountry", "ShippingAddressPostalCode", "ShippingAddressState", "ShippingAddressStreet", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("2174484e-ad52-41bf-b71c-d55eac6bbb4d"), 0, "831e1a2d-2e1b-42ef-a4ef-a89260b2d71b", new DateTime(2025, 4, 4, 5, 14, 57, 890, DateTimeKind.Utc).AddTicks(5706), "alice.w@example.com", true, "Alice", "Wonder", false, null, "ALICE.W@EXAMPLE.COM", "ALICE.W@EXAMPLE.COM", "AQAAAAIAAYagAAAAEIyWzrG79b+XviH3Ep31WK5S8qbZvpyqHMdVpj2vWH6fPWSCmbeCklP8BAEtT9ceEg==", null, false, "5E789CB4-042E-4585-A110-951F39233ED2", "Anytown", "USA", "90210", "CA", "123 Main St", false, "alice.w@example.com" },
                    { new Guid("e40bb8d9-65a2-4e83-a1ee-7101943274f7"), 0, "25b96a69-fead-42e1-bef6-7cc371b76aba", new DateTime(2025, 2, 23, 5, 14, 57, 769, DateTimeKind.Utc).AddTicks(9994), "admin@example.com", true, "Site", "Admin", false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEDvQIwNGpIR1jj8XgCsfFVLuIaJFyrewdo3TjG/q1UGlvXFFmiNDaNxfhSbK6qlyAA==", null, false, "44AC0325-D55F-4270-B312-07C21C90F05C", "Control Panel", "SERVERLAND", "00001", "SYS", "1 Admin Way", false, "admin@example.com" },
                    { new Guid("f42e7270-9c2f-472b-9846-c1390ae66be6"), 0, "679ffee1-c68e-4ace-bddd-d0e1093dc693", new DateTime(2025, 4, 14, 5, 14, 57, 989, DateTimeKind.Utc).AddTicks(1042), "bob.builder@example.com", true, "Bob", "Builder", false, null, "BOB.BUILDER@EXAMPLE.COM", "BOB.BUILDER@EXAMPLE.COM", "AQAAAAIAAYagAAAAEFA+U4nLx4USnZV3tOozRnItVOV70eLL+Is3RcTzKfYHdFs342NJ4ZerkRrRI5ZCkA==", null, false, "B75D4AC3-5C7F-40EB-823E-7A9408B22EB2", "Otherville", "USA", "10001", "NY", "456 Oak Ave", false, "bob.builder@example.com" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("16addfd7-73f2-4bee-9d7b-fb2d39b0f5dc"), "Clothing for all occasions.", "Apparel" },
                    { new Guid("4fd992d2-dfa2-47d8-8cb4-0c128afee1ad"), "Fiction, non-fiction, and educational.", "Books" },
                    { new Guid("55bbe612-be1e-4525-b32d-a86965dd4bda"), "Gadgets, devices, and more.", "Electronics" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("66e46801-c588-4b87-8272-2f3bac7b7c89"), new Guid("2174484e-ad52-41bf-b71c-d55eac6bbb4d") },
                    { new Guid("baa17e21-c8a7-4ce0-a6cf-525b7dc0d68c"), new Guid("e40bb8d9-65a2-4e83-a1ee-7101943274f7") },
                    { new Guid("66e46801-c588-4b87-8272-2f3bac7b7c89"), new Guid("f42e7270-9c2f-472b-9846-c1390ae66be6") }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "OrderDate", "PaymentTransactionId", "ShippingAddressCity", "ShippingAddressCountry", "ShippingAddressPostalCode", "ShippingAddressState", "ShippingAddressStreet", "Status", "TotalAmount", "UserId" },
                values: new object[,]
                {
                    { new Guid("d03b3259-00cc-47e6-a46f-4e9f0041c5c7"), new DateTime(2025, 5, 27, 5, 14, 57, 989, DateTimeKind.Utc).AddTicks(2540), "txn_alice_123seed", "Anytown", "USA", "90210", "CA", "123 Main St", 3, 199.99m, new Guid("2174484e-ad52-41bf-b71c-d55eac6bbb4d") },
                    { new Guid("e9518631-ff4b-4e40-b6f3-8839efa747a2"), new DateTime(2025, 5, 31, 5, 14, 57, 989, DateTimeKind.Utc).AddTicks(2667), "txn_bob_456seed", "Otherville", "USA", "10001", "NY", "456 Oak Ave", 2, 539.40m, new Guid("f42e7270-9c2f-472b-9846-c1390ae66be6") }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "DateCreated", "Description", "ImageUrl", "IsAvailable", "Name", "Price", "Sku", "StockQuantity" },
                values: new object[,]
                {
                    { new Guid("51db9b5c-6fa2-4434-a43c-70d272bff108"), new Guid("16addfd7-73f2-4bee-9d7b-fb2d39b0f5dc"), new DateTime(2025, 5, 24, 5, 14, 57, 989, DateTimeKind.Utc).AddTicks(2305), "Light and airy, perfect for summer.", "/images/products/dress-women.jpg", false, "Women's Summer Dress", 45.00m, "APRL-DRESS-001", 75 },
                    { new Guid("6cdd5be4-e028-43d0-9ddc-b4cda05b055c"), new Guid("4fd992d2-dfa2-47d8-8cb4-0c128afee1ad"), new DateTime(2025, 5, 14, 5, 14, 57, 989, DateTimeKind.Utc).AddTicks(2290), "Three bestselling sci-fi novels.", "/images/products/scifi-books.jpg", true, "The Sci-Fi Novel Collection", 29.99m, "BOOK-SCIFI-001", 100 },
                    { new Guid("a2c61f38-d7ab-454b-ad70-5ca8e70cea55"), new Guid("55bbe612-be1e-4525-b32d-a86965dd4bda"), new DateTime(2025, 5, 9, 5, 14, 57, 989, DateTimeKind.Utc).AddTicks(2286), "Vibrant colors, smart features.", "/images/products/smart-tv.jpg", true, "Smart LED TV 55-inch", 499.50m, "ELEC-TV-002", 25 },
                    { new Guid("bd64618c-9039-4093-a171-703100f2c666"), new Guid("16addfd7-73f2-4bee-9d7b-fb2d39b0f5dc"), new DateTime(2025, 5, 19, 5, 14, 57, 989, DateTimeKind.Utc).AddTicks(2302), "Comfortable and stylish.", "/images/products/tshirt-men.jpg", true, "Men's Classic Cotton T-Shirt", 19.95m, "APRL-TSHRT-001", 200 },
                    { new Guid("f2073be6-3216-49a7-9dfb-c38642e6fe27"), new Guid("55bbe612-be1e-4525-b32d-a86965dd4bda"), new DateTime(2025, 5, 4, 5, 14, 57, 989, DateTimeKind.Utc).AddTicks(2174), "Immerse yourself in sound.", "/images/products/headphones.jpg", true, "Wireless Noise-Cancelling Headphones", 199.99m, "ELEC-HDPH-001", 50 }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "OrderId", "ProductId", "Quantity", "UnitPriceAtPurchase" },
                values: new object[,]
                {
                    { new Guid("5cc4b55d-4691-4b23-9ecd-a2fe2d12c25e"), new Guid("d03b3259-00cc-47e6-a46f-4e9f0041c5c7"), new Guid("f2073be6-3216-49a7-9dfb-c38642e6fe27"), 1, 199.99m },
                    { new Guid("78357495-852e-4cb8-be4e-d07753da9366"), new Guid("e9518631-ff4b-4e40-b6f3-8839efa747a2"), new Guid("a2c61f38-d7ab-454b-ad70-5ca8e70cea55"), 1, 499.50m },
                    { new Guid("9916c04c-a290-4d7e-8835-bc9d22f77f62"), new Guid("e9518631-ff4b-4e40-b6f3-8839efa747a2"), new Guid("bd64618c-9039-4093-a171-703100f2c666"), 2, 19.95m }
                });

            migrationBuilder.InsertData(
                table: "ShoppingCartItems",
                columns: new[] { "Id", "DateAdded", "ProductId", "Quantity", "SessionId", "UserId" },
                values: new object[,]
                {
                    { new Guid("4b8b5ee9-667a-4f7b-b261-ac927391e893"), new DateTime(2025, 6, 1, 5, 14, 57, 989, DateTimeKind.Utc).AddTicks(2410), new Guid("f2073be6-3216-49a7-9dfb-c38642e6fe27"), 1, null, new Guid("2174484e-ad52-41bf-b71c-d55eac6bbb4d") },
                    { new Guid("8a083224-9e95-4690-9d4c-378a4d2e3ae4"), new DateTime(2025, 6, 3, 0, 14, 57, 989, DateTimeKind.Utc).AddTicks(2480), new Guid("6cdd5be4-e028-43d0-9ddc-b4cda05b055c"), 1, null, new Guid("f42e7270-9c2f-472b-9846-c1390ae66be6") },
                    { new Guid("d6e109b5-0547-45b5-a210-551d319eb5e8"), new DateTime(2025, 6, 2, 5, 14, 57, 989, DateTimeKind.Utc).AddTicks(2414), new Guid("bd64618c-9039-4093-a171-703100f2c666"), 2, null, new Guid("2174484e-ad52-41bf-b71c-d55eac6bbb4d") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_ProductId",
                table: "ShoppingCartItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_UserId",
                table: "ShoppingCartItems",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "ShoppingCartItems");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
