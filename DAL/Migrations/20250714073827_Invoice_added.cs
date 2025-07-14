using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project1_Api.Migrations
{
    /// <inheritdoc />
    public partial class Invoice_added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2cff1266-8f44-4a5c-8ff9-90c81240ca50"), new Guid("29c1f5be-7c4b-41b2-91cc-612970ba7d76") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2c5df0b1-6704-4487-bb58-6eacfe5aacdc"), new Guid("bd658b1a-bcf1-4f75-9ea9-66ba2cbc0e9d") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2cff1266-8f44-4a5c-8ff9-90c81240ca50"), new Guid("c0a270ef-a2a2-46ec-bdbf-839f1c711940") });

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: new Guid("806c81a6-ee40-4adf-a46f-e90da096d826"));

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: new Guid("94587454-b118-4645-a55b-7235e7b126c9"));

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: new Guid("95fd5ecc-73b2-40e4-adbb-b24f653da8f1"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b71d20a2-f2e5-48e7-85e1-5d4417310efd"));

            migrationBuilder.DeleteData(
                table: "ShoppingCartItems",
                keyColumn: "Id",
                keyValue: new Guid("056ba79a-22ba-4427-97f1-1333854d762e"));

            migrationBuilder.DeleteData(
                table: "ShoppingCartItems",
                keyColumn: "Id",
                keyValue: new Guid("06df002f-5c4a-46c8-81a8-e853cb41337b"));

            migrationBuilder.DeleteData(
                table: "ShoppingCartItems",
                keyColumn: "Id",
                keyValue: new Guid("26840e5f-2afe-4a57-8ddb-055848990434"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c5df0b1-6704-4487-bb58-6eacfe5aacdc"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2cff1266-8f44-4a5c-8ff9-90c81240ca50"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bd658b1a-bcf1-4f75-9ea9-66ba2cbc0e9d"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("22b803f9-3cd6-485a-8d0d-5ca8d258eb1d"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("ee32b788-ca28-43e1-a5e4-ecbb0e2d29aa"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9834c7b0-5267-4980-b126-259714e8a910"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b4d3247a-63e3-4bce-a5c2-9ab5d0ea960d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c89cf1bb-80b4-4b98-9d04-fa9c12296860"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d0356126-5777-49bf-8721-d35bc2cfe41c"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("29c1f5be-7c4b-41b2-91cc-612970ba7d76"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c0a270ef-a2a2-46ec-bdbf-839f1c711940"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6c968ba0-0b61-49e3-91fa-24d0ee7c436b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a229fb6e-a164-4fab-b82a-4a46a2e5a357"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f90905d0-7aa7-4e3a-874a-df6c34b44237"));

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPriceAtPurchase = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ShippingAddressStreet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippingAddressCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippingAddressCountry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippingAddressState = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippingAddressPostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("2d6deb72-68d9-415f-a9d7-11752aeb7b2b"), null, "Customer", "CUSTOMER" },
                    { new Guid("60fe8aa1-23bc-4c9d-b559-af0d123479ef"), null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateRegistered", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "ShippingAddressCity", "ShippingAddressCountry", "ShippingAddressPostalCode", "ShippingAddressState", "ShippingAddressStreet", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("35bfb8f2-1fb0-41ed-8096-bda193ac4fc8"), 0, "5a88e428-8452-4274-87b6-eaf95b462707", new DateTime(2025, 5, 15, 7, 38, 25, 712, DateTimeKind.Utc).AddTicks(8014), "alice.w@example.com", true, "Alice", "Wonder", false, null, "ALICE.W@EXAMPLE.COM", "ALICE.W@EXAMPLE.COM", "AQAAAAIAAYagAAAAEOkRZGEcnjYDp1H+Uz2nHlQDLKA36aQzrDLMY5ZBJ2oGSLsYDOc/8vfzhZwzB7p7dg==", null, false, "A8B788F0-B725-426E-86F7-C45F91116214", "Anytown", "USA", "90210", "CA", "123 Main St", false, "alice.w@example.com" },
                    { new Guid("83ce86b5-6abf-45f3-92d3-d4ab600bd7fa"), 0, "85cb39b2-915d-4258-b38b-b5eb90003146", new DateTime(2025, 5, 25, 7, 38, 25, 819, DateTimeKind.Utc).AddTicks(808), "bob.builder@example.com", true, "Bob", "Builder", false, null, "BOB.BUILDER@EXAMPLE.COM", "BOB.BUILDER@EXAMPLE.COM", "AQAAAAIAAYagAAAAEEqqsb8dcfASCYeSic8k+29Sq53RpAdGQ2zyMcvr1mysIV9EdsnjVC6H84UZwiFuJw==", null, false, "E0D00663-8259-4AA1-B2FF-D861C674A7B1", "Otherville", "USA", "10001", "NY", "456 Oak Ave", false, "bob.builder@example.com" },
                    { new Guid("8665ac0d-942e-4286-bdb0-4a5adb0cce6f"), 0, "e4b09e0f-fd21-4264-8257-5de45b966120", new DateTime(2025, 4, 5, 7, 38, 25, 564, DateTimeKind.Utc).AddTicks(1330), "admin@example.com", true, "Site", "Admin", false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEG/wDEMF24LXjcsgKvA/g7LWflaw0cf346lrDpEaBussX4Kj2FYPk8BHoXTUYLGe5w==", null, false, "D2E97A3A-3CFA-4936-8B62-1028AE317165", "Control Panel", "SERVERLAND", "00001", "SYS", "1 Admin Way", false, "admin@example.com" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("bb3e85c2-57e5-4bea-bddb-c038ad642772"), "Gadgets, devices, and more.", "Electronics" },
                    { new Guid("c3d404f5-0389-4702-8928-ec414c490971"), "Fiction, non-fiction, and educational.", "Books" },
                    { new Guid("e3ada52d-b5ae-4648-8c01-a7bc90cd537b"), "Clothing for all occasions.", "Apparel" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("2d6deb72-68d9-415f-a9d7-11752aeb7b2b"), new Guid("35bfb8f2-1fb0-41ed-8096-bda193ac4fc8") },
                    { new Guid("2d6deb72-68d9-415f-a9d7-11752aeb7b2b"), new Guid("83ce86b5-6abf-45f3-92d3-d4ab600bd7fa") },
                    { new Guid("60fe8aa1-23bc-4c9d-b559-af0d123479ef"), new Guid("8665ac0d-942e-4286-bdb0-4a5adb0cce6f") }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "ApplicationUserId", "OrderDate", "PaymentTransactionId", "ShippingAddressCity", "ShippingAddressCountry", "ShippingAddressPostalCode", "ShippingAddressState", "ShippingAddressStreet", "Status", "TotalAmount", "UserId" },
                values: new object[,]
                {
                    { new Guid("257e85c4-714f-4e69-a62f-75e040d9ea73"), null, new DateTime(2025, 7, 7, 7, 38, 25, 819, DateTimeKind.Utc).AddTicks(2506), "txn_alice_123seed", "Anytown", "USA", "90210", "CA", "123 Main St", 3, 199.99m, new Guid("35bfb8f2-1fb0-41ed-8096-bda193ac4fc8") },
                    { new Guid("e813e236-a887-46d6-9ed0-304cbd5981b5"), null, new DateTime(2025, 7, 11, 7, 38, 25, 819, DateTimeKind.Utc).AddTicks(2673), "txn_bob_456seed", "Otherville", "USA", "10001", "NY", "456 Oak Ave", 2, 539.40m, new Guid("83ce86b5-6abf-45f3-92d3-d4ab600bd7fa") }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "DateCreated", "Description", "ImageUrl", "IsAvailable", "Name", "Price", "Sku", "StockQuantity" },
                values: new object[,]
                {
                    { new Guid("53415843-74d3-4676-b59d-b3a9a3b277b2"), new Guid("e3ada52d-b5ae-4648-8c01-a7bc90cd537b"), new DateTime(2025, 6, 29, 7, 38, 25, 819, DateTimeKind.Utc).AddTicks(2127), "Comfortable and stylish.", "/images/products/tshirt-men.jpg", true, "Men's Classic Cotton T-Shirt", 19.95m, "APRL-TSHRT-001", 200 },
                    { new Guid("6ea500af-8c4e-44db-8e70-a6568f564c0a"), new Guid("c3d404f5-0389-4702-8928-ec414c490971"), new DateTime(2025, 6, 24, 7, 38, 25, 819, DateTimeKind.Utc).AddTicks(2123), "Three bestselling sci-fi novels.", "/images/products/scifi-books.jpg", true, "The Sci-Fi Novel Collection", 29.99m, "BOOK-SCIFI-001", 100 },
                    { new Guid("9c83f4d1-1a27-47b1-8863-919078e0e694"), new Guid("bb3e85c2-57e5-4bea-bddb-c038ad642772"), new DateTime(2025, 6, 19, 7, 38, 25, 819, DateTimeKind.Utc).AddTicks(2118), "Vibrant colors, smart features.", "/images/products/smart-tv.jpg", true, "Smart LED TV 55-inch", 499.50m, "ELEC-TV-002", 25 },
                    { new Guid("a029009b-2ad2-474c-b6fe-819d0054589d"), new Guid("e3ada52d-b5ae-4648-8c01-a7bc90cd537b"), new DateTime(2025, 7, 4, 7, 38, 25, 819, DateTimeKind.Utc).AddTicks(2136), "Light and airy, perfect for summer.", "/images/products/dress-women.jpg", false, "Women's Summer Dress", 45.00m, "APRL-DRESS-001", 75 },
                    { new Guid("dfc24533-574d-4991-a0f7-642348ff505d"), new Guid("bb3e85c2-57e5-4bea-bddb-c038ad642772"), new DateTime(2025, 6, 14, 7, 38, 25, 819, DateTimeKind.Utc).AddTicks(1975), "Immerse yourself in sound.", "/images/products/headphones.jpg", true, "Wireless Noise-Cancelling Headphones", 199.99m, "ELEC-HDPH-001", 50 }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "OrderId", "ProductId", "Quantity", "UnitPriceAtPurchase" },
                values: new object[,]
                {
                    { new Guid("ace75cf8-2ebf-4a93-a86c-1554e3dbb56b"), new Guid("e813e236-a887-46d6-9ed0-304cbd5981b5"), new Guid("9c83f4d1-1a27-47b1-8863-919078e0e694"), 1, 499.50m },
                    { new Guid("d7ffddb7-f991-455c-ad00-6abe687f3a1c"), new Guid("257e85c4-714f-4e69-a62f-75e040d9ea73"), new Guid("dfc24533-574d-4991-a0f7-642348ff505d"), 1, 199.99m },
                    { new Guid("fb7ec843-1357-4430-8582-2e4c9cbf585f"), new Guid("e813e236-a887-46d6-9ed0-304cbd5981b5"), new Guid("53415843-74d3-4676-b59d-b3a9a3b277b2"), 2, 19.95m }
                });

            migrationBuilder.InsertData(
                table: "ShoppingCartItems",
                columns: new[] { "Id", "ApplicationUserId", "DateAdded", "ProductId", "Quantity", "SessionId", "UserId" },
                values: new object[,]
                {
                    { new Guid("6ac5c8ca-13fc-478f-b779-6e97a2632d77"), null, new DateTime(2025, 7, 12, 7, 38, 25, 819, DateTimeKind.Utc).AddTicks(2294), new Guid("dfc24533-574d-4991-a0f7-642348ff505d"), 1, null, new Guid("35bfb8f2-1fb0-41ed-8096-bda193ac4fc8") },
                    { new Guid("91f7f2b7-5b2d-4e94-b26b-9f563f9673e5"), null, new DateTime(2025, 7, 13, 7, 38, 25, 819, DateTimeKind.Utc).AddTicks(2300), new Guid("53415843-74d3-4676-b59d-b3a9a3b277b2"), 2, null, new Guid("35bfb8f2-1fb0-41ed-8096-bda193ac4fc8") },
                    { new Guid("ba9773d8-a289-41b5-a26c-efb1797d132f"), null, new DateTime(2025, 7, 14, 2, 38, 25, 819, DateTimeKind.Utc).AddTicks(2390), new Guid("6ea500af-8c4e-44db-8e70-a6568f564c0a"), 1, null, new Guid("83ce86b5-6abf-45f3-92d3-d4ab600bd7fa") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2d6deb72-68d9-415f-a9d7-11752aeb7b2b"), new Guid("35bfb8f2-1fb0-41ed-8096-bda193ac4fc8") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2d6deb72-68d9-415f-a9d7-11752aeb7b2b"), new Guid("83ce86b5-6abf-45f3-92d3-d4ab600bd7fa") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("60fe8aa1-23bc-4c9d-b559-af0d123479ef"), new Guid("8665ac0d-942e-4286-bdb0-4a5adb0cce6f") });

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: new Guid("ace75cf8-2ebf-4a93-a86c-1554e3dbb56b"));

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: new Guid("d7ffddb7-f991-455c-ad00-6abe687f3a1c"));

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: new Guid("fb7ec843-1357-4430-8582-2e4c9cbf585f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a029009b-2ad2-474c-b6fe-819d0054589d"));

            migrationBuilder.DeleteData(
                table: "ShoppingCartItems",
                keyColumn: "Id",
                keyValue: new Guid("6ac5c8ca-13fc-478f-b779-6e97a2632d77"));

            migrationBuilder.DeleteData(
                table: "ShoppingCartItems",
                keyColumn: "Id",
                keyValue: new Guid("91f7f2b7-5b2d-4e94-b26b-9f563f9673e5"));

            migrationBuilder.DeleteData(
                table: "ShoppingCartItems",
                keyColumn: "Id",
                keyValue: new Guid("ba9773d8-a289-41b5-a26c-efb1797d132f"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2d6deb72-68d9-415f-a9d7-11752aeb7b2b"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("60fe8aa1-23bc-4c9d-b559-af0d123479ef"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8665ac0d-942e-4286-bdb0-4a5adb0cce6f"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("257e85c4-714f-4e69-a62f-75e040d9ea73"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("e813e236-a887-46d6-9ed0-304cbd5981b5"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("53415843-74d3-4676-b59d-b3a9a3b277b2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6ea500af-8c4e-44db-8e70-a6568f564c0a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9c83f4d1-1a27-47b1-8863-919078e0e694"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("dfc24533-574d-4991-a0f7-642348ff505d"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("35bfb8f2-1fb0-41ed-8096-bda193ac4fc8"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("83ce86b5-6abf-45f3-92d3-d4ab600bd7fa"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("bb3e85c2-57e5-4bea-bddb-c038ad642772"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c3d404f5-0389-4702-8928-ec414c490971"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e3ada52d-b5ae-4648-8c01-a7bc90cd537b"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("2c5df0b1-6704-4487-bb58-6eacfe5aacdc"), null, "Admin", "ADMIN" },
                    { new Guid("2cff1266-8f44-4a5c-8ff9-90c81240ca50"), null, "Customer", "CUSTOMER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateRegistered", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "ShippingAddressCity", "ShippingAddressCountry", "ShippingAddressPostalCode", "ShippingAddressState", "ShippingAddressStreet", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("29c1f5be-7c4b-41b2-91cc-612970ba7d76"), 0, "16742f2c-1951-408c-9848-99f55ae77f21", new DateTime(2025, 5, 15, 7, 25, 47, 681, DateTimeKind.Utc).AddTicks(2716), "alice.w@example.com", true, "Alice", "Wonder", false, null, "ALICE.W@EXAMPLE.COM", "ALICE.W@EXAMPLE.COM", "AQAAAAIAAYagAAAAEH3wlVGve6UAyX11pxj3rU2JaaNE6c81lFrPjWLRUrwvhyknMCdgcTAxHL2lg6TjzQ==", null, false, "1A5D3862-3729-4D40-8AF5-A3867F936656", "Anytown", "USA", "90210", "CA", "123 Main St", false, "alice.w@example.com" },
                    { new Guid("bd658b1a-bcf1-4f75-9ea9-66ba2cbc0e9d"), 0, "62302311-99ee-4ad0-af80-1a3262dc5c2b", new DateTime(2025, 4, 5, 7, 25, 47, 587, DateTimeKind.Utc).AddTicks(2082), "admin@example.com", true, "Site", "Admin", false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEI5YOgpidYR3mHWN3IpQWHvEHFVsRzw0MxKBLS48FPF3f2mMpn+og1aUkYFEdtCe5w==", null, false, "31E34A5C-AF5E-4C48-B66D-4D6282FAC846", "Control Panel", "SERVERLAND", "00001", "SYS", "1 Admin Way", false, "admin@example.com" },
                    { new Guid("c0a270ef-a2a2-46ec-bdbf-839f1c711940"), 0, "ebe75f49-3c9c-435a-94bf-cc4f92c198f6", new DateTime(2025, 5, 25, 7, 25, 47, 788, DateTimeKind.Utc).AddTicks(9614), "bob.builder@example.com", true, "Bob", "Builder", false, null, "BOB.BUILDER@EXAMPLE.COM", "BOB.BUILDER@EXAMPLE.COM", "AQAAAAIAAYagAAAAEPwhzplfhg0cDbh1RxoyVJ6d21XgCmkarSFZffMKmmFIRTFr19j+fOV49ocdUBv6vg==", null, false, "902921F7-883A-413C-AE67-F317A99182DB", "Otherville", "USA", "10001", "NY", "456 Oak Ave", false, "bob.builder@example.com" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("6c968ba0-0b61-49e3-91fa-24d0ee7c436b"), "Clothing for all occasions.", "Apparel" },
                    { new Guid("a229fb6e-a164-4fab-b82a-4a46a2e5a357"), "Gadgets, devices, and more.", "Electronics" },
                    { new Guid("f90905d0-7aa7-4e3a-874a-df6c34b44237"), "Fiction, non-fiction, and educational.", "Books" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("2cff1266-8f44-4a5c-8ff9-90c81240ca50"), new Guid("29c1f5be-7c4b-41b2-91cc-612970ba7d76") },
                    { new Guid("2c5df0b1-6704-4487-bb58-6eacfe5aacdc"), new Guid("bd658b1a-bcf1-4f75-9ea9-66ba2cbc0e9d") },
                    { new Guid("2cff1266-8f44-4a5c-8ff9-90c81240ca50"), new Guid("c0a270ef-a2a2-46ec-bdbf-839f1c711940") }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "ApplicationUserId", "OrderDate", "PaymentTransactionId", "ShippingAddressCity", "ShippingAddressCountry", "ShippingAddressPostalCode", "ShippingAddressState", "ShippingAddressStreet", "Status", "TotalAmount", "UserId" },
                values: new object[,]
                {
                    { new Guid("22b803f9-3cd6-485a-8d0d-5ca8d258eb1d"), null, new DateTime(2025, 7, 7, 7, 25, 47, 789, DateTimeKind.Utc).AddTicks(1107), "txn_alice_123seed", "Anytown", "USA", "90210", "CA", "123 Main St", 3, 199.99m, new Guid("29c1f5be-7c4b-41b2-91cc-612970ba7d76") },
                    { new Guid("ee32b788-ca28-43e1-a5e4-ecbb0e2d29aa"), null, new DateTime(2025, 7, 11, 7, 25, 47, 789, DateTimeKind.Utc).AddTicks(1319), "txn_bob_456seed", "Otherville", "USA", "10001", "NY", "456 Oak Ave", 2, 539.40m, new Guid("c0a270ef-a2a2-46ec-bdbf-839f1c711940") }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "DateCreated", "Description", "ImageUrl", "IsAvailable", "Name", "Price", "Sku", "StockQuantity" },
                values: new object[,]
                {
                    { new Guid("9834c7b0-5267-4980-b126-259714e8a910"), new Guid("a229fb6e-a164-4fab-b82a-4a46a2e5a357"), new DateTime(2025, 6, 19, 7, 25, 47, 789, DateTimeKind.Utc).AddTicks(797), "Vibrant colors, smart features.", "/images/products/smart-tv.jpg", true, "Smart LED TV 55-inch", 499.50m, "ELEC-TV-002", 25 },
                    { new Guid("b4d3247a-63e3-4bce-a5c2-9ab5d0ea960d"), new Guid("f90905d0-7aa7-4e3a-874a-df6c34b44237"), new DateTime(2025, 6, 24, 7, 25, 47, 789, DateTimeKind.Utc).AddTicks(802), "Three bestselling sci-fi novels.", "/images/products/scifi-books.jpg", true, "The Sci-Fi Novel Collection", 29.99m, "BOOK-SCIFI-001", 100 },
                    { new Guid("b71d20a2-f2e5-48e7-85e1-5d4417310efd"), new Guid("6c968ba0-0b61-49e3-91fa-24d0ee7c436b"), new DateTime(2025, 7, 4, 7, 25, 47, 789, DateTimeKind.Utc).AddTicks(810), "Light and airy, perfect for summer.", "/images/products/dress-women.jpg", false, "Women's Summer Dress", 45.00m, "APRL-DRESS-001", 75 },
                    { new Guid("c89cf1bb-80b4-4b98-9d04-fa9c12296860"), new Guid("6c968ba0-0b61-49e3-91fa-24d0ee7c436b"), new DateTime(2025, 6, 29, 7, 25, 47, 789, DateTimeKind.Utc).AddTicks(806), "Comfortable and stylish.", "/images/products/tshirt-men.jpg", true, "Men's Classic Cotton T-Shirt", 19.95m, "APRL-TSHRT-001", 200 },
                    { new Guid("d0356126-5777-49bf-8721-d35bc2cfe41c"), new Guid("a229fb6e-a164-4fab-b82a-4a46a2e5a357"), new DateTime(2025, 6, 14, 7, 25, 47, 789, DateTimeKind.Utc).AddTicks(788), "Immerse yourself in sound.", "/images/products/headphones.jpg", true, "Wireless Noise-Cancelling Headphones", 199.99m, "ELEC-HDPH-001", 50 }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "OrderId", "ProductId", "Quantity", "UnitPriceAtPurchase" },
                values: new object[,]
                {
                    { new Guid("806c81a6-ee40-4adf-a46f-e90da096d826"), new Guid("22b803f9-3cd6-485a-8d0d-5ca8d258eb1d"), new Guid("d0356126-5777-49bf-8721-d35bc2cfe41c"), 1, 199.99m },
                    { new Guid("94587454-b118-4645-a55b-7235e7b126c9"), new Guid("ee32b788-ca28-43e1-a5e4-ecbb0e2d29aa"), new Guid("c89cf1bb-80b4-4b98-9d04-fa9c12296860"), 2, 19.95m },
                    { new Guid("95fd5ecc-73b2-40e4-adbb-b24f653da8f1"), new Guid("ee32b788-ca28-43e1-a5e4-ecbb0e2d29aa"), new Guid("9834c7b0-5267-4980-b126-259714e8a910"), 1, 499.50m }
                });

            migrationBuilder.InsertData(
                table: "ShoppingCartItems",
                columns: new[] { "Id", "ApplicationUserId", "DateAdded", "ProductId", "Quantity", "SessionId", "UserId" },
                values: new object[,]
                {
                    { new Guid("056ba79a-22ba-4427-97f1-1333854d762e"), null, new DateTime(2025, 7, 14, 2, 25, 47, 789, DateTimeKind.Utc).AddTicks(1027), new Guid("b4d3247a-63e3-4bce-a5c2-9ab5d0ea960d"), 1, null, new Guid("c0a270ef-a2a2-46ec-bdbf-839f1c711940") },
                    { new Guid("06df002f-5c4a-46c8-81a8-e853cb41337b"), null, new DateTime(2025, 7, 12, 7, 25, 47, 789, DateTimeKind.Utc).AddTicks(933), new Guid("d0356126-5777-49bf-8721-d35bc2cfe41c"), 1, null, new Guid("29c1f5be-7c4b-41b2-91cc-612970ba7d76") },
                    { new Guid("26840e5f-2afe-4a57-8ddb-055848990434"), null, new DateTime(2025, 7, 13, 7, 25, 47, 789, DateTimeKind.Utc).AddTicks(941), new Guid("c89cf1bb-80b4-4b98-9d04-fa9c12296860"), 2, null, new Guid("29c1f5be-7c4b-41b2-91cc-612970ba7d76") }
                });
        }
    }
}
