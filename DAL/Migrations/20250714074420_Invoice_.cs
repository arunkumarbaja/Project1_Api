using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project1_Api.Migrations
{
    /// <inheritdoc />
    public partial class Invoice_ : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItems_AspNetUsers_UserId",
                table: "ShoppingCartItems");

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
                    { new Guid("2d40c3a2-5dfb-422d-9f8e-bfbd5d5a9d1f"), null, "Customer", "CUSTOMER" },
                    { new Guid("b35a0423-d0be-49f4-a9ed-3b5a9a1d2a54"), null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateRegistered", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "ShippingAddressCity", "ShippingAddressCountry", "ShippingAddressPostalCode", "ShippingAddressState", "ShippingAddressStreet", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("0d4e4678-29d4-4aab-8f56-4725162eb42b"), 0, "22bb12c5-27ce-4e29-bfd2-b865fb6b427c", new DateTime(2025, 4, 5, 7, 44, 19, 724, DateTimeKind.Utc).AddTicks(787), "admin@example.com", true, "Site", "Admin", false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEB2qncL7+eEntSsQVH5qTpbCEH7HX7kmaBxDPws9RGRLzzz4VtysShkOfVfmwmPl+w==", null, false, "5FE67096-E2C5-4114-BE60-AEF8C61098FA", "Control Panel", "SERVERLAND", "00001", "SYS", "1 Admin Way", false, "admin@example.com" },
                    { new Guid("445a39a0-beda-40fb-a1e7-81c7c503ea9f"), 0, "7562c3fc-c40f-440e-839f-361e1143c593", new DateTime(2025, 5, 25, 7, 44, 19, 899, DateTimeKind.Utc).AddTicks(3023), "bob.builder@example.com", true, "Bob", "Builder", false, null, "BOB.BUILDER@EXAMPLE.COM", "BOB.BUILDER@EXAMPLE.COM", "AQAAAAIAAYagAAAAEDpdDy06H93l5lmNtY4xAPp3SwWOBE/pJQ1eooKTuejEPfAsfHKt1ABfR7rxw1BpCA==", null, false, "DB0C94FB-CDA2-4683-AFCF-E61595F33706", "Otherville", "USA", "10001", "NY", "456 Oak Ave", false, "bob.builder@example.com" },
                    { new Guid("6449ba12-6618-4ddc-a297-02b02461b592"), 0, "c8d0aa3b-4796-414a-aef7-a28d1ed00a14", new DateTime(2025, 5, 15, 7, 44, 19, 812, DateTimeKind.Utc).AddTicks(2159), "alice.w@example.com", true, "Alice", "Wonder", false, null, "ALICE.W@EXAMPLE.COM", "ALICE.W@EXAMPLE.COM", "AQAAAAIAAYagAAAAEDmf2biRN8jnVLbONKQ4fewPdg+cIE6WgkFT7T/JS2fhRz5DSSyEC2fASZI4zl05Bw==", null, false, "8B2D079F-DB76-4539-9B0B-0C404C3ABCBC", "Anytown", "USA", "90210", "CA", "123 Main St", false, "alice.w@example.com" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("76960d7a-7323-4bb9-9451-caf91de6d087"), "Fiction, non-fiction, and educational.", "Books" },
                    { new Guid("781c50cb-955c-40de-b0ec-1f542e0090c4"), "Clothing for all occasions.", "Apparel" },
                    { new Guid("bed1ed01-5445-4f14-b9f4-5c72c49cd4c7"), "Gadgets, devices, and more.", "Electronics" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("b35a0423-d0be-49f4-a9ed-3b5a9a1d2a54"), new Guid("0d4e4678-29d4-4aab-8f56-4725162eb42b") },
                    { new Guid("2d40c3a2-5dfb-422d-9f8e-bfbd5d5a9d1f"), new Guid("445a39a0-beda-40fb-a1e7-81c7c503ea9f") },
                    { new Guid("2d40c3a2-5dfb-422d-9f8e-bfbd5d5a9d1f"), new Guid("6449ba12-6618-4ddc-a297-02b02461b592") }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "ApplicationUserId", "OrderDate", "PaymentTransactionId", "ShippingAddressCity", "ShippingAddressCountry", "ShippingAddressPostalCode", "ShippingAddressState", "ShippingAddressStreet", "Status", "TotalAmount", "UserId" },
                values: new object[,]
                {
                    { new Guid("182648fc-37ce-4764-b560-cc145be26675"), null, new DateTime(2025, 7, 7, 7, 44, 19, 899, DateTimeKind.Utc).AddTicks(4259), "txn_alice_123seed", "Anytown", "USA", "90210", "CA", "123 Main St", 3, 199.99m, new Guid("6449ba12-6618-4ddc-a297-02b02461b592") },
                    { new Guid("9b54f026-e3c6-4c9b-bf49-e91bcde8a37f"), null, new DateTime(2025, 7, 11, 7, 44, 19, 899, DateTimeKind.Utc).AddTicks(7704), "txn_bob_456seed", "Otherville", "USA", "10001", "NY", "456 Oak Ave", 2, 539.40m, new Guid("445a39a0-beda-40fb-a1e7-81c7c503ea9f") }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "DateCreated", "Description", "ImageUrl", "IsAvailable", "Name", "Price", "Sku", "StockQuantity" },
                values: new object[,]
                {
                    { new Guid("163054c6-eaf3-46e0-bbdd-ba10bb80829a"), new Guid("bed1ed01-5445-4f14-b9f4-5c72c49cd4c7"), new DateTime(2025, 6, 19, 7, 44, 19, 899, DateTimeKind.Utc).AddTicks(3931), "Vibrant colors, smart features.", "/images/products/smart-tv.jpg", true, "Smart LED TV 55-inch", 499.50m, "ELEC-TV-002", 25 },
                    { new Guid("859dd085-223b-4f0e-a8b5-ddc4912aceef"), new Guid("bed1ed01-5445-4f14-b9f4-5c72c49cd4c7"), new DateTime(2025, 6, 14, 7, 44, 19, 899, DateTimeKind.Utc).AddTicks(3927), "Immerse yourself in sound.", "/images/products/headphones.jpg", true, "Wireless Noise-Cancelling Headphones", 199.99m, "ELEC-HDPH-001", 50 },
                    { new Guid("b03f6ac2-4929-4100-ada2-0a50f58a52cb"), new Guid("781c50cb-955c-40de-b0ec-1f542e0090c4"), new DateTime(2025, 7, 4, 7, 44, 19, 899, DateTimeKind.Utc).AddTicks(3948), "Light and airy, perfect for summer.", "/images/products/dress-women.jpg", false, "Women's Summer Dress", 45.00m, "APRL-DRESS-001", 75 },
                    { new Guid("e494daf4-f457-4e63-a1c1-d7b1b41aabb4"), new Guid("781c50cb-955c-40de-b0ec-1f542e0090c4"), new DateTime(2025, 6, 29, 7, 44, 19, 899, DateTimeKind.Utc).AddTicks(3944), "Comfortable and stylish.", "/images/products/tshirt-men.jpg", true, "Men's Classic Cotton T-Shirt", 19.95m, "APRL-TSHRT-001", 200 },
                    { new Guid("e73cdf56-7c04-4fa8-a8ed-8992eae0a562"), new Guid("76960d7a-7323-4bb9-9451-caf91de6d087"), new DateTime(2025, 6, 24, 7, 44, 19, 899, DateTimeKind.Utc).AddTicks(3937), "Three bestselling sci-fi novels.", "/images/products/scifi-books.jpg", true, "The Sci-Fi Novel Collection", 29.99m, "BOOK-SCIFI-001", 100 }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "OrderId", "ProductId", "Quantity", "UnitPriceAtPurchase" },
                values: new object[,]
                {
                    { new Guid("899b3591-d522-430d-a65d-1ff4c8954f85"), new Guid("9b54f026-e3c6-4c9b-bf49-e91bcde8a37f"), new Guid("e494daf4-f457-4e63-a1c1-d7b1b41aabb4"), 2, 19.95m },
                    { new Guid("d6ac276c-32bb-45b9-91fa-27f33d57e6fc"), new Guid("182648fc-37ce-4764-b560-cc145be26675"), new Guid("859dd085-223b-4f0e-a8b5-ddc4912aceef"), 1, 199.99m },
                    { new Guid("e65730f9-8123-46b5-8c40-2aa29b80f9df"), new Guid("9b54f026-e3c6-4c9b-bf49-e91bcde8a37f"), new Guid("163054c6-eaf3-46e0-bbdd-ba10bb80829a"), 1, 499.50m }
                });

            migrationBuilder.InsertData(
                table: "ShoppingCartItems",
                columns: new[] { "Id", "ApplicationUserId", "DateAdded", "ProductId", "Quantity", "SessionId", "UserId" },
                values: new object[,]
                {
                    { new Guid("0240a0cd-b256-437b-9dac-e37ad9f17d71"), null, new DateTime(2025, 7, 13, 7, 44, 19, 899, DateTimeKind.Utc).AddTicks(4134), new Guid("e494daf4-f457-4e63-a1c1-d7b1b41aabb4"), 2, null, new Guid("6449ba12-6618-4ddc-a297-02b02461b592") },
                    { new Guid("6f2efbfd-52f5-4b93-b899-3b33fc048aab"), null, new DateTime(2025, 7, 12, 7, 44, 19, 899, DateTimeKind.Utc).AddTicks(4129), new Guid("859dd085-223b-4f0e-a8b5-ddc4912aceef"), 1, null, new Guid("6449ba12-6618-4ddc-a297-02b02461b592") },
                    { new Guid("81f1516d-5780-4d9a-8de5-79f31d1e0d74"), null, new DateTime(2025, 7, 14, 2, 44, 19, 899, DateTimeKind.Utc).AddTicks(4206), new Guid("e73cdf56-7c04-4fa8-a8ed-8992eae0a562"), 1, null, new Guid("445a39a0-beda-40fb-a1e7-81c7c503ea9f") }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItems_AspNetUsers_UserId",
                table: "ShoppingCartItems",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItems_AspNetUsers_UserId",
                table: "ShoppingCartItems");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("b35a0423-d0be-49f4-a9ed-3b5a9a1d2a54"), new Guid("0d4e4678-29d4-4aab-8f56-4725162eb42b") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2d40c3a2-5dfb-422d-9f8e-bfbd5d5a9d1f"), new Guid("445a39a0-beda-40fb-a1e7-81c7c503ea9f") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2d40c3a2-5dfb-422d-9f8e-bfbd5d5a9d1f"), new Guid("6449ba12-6618-4ddc-a297-02b02461b592") });

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: new Guid("899b3591-d522-430d-a65d-1ff4c8954f85"));

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: new Guid("d6ac276c-32bb-45b9-91fa-27f33d57e6fc"));

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: new Guid("e65730f9-8123-46b5-8c40-2aa29b80f9df"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b03f6ac2-4929-4100-ada2-0a50f58a52cb"));

            migrationBuilder.DeleteData(
                table: "ShoppingCartItems",
                keyColumn: "Id",
                keyValue: new Guid("0240a0cd-b256-437b-9dac-e37ad9f17d71"));

            migrationBuilder.DeleteData(
                table: "ShoppingCartItems",
                keyColumn: "Id",
                keyValue: new Guid("6f2efbfd-52f5-4b93-b899-3b33fc048aab"));

            migrationBuilder.DeleteData(
                table: "ShoppingCartItems",
                keyColumn: "Id",
                keyValue: new Guid("81f1516d-5780-4d9a-8de5-79f31d1e0d74"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2d40c3a2-5dfb-422d-9f8e-bfbd5d5a9d1f"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b35a0423-d0be-49f4-a9ed-3b5a9a1d2a54"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0d4e4678-29d4-4aab-8f56-4725162eb42b"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("182648fc-37ce-4764-b560-cc145be26675"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("9b54f026-e3c6-4c9b-bf49-e91bcde8a37f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("163054c6-eaf3-46e0-bbdd-ba10bb80829a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("859dd085-223b-4f0e-a8b5-ddc4912aceef"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e494daf4-f457-4e63-a1c1-d7b1b41aabb4"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e73cdf56-7c04-4fa8-a8ed-8992eae0a562"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("445a39a0-beda-40fb-a1e7-81c7c503ea9f"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6449ba12-6618-4ddc-a297-02b02461b592"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("76960d7a-7323-4bb9-9451-caf91de6d087"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("781c50cb-955c-40de-b0ec-1f542e0090c4"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("bed1ed01-5445-4f14-b9f4-5c72c49cd4c7"));

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

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItems_AspNetUsers_UserId",
                table: "ShoppingCartItems",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
