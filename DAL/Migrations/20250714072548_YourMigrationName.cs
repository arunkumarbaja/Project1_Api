using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project1_Api.Migrations
{
    /// <inheritdoc />
    public partial class YourMigrationName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("3e860fe9-f0e9-4b51-9061-2d051fe48911"), new Guid("32131d27-4858-4e27-9ee7-f780cbc947a1") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("3e860fe9-f0e9-4b51-9061-2d051fe48911"), new Guid("7b70dd23-2a99-4c84-a5f2-a0a9ca8614b9") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("846ff114-dfc6-451d-925f-5dcfea457c8a"), new Guid("9bdbb0b3-1cb9-4c3f-8ca6-6d0b1d1ed7fb") });

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: new Guid("12da3143-03e9-4769-9285-696e263e2637"));

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: new Guid("7bd6cca9-1b58-481f-bac5-6027a2a79de8"));

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: new Guid("da57d8bf-f5b6-43e7-b4bb-03b183c89750"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1e8a8c5d-e047-41fc-a467-082f23888c3b"));

            migrationBuilder.DeleteData(
                table: "ShoppingCartItems",
                keyColumn: "Id",
                keyValue: new Guid("c9ccdb89-0c06-43f0-97c6-adb8d46a947f"));

            migrationBuilder.DeleteData(
                table: "ShoppingCartItems",
                keyColumn: "Id",
                keyValue: new Guid("d3318fdc-a53c-430e-8084-b151a0a2dab2"));

            migrationBuilder.DeleteData(
                table: "ShoppingCartItems",
                keyColumn: "Id",
                keyValue: new Guid("eac78da5-4a05-4ac7-aaaa-b4da8d8a84be"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3e860fe9-f0e9-4b51-9061-2d051fe48911"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("846ff114-dfc6-451d-925f-5dcfea457c8a"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9bdbb0b3-1cb9-4c3f-8ca6-6d0b1d1ed7fb"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("2bf06f55-c94c-4df3-a512-06def363df93"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("8701c5d2-d44c-44b5-94cb-99769205f2c2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("21d5bf39-8e23-448a-a8b6-9f286f54a8dc"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7c320f12-432c-4f76-83ed-42b6c8734526"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("91cbd587-60ab-4805-9faa-5037c1c94b4c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("96328a9a-b2dc-4b2e-bc6c-b1c98c925bc1"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("32131d27-4858-4e27-9ee7-f780cbc947a1"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7b70dd23-2a99-4c84-a5f2-a0a9ca8614b9"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("46357b0b-5a1c-4fa7-aecc-ad8cd80b060b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f4d659ae-995a-4519-add9-e839052b51d1"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f81be342-0ef1-4822-8fae-c2c13377be76"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("3e860fe9-f0e9-4b51-9061-2d051fe48911"), null, "Customer", "CUSTOMER" },
                    { new Guid("846ff114-dfc6-451d-925f-5dcfea457c8a"), null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateRegistered", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "ShippingAddressCity", "ShippingAddressCountry", "ShippingAddressPostalCode", "ShippingAddressState", "ShippingAddressStreet", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("32131d27-4858-4e27-9ee7-f780cbc947a1"), 0, "03aaaaf2-873c-4362-9e51-783220a4c785", new DateTime(2025, 4, 14, 16, 52, 25, 446, DateTimeKind.Utc).AddTicks(3092), "alice.w@example.com", true, "Alice", "Wonder", false, null, "ALICE.W@EXAMPLE.COM", "ALICE.W@EXAMPLE.COM", "AQAAAAIAAYagAAAAEISIPavQ7zZGk42nVhYD9Xmk90QGUdLm3bXRxZtvyKZomus5mJSfwg98ujFGYUY+7A==", null, false, "33A4DA2D-ABA2-4D1A-B4E4-6C97D50D8BD7", "Anytown", "USA", "90210", "CA", "123 Main St", false, "alice.w@example.com" },
                    { new Guid("7b70dd23-2a99-4c84-a5f2-a0a9ca8614b9"), 0, "663ea6cb-6187-4aa8-a700-cedf0af3238e", new DateTime(2025, 4, 24, 16, 52, 25, 538, DateTimeKind.Utc).AddTicks(685), "bob.builder@example.com", true, "Bob", "Builder", false, null, "BOB.BUILDER@EXAMPLE.COM", "BOB.BUILDER@EXAMPLE.COM", "AQAAAAIAAYagAAAAEJY6q44qCDPh/45QSLNIZ95yf5RS2kP8YBXG35WHYsUr6Q9idVQRNEsM0G2Q9CAOGA==", null, false, "2A429E3D-B6ED-4B49-A70F-68CB83081556", "Otherville", "USA", "10001", "NY", "456 Oak Ave", false, "bob.builder@example.com" },
                    { new Guid("9bdbb0b3-1cb9-4c3f-8ca6-6d0b1d1ed7fb"), 0, "613633ce-088b-4a27-8ad6-b0e25a768496", new DateTime(2025, 3, 5, 16, 52, 25, 335, DateTimeKind.Utc).AddTicks(9317), "admin@example.com", true, "Site", "Admin", false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEL/Cbhqbze2wBridhAq3E14OVtaq4Clp/8E2UEfU2KoQi1RqdmcK5/kl5hGeeKdghw==", null, false, "30DAC99F-98B0-4B0C-A224-55AEE16069D5", "Control Panel", "SERVERLAND", "00001", "SYS", "1 Admin Way", false, "admin@example.com" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("46357b0b-5a1c-4fa7-aecc-ad8cd80b060b"), "Gadgets, devices, and more.", "Electronics" },
                    { new Guid("f4d659ae-995a-4519-add9-e839052b51d1"), "Clothing for all occasions.", "Apparel" },
                    { new Guid("f81be342-0ef1-4822-8fae-c2c13377be76"), "Fiction, non-fiction, and educational.", "Books" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("3e860fe9-f0e9-4b51-9061-2d051fe48911"), new Guid("32131d27-4858-4e27-9ee7-f780cbc947a1") },
                    { new Guid("3e860fe9-f0e9-4b51-9061-2d051fe48911"), new Guid("7b70dd23-2a99-4c84-a5f2-a0a9ca8614b9") },
                    { new Guid("846ff114-dfc6-451d-925f-5dcfea457c8a"), new Guid("9bdbb0b3-1cb9-4c3f-8ca6-6d0b1d1ed7fb") }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "ApplicationUserId", "OrderDate", "PaymentTransactionId", "ShippingAddressCity", "ShippingAddressCountry", "ShippingAddressPostalCode", "ShippingAddressState", "ShippingAddressStreet", "Status", "TotalAmount", "UserId" },
                values: new object[,]
                {
                    { new Guid("2bf06f55-c94c-4df3-a512-06def363df93"), null, new DateTime(2025, 6, 6, 16, 52, 25, 538, DateTimeKind.Utc).AddTicks(2134), "txn_alice_123seed", "Anytown", "USA", "90210", "CA", "123 Main St", 3, 199.99m, new Guid("32131d27-4858-4e27-9ee7-f780cbc947a1") },
                    { new Guid("8701c5d2-d44c-44b5-94cb-99769205f2c2"), null, new DateTime(2025, 6, 10, 16, 52, 25, 538, DateTimeKind.Utc).AddTicks(2367), "txn_bob_456seed", "Otherville", "USA", "10001", "NY", "456 Oak Ave", 2, 539.40m, new Guid("7b70dd23-2a99-4c84-a5f2-a0a9ca8614b9") }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "DateCreated", "Description", "ImageUrl", "IsAvailable", "Name", "Price", "Sku", "StockQuantity" },
                values: new object[,]
                {
                    { new Guid("1e8a8c5d-e047-41fc-a467-082f23888c3b"), new Guid("f4d659ae-995a-4519-add9-e839052b51d1"), new DateTime(2025, 6, 3, 16, 52, 25, 538, DateTimeKind.Utc).AddTicks(1665), "Light and airy, perfect for summer.", "/images/products/dress-women.jpg", false, "Women's Summer Dress", 45.00m, "APRL-DRESS-001", 75 },
                    { new Guid("21d5bf39-8e23-448a-a8b6-9f286f54a8dc"), new Guid("f4d659ae-995a-4519-add9-e839052b51d1"), new DateTime(2025, 5, 29, 16, 52, 25, 538, DateTimeKind.Utc).AddTicks(1651), "Comfortable and stylish.", "/images/products/tshirt-men.jpg", true, "Men's Classic Cotton T-Shirt", 19.95m, "APRL-TSHRT-001", 200 },
                    { new Guid("7c320f12-432c-4f76-83ed-42b6c8734526"), new Guid("f81be342-0ef1-4822-8fae-c2c13377be76"), new DateTime(2025, 5, 24, 16, 52, 25, 538, DateTimeKind.Utc).AddTicks(1647), "Three bestselling sci-fi novels.", "/images/products/scifi-books.jpg", true, "The Sci-Fi Novel Collection", 29.99m, "BOOK-SCIFI-001", 100 },
                    { new Guid("91cbd587-60ab-4805-9faa-5037c1c94b4c"), new Guid("46357b0b-5a1c-4fa7-aecc-ad8cd80b060b"), new DateTime(2025, 5, 19, 16, 52, 25, 538, DateTimeKind.Utc).AddTicks(1643), "Vibrant colors, smart features.", "/images/products/smart-tv.jpg", true, "Smart LED TV 55-inch", 499.50m, "ELEC-TV-002", 25 },
                    { new Guid("96328a9a-b2dc-4b2e-bc6c-b1c98c925bc1"), new Guid("46357b0b-5a1c-4fa7-aecc-ad8cd80b060b"), new DateTime(2025, 5, 14, 16, 52, 25, 538, DateTimeKind.Utc).AddTicks(1634), "Immerse yourself in sound.", "/images/products/headphones.jpg", true, "Wireless Noise-Cancelling Headphones", 199.99m, "ELEC-HDPH-001", 50 }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "OrderId", "ProductId", "Quantity", "UnitPriceAtPurchase" },
                values: new object[,]
                {
                    { new Guid("12da3143-03e9-4769-9285-696e263e2637"), new Guid("8701c5d2-d44c-44b5-94cb-99769205f2c2"), new Guid("21d5bf39-8e23-448a-a8b6-9f286f54a8dc"), 2, 19.95m },
                    { new Guid("7bd6cca9-1b58-481f-bac5-6027a2a79de8"), new Guid("2bf06f55-c94c-4df3-a512-06def363df93"), new Guid("96328a9a-b2dc-4b2e-bc6c-b1c98c925bc1"), 1, 199.99m },
                    { new Guid("da57d8bf-f5b6-43e7-b4bb-03b183c89750"), new Guid("8701c5d2-d44c-44b5-94cb-99769205f2c2"), new Guid("91cbd587-60ab-4805-9faa-5037c1c94b4c"), 1, 499.50m }
                });

            migrationBuilder.InsertData(
                table: "ShoppingCartItems",
                columns: new[] { "Id", "ApplicationUserId", "DateAdded", "ProductId", "Quantity", "SessionId", "UserId" },
                values: new object[,]
                {
                    { new Guid("c9ccdb89-0c06-43f0-97c6-adb8d46a947f"), null, new DateTime(2025, 6, 12, 16, 52, 25, 538, DateTimeKind.Utc).AddTicks(1901), new Guid("21d5bf39-8e23-448a-a8b6-9f286f54a8dc"), 2, null, new Guid("32131d27-4858-4e27-9ee7-f780cbc947a1") },
                    { new Guid("d3318fdc-a53c-430e-8084-b151a0a2dab2"), null, new DateTime(2025, 6, 13, 11, 52, 25, 538, DateTimeKind.Utc).AddTicks(1997), new Guid("7c320f12-432c-4f76-83ed-42b6c8734526"), 1, null, new Guid("7b70dd23-2a99-4c84-a5f2-a0a9ca8614b9") },
                    { new Guid("eac78da5-4a05-4ac7-aaaa-b4da8d8a84be"), null, new DateTime(2025, 6, 11, 16, 52, 25, 538, DateTimeKind.Utc).AddTicks(1882), new Guid("96328a9a-b2dc-4b2e-bc6c-b1c98c925bc1"), 1, null, new Guid("32131d27-4858-4e27-9ee7-f780cbc947a1") }
                });
        }
    }
}
