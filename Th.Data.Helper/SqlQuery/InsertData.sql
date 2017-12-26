INSERT INTO [dbo].[AspNetRoles] ([Id], [ConcurrencyStamp], [Description], [Name], [NormalizedName]) VALUES (N'38b8cd92-ab18-4210-9cd3-d19ce656005d', N'13198112-776c-45f8-bf93-cefc1aef8703', N'Normal user.', N'Users', N'USERS')
INSERT INTO [dbo].[AspNetRoles] ([Id], [ConcurrencyStamp], [Description], [Name], [NormalizedName]) VALUES (N'5886f9e8-1251-476d-b009-24c1f75a12a5', N'01b3822e-639d-4309-b354-e406fc6ed8b1', N'Administrator group.', N'Administrators', N'ADMINISTRATORS')

INSERT INTO [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [DateOfBirth], [Email], [EmailConfirmed], [FirstName], [FullName], [LastName], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName]) VALUES (N'7a817bb5-b935-4c51-8559-0560edd630a8', 0, N'a44f1e4e-789d-42a1-ae06-8ff2184ff5b4', N'2017-10-30 14:45:27', N'admin@gmail.com', 0, NULL, N'Administrator', NULL, 1, NULL, N'ADMIN@GMAIL.COM', N'ADMIN', N'AQAAAAEAACcQAAAAECd0DABT+zamx1xeSqeW5FRpOwyOqR2SseMirDWze4VapQ+mVyuSMVSsmp7LrMWwbA==', NULL, 0, N'64224f30-f7a5-406e-9a70-82fddc6a92ce', 0, N'Admin')
INSERT INTO [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [DateOfBirth], [Email], [EmailConfirmed], [FirstName], [FullName], [LastName], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName]) VALUES (N'8e78b0b8-ceb7-4c30-8b0c-6147b4ce42da', 0, N'0783bd68-910e-476a-afd6-a396303e62d9', N'2017-10-30 00:00:00', N'hgt1981@yahoo.com', 0, NULL, N'Huỳnh Gia Trung', NULL, 1, NULL, N'HGT1981@YAHOO.COM', N'HGT', N'AQAAAAEAACcQAAAAEFGVyyy8AwfjPJAbkI8cE+gPTAaYgYG72B0lycYjc1T60U9aIe+bqc1P9wnBX8Id1w==', NULL, 0, N'5968f806-8e29-4728-826b-83137780a35f', 0, N'hgt')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'8e78b0b8-ceb7-4c30-8b0c-6147b4ce42da', N'38b8cd92-ab18-4210-9cd3-d19ce656005d')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'7a817bb5-b935-4c51-8559-0560edd630a8', N'5886f9e8-1251-476d-b009-24c1f75a12a5')

SET IDENTITY_INSERT [dbo].[Countries] ON
INSERT INTO [dbo].[Countries] ([Id], [Name]) VALUES (1, N'Việt Nam')
SET IDENTITY_INSERT [dbo].[Countries] OFF

SET IDENTITY_INSERT [dbo].[Cities] ON
INSERT INTO [dbo].[Cities] ([Id], [CountryId], [Name]) VALUES (1, 1, N'Hồ Chí Minh')
INSERT INTO [dbo].[Cities] ([Id], [CountryId], [Name]) VALUES (2, 1, N'Sóc Trăng')
INSERT INTO [dbo].[Cities] ([Id], [CountryId], [Name]) VALUES (3, 1, N'Vĩnh Long')
INSERT INTO [dbo].[Cities] ([Id], [CountryId], [Name]) VALUES (4, 1, N'Long An')
INSERT INTO [dbo].[Cities] ([Id], [CountryId], [Name]) VALUES (5, 1, N'Tiền Giang')
INSERT INTO [dbo].[Cities] ([Id], [CountryId], [Name]) VALUES (6, 1, N'Tây Ninh')
INSERT INTO [dbo].[Cities] ([Id], [CountryId], [Name]) VALUES (7, 1, N'Trà Vinh')
INSERT INTO [dbo].[Cities] ([Id], [CountryId], [Name]) VALUES (8, 1, N'Cần Thơ')
INSERT INTO [dbo].[Cities] ([Id], [CountryId], [Name]) VALUES (9, 1, N'Bến Tre')
INSERT INTO [dbo].[Cities] ([Id], [CountryId], [Name]) VALUES (10, 1, N'Bạc Liêu')
INSERT INTO [dbo].[Cities] ([Id], [CountryId], [Name]) VALUES (11, 1, N'Cà Mau')
INSERT INTO [dbo].[Cities] ([Id], [CountryId], [Name]) VALUES (12, 1, N'Hậu Giang')
SET IDENTITY_INSERT [dbo].[Cities] OFF


