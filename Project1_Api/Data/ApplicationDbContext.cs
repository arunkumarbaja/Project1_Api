using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project1.Models;

namespace Project1.Data
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid, // User, Role, Key type
                                   IdentityUserClaim<Guid>, IdentityUserRole<Guid>,
                                   IdentityUserLogin<Guid>, IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // Your E-commerce DbSets
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

        // No need to DbSet<ApplicationUser> or DbSet<ApplicationRole> here,
        // they are handled by IdentityDbContext.
        // Your original custom `User` class is no longer needed as a DbSet if it's fully replaced by ApplicationUser.

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder); // CRUCIAL for Identity tables configuration

            // --- DEFINE IDs FOR SEEDING (to manage relationships consistently) ---

            // Role IDs
            var adminRoleId = Guid.NewGuid();
            var customerRoleId = Guid.NewGuid();

            // User IDs
            var adminUserId = Guid.NewGuid();
            var aliceUserId = Guid.NewGuid();
            var bobUserId = Guid.NewGuid();

            // Category IDs
            var categoryElectronicsId = Guid.NewGuid();
            var categoryBooksId = Guid.NewGuid();
            var categoryApparelId = Guid.NewGuid();

            // Product IDs
            var productHeadphonesId = Guid.NewGuid();
            var productTvId = Guid.NewGuid();
            var productSciFiBooksId = Guid.NewGuid();
            var productTshirtId = Guid.NewGuid();
            var productDressId = Guid.NewGuid();

            // Order IDs
            var orderAliceId = Guid.NewGuid();
            var orderBobId = Guid.NewGuid();


            // --- SEED ROLES (ApplicationRole) ---
            builder.Entity<ApplicationRole>().HasData(
                new ApplicationRole { Id = adminRoleId, Name = "Admin", NormalizedName = "ADMIN"},
                new ApplicationRole { Id = customerRoleId, Name = "Customer", NormalizedName = "CUSTOMER" }
            );

            // --- SEED USERS (ApplicationUser) ---
            var hasher = new PasswordHasher<ApplicationUser>();

            builder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = adminUserId,
                    UserName = "admin@example.com",
                    NormalizedUserName = "ADMIN@EXAMPLE.COM",
                    Email = "admin@example.com",
                    NormalizedEmail = "ADMIN@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "AdminP@$$wOrd!123"), // Use a strong, unique password
                    SecurityStamp = Guid.NewGuid().ToString("D").ToUpper(),
                    FirstName = "Site",
                    LastName = "Admin",
                    DateRegistered = DateTime.UtcNow.AddDays(-100),
                    // Admin might not have shipping details, or you can set them
                    ShippingAddressStreet = "1 Admin Way",
                    ShippingAddressCity = "Control Panel",
                    ShippingAddressState = "SYS",
                    ShippingAddressPostalCode = "00001",
                    ShippingAddressCountry = "SERVERLAND"
                },
                new ApplicationUser
                {
                    Id = aliceUserId,
                    UserName = "alice.w@example.com",
                    NormalizedUserName = "ALICE.W@EXAMPLE.COM",
                    Email = "alice.w@example.com",
                    NormalizedEmail = "ALICE.W@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "AliceP@$$wOrd!456"), // Use a strong, unique password
                    SecurityStamp = Guid.NewGuid().ToString("D").ToUpper(),
                    FirstName = "Alice",
                    LastName = "Wonder",
                    DateRegistered = DateTime.UtcNow.AddDays(-60),
                    ShippingAddressStreet = "123 Main St",
                    ShippingAddressCity = "Anytown",
                    ShippingAddressState = "CA",
                    ShippingAddressPostalCode = "90210",
                    ShippingAddressCountry = "USA"
                },
                new ApplicationUser
                {
                    Id = bobUserId,
                    UserName = "bob.builder@example.com",
                    NormalizedUserName = "BOB.BUILDER@EXAMPLE.COM",
                    Email = "bob.builder@example.com",
                    NormalizedEmail = "BOB.BUILDER@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "BobP@$$wOrd!789"), // Use a strong, unique password
                    SecurityStamp = Guid.NewGuid().ToString("D").ToUpper(),
                    FirstName = "Bob",
                    LastName = "Builder",
                    DateRegistered = DateTime.UtcNow.AddDays(-50),
                    ShippingAddressStreet = "456 Oak Ave",
                    ShippingAddressCity = "Otherville",
                    ShippingAddressState = "NY",
                    ShippingAddressPostalCode = "10001",
                    ShippingAddressCountry = "USA"
                }
            );

            // --- SEED USER ROLES (Assign roles to users) ---
            builder.Entity<IdentityUserRole<Guid>>().HasData(
                new IdentityUserRole<Guid> { UserId = adminUserId, RoleId = adminRoleId },
                new IdentityUserRole<Guid> { UserId = aliceUserId, RoleId = customerRoleId },
                new IdentityUserRole<Guid> { UserId = bobUserId, RoleId = customerRoleId }
            );

            // --- SEED CATEGORIES ---
            builder.Entity<Category>().HasData(
                new Category { Id = categoryElectronicsId, Name = "Electronics", Description = "Gadgets, devices, and more." },
                new Category { Id = categoryBooksId, Name = "Books", Description = "Fiction, non-fiction, and educational." },
                new Category { Id = categoryApparelId, Name = "Apparel", Description = "Clothing for all occasions." }
            );

            // --- SEED PRODUCTS ---
            builder.Entity<Product>().HasData(
                new Product
                {
                    Id = productHeadphonesId,
                    Name = "Wireless Noise-Cancelling Headphones",
                    Description = "Immerse yourself in sound.",
                    Price = 199.99m,
                    Sku = "ELEC-HDPH-001",
                    StockQuantity = 50,
                    IsAvailable = true,
                    ImageUrl = "/images/products/headphones.jpg",
                    CategoryId = categoryElectronicsId,
                    DateCreated = DateTime.UtcNow.AddDays(-30)
                },
                new Product
                {
                    Id = productTvId,
                    Name = "Smart LED TV 55-inch",
                    Description = "Vibrant colors, smart features.",
                    Price = 499.50m,
                    Sku = "ELEC-TV-002",
                    StockQuantity = 25,
                    IsAvailable = true,
                    ImageUrl = "/images/products/smart-tv.jpg",
                    CategoryId = categoryElectronicsId,
                    DateCreated = DateTime.UtcNow.AddDays(-25)
                },
                new Product
                {
                    Id = productSciFiBooksId,
                    Name = "The Sci-Fi Novel Collection",
                    Description = "Three bestselling sci-fi novels.",
                    Price = 29.99m,
                    Sku = "BOOK-SCIFI-001",
                    StockQuantity = 100,
                    IsAvailable = true,
                    ImageUrl = "/images/products/scifi-books.jpg",
                    CategoryId = categoryBooksId,
                    DateCreated = DateTime.UtcNow.AddDays(-20)
                },
                new Product
                {
                    Id = productTshirtId,
                    Name = "Men's Classic Cotton T-Shirt",
                    Description = "Comfortable and stylish.",
                    Price = 19.95m,
                    Sku = "APRL-TSHRT-001",
                    StockQuantity = 200,
                    IsAvailable = true,
                    ImageUrl = "/images/products/tshirt-men.jpg",
                    CategoryId = categoryApparelId,
                    DateCreated = DateTime.UtcNow.AddDays(-15)
                },
                new Product
                {
                    Id = productDressId,
                    Name = "Women's Summer Dress",
                    Description = "Light and airy, perfect for summer.",
                    Price = 45.00m,
                    Sku = "APRL-DRESS-001",
                    StockQuantity = 75,
                    IsAvailable = false,
                    ImageUrl = "/images/products/dress-women.jpg",
                    CategoryId = categoryApparelId,
                    DateCreated = DateTime.UtcNow.AddDays(-10)
                }
            );

            // --- SEED SHOPPING CART ITEMS ---
            // Alice's Cart
            builder.Entity<ShoppingCartItem>().HasData(
                new ShoppingCartItem
                {
                    Id = Guid.NewGuid(),
                    UserId = aliceUserId,
                    SessionId = null, // Or string.Empty, or a specific placeholder if non-nullable
                    ProductId = productHeadphonesId,
                    Quantity = 1,
                    DateAdded = DateTime.UtcNow.AddDays(-2)
                },
                new ShoppingCartItem
                {
                    Id = Guid.NewGuid(),
                    UserId = aliceUserId,
                    SessionId = null, // Or string.Empty
                    ProductId = productTshirtId,
                    Quantity = 2,
                    DateAdded = DateTime.UtcNow.AddDays(-1)
                }
            );
            // Bob's Cart
            builder.Entity<ShoppingCartItem>().HasData(
                new ShoppingCartItem
                {
                    Id = Guid.NewGuid(),
                    UserId = bobUserId,
                    SessionId = null, // Or string.Empty
                    ProductId = productSciFiBooksId,
                    Quantity = 1,
                    DateAdded = DateTime.UtcNow.AddHours(-5)
                }
            );


            // --- SEED ORDERS ---
            // Alice's Order (Headphones)
            decimal aliceOrderTotal = 199.99m * 1; // Headphones price * quantity
            builder.Entity<Order>().HasData(
                new Order
                {
                    Id = orderAliceId,
                    UserId = aliceUserId,
                    OrderDate = DateTime.UtcNow.AddDays(-7),
                    Status = OrderStatus.Delivered,
                    TotalAmount = aliceOrderTotal,
                    ShippingAddressStreet = "123 Main St", // Copied from Alice's profile at time of order
                    ShippingAddressCity = "Anytown",
                    ShippingAddressState = "CA",
                    ShippingAddressPostalCode = "90210",
                    ShippingAddressCountry = "USA",
                    PaymentTransactionId = "txn_alice_123seed"
                }
            );
            builder.Entity<OrderItem>().HasData(
                new OrderItem
                {
                    Id = Guid.NewGuid(),
                    OrderId = orderAliceId,
                    ProductId = productHeadphonesId,
                    Quantity = 1,
                    UnitPriceAtPurchase = 199.99m
                }
            );

            // Bob's Order (TV and T-Shirt)
            decimal bobOrderTvPrice = 499.50m;
            int bobOrderTvQty = 1;
            decimal bobOrderTshirtPrice = 19.95m;
            int bobOrderTshirtQty = 2;
            decimal bobOrderTotal = (bobOrderTvPrice * bobOrderTvQty) + (bobOrderTshirtPrice * bobOrderTshirtQty);

            builder.Entity<Order>().HasData(
                new Order
                {
                    Id = orderBobId,
                    UserId = bobUserId,
                    OrderDate = DateTime.UtcNow.AddDays(-3),
                    Status = OrderStatus.Shipped,
                    TotalAmount = bobOrderTotal,
                    ShippingAddressStreet = "456 Oak Ave", // Copied from Bob's profile
                    ShippingAddressCity = "Otherville",
                    ShippingAddressState = "NY",
                    ShippingAddressPostalCode = "10001",
                    ShippingAddressCountry = "USA",
                    PaymentTransactionId = "txn_bob_456seed"
                }
            );
            builder.Entity<OrderItem>().HasData(
                new OrderItem
                {
                    Id = Guid.NewGuid(),
                    OrderId = orderBobId,
                    ProductId = productTvId,
                    Quantity = bobOrderTvQty,
                    UnitPriceAtPurchase = bobOrderTvPrice
                },
                new OrderItem
                {
                    Id = Guid.NewGuid(),
                    OrderId = orderBobId,
                    ProductId = productTshirtId,
                    Quantity = bobOrderTshirtQty,
                    UnitPriceAtPurchase = bobOrderTshirtPrice
                }
            );


            // --- Fluent API Configurations for your E-commerce Entities (as in previous example) ---
            // This ensures relationships are correctly defined beyond just data annotations.
            builder.Entity<ApplicationUser>(b =>
            {
                b.HasMany(e => e.Orders)
                    .WithOne(e => e.User)
                    .HasForeignKey(o => o.UserId)
                    .IsRequired();

                b.HasMany(e => e.ShoppingCartItems)
                    .WithOne(e => e.User)
                    .HasForeignKey(sci => sci.UserId)
                    .IsRequired(false);
            });

            builder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            });

            builder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
                entity.HasOne(d => d.Category)
                      .WithMany(p => p.Products)
                      .HasForeignKey(d => d.CategoryId);
                entity.HasMany(p => p.ShoppingCartItems)
                      .WithOne(sci => sci.Product)
                      .HasForeignKey(sci => sci.ProductId);
                entity.HasMany(p => p.OrderItems)
                      .WithOne(oi => oi.Product)
                      .HasForeignKey(oi => oi.ProductId);
            });

            builder.Entity<Order>(entity =>
            {
                entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");
                // Relationship to User already configured from ApplicationUser side
            });

            builder.Entity<OrderItem>(entity =>
            {
                entity.Property(e => e.UnitPriceAtPurchase).HasColumnType("decimal(18, 2)");
                entity.HasOne(d => d.Order)
                      .WithMany(p => p.OrderItems)
                      .HasForeignKey(d => d.OrderId);
                // Relationship to Product already configured from Product side
            });
            // Relationship for ShoppingCartItem to Product already configured from Product side
            // Relationship for ShoppingCartItem to User already configured from ApplicationUser side
        }
    }
}
