IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250603051458_Intial'
)
BEGIN
    CREATE TABLE [AspNetRoles] (
        [Id] uniqueidentifier NOT NULL,
        [Name] nvarchar(256) NULL,
        [NormalizedName] nvarchar(256) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250603051458_Intial'
)
BEGIN
    CREATE TABLE [AspNetUsers] (
        [Id] uniqueidentifier NOT NULL,
        [FirstName] nvarchar(100) NOT NULL,
        [LastName] nvarchar(100) NOT NULL,
        [DateRegistered] datetime2 NOT NULL,
        [ShippingAddressStreet] nvarchar(200) NOT NULL,
        [ShippingAddressCity] nvarchar(100) NOT NULL,
        [ShippingAddressState] nvarchar(100) NOT NULL,
        [ShippingAddressPostalCode] nvarchar(20) NOT NULL,
        [ShippingAddressCountry] nvarchar(100) NOT NULL,
        [UserName] nvarchar(256) NULL,
        [NormalizedUserName] nvarchar(256) NULL,
        [Email] nvarchar(256) NULL,
        [NormalizedEmail] nvarchar(256) NULL,
        [EmailConfirmed] bit NOT NULL,
        [PasswordHash] nvarchar(max) NULL,
        [SecurityStamp] nvarchar(max) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [PhoneNumberConfirmed] bit NOT NULL,
        [TwoFactorEnabled] bit NOT NULL,
        [LockoutEnd] datetimeoffset NULL,
        [LockoutEnabled] bit NOT NULL,
        [AccessFailedCount] int NOT NULL,
        CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250603051458_Intial'
)
BEGIN
    CREATE TABLE [Categories] (
        [Id] uniqueidentifier NOT NULL,
        [Name] nvarchar(100) NOT NULL,
        [Description] nvarchar(250) NOT NULL,
        CONSTRAINT [PK_Categories] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250603051458_Intial'
)
BEGIN
    CREATE TABLE [AspNetRoleClaims] (
        [Id] int NOT NULL IDENTITY,
        [RoleId] uniqueidentifier NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250603051458_Intial'
)
BEGIN
    CREATE TABLE [AspNetUserClaims] (
        [Id] int NOT NULL IDENTITY,
        [UserId] uniqueidentifier NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250603051458_Intial'
)
BEGIN
    CREATE TABLE [AspNetUserLogins] (
        [LoginProvider] nvarchar(450) NOT NULL,
        [ProviderKey] nvarchar(450) NOT NULL,
        [ProviderDisplayName] nvarchar(max) NULL,
        [UserId] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
        CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250603051458_Intial'
)
BEGIN
    CREATE TABLE [AspNetUserRoles] (
        [UserId] uniqueidentifier NOT NULL,
        [RoleId] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
        CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250603051458_Intial'
)
BEGIN
    CREATE TABLE [AspNetUserTokens] (
        [UserId] uniqueidentifier NOT NULL,
        [LoginProvider] nvarchar(450) NOT NULL,
        [Name] nvarchar(450) NOT NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
        CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250603051458_Intial'
)
BEGIN
    CREATE TABLE [Orders] (
        [Id] uniqueidentifier NOT NULL,
        [UserId] uniqueidentifier NOT NULL,
        [OrderDate] datetime2 NOT NULL,
        [Status] int NOT NULL,
        [TotalAmount] decimal(18,2) NOT NULL,
        [ShippingAddressStreet] nvarchar(200) NOT NULL,
        [ShippingAddressCity] nvarchar(100) NOT NULL,
        [ShippingAddressState] nvarchar(100) NOT NULL,
        [ShippingAddressPostalCode] nvarchar(20) NOT NULL,
        [ShippingAddressCountry] nvarchar(100) NOT NULL,
        [PaymentTransactionId] nvarchar(50) NOT NULL,
        CONSTRAINT [PK_Orders] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Orders_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250603051458_Intial'
)
BEGIN
    CREATE TABLE [Products] (
        [Id] uniqueidentifier NOT NULL,
        [Name] nvarchar(200) NOT NULL,
        [Description] nvarchar(1000) NOT NULL,
        [Price] decimal(18,2) NOT NULL,
        [Sku] nvarchar(50) NOT NULL,
        [StockQuantity] int NOT NULL,
        [IsAvailable] bit NOT NULL,
        [ImageUrl] nvarchar(max) NOT NULL,
        [CategoryId] uniqueidentifier NOT NULL,
        [DateCreated] datetime2 NOT NULL,
        CONSTRAINT [PK_Products] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Products_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Categories] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250603051458_Intial'
)
BEGIN
    CREATE TABLE [OrderItems] (
        [Id] uniqueidentifier NOT NULL,
        [OrderId] uniqueidentifier NOT NULL,
        [ProductId] uniqueidentifier NOT NULL,
        [Quantity] int NOT NULL,
        [UnitPriceAtPurchase] decimal(18,2) NOT NULL,
        CONSTRAINT [PK_OrderItems] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_OrderItems_Orders_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [Orders] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_OrderItems_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250603051458_Intial'
)
BEGIN
    CREATE TABLE [ShoppingCartItems] (
        [Id] uniqueidentifier NOT NULL,
        [UserId] uniqueidentifier NULL,
        [SessionId] nvarchar(128) NULL,
        [ProductId] uniqueidentifier NOT NULL,
        [Quantity] int NOT NULL,
        [DateAdded] datetime2 NOT NULL,
        CONSTRAINT [PK_ShoppingCartItems] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_ShoppingCartItems_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]),
        CONSTRAINT [FK_ShoppingCartItems_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250603051458_Intial'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
        SET IDENTITY_INSERT [AspNetRoles] ON;
    EXEC(N'INSERT INTO [AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName])
    VALUES (''66e46801-c588-4b87-8272-2f3bac7b7c89'', NULL, N''Customer'', N''CUSTOMER''),
    (''baa17e21-c8a7-4ce0-a6cf-525b7dc0d68c'', NULL, N''Admin'', N''ADMIN'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
        SET IDENTITY_INSERT [AspNetRoles] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250603051458_Intial'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AccessFailedCount', N'ConcurrencyStamp', N'DateRegistered', N'Email', N'EmailConfirmed', N'FirstName', N'LastName', N'LockoutEnabled', N'LockoutEnd', N'NormalizedEmail', N'NormalizedUserName', N'PasswordHash', N'PhoneNumber', N'PhoneNumberConfirmed', N'SecurityStamp', N'ShippingAddressCity', N'ShippingAddressCountry', N'ShippingAddressPostalCode', N'ShippingAddressState', N'ShippingAddressStreet', N'TwoFactorEnabled', N'UserName') AND [object_id] = OBJECT_ID(N'[AspNetUsers]'))
        SET IDENTITY_INSERT [AspNetUsers] ON;
    EXEC(N'INSERT INTO [AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [DateRegistered], [Email], [EmailConfirmed], [FirstName], [LastName], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [ShippingAddressCity], [ShippingAddressCountry], [ShippingAddressPostalCode], [ShippingAddressState], [ShippingAddressStreet], [TwoFactorEnabled], [UserName])
    VALUES (''2174484e-ad52-41bf-b71c-d55eac6bbb4d'', 0, N''831e1a2d-2e1b-42ef-a4ef-a89260b2d71b'', ''2025-04-04T05:14:57.8905706Z'', N''alice.w@example.com'', CAST(1 AS bit), N''Alice'', N''Wonder'', CAST(0 AS bit), NULL, N''ALICE.W@EXAMPLE.COM'', N''ALICE.W@EXAMPLE.COM'', N''AQAAAAIAAYagAAAAEIyWzrG79b+XviH3Ep31WK5S8qbZvpyqHMdVpj2vWH6fPWSCmbeCklP8BAEtT9ceEg=='', NULL, CAST(0 AS bit), N''5E789CB4-042E-4585-A110-951F39233ED2'', N''Anytown'', N''USA'', N''90210'', N''CA'', N''123 Main St'', CAST(0 AS bit), N''alice.w@example.com''),
    (''e40bb8d9-65a2-4e83-a1ee-7101943274f7'', 0, N''25b96a69-fead-42e1-bef6-7cc371b76aba'', ''2025-02-23T05:14:57.7699994Z'', N''admin@example.com'', CAST(1 AS bit), N''Site'', N''Admin'', CAST(0 AS bit), NULL, N''ADMIN@EXAMPLE.COM'', N''ADMIN@EXAMPLE.COM'', N''AQAAAAIAAYagAAAAEDvQIwNGpIR1jj8XgCsfFVLuIaJFyrewdo3TjG/q1UGlvXFFmiNDaNxfhSbK6qlyAA=='', NULL, CAST(0 AS bit), N''44AC0325-D55F-4270-B312-07C21C90F05C'', N''Control Panel'', N''SERVERLAND'', N''00001'', N''SYS'', N''1 Admin Way'', CAST(0 AS bit), N''admin@example.com''),
    (''f42e7270-9c2f-472b-9846-c1390ae66be6'', 0, N''679ffee1-c68e-4ace-bddd-d0e1093dc693'', ''2025-04-14T05:14:57.9891042Z'', N''bob.builder@example.com'', CAST(1 AS bit), N''Bob'', N''Builder'', CAST(0 AS bit), NULL, N''BOB.BUILDER@EXAMPLE.COM'', N''BOB.BUILDER@EXAMPLE.COM'', N''AQAAAAIAAYagAAAAEFA+U4nLx4USnZV3tOozRnItVOV70eLL+Is3RcTzKfYHdFs342NJ4ZerkRrRI5ZCkA=='', NULL, CAST(0 AS bit), N''B75D4AC3-5C7F-40EB-823E-7A9408B22EB2'', N''Otherville'', N''USA'', N''10001'', N''NY'', N''456 Oak Ave'', CAST(0 AS bit), N''bob.builder@example.com'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AccessFailedCount', N'ConcurrencyStamp', N'DateRegistered', N'Email', N'EmailConfirmed', N'FirstName', N'LastName', N'LockoutEnabled', N'LockoutEnd', N'NormalizedEmail', N'NormalizedUserName', N'PasswordHash', N'PhoneNumber', N'PhoneNumberConfirmed', N'SecurityStamp', N'ShippingAddressCity', N'ShippingAddressCountry', N'ShippingAddressPostalCode', N'ShippingAddressState', N'ShippingAddressStreet', N'TwoFactorEnabled', N'UserName') AND [object_id] = OBJECT_ID(N'[AspNetUsers]'))
        SET IDENTITY_INSERT [AspNetUsers] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250603051458_Intial'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Description', N'Name') AND [object_id] = OBJECT_ID(N'[Categories]'))
        SET IDENTITY_INSERT [Categories] ON;
    EXEC(N'INSERT INTO [Categories] ([Id], [Description], [Name])
    VALUES (''16addfd7-73f2-4bee-9d7b-fb2d39b0f5dc'', N''Clothing for all occasions.'', N''Apparel''),
    (''4fd992d2-dfa2-47d8-8cb4-0c128afee1ad'', N''Fiction, non-fiction, and educational.'', N''Books''),
    (''55bbe612-be1e-4525-b32d-a86965dd4bda'', N''Gadgets, devices, and more.'', N''Electronics'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Description', N'Name') AND [object_id] = OBJECT_ID(N'[Categories]'))
        SET IDENTITY_INSERT [Categories] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250603051458_Intial'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'RoleId', N'UserId') AND [object_id] = OBJECT_ID(N'[AspNetUserRoles]'))
        SET IDENTITY_INSERT [AspNetUserRoles] ON;
    EXEC(N'INSERT INTO [AspNetUserRoles] ([RoleId], [UserId])
    VALUES (''66e46801-c588-4b87-8272-2f3bac7b7c89'', ''2174484e-ad52-41bf-b71c-d55eac6bbb4d''),
    (''baa17e21-c8a7-4ce0-a6cf-525b7dc0d68c'', ''e40bb8d9-65a2-4e83-a1ee-7101943274f7''),
    (''66e46801-c588-4b87-8272-2f3bac7b7c89'', ''f42e7270-9c2f-472b-9846-c1390ae66be6'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'RoleId', N'UserId') AND [object_id] = OBJECT_ID(N'[AspNetUserRoles]'))
        SET IDENTITY_INSERT [AspNetUserRoles] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250603051458_Intial'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'OrderDate', N'PaymentTransactionId', N'ShippingAddressCity', N'ShippingAddressCountry', N'ShippingAddressPostalCode', N'ShippingAddressState', N'ShippingAddressStreet', N'Status', N'TotalAmount', N'UserId') AND [object_id] = OBJECT_ID(N'[Orders]'))
        SET IDENTITY_INSERT [Orders] ON;
    EXEC(N'INSERT INTO [Orders] ([Id], [OrderDate], [PaymentTransactionId], [ShippingAddressCity], [ShippingAddressCountry], [ShippingAddressPostalCode], [ShippingAddressState], [ShippingAddressStreet], [Status], [TotalAmount], [UserId])
    VALUES (''d03b3259-00cc-47e6-a46f-4e9f0041c5c7'', ''2025-05-27T05:14:57.9892540Z'', N''txn_alice_123seed'', N''Anytown'', N''USA'', N''90210'', N''CA'', N''123 Main St'', 3, 199.99, ''2174484e-ad52-41bf-b71c-d55eac6bbb4d''),
    (''e9518631-ff4b-4e40-b6f3-8839efa747a2'', ''2025-05-31T05:14:57.9892667Z'', N''txn_bob_456seed'', N''Otherville'', N''USA'', N''10001'', N''NY'', N''456 Oak Ave'', 2, 539.4, ''f42e7270-9c2f-472b-9846-c1390ae66be6'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'OrderDate', N'PaymentTransactionId', N'ShippingAddressCity', N'ShippingAddressCountry', N'ShippingAddressPostalCode', N'ShippingAddressState', N'ShippingAddressStreet', N'Status', N'TotalAmount', N'UserId') AND [object_id] = OBJECT_ID(N'[Orders]'))
        SET IDENTITY_INSERT [Orders] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250603051458_Intial'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CategoryId', N'DateCreated', N'Description', N'ImageUrl', N'IsAvailable', N'Name', N'Price', N'Sku', N'StockQuantity') AND [object_id] = OBJECT_ID(N'[Products]'))
        SET IDENTITY_INSERT [Products] ON;
    EXEC(N'INSERT INTO [Products] ([Id], [CategoryId], [DateCreated], [Description], [ImageUrl], [IsAvailable], [Name], [Price], [Sku], [StockQuantity])
    VALUES (''51db9b5c-6fa2-4434-a43c-70d272bff108'', ''16addfd7-73f2-4bee-9d7b-fb2d39b0f5dc'', ''2025-05-24T05:14:57.9892305Z'', N''Light and airy, perfect for summer.'', N''/images/products/dress-women.jpg'', CAST(0 AS bit), N''Women''''s Summer Dress'', 45.0, N''APRL-DRESS-001'', 75),
    (''6cdd5be4-e028-43d0-9ddc-b4cda05b055c'', ''4fd992d2-dfa2-47d8-8cb4-0c128afee1ad'', ''2025-05-14T05:14:57.9892290Z'', N''Three bestselling sci-fi novels.'', N''/images/products/scifi-books.jpg'', CAST(1 AS bit), N''The Sci-Fi Novel Collection'', 29.99, N''BOOK-SCIFI-001'', 100),
    (''a2c61f38-d7ab-454b-ad70-5ca8e70cea55'', ''55bbe612-be1e-4525-b32d-a86965dd4bda'', ''2025-05-09T05:14:57.9892286Z'', N''Vibrant colors, smart features.'', N''/images/products/smart-tv.jpg'', CAST(1 AS bit), N''Smart LED TV 55-inch'', 499.5, N''ELEC-TV-002'', 25),
    (''bd64618c-9039-4093-a171-703100f2c666'', ''16addfd7-73f2-4bee-9d7b-fb2d39b0f5dc'', ''2025-05-19T05:14:57.9892302Z'', N''Comfortable and stylish.'', N''/images/products/tshirt-men.jpg'', CAST(1 AS bit), N''Men''''s Classic Cotton T-Shirt'', 19.95, N''APRL-TSHRT-001'', 200),
    (''f2073be6-3216-49a7-9dfb-c38642e6fe27'', ''55bbe612-be1e-4525-b32d-a86965dd4bda'', ''2025-05-04T05:14:57.9892174Z'', N''Immerse yourself in sound.'', N''/images/products/headphones.jpg'', CAST(1 AS bit), N''Wireless Noise-Cancelling Headphones'', 199.99, N''ELEC-HDPH-001'', 50)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CategoryId', N'DateCreated', N'Description', N'ImageUrl', N'IsAvailable', N'Name', N'Price', N'Sku', N'StockQuantity') AND [object_id] = OBJECT_ID(N'[Products]'))
        SET IDENTITY_INSERT [Products] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250603051458_Intial'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'OrderId', N'ProductId', N'Quantity', N'UnitPriceAtPurchase') AND [object_id] = OBJECT_ID(N'[OrderItems]'))
        SET IDENTITY_INSERT [OrderItems] ON;
    EXEC(N'INSERT INTO [OrderItems] ([Id], [OrderId], [ProductId], [Quantity], [UnitPriceAtPurchase])
    VALUES (''5cc4b55d-4691-4b23-9ecd-a2fe2d12c25e'', ''d03b3259-00cc-47e6-a46f-4e9f0041c5c7'', ''f2073be6-3216-49a7-9dfb-c38642e6fe27'', 1, 199.99),
    (''78357495-852e-4cb8-be4e-d07753da9366'', ''e9518631-ff4b-4e40-b6f3-8839efa747a2'', ''a2c61f38-d7ab-454b-ad70-5ca8e70cea55'', 1, 499.5),
    (''9916c04c-a290-4d7e-8835-bc9d22f77f62'', ''e9518631-ff4b-4e40-b6f3-8839efa747a2'', ''bd64618c-9039-4093-a171-703100f2c666'', 2, 19.95)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'OrderId', N'ProductId', N'Quantity', N'UnitPriceAtPurchase') AND [object_id] = OBJECT_ID(N'[OrderItems]'))
        SET IDENTITY_INSERT [OrderItems] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250603051458_Intial'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DateAdded', N'ProductId', N'Quantity', N'SessionId', N'UserId') AND [object_id] = OBJECT_ID(N'[ShoppingCartItems]'))
        SET IDENTITY_INSERT [ShoppingCartItems] ON;
    EXEC(N'INSERT INTO [ShoppingCartItems] ([Id], [DateAdded], [ProductId], [Quantity], [SessionId], [UserId])
    VALUES (''4b8b5ee9-667a-4f7b-b261-ac927391e893'', ''2025-06-01T05:14:57.9892410Z'', ''f2073be6-3216-49a7-9dfb-c38642e6fe27'', 1, NULL, ''2174484e-ad52-41bf-b71c-d55eac6bbb4d''),
    (''8a083224-9e95-4690-9d4c-378a4d2e3ae4'', ''2025-06-03T00:14:57.9892480Z'', ''6cdd5be4-e028-43d0-9ddc-b4cda05b055c'', 1, NULL, ''f42e7270-9c2f-472b-9846-c1390ae66be6''),
    (''d6e109b5-0547-45b5-a210-551d319eb5e8'', ''2025-06-02T05:14:57.9892414Z'', ''bd64618c-9039-4093-a171-703100f2c666'', 2, NULL, ''2174484e-ad52-41bf-b71c-d55eac6bbb4d'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DateAdded', N'ProductId', N'Quantity', N'SessionId', N'UserId') AND [object_id] = OBJECT_ID(N'[ShoppingCartItems]'))
        SET IDENTITY_INSERT [ShoppingCartItems] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250603051458_Intial'
)
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250603051458_Intial'
)
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250603051458_Intial'
)
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250603051458_Intial'
)
BEGIN
    CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250603051458_Intial'
)
BEGIN
    CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250603051458_Intial'
)
BEGIN
    CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250603051458_Intial'
)
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250603051458_Intial'
)
BEGIN
    CREATE INDEX [IX_OrderItems_OrderId] ON [OrderItems] ([OrderId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250603051458_Intial'
)
BEGIN
    CREATE INDEX [IX_OrderItems_ProductId] ON [OrderItems] ([ProductId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250603051458_Intial'
)
BEGIN
    CREATE INDEX [IX_Orders_UserId] ON [Orders] ([UserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250603051458_Intial'
)
BEGIN
    CREATE INDEX [IX_Products_CategoryId] ON [Products] ([CategoryId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250603051458_Intial'
)
BEGIN
    CREATE INDEX [IX_ShoppingCartItems_ProductId] ON [ShoppingCartItems] ([ProductId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250603051458_Intial'
)
BEGIN
    CREATE INDEX [IX_ShoppingCartItems_UserId] ON [ShoppingCartItems] ([UserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250603051458_Intial'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20250603051458_Intial', N'8.0.6');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250605100821_Changed_2'
)
BEGIN
    EXEC(N'DELETE FROM [AspNetUserRoles]
    WHERE [RoleId] = ''66e46801-c588-4b87-8272-2f3bac7b7c89'' AND [UserId] = ''2174484e-ad52-41bf-b71c-d55eac6bbb4d'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250605100821_Changed_2'
)
BEGIN
    EXEC(N'DELETE FROM [AspNetUserRoles]
    WHERE [RoleId] = ''baa17e21-c8a7-4ce0-a6cf-525b7dc0d68c'' AND [UserId] = ''e40bb8d9-65a2-4e83-a1ee-7101943274f7'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250605100821_Changed_2'
)
BEGIN
    EXEC(N'DELETE FROM [AspNetUserRoles]
    WHERE [RoleId] = ''66e46801-c588-4b87-8272-2f3bac7b7c89'' AND [UserId] = ''f42e7270-9c2f-472b-9846-c1390ae66be6'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250605100821_Changed_2'
)
BEGIN
    EXEC(N'DELETE FROM [OrderItems]
    WHERE [Id] = ''5cc4b55d-4691-4b23-9ecd-a2fe2d12c25e'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250605100821_Changed_2'
)
BEGIN
    EXEC(N'DELETE FROM [OrderItems]
    WHERE [Id] = ''78357495-852e-4cb8-be4e-d07753da9366'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250605100821_Changed_2'
)
BEGIN
    EXEC(N'DELETE FROM [OrderItems]
    WHERE [Id] = ''9916c04c-a290-4d7e-8835-bc9d22f77f62'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250605100821_Changed_2'
)
BEGIN
    EXEC(N'DELETE FROM [Products]
    WHERE [Id] = ''51db9b5c-6fa2-4434-a43c-70d272bff108'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250605100821_Changed_2'
)
BEGIN
    EXEC(N'DELETE FROM [ShoppingCartItems]
    WHERE [Id] = ''4b8b5ee9-667a-4f7b-b261-ac927391e893'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250605100821_Changed_2'
)
BEGIN
    EXEC(N'DELETE FROM [ShoppingCartItems]
    WHERE [Id] = ''8a083224-9e95-4690-9d4c-378a4d2e3ae4'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250605100821_Changed_2'
)
BEGIN
    EXEC(N'DELETE FROM [ShoppingCartItems]
    WHERE [Id] = ''d6e109b5-0547-45b5-a210-551d319eb5e8'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250605100821_Changed_2'
)
BEGIN
    EXEC(N'DELETE FROM [AspNetRoles]
    WHERE [Id] = ''66e46801-c588-4b87-8272-2f3bac7b7c89'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250605100821_Changed_2'
)
BEGIN
    EXEC(N'DELETE FROM [AspNetRoles]
    WHERE [Id] = ''baa17e21-c8a7-4ce0-a6cf-525b7dc0d68c'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250605100821_Changed_2'
)
BEGIN
    EXEC(N'DELETE FROM [AspNetUsers]
    WHERE [Id] = ''e40bb8d9-65a2-4e83-a1ee-7101943274f7'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250605100821_Changed_2'
)
BEGIN
    EXEC(N'DELETE FROM [Orders]
    WHERE [Id] = ''d03b3259-00cc-47e6-a46f-4e9f0041c5c7'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250605100821_Changed_2'
)
BEGIN
    EXEC(N'DELETE FROM [Orders]
    WHERE [Id] = ''e9518631-ff4b-4e40-b6f3-8839efa747a2'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250605100821_Changed_2'
)
BEGIN
    EXEC(N'DELETE FROM [Products]
    WHERE [Id] = ''6cdd5be4-e028-43d0-9ddc-b4cda05b055c'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250605100821_Changed_2'
)
BEGIN
    EXEC(N'DELETE FROM [Products]
    WHERE [Id] = ''a2c61f38-d7ab-454b-ad70-5ca8e70cea55'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250605100821_Changed_2'
)
BEGIN
    EXEC(N'DELETE FROM [Products]
    WHERE [Id] = ''bd64618c-9039-4093-a171-703100f2c666'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250605100821_Changed_2'
)
BEGIN
    EXEC(N'DELETE FROM [Products]
    WHERE [Id] = ''f2073be6-3216-49a7-9dfb-c38642e6fe27'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250605100821_Changed_2'
)
BEGIN
    EXEC(N'DELETE FROM [AspNetUsers]
    WHERE [Id] = ''2174484e-ad52-41bf-b71c-d55eac6bbb4d'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250605100821_Changed_2'
)
BEGIN
    EXEC(N'DELETE FROM [AspNetUsers]
    WHERE [Id] = ''f42e7270-9c2f-472b-9846-c1390ae66be6'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250605100821_Changed_2'
)
BEGIN
    EXEC(N'DELETE FROM [Categories]
    WHERE [Id] = ''16addfd7-73f2-4bee-9d7b-fb2d39b0f5dc'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250605100821_Changed_2'
)
BEGIN
    EXEC(N'DELETE FROM [Categories]
    WHERE [Id] = ''4fd992d2-dfa2-47d8-8cb4-0c128afee1ad'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250605100821_Changed_2'
)
BEGIN
    EXEC(N'DELETE FROM [Categories]
    WHERE [Id] = ''55bbe612-be1e-4525-b32d-a86965dd4bda'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250605100821_Changed_2'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
        SET IDENTITY_INSERT [AspNetRoles] ON;
    EXEC(N'INSERT INTO [AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName])
    VALUES (''28521b0f-c2ea-4389-9222-a3b1108acdae'', NULL, N''Admin'', N''ADMIN''),
    (''4f42e81a-4def-4765-9d2a-48049af7cf0f'', NULL, N''Customer'', N''CUSTOMER'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
        SET IDENTITY_INSERT [AspNetRoles] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250605100821_Changed_2'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AccessFailedCount', N'ConcurrencyStamp', N'DateRegistered', N'Email', N'EmailConfirmed', N'FirstName', N'LastName', N'LockoutEnabled', N'LockoutEnd', N'NormalizedEmail', N'NormalizedUserName', N'PasswordHash', N'PhoneNumber', N'PhoneNumberConfirmed', N'SecurityStamp', N'ShippingAddressCity', N'ShippingAddressCountry', N'ShippingAddressPostalCode', N'ShippingAddressState', N'ShippingAddressStreet', N'TwoFactorEnabled', N'UserName') AND [object_id] = OBJECT_ID(N'[AspNetUsers]'))
        SET IDENTITY_INSERT [AspNetUsers] ON;
    EXEC(N'INSERT INTO [AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [DateRegistered], [Email], [EmailConfirmed], [FirstName], [LastName], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [ShippingAddressCity], [ShippingAddressCountry], [ShippingAddressPostalCode], [ShippingAddressState], [ShippingAddressStreet], [TwoFactorEnabled], [UserName])
    VALUES (''0c7099aa-54d8-41ea-a33b-4b553eb773f1'', 0, N''d0844277-1309-4b23-8290-e11eacf6e60d'', ''2025-04-06T10:08:20.6623843Z'', N''alice.w@example.com'', CAST(1 AS bit), N''Alice'', N''Wonder'', CAST(0 AS bit), NULL, N''ALICE.W@EXAMPLE.COM'', N''ALICE.W@EXAMPLE.COM'', N''AQAAAAIAAYagAAAAEOmKdGgpqHCGqfOM94bVmI3Xn+6tyaiWjPbdmjXKK0uTFFWGBypr7WQ3dfUwNiYN+Q=='', NULL, CAST(0 AS bit), N''A16CA07C-293D-4904-9704-B4E711D8B2A8'', N''Anytown'', N''USA'', N''90210'', N''CA'', N''123 Main St'', CAST(0 AS bit), N''alice.w@example.com''),
    (''4aa57a55-b36b-4fe9-8293-ad981499dfe9'', 0, N''60c7d2f9-0611-4917-8307-160f409a965c'', ''2025-04-16T10:08:20.7833951Z'', N''bob.builder@example.com'', CAST(1 AS bit), N''Bob'', N''Builder'', CAST(0 AS bit), NULL, N''BOB.BUILDER@EXAMPLE.COM'', N''BOB.BUILDER@EXAMPLE.COM'', N''AQAAAAIAAYagAAAAEIWrut2cT+ad8/ivyCnOGt9Q7c7dfNk5zT/zeN4rDhaeFTjBVB/k3MmN4c0N3h4Bpw=='', NULL, CAST(0 AS bit), N''3AC93D27-7BA5-4F65-9EF8-00CB4D4DB170'', N''Otherville'', N''USA'', N''10001'', N''NY'', N''456 Oak Ave'', CAST(0 AS bit), N''bob.builder@example.com''),
    (''4c982cdf-e97c-4469-bfde-af565e88b93a'', 0, N''2465b42f-3ad3-46f6-88f0-5e12fc9034f3'', ''2025-02-25T10:08:20.5532544Z'', N''admin@example.com'', CAST(1 AS bit), N''Site'', N''Admin'', CAST(0 AS bit), NULL, N''ADMIN@EXAMPLE.COM'', N''ADMIN@EXAMPLE.COM'', N''AQAAAAIAAYagAAAAEHxb1DUsGbXoXtfQZ4Q/sekKvMY5y5r946DcI0nUyXywhlY1avcpaPxNpvKMT8TClQ=='', NULL, CAST(0 AS bit), N''F74CB5B6-EAC6-4944-8BA3-45908774E33D'', N''Control Panel'', N''SERVERLAND'', N''00001'', N''SYS'', N''1 Admin Way'', CAST(0 AS bit), N''admin@example.com'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AccessFailedCount', N'ConcurrencyStamp', N'DateRegistered', N'Email', N'EmailConfirmed', N'FirstName', N'LastName', N'LockoutEnabled', N'LockoutEnd', N'NormalizedEmail', N'NormalizedUserName', N'PasswordHash', N'PhoneNumber', N'PhoneNumberConfirmed', N'SecurityStamp', N'ShippingAddressCity', N'ShippingAddressCountry', N'ShippingAddressPostalCode', N'ShippingAddressState', N'ShippingAddressStreet', N'TwoFactorEnabled', N'UserName') AND [object_id] = OBJECT_ID(N'[AspNetUsers]'))
        SET IDENTITY_INSERT [AspNetUsers] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250605100821_Changed_2'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Description', N'Name') AND [object_id] = OBJECT_ID(N'[Categories]'))
        SET IDENTITY_INSERT [Categories] ON;
    EXEC(N'INSERT INTO [Categories] ([Id], [Description], [Name])
    VALUES (''6b432f99-7930-4009-b798-cfb777372a75'', N''Gadgets, devices, and more.'', N''Electronics''),
    (''aa7d2b89-a106-443e-8bf4-13b5a785fe99'', N''Fiction, non-fiction, and educational.'', N''Books''),
    (''c1a6a076-cf98-433a-8d2d-a909c0bf8c3e'', N''Clothing for all occasions.'', N''Apparel'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Description', N'Name') AND [object_id] = OBJECT_ID(N'[Categories]'))
        SET IDENTITY_INSERT [Categories] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250605100821_Changed_2'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'RoleId', N'UserId') AND [object_id] = OBJECT_ID(N'[AspNetUserRoles]'))
        SET IDENTITY_INSERT [AspNetUserRoles] ON;
    EXEC(N'INSERT INTO [AspNetUserRoles] ([RoleId], [UserId])
    VALUES (''4f42e81a-4def-4765-9d2a-48049af7cf0f'', ''0c7099aa-54d8-41ea-a33b-4b553eb773f1''),
    (''4f42e81a-4def-4765-9d2a-48049af7cf0f'', ''4aa57a55-b36b-4fe9-8293-ad981499dfe9''),
    (''28521b0f-c2ea-4389-9222-a3b1108acdae'', ''4c982cdf-e97c-4469-bfde-af565e88b93a'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'RoleId', N'UserId') AND [object_id] = OBJECT_ID(N'[AspNetUserRoles]'))
        SET IDENTITY_INSERT [AspNetUserRoles] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250605100821_Changed_2'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'OrderDate', N'PaymentTransactionId', N'ShippingAddressCity', N'ShippingAddressCountry', N'ShippingAddressPostalCode', N'ShippingAddressState', N'ShippingAddressStreet', N'Status', N'TotalAmount', N'UserId') AND [object_id] = OBJECT_ID(N'[Orders]'))
        SET IDENTITY_INSERT [Orders] ON;
    EXEC(N'INSERT INTO [Orders] ([Id], [OrderDate], [PaymentTransactionId], [ShippingAddressCity], [ShippingAddressCountry], [ShippingAddressPostalCode], [ShippingAddressState], [ShippingAddressStreet], [Status], [TotalAmount], [UserId])
    VALUES (''6eb44941-1b9f-467b-ac6e-fbdc1b48df85'', ''2025-05-29T10:08:20.7834997Z'', N''txn_alice_123seed'', N''Anytown'', N''USA'', N''90210'', N''CA'', N''123 Main St'', 3, 199.99, ''0c7099aa-54d8-41ea-a33b-4b553eb773f1''),
    (''a623000d-05a0-4b24-bdd8-b275eae84e61'', ''2025-06-02T10:08:20.7835116Z'', N''txn_bob_456seed'', N''Otherville'', N''USA'', N''10001'', N''NY'', N''456 Oak Ave'', 2, 539.4, ''4aa57a55-b36b-4fe9-8293-ad981499dfe9'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'OrderDate', N'PaymentTransactionId', N'ShippingAddressCity', N'ShippingAddressCountry', N'ShippingAddressPostalCode', N'ShippingAddressState', N'ShippingAddressStreet', N'Status', N'TotalAmount', N'UserId') AND [object_id] = OBJECT_ID(N'[Orders]'))
        SET IDENTITY_INSERT [Orders] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250605100821_Changed_2'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CategoryId', N'DateCreated', N'Description', N'ImageUrl', N'IsAvailable', N'Name', N'Price', N'Sku', N'StockQuantity') AND [object_id] = OBJECT_ID(N'[Products]'))
        SET IDENTITY_INSERT [Products] ON;
    EXEC(N'INSERT INTO [Products] ([Id], [CategoryId], [DateCreated], [Description], [ImageUrl], [IsAvailable], [Name], [Price], [Sku], [StockQuantity])
    VALUES (''33cd4c4b-a02b-4214-b7f7-b7c22e9c681c'', ''c1a6a076-cf98-433a-8d2d-a909c0bf8c3e'', ''2025-05-26T10:08:20.7834802Z'', N''Light and airy, perfect for summer.'', N''/images/products/dress-women.jpg'', CAST(0 AS bit), N''Women''''s Summer Dress'', 45.0, N''APRL-DRESS-001'', 75),
    (''6b13cd9e-41c7-4596-8313-4ebed21703c9'', ''c1a6a076-cf98-433a-8d2d-a909c0bf8c3e'', ''2025-05-21T10:08:20.7834791Z'', N''Comfortable and stylish.'', N''/images/products/tshirt-men.jpg'', CAST(1 AS bit), N''Men''''s Classic Cotton T-Shirt'', 19.95, N''APRL-TSHRT-001'', 200),
    (''6f219ba7-ebbc-446c-86d9-46c0ba9415aa'', ''6b432f99-7930-4009-b798-cfb777372a75'', ''2025-05-11T10:08:20.7834784Z'', N''Vibrant colors, smart features.'', N''/images/products/smart-tv.jpg'', CAST(1 AS bit), N''Smart LED TV 55-inch'', 499.5, N''ELEC-TV-002'', 25),
    (''9331ae45-b337-495b-bdd9-4fa45c828acc'', ''6b432f99-7930-4009-b798-cfb777372a75'', ''2025-05-06T10:08:20.7834779Z'', N''Immerse yourself in sound.'', N''/images/products/headphones.jpg'', CAST(1 AS bit), N''Wireless Noise-Cancelling Headphones'', 199.99, N''ELEC-HDPH-001'', 50),
    (''9d9a7865-f83c-4190-b58b-ef9ad0169cd9'', ''aa7d2b89-a106-443e-8bf4-13b5a785fe99'', ''2025-05-16T10:08:20.7834788Z'', N''Three bestselling sci-fi novels.'', N''/images/products/scifi-books.jpg'', CAST(1 AS bit), N''The Sci-Fi Novel Collection'', 29.99, N''BOOK-SCIFI-001'', 100)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CategoryId', N'DateCreated', N'Description', N'ImageUrl', N'IsAvailable', N'Name', N'Price', N'Sku', N'StockQuantity') AND [object_id] = OBJECT_ID(N'[Products]'))
        SET IDENTITY_INSERT [Products] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250605100821_Changed_2'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'OrderId', N'ProductId', N'Quantity', N'UnitPriceAtPurchase') AND [object_id] = OBJECT_ID(N'[OrderItems]'))
        SET IDENTITY_INSERT [OrderItems] ON;
    EXEC(N'INSERT INTO [OrderItems] ([Id], [OrderId], [ProductId], [Quantity], [UnitPriceAtPurchase])
    VALUES (''18e6e290-bdcd-486b-9961-22043d70eb12'', ''a623000d-05a0-4b24-bdd8-b275eae84e61'', ''6b13cd9e-41c7-4596-8313-4ebed21703c9'', 2, 19.95),
    (''1c11b392-a611-4d0f-b2eb-6177d35fd5b9'', ''6eb44941-1b9f-467b-ac6e-fbdc1b48df85'', ''9331ae45-b337-495b-bdd9-4fa45c828acc'', 1, 199.99),
    (''32f2d16b-a3fb-435c-b684-b418d64e42a2'', ''a623000d-05a0-4b24-bdd8-b275eae84e61'', ''6f219ba7-ebbc-446c-86d9-46c0ba9415aa'', 1, 499.5)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'OrderId', N'ProductId', N'Quantity', N'UnitPriceAtPurchase') AND [object_id] = OBJECT_ID(N'[OrderItems]'))
        SET IDENTITY_INSERT [OrderItems] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250605100821_Changed_2'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DateAdded', N'ProductId', N'Quantity', N'SessionId', N'UserId') AND [object_id] = OBJECT_ID(N'[ShoppingCartItems]'))
        SET IDENTITY_INSERT [ShoppingCartItems] ON;
    EXEC(N'INSERT INTO [ShoppingCartItems] ([Id], [DateAdded], [ProductId], [Quantity], [SessionId], [UserId])
    VALUES (''255e870c-ebfd-420c-ac25-309a4d1f0429'', ''2025-06-05T05:08:20.7834937Z'', ''9d9a7865-f83c-4190-b58b-ef9ad0169cd9'', 1, NULL, ''4aa57a55-b36b-4fe9-8293-ad981499dfe9''),
    (''3a8ec6c7-1464-4824-9747-571c6b2181ed'', ''2025-06-04T10:08:20.7834879Z'', ''6b13cd9e-41c7-4596-8313-4ebed21703c9'', 2, NULL, ''0c7099aa-54d8-41ea-a33b-4b553eb773f1''),
    (''736e3382-a0d8-4bcc-908e-a480b53969a8'', ''2025-06-03T10:08:20.7834875Z'', ''9331ae45-b337-495b-bdd9-4fa45c828acc'', 1, NULL, ''0c7099aa-54d8-41ea-a33b-4b553eb773f1'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DateAdded', N'ProductId', N'Quantity', N'SessionId', N'UserId') AND [object_id] = OBJECT_ID(N'[ShoppingCartItems]'))
        SET IDENTITY_INSERT [ShoppingCartItems] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250605100821_Changed_2'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20250605100821_Changed_2', N'8.0.6');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250605103234_Changed_3'
)
BEGIN
    EXEC(N'DELETE FROM [AspNetUserRoles]
    WHERE [RoleId] = ''4f42e81a-4def-4765-9d2a-48049af7cf0f'' AND [UserId] = ''0c7099aa-54d8-41ea-a33b-4b553eb773f1'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250605103234_Changed_3'
)
BEGIN
    EXEC(N'DELETE FROM [AspNetUserRoles]
    WHERE [RoleId] = ''4f42e81a-4def-4765-9d2a-48049af7cf0f'' AND [UserId] = ''4aa57a55-b36b-4fe9-8293-ad981499dfe9'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250605103234_Changed_3'
)
BEGIN
    EXEC(N'DELETE FROM [AspNetUserRoles]
    WHERE [RoleId] = ''28521b0f-c2ea-4389-9222-a3b1108acdae'' AND [UserId] = ''4c982cdf-e97c-4469-bfde-af565e88b93a'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250605103234_Changed_3'
)
BEGIN
    EXEC(N'DELETE FROM [OrderItems]
    WHERE [Id] = ''18e6e290-bdcd-486b-9961-22043d70eb12'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250605103234_Changed_3'
)
BEGIN
    EXEC(N'DELETE FROM [OrderItems]
    WHERE [Id] = ''1c11b392-a611-4d0f-b2eb-6177d35fd5b9'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250605103234_Changed_3'
)
BEGIN
    EXEC(N'DELETE FROM [OrderItems]
    WHERE [Id] = ''32f2d16b-a3fb-435c-b684-b418d64e42a2'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250605103234_Changed_3'
)
BEGIN
    EXEC(N'DELETE FROM [Products]
    WHERE [Id] = ''33cd4c4b-a02b-4214-b7f7-b7c22e9c681c'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250605103234_Changed_3'
)
BEGIN
    EXEC(N'DELETE FROM [ShoppingCartItems]
    WHERE [Id] = ''255e870c-ebfd-420c-ac25-309a4d1f0429'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250605103234_Changed_3'
)
BEGIN
    EXEC(N'DELETE FROM [ShoppingCartItems]
    WHERE [Id] = ''3a8ec6c7-1464-4824-9747-571c6b2181ed'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250605103234_Changed_3'
)
BEGIN
    EXEC(N'DELETE FROM [ShoppingCartItems]
    WHERE [Id] = ''736e3382-a0d8-4bcc-908e-a480b53969a8'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250605103234_Changed_3'
)
BEGIN
    EXEC(N'DELETE FROM [AspNetRoles]
    WHERE [Id] = ''28521b0f-c2ea-4389-9222-a3b1108acdae'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250605103234_Changed_3'
)
BEGIN
    EXEC(N'DELETE FROM [AspNetRoles]
    WHERE [Id] = ''4f42e81a-4def-4765-9d2a-48049af7cf0f'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250605103234_Changed_3'
)
BEGIN
    EXEC(N'DELETE FROM [AspNetUsers]
    WHERE [Id] = ''4c982cdf-e97c-4469-bfde-af565e88b93a'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250605103234_Changed_3'
)
BEGIN
    EXEC(N'DELETE FROM [Orders]
    WHERE [Id] = ''6eb44941-1b9f-467b-ac6e-fbdc1b48df85'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250605103234_Changed_3'
)
BEGIN
    EXEC(N'DELETE FROM [Orders]
    WHERE [Id] = ''a623000d-05a0-4b24-bdd8-b275eae84e61'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250605103234_Changed_3'
)
BEGIN
    EXEC(N'DELETE FROM [Products]
    WHERE [Id] = ''6b13cd9e-41c7-4596-8313-4ebed21703c9'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250605103234_Changed_3'
)
BEGIN
    EXEC(N'DELETE FROM [Products]
    WHERE [Id] = ''6f219ba7-ebbc-446c-86d9-46c0ba9415aa'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250605103234_Changed_3'
)
BEGIN
    EXEC(N'DELETE FROM [Products]
    WHERE [Id] = ''9331ae45-b337-495b-bdd9-4fa45c828acc'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250605103234_Changed_3'
)
BEGIN
    EXEC(N'DELETE FROM [Products]
    WHERE [Id] = ''9d9a7865-f83c-4190-b58b-ef9ad0169cd9'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250605103234_Changed_3'
)
BEGIN
    EXEC(N'DELETE FROM [AspNetUsers]
    WHERE [Id] = ''0c7099aa-54d8-41ea-a33b-4b553eb773f1'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250605103234_Changed_3'
)
BEGIN
    EXEC(N'DELETE FROM [AspNetUsers]
    WHERE [Id] = ''4aa57a55-b36b-4fe9-8293-ad981499dfe9'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250605103234_Changed_3'
)
BEGIN
    EXEC(N'DELETE FROM [Categories]
    WHERE [Id] = ''6b432f99-7930-4009-b798-cfb777372a75'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250605103234_Changed_3'
)
BEGIN
    EXEC(N'DELETE FROM [Categories]
    WHERE [Id] = ''aa7d2b89-a106-443e-8bf4-13b5a785fe99'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250605103234_Changed_3'
)
BEGIN
    EXEC(N'DELETE FROM [Categories]
    WHERE [Id] = ''c1a6a076-cf98-433a-8d2d-a909c0bf8c3e'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250605103234_Changed_3'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
        SET IDENTITY_INSERT [AspNetRoles] ON;
    EXEC(N'INSERT INTO [AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName])
    VALUES (''4d4d65a3-68ea-4959-9f71-5ee64baccbfe'', NULL, N''Admin'', N''ADMIN''),
    (''f8334bf9-f3bf-4162-b765-b11bca6a6c84'', NULL, N''Customer'', N''CUSTOMER'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
        SET IDENTITY_INSERT [AspNetRoles] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250605103234_Changed_3'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AccessFailedCount', N'ConcurrencyStamp', N'DateRegistered', N'Email', N'EmailConfirmed', N'FirstName', N'LastName', N'LockoutEnabled', N'LockoutEnd', N'NormalizedEmail', N'NormalizedUserName', N'PasswordHash', N'PhoneNumber', N'PhoneNumberConfirmed', N'SecurityStamp', N'ShippingAddressCity', N'ShippingAddressCountry', N'ShippingAddressPostalCode', N'ShippingAddressState', N'ShippingAddressStreet', N'TwoFactorEnabled', N'UserName') AND [object_id] = OBJECT_ID(N'[AspNetUsers]'))
        SET IDENTITY_INSERT [AspNetUsers] ON;
    EXEC(N'INSERT INTO [AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [DateRegistered], [Email], [EmailConfirmed], [FirstName], [LastName], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [ShippingAddressCity], [ShippingAddressCountry], [ShippingAddressPostalCode], [ShippingAddressState], [ShippingAddressStreet], [TwoFactorEnabled], [UserName])
    VALUES (''23476a76-c69a-4bef-8c68-467832b72c4f'', 0, N''93b591d2-b268-4f84-ae0f-f5254f56ac09'', ''2025-04-06T10:32:32.9378701Z'', N''alice.w@example.com'', CAST(1 AS bit), N''Alice'', N''Wonder'', CAST(0 AS bit), NULL, N''ALICE.W@EXAMPLE.COM'', N''ALICE.W@EXAMPLE.COM'', N''AQAAAAIAAYagAAAAEFDf4v6M56fnS/7MFTzWNRC9n+lUrbMDA6WGqYaFBoIL9QX4/fkM/kPwKSfalzD80w=='', NULL, CAST(0 AS bit), N''56C8CAF4-BD83-4742-8D2E-1B64D704C9C9'', N''Anytown'', N''USA'', N''90210'', N''CA'', N''123 Main St'', CAST(0 AS bit), N''alice.w@example.com''),
    (''43f8af90-4d78-4c12-8365-ba159decfbad'', 0, N''a955b777-741e-48c4-a4e7-0ea5068abc73'', ''2025-02-25T10:32:32.7914701Z'', N''admin@example.com'', CAST(1 AS bit), N''Site'', N''Admin'', CAST(0 AS bit), NULL, N''ADMIN@EXAMPLE.COM'', N''ADMIN@EXAMPLE.COM'', N''AQAAAAIAAYagAAAAEDmBtkUjUCL3pFtGpmPtTbw1t1RXglR3tkEz/ktyk721efAPHD4F2XXnX5DKMwVkmg=='', NULL, CAST(0 AS bit), N''13F0391D-5A4A-4903-A1A0-E0CE1E9EF00A'', N''Control Panel'', N''SERVERLAND'', N''00001'', N''SYS'', N''1 Admin Way'', CAST(0 AS bit), N''admin@example.com''),
    (''64d8122e-5e3c-4ba8-ad31-0709286d9783'', 0, N''57338123-d32e-4143-8b84-bd00e1f87870'', ''2025-04-16T10:32:33.0790415Z'', N''bob.builder@example.com'', CAST(1 AS bit), N''Bob'', N''Builder'', CAST(0 AS bit), NULL, N''BOB.BUILDER@EXAMPLE.COM'', N''BOB.BUILDER@EXAMPLE.COM'', N''AQAAAAIAAYagAAAAEJXXOuHaBcx/iKKKct4H1IP7tBv4vfA1YHxrwEonqz/KoMe9eNsNLSi8j2XmYWzAcg=='', NULL, CAST(0 AS bit), N''157546A4-0F03-4366-974A-10DCB2315F45'', N''Otherville'', N''USA'', N''10001'', N''NY'', N''456 Oak Ave'', CAST(0 AS bit), N''bob.builder@example.com'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AccessFailedCount', N'ConcurrencyStamp', N'DateRegistered', N'Email', N'EmailConfirmed', N'FirstName', N'LastName', N'LockoutEnabled', N'LockoutEnd', N'NormalizedEmail', N'NormalizedUserName', N'PasswordHash', N'PhoneNumber', N'PhoneNumberConfirmed', N'SecurityStamp', N'ShippingAddressCity', N'ShippingAddressCountry', N'ShippingAddressPostalCode', N'ShippingAddressState', N'ShippingAddressStreet', N'TwoFactorEnabled', N'UserName') AND [object_id] = OBJECT_ID(N'[AspNetUsers]'))
        SET IDENTITY_INSERT [AspNetUsers] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250605103234_Changed_3'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Description', N'Name') AND [object_id] = OBJECT_ID(N'[Categories]'))
        SET IDENTITY_INSERT [Categories] ON;
    EXEC(N'INSERT INTO [Categories] ([Id], [Description], [Name])
    VALUES (''218545d9-b2f5-4766-8e0e-8a3385c0fc6d'', N''Gadgets, devices, and more.'', N''Electronics''),
    (''c3ff0dbd-0579-40c9-b545-080ddf0592c3'', N''Fiction, non-fiction, and educational.'', N''Books''),
    (''e83019c1-0ac6-46da-bca9-6e8962247266'', N''Clothing for all occasions.'', N''Apparel'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Description', N'Name') AND [object_id] = OBJECT_ID(N'[Categories]'))
        SET IDENTITY_INSERT [Categories] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250605103234_Changed_3'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'RoleId', N'UserId') AND [object_id] = OBJECT_ID(N'[AspNetUserRoles]'))
        SET IDENTITY_INSERT [AspNetUserRoles] ON;
    EXEC(N'INSERT INTO [AspNetUserRoles] ([RoleId], [UserId])
    VALUES (''f8334bf9-f3bf-4162-b765-b11bca6a6c84'', ''23476a76-c69a-4bef-8c68-467832b72c4f''),
    (''4d4d65a3-68ea-4959-9f71-5ee64baccbfe'', ''43f8af90-4d78-4c12-8365-ba159decfbad''),
    (''f8334bf9-f3bf-4162-b765-b11bca6a6c84'', ''64d8122e-5e3c-4ba8-ad31-0709286d9783'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'RoleId', N'UserId') AND [object_id] = OBJECT_ID(N'[AspNetUserRoles]'))
        SET IDENTITY_INSERT [AspNetUserRoles] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250605103234_Changed_3'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'OrderDate', N'PaymentTransactionId', N'ShippingAddressCity', N'ShippingAddressCountry', N'ShippingAddressPostalCode', N'ShippingAddressState', N'ShippingAddressStreet', N'Status', N'TotalAmount', N'UserId') AND [object_id] = OBJECT_ID(N'[Orders]'))
        SET IDENTITY_INSERT [Orders] ON;
    EXEC(N'INSERT INTO [Orders] ([Id], [OrderDate], [PaymentTransactionId], [ShippingAddressCity], [ShippingAddressCountry], [ShippingAddressPostalCode], [ShippingAddressState], [ShippingAddressStreet], [Status], [TotalAmount], [UserId])
    VALUES (''20fe6292-620d-4aaf-9db5-6db7d805f626'', ''2025-05-29T10:32:33.0792113Z'', N''txn_alice_123seed'', N''Anytown'', N''USA'', N''90210'', N''CA'', N''123 Main St'', 3, 199.99, ''23476a76-c69a-4bef-8c68-467832b72c4f''),
    (''cd34ec29-d0d6-4ddd-981d-f43a609a2374'', ''2025-06-02T10:32:33.0792302Z'', N''txn_bob_456seed'', N''Otherville'', N''USA'', N''10001'', N''NY'', N''456 Oak Ave'', 2, 539.4, ''64d8122e-5e3c-4ba8-ad31-0709286d9783'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'OrderDate', N'PaymentTransactionId', N'ShippingAddressCity', N'ShippingAddressCountry', N'ShippingAddressPostalCode', N'ShippingAddressState', N'ShippingAddressStreet', N'Status', N'TotalAmount', N'UserId') AND [object_id] = OBJECT_ID(N'[Orders]'))
        SET IDENTITY_INSERT [Orders] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250605103234_Changed_3'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CategoryId', N'DateCreated', N'Description', N'ImageUrl', N'IsAvailable', N'Name', N'Price', N'Sku', N'StockQuantity') AND [object_id] = OBJECT_ID(N'[Products]'))
        SET IDENTITY_INSERT [Products] ON;
    EXEC(N'INSERT INTO [Products] ([Id], [CategoryId], [DateCreated], [Description], [ImageUrl], [IsAvailable], [Name], [Price], [Sku], [StockQuantity])
    VALUES (''502d001e-2b58-43f2-8e04-6f2309b31721'', ''e83019c1-0ac6-46da-bca9-6e8962247266'', ''2025-05-26T10:32:33.0791796Z'', N''Light and airy, perfect for summer.'', N''/images/products/dress-women.jpg'', CAST(0 AS bit), N''Women''''s Summer Dress'', 45.0, N''APRL-DRESS-001'', 75),
    (''a3f1d105-f357-4173-9a62-be533aa7dd99'', ''218545d9-b2f5-4766-8e0e-8a3385c0fc6d'', ''2025-05-06T10:32:33.0791762Z'', N''Immerse yourself in sound.'', N''/images/products/headphones.jpg'', CAST(1 AS bit), N''Wireless Noise-Cancelling Headphones'', 199.99, N''ELEC-HDPH-001'', 50),
    (''c751e199-9a58-4619-a331-24390f30a311'', ''218545d9-b2f5-4766-8e0e-8a3385c0fc6d'', ''2025-05-11T10:32:33.0791770Z'', N''Vibrant colors, smart features.'', N''/images/products/smart-tv.jpg'', CAST(1 AS bit), N''Smart LED TV 55-inch'', 499.5, N''ELEC-TV-002'', 25),
    (''e6097226-3a38-4a82-ac10-8ddb5a8819ce'', ''e83019c1-0ac6-46da-bca9-6e8962247266'', ''2025-05-21T10:32:33.0791792Z'', N''Comfortable and stylish.'', N''/images/products/tshirt-men.jpg'', CAST(1 AS bit), N''Men''''s Classic Cotton T-Shirt'', 19.95, N''APRL-TSHRT-001'', 200),
    (''fe95b471-f8eb-40ad-9400-9b1a9e01f890'', ''c3ff0dbd-0579-40c9-b545-080ddf0592c3'', ''2025-05-16T10:32:33.0791775Z'', N''Three bestselling sci-fi novels.'', N''/images/products/scifi-books.jpg'', CAST(1 AS bit), N''The Sci-Fi Novel Collection'', 29.99, N''BOOK-SCIFI-001'', 100)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CategoryId', N'DateCreated', N'Description', N'ImageUrl', N'IsAvailable', N'Name', N'Price', N'Sku', N'StockQuantity') AND [object_id] = OBJECT_ID(N'[Products]'))
        SET IDENTITY_INSERT [Products] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250605103234_Changed_3'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'OrderId', N'ProductId', N'Quantity', N'UnitPriceAtPurchase') AND [object_id] = OBJECT_ID(N'[OrderItems]'))
        SET IDENTITY_INSERT [OrderItems] ON;
    EXEC(N'INSERT INTO [OrderItems] ([Id], [OrderId], [ProductId], [Quantity], [UnitPriceAtPurchase])
    VALUES (''4d8a5e29-a365-4f1d-81c3-f76122dbd52f'', ''cd34ec29-d0d6-4ddd-981d-f43a609a2374'', ''c751e199-9a58-4619-a331-24390f30a311'', 1, 499.5),
    (''514856ea-0c52-43ba-964c-85881381dd44'', ''20fe6292-620d-4aaf-9db5-6db7d805f626'', ''a3f1d105-f357-4173-9a62-be533aa7dd99'', 1, 199.99),
    (''f8f30353-10a8-46e9-81c8-f71ad6d6e82a'', ''cd34ec29-d0d6-4ddd-981d-f43a609a2374'', ''e6097226-3a38-4a82-ac10-8ddb5a8819ce'', 2, 19.95)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'OrderId', N'ProductId', N'Quantity', N'UnitPriceAtPurchase') AND [object_id] = OBJECT_ID(N'[OrderItems]'))
        SET IDENTITY_INSERT [OrderItems] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250605103234_Changed_3'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DateAdded', N'ProductId', N'Quantity', N'SessionId', N'UserId') AND [object_id] = OBJECT_ID(N'[ShoppingCartItems]'))
        SET IDENTITY_INSERT [ShoppingCartItems] ON;
    EXEC(N'INSERT INTO [ShoppingCartItems] ([Id], [DateAdded], [ProductId], [Quantity], [SessionId], [UserId])
    VALUES (''27c92d8f-9826-4917-8f1c-0b1f5a828527'', ''2025-06-05T05:32:33.0792022Z'', ''fe95b471-f8eb-40ad-9400-9b1a9e01f890'', 1, NULL, ''64d8122e-5e3c-4ba8-ad31-0709286d9783''),
    (''7791b420-259d-4039-bb3a-1519cecf0c3e'', ''2025-06-04T10:32:33.0791922Z'', ''e6097226-3a38-4a82-ac10-8ddb5a8819ce'', 2, NULL, ''23476a76-c69a-4bef-8c68-467832b72c4f''),
    (''8d9cea9e-2488-49a2-b667-c4295527dcef'', ''2025-06-03T10:32:33.0791917Z'', ''a3f1d105-f357-4173-9a62-be533aa7dd99'', 1, NULL, ''23476a76-c69a-4bef-8c68-467832b72c4f'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DateAdded', N'ProductId', N'Quantity', N'SessionId', N'UserId') AND [object_id] = OBJECT_ID(N'[ShoppingCartItems]'))
        SET IDENTITY_INSERT [ShoppingCartItems] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250605103234_Changed_3'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20250605103234_Changed_3', N'8.0.6');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250613165226_shippingCartItem_Updated'
)
BEGIN
    EXEC(N'DELETE FROM [AspNetUserRoles]
    WHERE [RoleId] = ''f8334bf9-f3bf-4162-b765-b11bca6a6c84'' AND [UserId] = ''23476a76-c69a-4bef-8c68-467832b72c4f'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250613165226_shippingCartItem_Updated'
)
BEGIN
    EXEC(N'DELETE FROM [AspNetUserRoles]
    WHERE [RoleId] = ''4d4d65a3-68ea-4959-9f71-5ee64baccbfe'' AND [UserId] = ''43f8af90-4d78-4c12-8365-ba159decfbad'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250613165226_shippingCartItem_Updated'
)
BEGIN
    EXEC(N'DELETE FROM [AspNetUserRoles]
    WHERE [RoleId] = ''f8334bf9-f3bf-4162-b765-b11bca6a6c84'' AND [UserId] = ''64d8122e-5e3c-4ba8-ad31-0709286d9783'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250613165226_shippingCartItem_Updated'
)
BEGIN
    EXEC(N'DELETE FROM [OrderItems]
    WHERE [Id] = ''4d8a5e29-a365-4f1d-81c3-f76122dbd52f'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250613165226_shippingCartItem_Updated'
)
BEGIN
    EXEC(N'DELETE FROM [OrderItems]
    WHERE [Id] = ''514856ea-0c52-43ba-964c-85881381dd44'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250613165226_shippingCartItem_Updated'
)
BEGIN
    EXEC(N'DELETE FROM [OrderItems]
    WHERE [Id] = ''f8f30353-10a8-46e9-81c8-f71ad6d6e82a'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250613165226_shippingCartItem_Updated'
)
BEGIN
    EXEC(N'DELETE FROM [Products]
    WHERE [Id] = ''502d001e-2b58-43f2-8e04-6f2309b31721'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250613165226_shippingCartItem_Updated'
)
BEGIN
    EXEC(N'DELETE FROM [ShoppingCartItems]
    WHERE [Id] = ''27c92d8f-9826-4917-8f1c-0b1f5a828527'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250613165226_shippingCartItem_Updated'
)
BEGIN
    EXEC(N'DELETE FROM [ShoppingCartItems]
    WHERE [Id] = ''7791b420-259d-4039-bb3a-1519cecf0c3e'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250613165226_shippingCartItem_Updated'
)
BEGIN
    EXEC(N'DELETE FROM [ShoppingCartItems]
    WHERE [Id] = ''8d9cea9e-2488-49a2-b667-c4295527dcef'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250613165226_shippingCartItem_Updated'
)
BEGIN
    EXEC(N'DELETE FROM [AspNetRoles]
    WHERE [Id] = ''4d4d65a3-68ea-4959-9f71-5ee64baccbfe'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250613165226_shippingCartItem_Updated'
)
BEGIN
    EXEC(N'DELETE FROM [AspNetRoles]
    WHERE [Id] = ''f8334bf9-f3bf-4162-b765-b11bca6a6c84'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250613165226_shippingCartItem_Updated'
)
BEGIN
    EXEC(N'DELETE FROM [AspNetUsers]
    WHERE [Id] = ''43f8af90-4d78-4c12-8365-ba159decfbad'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250613165226_shippingCartItem_Updated'
)
BEGIN
    EXEC(N'DELETE FROM [Orders]
    WHERE [Id] = ''20fe6292-620d-4aaf-9db5-6db7d805f626'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250613165226_shippingCartItem_Updated'
)
BEGIN
    EXEC(N'DELETE FROM [Orders]
    WHERE [Id] = ''cd34ec29-d0d6-4ddd-981d-f43a609a2374'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250613165226_shippingCartItem_Updated'
)
BEGIN
    EXEC(N'DELETE FROM [Products]
    WHERE [Id] = ''a3f1d105-f357-4173-9a62-be533aa7dd99'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250613165226_shippingCartItem_Updated'
)
BEGIN
    EXEC(N'DELETE FROM [Products]
    WHERE [Id] = ''c751e199-9a58-4619-a331-24390f30a311'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250613165226_shippingCartItem_Updated'
)
BEGIN
    EXEC(N'DELETE FROM [Products]
    WHERE [Id] = ''e6097226-3a38-4a82-ac10-8ddb5a8819ce'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250613165226_shippingCartItem_Updated'
)
BEGIN
    EXEC(N'DELETE FROM [Products]
    WHERE [Id] = ''fe95b471-f8eb-40ad-9400-9b1a9e01f890'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250613165226_shippingCartItem_Updated'
)
BEGIN
    EXEC(N'DELETE FROM [AspNetUsers]
    WHERE [Id] = ''23476a76-c69a-4bef-8c68-467832b72c4f'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250613165226_shippingCartItem_Updated'
)
BEGIN
    EXEC(N'DELETE FROM [AspNetUsers]
    WHERE [Id] = ''64d8122e-5e3c-4ba8-ad31-0709286d9783'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250613165226_shippingCartItem_Updated'
)
BEGIN
    EXEC(N'DELETE FROM [Categories]
    WHERE [Id] = ''218545d9-b2f5-4766-8e0e-8a3385c0fc6d'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250613165226_shippingCartItem_Updated'
)
BEGIN
    EXEC(N'DELETE FROM [Categories]
    WHERE [Id] = ''c3ff0dbd-0579-40c9-b545-080ddf0592c3'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250613165226_shippingCartItem_Updated'
)
BEGIN
    EXEC(N'DELETE FROM [Categories]
    WHERE [Id] = ''e83019c1-0ac6-46da-bca9-6e8962247266'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250613165226_shippingCartItem_Updated'
)
BEGIN
    ALTER TABLE [ShoppingCartItems] ADD [ApplicationUserId] uniqueidentifier NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250613165226_shippingCartItem_Updated'
)
BEGIN
    ALTER TABLE [Orders] ADD [ApplicationUserId] uniqueidentifier NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250613165226_shippingCartItem_Updated'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
        SET IDENTITY_INSERT [AspNetRoles] ON;
    EXEC(N'INSERT INTO [AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName])
    VALUES (''3e860fe9-f0e9-4b51-9061-2d051fe48911'', NULL, N''Customer'', N''CUSTOMER''),
    (''846ff114-dfc6-451d-925f-5dcfea457c8a'', NULL, N''Admin'', N''ADMIN'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
        SET IDENTITY_INSERT [AspNetRoles] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250613165226_shippingCartItem_Updated'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AccessFailedCount', N'ConcurrencyStamp', N'DateRegistered', N'Email', N'EmailConfirmed', N'FirstName', N'LastName', N'LockoutEnabled', N'LockoutEnd', N'NormalizedEmail', N'NormalizedUserName', N'PasswordHash', N'PhoneNumber', N'PhoneNumberConfirmed', N'SecurityStamp', N'ShippingAddressCity', N'ShippingAddressCountry', N'ShippingAddressPostalCode', N'ShippingAddressState', N'ShippingAddressStreet', N'TwoFactorEnabled', N'UserName') AND [object_id] = OBJECT_ID(N'[AspNetUsers]'))
        SET IDENTITY_INSERT [AspNetUsers] ON;
    EXEC(N'INSERT INTO [AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [DateRegistered], [Email], [EmailConfirmed], [FirstName], [LastName], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [ShippingAddressCity], [ShippingAddressCountry], [ShippingAddressPostalCode], [ShippingAddressState], [ShippingAddressStreet], [TwoFactorEnabled], [UserName])
    VALUES (''32131d27-4858-4e27-9ee7-f780cbc947a1'', 0, N''03aaaaf2-873c-4362-9e51-783220a4c785'', ''2025-04-14T16:52:25.4463092Z'', N''alice.w@example.com'', CAST(1 AS bit), N''Alice'', N''Wonder'', CAST(0 AS bit), NULL, N''ALICE.W@EXAMPLE.COM'', N''ALICE.W@EXAMPLE.COM'', N''AQAAAAIAAYagAAAAEISIPavQ7zZGk42nVhYD9Xmk90QGUdLm3bXRxZtvyKZomus5mJSfwg98ujFGYUY+7A=='', NULL, CAST(0 AS bit), N''33A4DA2D-ABA2-4D1A-B4E4-6C97D50D8BD7'', N''Anytown'', N''USA'', N''90210'', N''CA'', N''123 Main St'', CAST(0 AS bit), N''alice.w@example.com''),
    (''7b70dd23-2a99-4c84-a5f2-a0a9ca8614b9'', 0, N''663ea6cb-6187-4aa8-a700-cedf0af3238e'', ''2025-04-24T16:52:25.5380685Z'', N''bob.builder@example.com'', CAST(1 AS bit), N''Bob'', N''Builder'', CAST(0 AS bit), NULL, N''BOB.BUILDER@EXAMPLE.COM'', N''BOB.BUILDER@EXAMPLE.COM'', N''AQAAAAIAAYagAAAAEJY6q44qCDPh/45QSLNIZ95yf5RS2kP8YBXG35WHYsUr6Q9idVQRNEsM0G2Q9CAOGA=='', NULL, CAST(0 AS bit), N''2A429E3D-B6ED-4B49-A70F-68CB83081556'', N''Otherville'', N''USA'', N''10001'', N''NY'', N''456 Oak Ave'', CAST(0 AS bit), N''bob.builder@example.com''),
    (''9bdbb0b3-1cb9-4c3f-8ca6-6d0b1d1ed7fb'', 0, N''613633ce-088b-4a27-8ad6-b0e25a768496'', ''2025-03-05T16:52:25.3359317Z'', N''admin@example.com'', CAST(1 AS bit), N''Site'', N''Admin'', CAST(0 AS bit), NULL, N''ADMIN@EXAMPLE.COM'', N''ADMIN@EXAMPLE.COM'', N''AQAAAAIAAYagAAAAEL/Cbhqbze2wBridhAq3E14OVtaq4Clp/8E2UEfU2KoQi1RqdmcK5/kl5hGeeKdghw=='', NULL, CAST(0 AS bit), N''30DAC99F-98B0-4B0C-A224-55AEE16069D5'', N''Control Panel'', N''SERVERLAND'', N''00001'', N''SYS'', N''1 Admin Way'', CAST(0 AS bit), N''admin@example.com'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AccessFailedCount', N'ConcurrencyStamp', N'DateRegistered', N'Email', N'EmailConfirmed', N'FirstName', N'LastName', N'LockoutEnabled', N'LockoutEnd', N'NormalizedEmail', N'NormalizedUserName', N'PasswordHash', N'PhoneNumber', N'PhoneNumberConfirmed', N'SecurityStamp', N'ShippingAddressCity', N'ShippingAddressCountry', N'ShippingAddressPostalCode', N'ShippingAddressState', N'ShippingAddressStreet', N'TwoFactorEnabled', N'UserName') AND [object_id] = OBJECT_ID(N'[AspNetUsers]'))
        SET IDENTITY_INSERT [AspNetUsers] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250613165226_shippingCartItem_Updated'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Description', N'Name') AND [object_id] = OBJECT_ID(N'[Categories]'))
        SET IDENTITY_INSERT [Categories] ON;
    EXEC(N'INSERT INTO [Categories] ([Id], [Description], [Name])
    VALUES (''46357b0b-5a1c-4fa7-aecc-ad8cd80b060b'', N''Gadgets, devices, and more.'', N''Electronics''),
    (''f4d659ae-995a-4519-add9-e839052b51d1'', N''Clothing for all occasions.'', N''Apparel''),
    (''f81be342-0ef1-4822-8fae-c2c13377be76'', N''Fiction, non-fiction, and educational.'', N''Books'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Description', N'Name') AND [object_id] = OBJECT_ID(N'[Categories]'))
        SET IDENTITY_INSERT [Categories] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250613165226_shippingCartItem_Updated'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'RoleId', N'UserId') AND [object_id] = OBJECT_ID(N'[AspNetUserRoles]'))
        SET IDENTITY_INSERT [AspNetUserRoles] ON;
    EXEC(N'INSERT INTO [AspNetUserRoles] ([RoleId], [UserId])
    VALUES (''3e860fe9-f0e9-4b51-9061-2d051fe48911'', ''32131d27-4858-4e27-9ee7-f780cbc947a1''),
    (''3e860fe9-f0e9-4b51-9061-2d051fe48911'', ''7b70dd23-2a99-4c84-a5f2-a0a9ca8614b9''),
    (''846ff114-dfc6-451d-925f-5dcfea457c8a'', ''9bdbb0b3-1cb9-4c3f-8ca6-6d0b1d1ed7fb'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'RoleId', N'UserId') AND [object_id] = OBJECT_ID(N'[AspNetUserRoles]'))
        SET IDENTITY_INSERT [AspNetUserRoles] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250613165226_shippingCartItem_Updated'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ApplicationUserId', N'OrderDate', N'PaymentTransactionId', N'ShippingAddressCity', N'ShippingAddressCountry', N'ShippingAddressPostalCode', N'ShippingAddressState', N'ShippingAddressStreet', N'Status', N'TotalAmount', N'UserId') AND [object_id] = OBJECT_ID(N'[Orders]'))
        SET IDENTITY_INSERT [Orders] ON;
    EXEC(N'INSERT INTO [Orders] ([Id], [ApplicationUserId], [OrderDate], [PaymentTransactionId], [ShippingAddressCity], [ShippingAddressCountry], [ShippingAddressPostalCode], [ShippingAddressState], [ShippingAddressStreet], [Status], [TotalAmount], [UserId])
    VALUES (''2bf06f55-c94c-4df3-a512-06def363df93'', NULL, ''2025-06-06T16:52:25.5382134Z'', N''txn_alice_123seed'', N''Anytown'', N''USA'', N''90210'', N''CA'', N''123 Main St'', 3, 199.99, ''32131d27-4858-4e27-9ee7-f780cbc947a1''),
    (''8701c5d2-d44c-44b5-94cb-99769205f2c2'', NULL, ''2025-06-10T16:52:25.5382367Z'', N''txn_bob_456seed'', N''Otherville'', N''USA'', N''10001'', N''NY'', N''456 Oak Ave'', 2, 539.4, ''7b70dd23-2a99-4c84-a5f2-a0a9ca8614b9'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ApplicationUserId', N'OrderDate', N'PaymentTransactionId', N'ShippingAddressCity', N'ShippingAddressCountry', N'ShippingAddressPostalCode', N'ShippingAddressState', N'ShippingAddressStreet', N'Status', N'TotalAmount', N'UserId') AND [object_id] = OBJECT_ID(N'[Orders]'))
        SET IDENTITY_INSERT [Orders] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250613165226_shippingCartItem_Updated'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CategoryId', N'DateCreated', N'Description', N'ImageUrl', N'IsAvailable', N'Name', N'Price', N'Sku', N'StockQuantity') AND [object_id] = OBJECT_ID(N'[Products]'))
        SET IDENTITY_INSERT [Products] ON;
    EXEC(N'INSERT INTO [Products] ([Id], [CategoryId], [DateCreated], [Description], [ImageUrl], [IsAvailable], [Name], [Price], [Sku], [StockQuantity])
    VALUES (''1e8a8c5d-e047-41fc-a467-082f23888c3b'', ''f4d659ae-995a-4519-add9-e839052b51d1'', ''2025-06-03T16:52:25.5381665Z'', N''Light and airy, perfect for summer.'', N''/images/products/dress-women.jpg'', CAST(0 AS bit), N''Women''''s Summer Dress'', 45.0, N''APRL-DRESS-001'', 75),
    (''21d5bf39-8e23-448a-a8b6-9f286f54a8dc'', ''f4d659ae-995a-4519-add9-e839052b51d1'', ''2025-05-29T16:52:25.5381651Z'', N''Comfortable and stylish.'', N''/images/products/tshirt-men.jpg'', CAST(1 AS bit), N''Men''''s Classic Cotton T-Shirt'', 19.95, N''APRL-TSHRT-001'', 200),
    (''7c320f12-432c-4f76-83ed-42b6c8734526'', ''f81be342-0ef1-4822-8fae-c2c13377be76'', ''2025-05-24T16:52:25.5381647Z'', N''Three bestselling sci-fi novels.'', N''/images/products/scifi-books.jpg'', CAST(1 AS bit), N''The Sci-Fi Novel Collection'', 29.99, N''BOOK-SCIFI-001'', 100),
    (''91cbd587-60ab-4805-9faa-5037c1c94b4c'', ''46357b0b-5a1c-4fa7-aecc-ad8cd80b060b'', ''2025-05-19T16:52:25.5381643Z'', N''Vibrant colors, smart features.'', N''/images/products/smart-tv.jpg'', CAST(1 AS bit), N''Smart LED TV 55-inch'', 499.5, N''ELEC-TV-002'', 25),
    (''96328a9a-b2dc-4b2e-bc6c-b1c98c925bc1'', ''46357b0b-5a1c-4fa7-aecc-ad8cd80b060b'', ''2025-05-14T16:52:25.5381634Z'', N''Immerse yourself in sound.'', N''/images/products/headphones.jpg'', CAST(1 AS bit), N''Wireless Noise-Cancelling Headphones'', 199.99, N''ELEC-HDPH-001'', 50)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CategoryId', N'DateCreated', N'Description', N'ImageUrl', N'IsAvailable', N'Name', N'Price', N'Sku', N'StockQuantity') AND [object_id] = OBJECT_ID(N'[Products]'))
        SET IDENTITY_INSERT [Products] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250613165226_shippingCartItem_Updated'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'OrderId', N'ProductId', N'Quantity', N'UnitPriceAtPurchase') AND [object_id] = OBJECT_ID(N'[OrderItems]'))
        SET IDENTITY_INSERT [OrderItems] ON;
    EXEC(N'INSERT INTO [OrderItems] ([Id], [OrderId], [ProductId], [Quantity], [UnitPriceAtPurchase])
    VALUES (''12da3143-03e9-4769-9285-696e263e2637'', ''8701c5d2-d44c-44b5-94cb-99769205f2c2'', ''21d5bf39-8e23-448a-a8b6-9f286f54a8dc'', 2, 19.95),
    (''7bd6cca9-1b58-481f-bac5-6027a2a79de8'', ''2bf06f55-c94c-4df3-a512-06def363df93'', ''96328a9a-b2dc-4b2e-bc6c-b1c98c925bc1'', 1, 199.99),
    (''da57d8bf-f5b6-43e7-b4bb-03b183c89750'', ''8701c5d2-d44c-44b5-94cb-99769205f2c2'', ''91cbd587-60ab-4805-9faa-5037c1c94b4c'', 1, 499.5)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'OrderId', N'ProductId', N'Quantity', N'UnitPriceAtPurchase') AND [object_id] = OBJECT_ID(N'[OrderItems]'))
        SET IDENTITY_INSERT [OrderItems] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250613165226_shippingCartItem_Updated'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ApplicationUserId', N'DateAdded', N'ProductId', N'Quantity', N'SessionId', N'UserId') AND [object_id] = OBJECT_ID(N'[ShoppingCartItems]'))
        SET IDENTITY_INSERT [ShoppingCartItems] ON;
    EXEC(N'INSERT INTO [ShoppingCartItems] ([Id], [ApplicationUserId], [DateAdded], [ProductId], [Quantity], [SessionId], [UserId])
    VALUES (''c9ccdb89-0c06-43f0-97c6-adb8d46a947f'', NULL, ''2025-06-12T16:52:25.5381901Z'', ''21d5bf39-8e23-448a-a8b6-9f286f54a8dc'', 2, NULL, ''32131d27-4858-4e27-9ee7-f780cbc947a1''),
    (''d3318fdc-a53c-430e-8084-b151a0a2dab2'', NULL, ''2025-06-13T11:52:25.5381997Z'', ''7c320f12-432c-4f76-83ed-42b6c8734526'', 1, NULL, ''7b70dd23-2a99-4c84-a5f2-a0a9ca8614b9''),
    (''eac78da5-4a05-4ac7-aaaa-b4da8d8a84be'', NULL, ''2025-06-11T16:52:25.5381882Z'', ''96328a9a-b2dc-4b2e-bc6c-b1c98c925bc1'', 1, NULL, ''32131d27-4858-4e27-9ee7-f780cbc947a1'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ApplicationUserId', N'DateAdded', N'ProductId', N'Quantity', N'SessionId', N'UserId') AND [object_id] = OBJECT_ID(N'[ShoppingCartItems]'))
        SET IDENTITY_INSERT [ShoppingCartItems] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250613165226_shippingCartItem_Updated'
)
BEGIN
    CREATE INDEX [IX_ShoppingCartItems_ApplicationUserId] ON [ShoppingCartItems] ([ApplicationUserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250613165226_shippingCartItem_Updated'
)
BEGIN
    CREATE INDEX [IX_Orders_ApplicationUserId] ON [Orders] ([ApplicationUserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250613165226_shippingCartItem_Updated'
)
BEGIN
    ALTER TABLE [Orders] ADD CONSTRAINT [FK_Orders_AspNetUsers_ApplicationUserId] FOREIGN KEY ([ApplicationUserId]) REFERENCES [AspNetUsers] ([Id]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250613165226_shippingCartItem_Updated'
)
BEGIN
    ALTER TABLE [ShoppingCartItems] ADD CONSTRAINT [FK_ShoppingCartItems_AspNetUsers_ApplicationUserId] FOREIGN KEY ([ApplicationUserId]) REFERENCES [AspNetUsers] ([Id]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250613165226_shippingCartItem_Updated'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20250613165226_shippingCartItem_Updated', N'8.0.6');
END;
GO

COMMIT;
GO

