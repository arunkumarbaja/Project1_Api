using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project1_Api.Migrations
{
    /// <inheritdoc />
    public partial class Changed_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("66e46801-c588-4b87-8272-2f3bac7b7c89"), new Guid("2174484e-ad52-41bf-b71c-d55eac6bbb4d") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("baa17e21-c8a7-4ce0-a6cf-525b7dc0d68c"), new Guid("e40bb8d9-65a2-4e83-a1ee-7101943274f7") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("66e46801-c588-4b87-8272-2f3bac7b7c89"), new Guid("f42e7270-9c2f-472b-9846-c1390ae66be6") });

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: new Guid("5cc4b55d-4691-4b23-9ecd-a2fe2d12c25e"));

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: new Guid("78357495-852e-4cb8-be4e-d07753da9366"));

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: new Guid("9916c04c-a290-4d7e-8835-bc9d22f77f62"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("51db9b5c-6fa2-4434-a43c-70d272bff108"));

            migrationBuilder.DeleteData(
                table: "ShoppingCartItems",
                keyColumn: "Id",
                keyValue: new Guid("4b8b5ee9-667a-4f7b-b261-ac927391e893"));

            migrationBuilder.DeleteData(
                table: "ShoppingCartItems",
                keyColumn: "Id",
                keyValue: new Guid("8a083224-9e95-4690-9d4c-378a4d2e3ae4"));

            migrationBuilder.DeleteData(
                table: "ShoppingCartItems",
                keyColumn: "Id",
                keyValue: new Guid("d6e109b5-0547-45b5-a210-551d319eb5e8"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("66e46801-c588-4b87-8272-2f3bac7b7c89"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("baa17e21-c8a7-4ce0-a6cf-525b7dc0d68c"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e40bb8d9-65a2-4e83-a1ee-7101943274f7"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("d03b3259-00cc-47e6-a46f-4e9f0041c5c7"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("e9518631-ff4b-4e40-b6f3-8839efa747a2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6cdd5be4-e028-43d0-9ddc-b4cda05b055c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a2c61f38-d7ab-454b-ad70-5ca8e70cea55"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("bd64618c-9039-4093-a171-703100f2c666"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f2073be6-3216-49a7-9dfb-c38642e6fe27"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2174484e-ad52-41bf-b71c-d55eac6bbb4d"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f42e7270-9c2f-472b-9846-c1390ae66be6"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("16addfd7-73f2-4bee-9d7b-fb2d39b0f5dc"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4fd992d2-dfa2-47d8-8cb4-0c128afee1ad"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("55bbe612-be1e-4525-b32d-a86965dd4bda"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("28521b0f-c2ea-4389-9222-a3b1108acdae"), null, "Admin", "ADMIN" },
                    { new Guid("4f42e81a-4def-4765-9d2a-48049af7cf0f"), null, "Customer", "CUSTOMER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateRegistered", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "ShippingAddressCity", "ShippingAddressCountry", "ShippingAddressPostalCode", "ShippingAddressState", "ShippingAddressStreet", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("0c7099aa-54d8-41ea-a33b-4b553eb773f1"), 0, "d0844277-1309-4b23-8290-e11eacf6e60d", new DateTime(2025, 4, 6, 10, 8, 20, 662, DateTimeKind.Utc).AddTicks(3843), "alice.w@example.com", true, "Alice", "Wonder", false, null, "ALICE.W@EXAMPLE.COM", "ALICE.W@EXAMPLE.COM", "AQAAAAIAAYagAAAAEOmKdGgpqHCGqfOM94bVmI3Xn+6tyaiWjPbdmjXKK0uTFFWGBypr7WQ3dfUwNiYN+Q==", null, false, "A16CA07C-293D-4904-9704-B4E711D8B2A8", "Anytown", "USA", "90210", "CA", "123 Main St", false, "alice.w@example.com" },
                    { new Guid("4aa57a55-b36b-4fe9-8293-ad981499dfe9"), 0, "60c7d2f9-0611-4917-8307-160f409a965c", new DateTime(2025, 4, 16, 10, 8, 20, 783, DateTimeKind.Utc).AddTicks(3951), "bob.builder@example.com", true, "Bob", "Builder", false, null, "BOB.BUILDER@EXAMPLE.COM", "BOB.BUILDER@EXAMPLE.COM", "AQAAAAIAAYagAAAAEIWrut2cT+ad8/ivyCnOGt9Q7c7dfNk5zT/zeN4rDhaeFTjBVB/k3MmN4c0N3h4Bpw==", null, false, "3AC93D27-7BA5-4F65-9EF8-00CB4D4DB170", "Otherville", "USA", "10001", "NY", "456 Oak Ave", false, "bob.builder@example.com" },
                    { new Guid("4c982cdf-e97c-4469-bfde-af565e88b93a"), 0, "2465b42f-3ad3-46f6-88f0-5e12fc9034f3", new DateTime(2025, 2, 25, 10, 8, 20, 553, DateTimeKind.Utc).AddTicks(2544), "admin@example.com", true, "Site", "Admin", false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEHxb1DUsGbXoXtfQZ4Q/sekKvMY5y5r946DcI0nUyXywhlY1avcpaPxNpvKMT8TClQ==", null, false, "F74CB5B6-EAC6-4944-8BA3-45908774E33D", "Control Panel", "SERVERLAND", "00001", "SYS", "1 Admin Way", false, "admin@example.com" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("6b432f99-7930-4009-b798-cfb777372a75"), "Gadgets, devices, and more.", "Electronics" },
                    { new Guid("aa7d2b89-a106-443e-8bf4-13b5a785fe99"), "Fiction, non-fiction, and educational.", "Books" },
                    { new Guid("c1a6a076-cf98-433a-8d2d-a909c0bf8c3e"), "Clothing for all occasions.", "Apparel" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("4f42e81a-4def-4765-9d2a-48049af7cf0f"), new Guid("0c7099aa-54d8-41ea-a33b-4b553eb773f1") },
                    { new Guid("4f42e81a-4def-4765-9d2a-48049af7cf0f"), new Guid("4aa57a55-b36b-4fe9-8293-ad981499dfe9") },
                    { new Guid("28521b0f-c2ea-4389-9222-a3b1108acdae"), new Guid("4c982cdf-e97c-4469-bfde-af565e88b93a") }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "OrderDate", "PaymentTransactionId", "ShippingAddressCity", "ShippingAddressCountry", "ShippingAddressPostalCode", "ShippingAddressState", "ShippingAddressStreet", "Status", "TotalAmount", "UserId" },
                values: new object[,]
                {
                    { new Guid("6eb44941-1b9f-467b-ac6e-fbdc1b48df85"), new DateTime(2025, 5, 29, 10, 8, 20, 783, DateTimeKind.Utc).AddTicks(4997), "txn_alice_123seed", "Anytown", "USA", "90210", "CA", "123 Main St", 3, 199.99m, new Guid("0c7099aa-54d8-41ea-a33b-4b553eb773f1") },
                    { new Guid("a623000d-05a0-4b24-bdd8-b275eae84e61"), new DateTime(2025, 6, 2, 10, 8, 20, 783, DateTimeKind.Utc).AddTicks(5116), "txn_bob_456seed", "Otherville", "USA", "10001", "NY", "456 Oak Ave", 2, 539.40m, new Guid("4aa57a55-b36b-4fe9-8293-ad981499dfe9") }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "DateCreated", "Description", "ImageUrl", "IsAvailable", "Name", "Price", "Sku", "StockQuantity" },
                values: new object[,]
                {
                    { new Guid("33cd4c4b-a02b-4214-b7f7-b7c22e9c681c"), new Guid("c1a6a076-cf98-433a-8d2d-a909c0bf8c3e"), new DateTime(2025, 5, 26, 10, 8, 20, 783, DateTimeKind.Utc).AddTicks(4802), "Light and airy, perfect for summer.", "/images/products/dress-women.jpg", false, "Women's Summer Dress", 45.00m, "APRL-DRESS-001", 75 },
                    { new Guid("6b13cd9e-41c7-4596-8313-4ebed21703c9"), new Guid("c1a6a076-cf98-433a-8d2d-a909c0bf8c3e"), new DateTime(2025, 5, 21, 10, 8, 20, 783, DateTimeKind.Utc).AddTicks(4791), "Comfortable and stylish.", "/images/products/tshirt-men.jpg", true, "Men's Classic Cotton T-Shirt", 19.95m, "APRL-TSHRT-001", 200 },
                    { new Guid("6f219ba7-ebbc-446c-86d9-46c0ba9415aa"), new Guid("6b432f99-7930-4009-b798-cfb777372a75"), new DateTime(2025, 5, 11, 10, 8, 20, 783, DateTimeKind.Utc).AddTicks(4784), "Vibrant colors, smart features.", "/images/products/smart-tv.jpg", true, "Smart LED TV 55-inch", 499.50m, "ELEC-TV-002", 25 },
                    { new Guid("9331ae45-b337-495b-bdd9-4fa45c828acc"), new Guid("6b432f99-7930-4009-b798-cfb777372a75"), new DateTime(2025, 5, 6, 10, 8, 20, 783, DateTimeKind.Utc).AddTicks(4779), "Immerse yourself in sound.", "/images/products/headphones.jpg", true, "Wireless Noise-Cancelling Headphones", 199.99m, "ELEC-HDPH-001", 50 },
                    { new Guid("9d9a7865-f83c-4190-b58b-ef9ad0169cd9"), new Guid("aa7d2b89-a106-443e-8bf4-13b5a785fe99"), new DateTime(2025, 5, 16, 10, 8, 20, 783, DateTimeKind.Utc).AddTicks(4788), "Three bestselling sci-fi novels.", "/images/products/scifi-books.jpg", true, "The Sci-Fi Novel Collection", 29.99m, "BOOK-SCIFI-001", 100 }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "OrderId", "ProductId", "Quantity", "UnitPriceAtPurchase" },
                values: new object[,]
                {
                    { new Guid("18e6e290-bdcd-486b-9961-22043d70eb12"), new Guid("a623000d-05a0-4b24-bdd8-b275eae84e61"), new Guid("6b13cd9e-41c7-4596-8313-4ebed21703c9"), 2, 19.95m },
                    { new Guid("1c11b392-a611-4d0f-b2eb-6177d35fd5b9"), new Guid("6eb44941-1b9f-467b-ac6e-fbdc1b48df85"), new Guid("9331ae45-b337-495b-bdd9-4fa45c828acc"), 1, 199.99m },
                    { new Guid("32f2d16b-a3fb-435c-b684-b418d64e42a2"), new Guid("a623000d-05a0-4b24-bdd8-b275eae84e61"), new Guid("6f219ba7-ebbc-446c-86d9-46c0ba9415aa"), 1, 499.50m }
                });

            migrationBuilder.InsertData(
                table: "ShoppingCartItems",
                columns: new[] { "Id", "DateAdded", "ProductId", "Quantity", "SessionId", "UserId" },
                values: new object[,]
                {
                    { new Guid("255e870c-ebfd-420c-ac25-309a4d1f0429"), new DateTime(2025, 6, 5, 5, 8, 20, 783, DateTimeKind.Utc).AddTicks(4937), new Guid("9d9a7865-f83c-4190-b58b-ef9ad0169cd9"), 1, null, new Guid("4aa57a55-b36b-4fe9-8293-ad981499dfe9") },
                    { new Guid("3a8ec6c7-1464-4824-9747-571c6b2181ed"), new DateTime(2025, 6, 4, 10, 8, 20, 783, DateTimeKind.Utc).AddTicks(4879), new Guid("6b13cd9e-41c7-4596-8313-4ebed21703c9"), 2, null, new Guid("0c7099aa-54d8-41ea-a33b-4b553eb773f1") },
                    { new Guid("736e3382-a0d8-4bcc-908e-a480b53969a8"), new DateTime(2025, 6, 3, 10, 8, 20, 783, DateTimeKind.Utc).AddTicks(4875), new Guid("9331ae45-b337-495b-bdd9-4fa45c828acc"), 1, null, new Guid("0c7099aa-54d8-41ea-a33b-4b553eb773f1") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4f42e81a-4def-4765-9d2a-48049af7cf0f"), new Guid("0c7099aa-54d8-41ea-a33b-4b553eb773f1") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4f42e81a-4def-4765-9d2a-48049af7cf0f"), new Guid("4aa57a55-b36b-4fe9-8293-ad981499dfe9") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("28521b0f-c2ea-4389-9222-a3b1108acdae"), new Guid("4c982cdf-e97c-4469-bfde-af565e88b93a") });

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: new Guid("18e6e290-bdcd-486b-9961-22043d70eb12"));

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: new Guid("1c11b392-a611-4d0f-b2eb-6177d35fd5b9"));

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: new Guid("32f2d16b-a3fb-435c-b684-b418d64e42a2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("33cd4c4b-a02b-4214-b7f7-b7c22e9c681c"));

            migrationBuilder.DeleteData(
                table: "ShoppingCartItems",
                keyColumn: "Id",
                keyValue: new Guid("255e870c-ebfd-420c-ac25-309a4d1f0429"));

            migrationBuilder.DeleteData(
                table: "ShoppingCartItems",
                keyColumn: "Id",
                keyValue: new Guid("3a8ec6c7-1464-4824-9747-571c6b2181ed"));

            migrationBuilder.DeleteData(
                table: "ShoppingCartItems",
                keyColumn: "Id",
                keyValue: new Guid("736e3382-a0d8-4bcc-908e-a480b53969a8"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("28521b0f-c2ea-4389-9222-a3b1108acdae"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4f42e81a-4def-4765-9d2a-48049af7cf0f"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4c982cdf-e97c-4469-bfde-af565e88b93a"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("6eb44941-1b9f-467b-ac6e-fbdc1b48df85"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("a623000d-05a0-4b24-bdd8-b275eae84e61"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6b13cd9e-41c7-4596-8313-4ebed21703c9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6f219ba7-ebbc-446c-86d9-46c0ba9415aa"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9331ae45-b337-495b-bdd9-4fa45c828acc"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9d9a7865-f83c-4190-b58b-ef9ad0169cd9"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0c7099aa-54d8-41ea-a33b-4b553eb773f1"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4aa57a55-b36b-4fe9-8293-ad981499dfe9"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6b432f99-7930-4009-b798-cfb777372a75"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("aa7d2b89-a106-443e-8bf4-13b5a785fe99"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c1a6a076-cf98-433a-8d2d-a909c0bf8c3e"));

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
        }
    }
}