SET IDENTITY_INSERT [dbo].[Categories] ON
INSERT INTO [dbo].[Categories] ([Id], [Name], [NameVn], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (1, N'Electronic', N'Điện Tử', NULL, NULL, NULL, NULL)
INSERT INTO [dbo].[Categories] ([Id], [Name], [NameVn], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (2, N'Household appliance', N'Điện gia dụng', NULL, NULL, NULL, NULL)
INSERT INTO [dbo].[Categories] ([Id], [Name], [NameVn], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (3, N'Smartphone', N'Điện thoại', NULL, NULL, NULL, NULL)
INSERT INTO [dbo].[Categories] ([Id], [Name], [NameVn], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate]) VALUES (4, N'Television', N'Tivi', N'Admin', N'2017-11-23 07:25:25', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Categories] OFF


INSERT INTO [dbo].[Suppliers] ([Id], [Email], [Logo], [Name], [Phone]) VALUES (N'e34f4e8f-773e-4f83-bc70-3568248c8d6e', N'hgt1981@yahoo.com', N'', N'Huỳnh Gia Trung', N'0981663291')

SET IDENTITY_INSERT [dbo].[Products] ON
INSERT INTO [dbo].[Products] ([Id], [CategoryId], [Description], [Image], [Name], [SupplierId], [UnitPrice]) VALUES (1, 1, N'Samsung Note 9', N'0113b9eb207730a79986d7506c9c5972cb579e726f.jpg', N'Samsung Note 9', N'e34f4e8f-773e-4f83-bc70-3568248c8d6e', CAST(23000000.00 AS Decimal(18, 2)))
INSERT INTO [dbo].[Products] ([Id], [CategoryId], [Description], [Image], [Name], [SupplierId], [UnitPrice]) VALUES (2, 1, N'iPhone X là một điện thoại thông minh được Apple Inc. thiết kế, phát triển và đưaa ra thị truờng.
Thiết kế sang trọng cùng với việc hoàn thiện hai mặt kính hoàn hảo.
', N'iPhoneX.jpg', N'iPhone X', N'e34f4e8f-773e-4f83-bc70-3568248c8d6e', CAST(43000000.00 AS Decimal(18, 2)))
INSERT INTO [dbo].[Products] ([Id], [CategoryId], [Description], [Image], [Name], [SupplierId], [UnitPrice]) VALUES (3, 1, N'Sử dụng chất liệu nhôm kết hợp kính toát lên vẻ đẹp sang trọng, quyến rũ.', N'iPhoneX-Silver.jpg', N'iPhone X Bạc', N'e34f4e8f-773e-4f83-bc70-3568248c8d6e', CAST(43000000.00 AS Decimal(18, 2)))
INSERT INTO [dbo].[Products] ([Id], [CategoryId], [Description], [Image], [Name], [SupplierId], [UnitPrice]) VALUES (4, 1, N'Sony Xperia X Compact Black
', N'xperia-x-compact-black-D1-hero.png', N'Sony Xperia X Compact Black', N'e34f4e8f-773e-4f83-bc70-3568248c8d6e', CAST(1300000.00 AS Decimal(18, 2)))
INSERT INTO [dbo].[Products] ([Id], [CategoryId], [Description], [Image], [Name], [SupplierId], [UnitPrice]) VALUES (5, 1, N'Sony Xperia XZ1
Trình tạo ảnh 3D sáng tạo trên Xperia™ XZ1, cùng với màn hình HDR, Motion Eye™ và chất luợnng âm thanh vượt trội, mở ra thế giới giải trí mới.
- Quay video chuyển động siêu chậm.
- Chụp ảnh có dự đoán.
- Chụp liên tục tự động lấy nét.
', N'sony-xperia-xz1.jpg', N'Sony Xperia XZ1', N'e34f4e8f-773e-4f83-bc70-3568248c8d6e', CAST(15990000.00 AS Decimal(18, 2)))
INSERT INTO [dbo].[Products] ([Id], [CategoryId], [Description], [Image], [Name], [SupplierId], [UnitPrice]) VALUES (6, 1, N'Samsung Note 8', N'galaxy-note8-midnight-black.jpg', N'Samsung Note 8', N'e34f4e8f-773e-4f83-bc70-3568248c8d6e', CAST(23000000.00 AS Decimal(18, 2)))
INSERT INTO [dbo].[Products] ([Id], [CategoryId], [Description], [Image], [Name], [SupplierId], [UnitPrice]) VALUES (7, 1, N'Samsung Note 7', N'galaxy-note7-midnight-black.jpg', N'Samsung Note 7', N'e34f4e8f-773e-4f83-bc70-3568248c8d6e', CAST(10000000.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Products] OFF

SET IDENTITY_INSERT [dbo].[Orders] ON
INSERT INTO [dbo].[Orders] ([OrderId], [CityId], [IsShipped], [OrderDate], [ShipAddress], [UserId]) VALUES (1, 1, 0, N'2017-11-11 10:31:12', N'29, đường 3643A, Phạm Thế Hiển P.7, Q.8', NULL)
INSERT INTO [dbo].[Orders] ([OrderId], [CityId], [IsShipped], [OrderDate], [ShipAddress], [UserId]) VALUES (2, 1, 0, N'2017-11-11 10:37:17', N'29, đường 3643A, Phạm Thế Hiển P.7, Q.8', NULL)
INSERT INTO [dbo].[Orders] ([OrderId], [CityId], [IsShipped], [OrderDate], [ShipAddress], [UserId]) VALUES (3, 1, 0, N'2017-11-11 10:39:09', N'29, đường 3643A, Phạm Thế Hiển P.7, Q.8', NULL)
SET IDENTITY_INSERT [dbo].[Orders] OFF

SET IDENTITY_INSERT [dbo].[OrderDetails] ON
INSERT INTO [dbo].[OrderDetails] ([OrderDetailId], [OrderId], [Price], [ProductId], [Quantity], [SubTotal]) VALUES (1, 1, CAST(23000000.00 AS Decimal(18, 2)), 1, CAST(1.00 AS Decimal(18, 2)), CAST(23000000.00 AS Decimal(18, 2)))
INSERT INTO [dbo].[OrderDetails] ([OrderDetailId], [OrderId], [Price], [ProductId], [Quantity], [SubTotal]) VALUES (2, 1, CAST(1300000.00 AS Decimal(18, 2)), 4, CAST(1.00 AS Decimal(18, 2)), CAST(1300000.00 AS Decimal(18, 2)))
INSERT INTO [dbo].[OrderDetails] ([OrderDetailId], [OrderId], [Price], [ProductId], [Quantity], [SubTotal]) VALUES (1002, 2, CAST(43000000.00 AS Decimal(18, 2)), 2, CAST(1.00 AS Decimal(18, 2)), CAST(43000000.00 AS Decimal(18, 2)))
INSERT INTO [dbo].[OrderDetails] ([OrderDetailId], [OrderId], [Price], [ProductId], [Quantity], [SubTotal]) VALUES (1003, 3, CAST(43000000.00 AS Decimal(18, 2)), 3, CAST(1.00 AS Decimal(18, 2)), CAST(43000000.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[OrderDetails] OFF
