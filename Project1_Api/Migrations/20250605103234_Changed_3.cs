using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project1_Api.Migrations
{
    /// <inheritdoc />
    public partial class Changed_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
