using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project1_Api.Migrations
{
    /// <inheritdoc />
    public partial class shippingCartItem_Updated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("f8334bf9-f3bf-4162-b765-b11bca6a6c84"), new Guid("23476a76-c69a-4bef-8c68-467832b72c4f") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4d4d65a3-68ea-4959-9f71-5ee64baccbfe"), new Guid("43f8af90-4d78-4c12-8365-ba159decfbad") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("f8334bf9-f3bf-4162-b765-b11bca6a6c84"), new Guid("64d8122e-5e3c-4ba8-ad31-0709286d9783") });

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: new Guid("4d8a5e29-a365-4f1d-81c3-f76122dbd52f"));

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: new Guid("514856ea-0c52-43ba-964c-85881381dd44"));

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: new Guid("f8f30353-10a8-46e9-81c8-f71ad6d6e82a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("502d001e-2b58-43f2-8e04-6f2309b31721"));

            migrationBuilder.DeleteData(
                table: "ShoppingCartItems",
                keyColumn: "Id",
                keyValue: new Guid("27c92d8f-9826-4917-8f1c-0b1f5a828527"));

            migrationBuilder.DeleteData(
                table: "ShoppingCartItems",
                keyColumn: "Id",
                keyValue: new Guid("7791b420-259d-4039-bb3a-1519cecf0c3e"));

            migrationBuilder.DeleteData(
                table: "ShoppingCartItems",
                keyColumn: "Id",
                keyValue: new Guid("8d9cea9e-2488-49a2-b667-c4295527dcef"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4d4d65a3-68ea-4959-9f71-5ee64baccbfe"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f8334bf9-f3bf-4162-b765-b11bca6a6c84"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("43f8af90-4d78-4c12-8365-ba159decfbad"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("20fe6292-620d-4aaf-9db5-6db7d805f626"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("cd34ec29-d0d6-4ddd-981d-f43a609a2374"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a3f1d105-f357-4173-9a62-be533aa7dd99"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c751e199-9a58-4619-a331-24390f30a311"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e6097226-3a38-4a82-ac10-8ddb5a8819ce"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("fe95b471-f8eb-40ad-9400-9b1a9e01f890"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("23476a76-c69a-4bef-8c68-467832b72c4f"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("64d8122e-5e3c-4ba8-ad31-0709286d9783"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("218545d9-b2f5-4766-8e0e-8a3385c0fc6d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c3ff0dbd-0579-40c9-b545-080ddf0592c3"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e83019c1-0ac6-46da-bca9-6e8962247266"));

            migrationBuilder.AddColumn<Guid>(
                name: "ApplicationUserId",
                table: "ShoppingCartItems",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ApplicationUserId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_ApplicationUserId",
                table: "ShoppingCartItems",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ApplicationUserId",
                table: "Orders",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_ApplicationUserId",
                table: "Orders",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItems_AspNetUsers_ApplicationUserId",
                table: "ShoppingCartItems",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_ApplicationUserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItems_AspNetUsers_ApplicationUserId",
                table: "ShoppingCartItems");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCartItems_ApplicationUserId",
                table: "ShoppingCartItems");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ApplicationUserId",
                table: "Orders");

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

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "ShoppingCartItems");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Orders");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("4d4d65a3-68ea-4959-9f71-5ee64baccbfe"), null, "Admin", "ADMIN" },
                    { new Guid("f8334bf9-f3bf-4162-b765-b11bca6a6c84"), null, "Customer", "CUSTOMER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateRegistered", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "ShippingAddressCity", "ShippingAddressCountry", "ShippingAddressPostalCode", "ShippingAddressState", "ShippingAddressStreet", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("23476a76-c69a-4bef-8c68-467832b72c4f"), 0, "93b591d2-b268-4f84-ae0f-f5254f56ac09", new DateTime(2025, 4, 6, 10, 32, 32, 937, DateTimeKind.Utc).AddTicks(8701), "alice.w@example.com", true, "Alice", "Wonder", false, null, "ALICE.W@EXAMPLE.COM", "ALICE.W@EXAMPLE.COM", "AQAAAAIAAYagAAAAEFDf4v6M56fnS/7MFTzWNRC9n+lUrbMDA6WGqYaFBoIL9QX4/fkM/kPwKSfalzD80w==", null, false, "56C8CAF4-BD83-4742-8D2E-1B64D704C9C9", "Anytown", "USA", "90210", "CA", "123 Main St", false, "alice.w@example.com" },
                    { new Guid("43f8af90-4d78-4c12-8365-ba159decfbad"), 0, "a955b777-741e-48c4-a4e7-0ea5068abc73", new DateTime(2025, 2, 25, 10, 32, 32, 791, DateTimeKind.Utc).AddTicks(4701), "admin@example.com", true, "Site", "Admin", false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEDmBtkUjUCL3pFtGpmPtTbw1t1RXglR3tkEz/ktyk721efAPHD4F2XXnX5DKMwVkmg==", null, false, "13F0391D-5A4A-4903-A1A0-E0CE1E9EF00A", "Control Panel", "SERVERLAND", "00001", "SYS", "1 Admin Way", false, "admin@example.com" },
                    { new Guid("64d8122e-5e3c-4ba8-ad31-0709286d9783"), 0, "57338123-d32e-4143-8b84-bd00e1f87870", new DateTime(2025, 4, 16, 10, 32, 33, 79, DateTimeKind.Utc).AddTicks(415), "bob.builder@example.com", true, "Bob", "Builder", false, null, "BOB.BUILDER@EXAMPLE.COM", "BOB.BUILDER@EXAMPLE.COM", "AQAAAAIAAYagAAAAEJXXOuHaBcx/iKKKct4H1IP7tBv4vfA1YHxrwEonqz/KoMe9eNsNLSi8j2XmYWzAcg==", null, false, "157546A4-0F03-4366-974A-10DCB2315F45", "Otherville", "USA", "10001", "NY", "456 Oak Ave", false, "bob.builder@example.com" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("218545d9-b2f5-4766-8e0e-8a3385c0fc6d"), "Gadgets, devices, and more.", "Electronics" },
                    { new Guid("c3ff0dbd-0579-40c9-b545-080ddf0592c3"), "Fiction, non-fiction, and educational.", "Books" },
                    { new Guid("e83019c1-0ac6-46da-bca9-6e8962247266"), "Clothing for all occasions.", "Apparel" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("f8334bf9-f3bf-4162-b765-b11bca6a6c84"), new Guid("23476a76-c69a-4bef-8c68-467832b72c4f") },
                    { new Guid("4d4d65a3-68ea-4959-9f71-5ee64baccbfe"), new Guid("43f8af90-4d78-4c12-8365-ba159decfbad") },
                    { new Guid("f8334bf9-f3bf-4162-b765-b11bca6a6c84"), new Guid("64d8122e-5e3c-4ba8-ad31-0709286d9783") }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "OrderDate", "PaymentTransactionId", "ShippingAddressCity", "ShippingAddressCountry", "ShippingAddressPostalCode", "ShippingAddressState", "ShippingAddressStreet", "Status", "TotalAmount", "UserId" },
                values: new object[,]
                {
                    { new Guid("20fe6292-620d-4aaf-9db5-6db7d805f626"), new DateTime(2025, 5, 29, 10, 32, 33, 79, DateTimeKind.Utc).AddTicks(2113), "txn_alice_123seed", "Anytown", "USA", "90210", "CA", "123 Main St", 3, 199.99m, new Guid("23476a76-c69a-4bef-8c68-467832b72c4f") },
                    { new Guid("cd34ec29-d0d6-4ddd-981d-f43a609a2374"), new DateTime(2025, 6, 2, 10, 32, 33, 79, DateTimeKind.Utc).AddTicks(2302), "txn_bob_456seed", "Otherville", "USA", "10001", "NY", "456 Oak Ave", 2, 539.40m, new Guid("64d8122e-5e3c-4ba8-ad31-0709286d9783") }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "DateCreated", "Description", "ImageUrl", "IsAvailable", "Name", "Price", "Sku", "StockQuantity" },
                values: new object[,]
                {
                    { new Guid("502d001e-2b58-43f2-8e04-6f2309b31721"), new Guid("e83019c1-0ac6-46da-bca9-6e8962247266"), new DateTime(2025, 5, 26, 10, 32, 33, 79, DateTimeKind.Utc).AddTicks(1796), "Light and airy, perfect for summer.", "/images/products/dress-women.jpg", false, "Women's Summer Dress", 45.00m, "APRL-DRESS-001", 75 },
                    { new Guid("a3f1d105-f357-4173-9a62-be533aa7dd99"), new Guid("218545d9-b2f5-4766-8e0e-8a3385c0fc6d"), new DateTime(2025, 5, 6, 10, 32, 33, 79, DateTimeKind.Utc).AddTicks(1762), "Immerse yourself in sound.", "/images/products/headphones.jpg", true, "Wireless Noise-Cancelling Headphones", 199.99m, "ELEC-HDPH-001", 50 },
                    { new Guid("c751e199-9a58-4619-a331-24390f30a311"), new Guid("218545d9-b2f5-4766-8e0e-8a3385c0fc6d"), new DateTime(2025, 5, 11, 10, 32, 33, 79, DateTimeKind.Utc).AddTicks(1770), "Vibrant colors, smart features.", "/images/products/smart-tv.jpg", true, "Smart LED TV 55-inch", 499.50m, "ELEC-TV-002", 25 },
                    { new Guid("e6097226-3a38-4a82-ac10-8ddb5a8819ce"), new Guid("e83019c1-0ac6-46da-bca9-6e8962247266"), new DateTime(2025, 5, 21, 10, 32, 33, 79, DateTimeKind.Utc).AddTicks(1792), "Comfortable and stylish.", "/images/products/tshirt-men.jpg", true, "Men's Classic Cotton T-Shirt", 19.95m, "APRL-TSHRT-001", 200 },
                    { new Guid("fe95b471-f8eb-40ad-9400-9b1a9e01f890"), new Guid("c3ff0dbd-0579-40c9-b545-080ddf0592c3"), new DateTime(2025, 5, 16, 10, 32, 33, 79, DateTimeKind.Utc).AddTicks(1775), "Three bestselling sci-fi novels.", "/images/products/scifi-books.jpg", true, "The Sci-Fi Novel Collection", 29.99m, "BOOK-SCIFI-001", 100 }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "OrderId", "ProductId", "Quantity", "UnitPriceAtPurchase" },
                values: new object[,]
                {
                    { new Guid("4d8a5e29-a365-4f1d-81c3-f76122dbd52f"), new Guid("cd34ec29-d0d6-4ddd-981d-f43a609a2374"), new Guid("c751e199-9a58-4619-a331-24390f30a311"), 1, 499.50m },
                    { new Guid("514856ea-0c52-43ba-964c-85881381dd44"), new Guid("20fe6292-620d-4aaf-9db5-6db7d805f626"), new Guid("a3f1d105-f357-4173-9a62-be533aa7dd99"), 1, 199.99m },
                    { new Guid("f8f30353-10a8-46e9-81c8-f71ad6d6e82a"), new Guid("cd34ec29-d0d6-4ddd-981d-f43a609a2374"), new Guid("e6097226-3a38-4a82-ac10-8ddb5a8819ce"), 2, 19.95m }
                });

            migrationBuilder.InsertData(
                table: "ShoppingCartItems",
                columns: new[] { "Id", "DateAdded", "ProductId", "Quantity", "SessionId", "UserId" },
                values: new object[,]
                {
                    { new Guid("27c92d8f-9826-4917-8f1c-0b1f5a828527"), new DateTime(2025, 6, 5, 5, 32, 33, 79, DateTimeKind.Utc).AddTicks(2022), new Guid("fe95b471-f8eb-40ad-9400-9b1a9e01f890"), 1, null, new Guid("64d8122e-5e3c-4ba8-ad31-0709286d9783") },
                    { new Guid("7791b420-259d-4039-bb3a-1519cecf0c3e"), new DateTime(2025, 6, 4, 10, 32, 33, 79, DateTimeKind.Utc).AddTicks(1922), new Guid("e6097226-3a38-4a82-ac10-8ddb5a8819ce"), 2, null, new Guid("23476a76-c69a-4bef-8c68-467832b72c4f") },
                    { new Guid("8d9cea9e-2488-49a2-b667-c4295527dcef"), new DateTime(2025, 6, 3, 10, 32, 33, 79, DateTimeKind.Utc).AddTicks(1917), new Guid("a3f1d105-f357-4173-9a62-be533aa7dd99"), 1, null, new Guid("23476a76-c69a-4bef-8c68-467832b72c4f") }
                });
        }
    }
}
