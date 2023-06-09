USE [FoodToGo]
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Username], [Salt], [Password], [Role], [PhoneNumber], [Email]) VALUES (1, N'admin', N'OrfFAGuOcvucVn0smdS0ocRSwrw2RBZKZY09lYsa51s=', N'M1PidK1hA2qX3cfz7+wnwZy4Cgs=', N'Admin', N'0938889999', N'admin@gmail.com')
INSERT [dbo].[Users] ([Id], [Username], [Salt], [Password], [Role], [PhoneNumber], [Email]) VALUES (2, N'merchant1', N'OG1bDlkl7Nxaia5Znu8Za0WYTBfMCOIvtQckLgDs6dE=', N'EONe65eDPx6rFTK+ImiI9U+F9ys=', N'User', N'0923567243', N'merchant1@gmail.com')
INSERT [dbo].[Users] ([Id], [Username], [Salt], [Password], [Role], [PhoneNumber], [Email]) VALUES (3, N'merchant2', N'mhOmycYdaYvJ50IHao/qU4a5FzcwoYkR3n/GbbpMR+8=', N'Ib82lLB32eu+BlC2EDzpGvPWmzI=', N'User', N'0934407755', N'merchant2@gmail.com')
INSERT [dbo].[Users] ([Id], [Username], [Salt], [Password], [Role], [PhoneNumber], [Email]) VALUES (4, N'merchant3', N'4MzlReNa2GToZlU6aoiwJIkGIASvbz905WDxaHSY8pw=', N'B+E57NxGUFejK5JlsHZDzfQUOj8=', N'User', N'0928884545', N'merchant3@gmail.com')
INSERT [dbo].[Users] ([Id], [Username], [Salt], [Password], [Role], [PhoneNumber], [Email]) VALUES (5, N'merchant4', N'L/CmQOGEk5zhBUBZiJ/CngrjZgqY6sxCk4rL42527fM=', N'qv46DeFzAOwPXNnZ/2JcR3fmuuw=', N'User', N'0925654343', N'merchant4@gmail.com')
INSERT [dbo].[Users] ([Id], [Username], [Salt], [Password], [Role], [PhoneNumber], [Email]) VALUES (6, N'customer1', N'PVdBeXciZXE11U1CrUbTuRP+Sb7815UhfsVsegMROcI=', N'hAHqLIvj9/mVY9rkMnwA3pDBHcU=', N'User', N'0925638241', N'customer1@gmail.com')
INSERT [dbo].[Users] ([Id], [Username], [Salt], [Password], [Role], [PhoneNumber], [Email]) VALUES (7, N'customer2', N'yn/cyiM/36mJMXWL8CyE2MilFeuK+Axv/FnJJcFQRRc=', N'z05X4UIyD1LcjpFlXBHUK3N4SCI=', N'User', N'0923458633', N'customer2@gmail.com')
INSERT [dbo].[Users] ([Id], [Username], [Salt], [Password], [Role], [PhoneNumber], [Email]) VALUES (8, N'shipper1', N'lFFrKKUycchVerYoc9CRmgF9L6Uj/KtM0atACv98gjY=', N'C4DeNbBpxRAx+Ney1DKTSWHxQ04=', N'User', N'0925658324', N'shipper1@gmail.com')
INSERT [dbo].[Users] ([Id], [Username], [Salt], [Password], [Role], [PhoneNumber], [Email]) VALUES (9, N'shipper2', N'C3HXolvEvFgt8Q5QBO9EeYgDEU3T6cB+a8CFDnWTzFk=', N'3Eo4J1EgyvoaCpebnhdCgdWKAwI=', N'User', N'0962385476', N'shipper2@gmail.com')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
INSERT [dbo].[Customers] ([CustomerId], [FirstName], [LastName], [MiddleName], [Address], [Rating]) VALUES (6, N'Nguyen', N'Minh', N'Ngoc', N'28 Đ. Lê Lợi, Bến Nghé, Quận 1, Thành phố Hồ Chí Minh, Vietnam', 3.9)
INSERT [dbo].[Customers] ([CustomerId], [FirstName], [LastName], [MiddleName], [Address], [Rating]) VALUES (7, N'Nguyen', N'Mai', N'Thi', N'71 Lý Tự Trọng, Khu phố 6, Quận 1, Thành phố Hồ Chí Minh, Vietnam', 0)
GO
INSERT [dbo].[OnlineCustomerLocations] ([CustomerId], [GeoLatitude], [GeoLongitude]) VALUES (6, 10.760935, 106.689395)
GO
SET IDENTITY_INSERT [dbo].[Merchants] ON 

INSERT [dbo].[Merchants] ([MerchantId], [UserId], [Name], [Address], [PhoneNumber], [GeoLatitude], [GeoLongitude], [IsDeleted], [Rating]) VALUES (1, 2, N'Vee Ayy Food', N'345/84 Đ. Trần Hưng Đạo, Cầu Kho, Quận 1, Thành phố Hồ Chí Minh, Vietnam', N'0913536683', 10.7609493, 106.6893029, 0, 4)
INSERT [dbo].[Merchants] ([MerchantId], [UserId], [Name], [Address], [PhoneNumber], [GeoLatitude], [GeoLongitude], [IsDeleted], [Rating]) VALUES (2, 2, N'Miya Sushi & BBQ', N'210Tes Đ. Nguyễn Trãi, Phường Phạm Ngũ Lão, Quận 1, Thành phố Hồ Chí Minh, Vietnam', N'0909347544', 10.7669315, 106.6883291, 0, 4.3)
INSERT [dbo].[Merchants] ([MerchantId], [UserId], [Name], [Address], [PhoneNumber], [GeoLatitude], [GeoLongitude], [IsDeleted], [Rating]) VALUES (3, 2, N'Bento Dino', N'134/3/1 Đ. Bùi Thị Xuân, Phường Phạm Ngũ Lão, Quận 1, Thành phố Hồ Chí Minh, Vietnam', N'0903384231', 10.769914, 106.687573, 0, 4.7)
INSERT [dbo].[Merchants] ([MerchantId], [UserId], [Name], [Address], [PhoneNumber], [GeoLatitude], [GeoLongitude], [IsDeleted], [Rating]) VALUES (4, 3, N'Juice Time - Quan 5', N'118 Đ. An D. Vương, Phường 9, Quận 5, Thành phố Hồ Chí Minh, Vietnam', N'0922324548', 10.7567696, 106.6689003, 0, 3.25)
INSERT [dbo].[Merchants] ([MerchantId], [UserId], [Name], [Address], [PhoneNumber], [GeoLatitude], [GeoLongitude], [IsDeleted], [Rating]) VALUES (5, 3, N'Che Thai Thao - Quan 8', N'722 Đ. Hưng Phú, Phường 10, Quận 8, Thành phố Hồ Chí Minh, Vietnam', N'0924541784', 10.7459338, 106.6666309, 0, 3)
INSERT [dbo].[Merchants] ([MerchantId], [UserId], [Name], [Address], [PhoneNumber], [GeoLatitude], [GeoLongitude], [IsDeleted], [Rating]) VALUES (6, 3, N'Quan Lau Van Hao - Quan 5', N'411 Đ. Nguyễn Chí Thanh, Phường 15, Quận 5, Thành phố Hồ Chí Minh, Vietnam', N'095368952', 10.7564651, 106.6527322, 0, 4.8)
INSERT [dbo].[Merchants] ([MerchantId], [UserId], [Name], [Address], [PhoneNumber], [GeoLatitude], [GeoLongitude], [IsDeleted], [Rating]) VALUES (8, 3, N'test', N'QPG2+757, Bến Nghé, District 1, Ho Chi Minh City, Vietnam', N'09253689253', 10.7756583, 106.7004233, 0, 3.6)
SET IDENTITY_INSERT [dbo].[Merchants] OFF
GO
SET IDENTITY_INSERT [dbo].[Promotions] ON 

INSERT [dbo].[Promotions] ([Id], [DiscountCreatorMerchantId], [Name], [DiscountPercentage], [DiscountAmount], [CreatedDate], [StartDate], [EndDate], [Quantity], [QuantityLeft], [Description]) VALUES (1, 1, N'Vee Ayy Food - June Discount', 10, 5.0000, CAST(N'2023-06-22T19:34:38.4922021' AS DateTime2), CAST(N'2023-06-20T00:00:00.0000000' AS DateTime2), CAST(N'2023-06-30T00:00:00.0000000' AS DateTime2), 20, 17, N'')
INSERT [dbo].[Promotions] ([Id], [DiscountCreatorMerchantId], [Name], [DiscountPercentage], [DiscountAmount], [CreatedDate], [StartDate], [EndDate], [Quantity], [QuantityLeft], [Description]) VALUES (4, 1, N'Vee Ayy Food - July Discount', 10, 5.0000, CAST(N'2023-06-20T15:25:32.8914985' AS DateTime2), CAST(N'2023-07-01T00:00:00.0000000' AS DateTime2), CAST(N'2023-07-31T00:00:00.0000000' AS DateTime2), 100, 100, N'July Discount 10% - max 5$')
INSERT [dbo].[Promotions] ([Id], [DiscountCreatorMerchantId], [Name], [DiscountPercentage], [DiscountAmount], [CreatedDate], [StartDate], [EndDate], [Quantity], [QuantityLeft], [Description]) VALUES (5, 5, N'Che Thai Thao - May Discount', 10, 2.0000, CAST(N'2023-06-20T16:17:36.3700826' AS DateTime2), CAST(N'2023-05-01T00:00:00.0000000' AS DateTime2), CAST(N'2023-05-20T00:00:00.0000000' AS DateTime2), 20, 20, N'May Discount - 10 %')
INSERT [dbo].[Promotions] ([Id], [DiscountCreatorMerchantId], [Name], [DiscountPercentage], [DiscountAmount], [CreatedDate], [StartDate], [EndDate], [Quantity], [QuantityLeft], [Description]) VALUES (6, 4, N'Juice Time - June Discount', 10, 3.0000, CAST(N'2023-06-20T16:22:56.2836704' AS DateTime2), CAST(N'2023-06-20T00:00:00.0000000' AS DateTime2), CAST(N'2023-06-30T00:00:00.0000000' AS DateTime2), 15, 15, N'June Discount - 10%')
INSERT [dbo].[Promotions] ([Id], [DiscountCreatorMerchantId], [Name], [DiscountPercentage], [DiscountAmount], [CreatedDate], [StartDate], [EndDate], [Quantity], [QuantityLeft], [Description]) VALUES (7, 4, N'Juice Time - July Discount', 20, 5.0000, CAST(N'2023-06-20T16:23:59.9019788' AS DateTime2), CAST(N'2023-07-01T00:00:00.0000000' AS DateTime2), CAST(N'2023-07-31T00:00:00.0000000' AS DateTime2), 40, 40, N'20% - 5')
INSERT [dbo].[Promotions] ([Id], [DiscountCreatorMerchantId], [Name], [DiscountPercentage], [DiscountAmount], [CreatedDate], [StartDate], [EndDate], [Quantity], [QuantityLeft], [Description]) VALUES (8, 4, N'Juice Time - May Discount', 15, 3.0000, CAST(N'2023-05-20T16:25:01.4879444' AS DateTime2), CAST(N'2023-05-20T00:00:00.0000000' AS DateTime2), CAST(N'2023-05-20T00:00:00.0000000' AS DateTime2), 50, 50, N'15% - 3')
SET IDENTITY_INSERT [dbo].[Promotions] OFF
GO
INSERT [dbo].[Shippers] ([UserId], [FirstName], [LastName], [MiddleName], [VehicleType], [VehicleNumberPlate], [Rating]) VALUES (8, N'Dang', N'Tin', N'Vu', N'AirBlade 125cc', N'51-T2 324.43', 0)
INSERT [dbo].[Shippers] ([UserId], [FirstName], [LastName], [MiddleName], [VehicleType], [VehicleNumberPlate], [Rating]) VALUES (9, N'Tran', N'Nam', N'Quy', N'Wave alpha', N'42-E4 324.52', 3.75)
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([Id], [MerchantId], [ShipperId], [CustomerId], [PromotionId], [PlacedTime], [ETA], [DeliveryCompletionTime], [OrderPrice], [ShippingFee], [AppFee], [PromotionDiscount], [Status], [CancellationReason], [cancelledBy], [DeliveryAddress], [DeliveryLatitude], [DeliveryLongitude]) VALUES (6, 1, NULL, 6, 1, CAST(N'2023-06-20T17:51:01.0770210' AS DateTime2), CAST(N'2023-06-20T00:23:00.0000000' AS DateTime2), NULL, 8.0000, 10.0000, 0.8000, 0.8000, N'cancelled', N'test', N'customer', N'QPG2+757, Bến Nghé, District 1, Ho Chi Minh City, Vietnam', 10.7756583, 106.7004233)
INSERT [dbo].[Orders] ([Id], [MerchantId], [ShipperId], [CustomerId], [PromotionId], [PlacedTime], [ETA], [DeliveryCompletionTime], [OrderPrice], [ShippingFee], [AppFee], [PromotionDiscount], [Status], [CancellationReason], [cancelledBy], [DeliveryAddress], [DeliveryLatitude], [DeliveryLongitude]) VALUES (7, 2, 9, 6, NULL, CAST(N'2023-06-21T14:42:03.4270650' AS DateTime2), CAST(N'2023-06-21T00:18:00.0000000' AS DateTime2), NULL, 38.0000, 5.0000, 3.8000, 0.0000, N'cancelled', N'Khong giao duoc', N'shipper', N'235 Đ. Nguyễn Văn Cừ, Phường Nguyễn Cư Trinh, Quận 1, Thành phố Hồ Chí Minh, Vietnam', 10.763055, 106.6830867)
INSERT [dbo].[Orders] ([Id], [MerchantId], [ShipperId], [CustomerId], [PromotionId], [PlacedTime], [ETA], [DeliveryCompletionTime], [OrderPrice], [ShippingFee], [AppFee], [PromotionDiscount], [Status], [CancellationReason], [cancelledBy], [DeliveryAddress], [DeliveryLatitude], [DeliveryLongitude]) VALUES (8, 4, 9, 6, NULL, CAST(N'2023-06-21T14:42:17.0598380' AS DateTime2), CAST(N'2023-06-21T00:22:00.0000000' AS DateTime2), NULL, 16.0000, 8.5000, 1.6000, 0.0000, N'cancelled', N'Cua hang dong', N'shipper', N'235 Đ. Nguyễn Văn Cừ, Phường Nguyễn Cư Trinh, Quận 1, Thành phố Hồ Chí Minh, Vietnam', 10.763055, 106.6830867)
INSERT [dbo].[Orders] ([Id], [MerchantId], [ShipperId], [CustomerId], [PromotionId], [PlacedTime], [ETA], [DeliveryCompletionTime], [OrderPrice], [ShippingFee], [AppFee], [PromotionDiscount], [Status], [CancellationReason], [cancelledBy], [DeliveryAddress], [DeliveryLatitude], [DeliveryLongitude]) VALUES (9, 1, 9, 6, 1, CAST(N'2023-06-21T14:42:36.4696030' AS DateTime2), CAST(N'2023-06-21T00:18:00.0000000' AS DateTime2), NULL, 40.5000, 5.0000, 4.1000, 4.0000, N'cancelled', N'Cua Hang het hang', N'shipper', N'235 Đ. Nguyễn Văn Cừ, Phường Nguyễn Cư Trinh, Quận 1, Thành phố Hồ Chí Minh, Vietnam', 10.763055, 106.6830867)
INSERT [dbo].[Orders] ([Id], [MerchantId], [ShipperId], [CustomerId], [PromotionId], [PlacedTime], [ETA], [DeliveryCompletionTime], [OrderPrice], [ShippingFee], [AppFee], [PromotionDiscount], [Status], [CancellationReason], [cancelledBy], [DeliveryAddress], [DeliveryLatitude], [DeliveryLongitude]) VALUES (10, 4, 9, 6, NULL, CAST(N'2023-06-21T20:51:08.4683020' AS DateTime2), CAST(N'2023-06-21T00:22:00.0000000' AS DateTime2), NULL, 6.5000, 8.5000, 0.7000, 0.0000, N'cancelled', N'Unable to deliver', N'shipper', N'235 Đ. Nguyễn Văn Cừ, Phường Nguyễn Cư Trinh, Quận 1, Thành phố Hồ Chí Minh, Vietnam', 10.763055, 106.6830867)
INSERT [dbo].[Orders] ([Id], [MerchantId], [ShipperId], [CustomerId], [PromotionId], [PlacedTime], [ETA], [DeliveryCompletionTime], [OrderPrice], [ShippingFee], [AppFee], [PromotionDiscount], [Status], [CancellationReason], [cancelledBy], [DeliveryAddress], [DeliveryLatitude], [DeliveryLongitude]) VALUES (11, 5, 8, 6, NULL, CAST(N'2023-06-21T20:51:26.4107490' AS DateTime2), CAST(N'2023-06-21T00:25:00.0000000' AS DateTime2), NULL, 9.0000, 13.0000, 0.9000, 0.0000, N'cancelled', N'out of order', N'shipper', N'235 Đ. Nguyễn Văn Cừ, Phường Nguyễn Cư Trinh, Quận 1, Thành phố Hồ Chí Minh, Vietnam', 10.763055, 106.6830867)
INSERT [dbo].[Orders] ([Id], [MerchantId], [ShipperId], [CustomerId], [PromotionId], [PlacedTime], [ETA], [DeliveryCompletionTime], [OrderPrice], [ShippingFee], [AppFee], [PromotionDiscount], [Status], [CancellationReason], [cancelledBy], [DeliveryAddress], [DeliveryLatitude], [DeliveryLongitude]) VALUES (12, 1, 8, 6, 1, CAST(N'2023-06-22T19:34:37.1792030' AS DateTime2), CAST(N'2023-06-22T00:18:00.0000000' AS DateTime2), NULL, 17.0000, 5.0000, 1.7000, 1.7000, N'delivering', N'', N'', N'Đối Diện 30 - 32 Lý Thái Tổ, phường 1, Quận 10, Thành phố Hồ Chí Minh, Vietnam', 10.765674448628495, 106.68067026883364)
INSERT [dbo].[Orders] ([Id], [MerchantId], [ShipperId], [CustomerId], [PromotionId], [PlacedTime], [ETA], [DeliveryCompletionTime], [OrderPrice], [ShippingFee], [AppFee], [PromotionDiscount], [Status], [CancellationReason], [cancelledBy], [DeliveryAddress], [DeliveryLatitude], [DeliveryLongitude]) VALUES (13, 5, 8, 6, NULL, CAST(N'2023-06-22T19:34:59.4274950' AS DateTime2), CAST(N'2023-06-22T00:25:00.0000000' AS DateTime2), NULL, 2.0000, 13.0000, 0.2000, 0.0000, N'cancelled', N'Cant deliver (test)', N'shipper', N'235 Đ. Nguyễn Văn Cừ, Phường Nguyễn Cư Trinh, Quận 1, Thành phố Hồ Chí Minh, Vietnam', 10.763055, 106.6830867)
INSERT [dbo].[Orders] ([Id], [MerchantId], [ShipperId], [CustomerId], [PromotionId], [PlacedTime], [ETA], [DeliveryCompletionTime], [OrderPrice], [ShippingFee], [AppFee], [PromotionDiscount], [Status], [CancellationReason], [cancelledBy], [DeliveryAddress], [DeliveryLatitude], [DeliveryLongitude]) VALUES (14, 2, NULL, 6, NULL, CAST(N'2023-07-02T20:08:19.8450620' AS DateTime2), CAST(N'2023-07-02T00:28:00.0000000' AS DateTime2), NULL, 19.0000, 16.5000, 1.9000, 0.0000, N'placed', N'', N'', N'722 Đ. Hưng Phú, Phường 10, Quận 8, Thành phố Hồ Chí Minh, Vietnam', 10.74592, 106.6666383)
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[MenuItemTypes] ON 

INSERT [dbo].[MenuItemTypes] ([Id], [Name]) VALUES (1, N'Main Courses')
INSERT [dbo].[MenuItemTypes] ([Id], [Name]) VALUES (2, N'Snacks')
INSERT [dbo].[MenuItemTypes] ([Id], [Name]) VALUES (3, N'Drinks')
SET IDENTITY_INSERT [dbo].[MenuItemTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[MenuItems] ON 

INSERT [dbo].[MenuItems] ([Id], [MerchantId], [ItemTypeId], [Name], [UnitPrice], [Description], [IsClosed], [Rating]) VALUES (1, 1, 1, N'Tom lac pho mai', 4.0000, N'Tom lac pho mai', 0, 4.1)
INSERT [dbo].[MenuItems] ([Id], [MerchantId], [ItemTypeId], [Name], [UnitPrice], [Description], [IsClosed], [Rating]) VALUES (2, 1, 1, N'Tom Chien Sot Mat Ong', 4.5000, N'Tom Chien Sot Mat Ong', 0, 3.5)
INSERT [dbo].[MenuItems] ([Id], [MerchantId], [ItemTypeId], [Name], [UnitPrice], [Description], [IsClosed], [Rating]) VALUES (3, 1, 1, N'Xiu mai - 1 phan', 2.5000, N'Xiu mai hap 1 phan', 0, 4.3)
INSERT [dbo].[MenuItems] ([Id], [MerchantId], [ItemTypeId], [Name], [UnitPrice], [Description], [IsClosed], [Rating]) VALUES (4, 1, 1, N'Banh Cuon Xa Xiu - 1 Phan', 3.5000, N'Banh Cuon Xa Xiu - 1 Phan', 1, 4.5)
INSERT [dbo].[MenuItems] ([Id], [MerchantId], [ItemTypeId], [Name], [UnitPrice], [Description], [IsClosed], [Rating]) VALUES (5, 1, 1, N'Ga Vong Pho Mai - 1 Phan', 5.0000, N'Ga Vong Pho Mai - 1 Phan', 1, 0)
INSERT [dbo].[MenuItems] ([Id], [MerchantId], [ItemTypeId], [Name], [UnitPrice], [Description], [IsClosed], [Rating]) VALUES (6, 1, 1, N'Canh Ga BBQ - 1 Phan', 6.2000, N'Canh Ga BBQ - 1 Phan', 0, 4.8)
INSERT [dbo].[MenuItems] ([Id], [MerchantId], [ItemTypeId], [Name], [UnitPrice], [Description], [IsClosed], [Rating]) VALUES (7, 1, 1, N'Com Chien Ca Man - 1 Phan', 5.5000, N'Com Chien Ca Man - 1 Phan', 0, 4.8)
INSERT [dbo].[MenuItems] ([Id], [MerchantId], [ItemTypeId], [Name], [UnitPrice], [Description], [IsClosed], [Rating]) VALUES (8, 2, 1, N'JP2 Banh Xeo Hai San', 6.0000, N'Banh Xeo Hai San - 1 Phan', 0, 4.9)
INSERT [dbo].[MenuItems] ([Id], [MerchantId], [ItemTypeId], [Name], [UnitPrice], [Description], [IsClosed], [Rating]) VALUES (9, 2, 1, N'JP1 Banh Xeo Thit Heo', 7.0000, N'Banh Xep Thit Heo', 0, 3.2)
INSERT [dbo].[MenuItems] ([Id], [MerchantId], [ItemTypeId], [Name], [UnitPrice], [Description], [IsClosed], [Rating]) VALUES (10, 3, 1, N'Com Trung Chien', 2.0000, N'Com Trung Chien', 0, 3.1)
INSERT [dbo].[MenuItems] ([Id], [MerchantId], [ItemTypeId], [Name], [UnitPrice], [Description], [IsClosed], [Rating]) VALUES (11, 3, 1, N'Com Bo Xao', 3.0000, N'Com Bo Xao', 0, 3.9)
INSERT [dbo].[MenuItems] ([Id], [MerchantId], [ItemTypeId], [Name], [UnitPrice], [Description], [IsClosed], [Rating]) VALUES (12, 3, 3, N'Coca Cola - 1 Chai', 1.0000, N'Coca Cola Chai', 0, 4.1)
INSERT [dbo].[MenuItems] ([Id], [MerchantId], [ItemTypeId], [Name], [UnitPrice], [Description], [IsClosed], [Rating]) VALUES (13, 3, 3, N'Coca Cola Light - 1 Lon', 1.0000, N'Coca Cola Light - 1 Lon', 0, 4)
INSERT [dbo].[MenuItems] ([Id], [MerchantId], [ItemTypeId], [Name], [UnitPrice], [Description], [IsClosed], [Rating]) VALUES (14, 3, 1, N'Com Chien Xu Sot Bo - 1 Phan', 3.0000, N'Com Chien Xu Sot Bo - 1 Phan', 0, 4.5)
INSERT [dbo].[MenuItems] ([Id], [MerchantId], [ItemTypeId], [Name], [UnitPrice], [Description], [IsClosed], [Rating]) VALUES (15, 4, 3, N'Tra Sua Pho Mai Tuoi - 1 Ly', 2.0000, N'Tra Sua Pho Mai Tuoi - 1 Ly', 0, 4.2)
INSERT [dbo].[MenuItems] ([Id], [MerchantId], [ItemTypeId], [Name], [UnitPrice], [Description], [IsClosed], [Rating]) VALUES (16, 4, 3, N'Tra Sua Dac Che', 2.5000, N'1 Ly', 0, 4.3)
INSERT [dbo].[MenuItems] ([Id], [MerchantId], [ItemTypeId], [Name], [UnitPrice], [Description], [IsClosed], [Rating]) VALUES (17, 4, 3, N'Ca Phe Da', 2.0000, N'1 Ly', 0, 4.1)
INSERT [dbo].[MenuItems] ([Id], [MerchantId], [ItemTypeId], [Name], [UnitPrice], [Description], [IsClosed], [Rating]) VALUES (18, 4, 3, N'Ca Phe Sua Da', 2.5000, N'1 Ly', 0, 4.2)
INSERT [dbo].[MenuItems] ([Id], [MerchantId], [ItemTypeId], [Name], [UnitPrice], [Description], [IsClosed], [Rating]) VALUES (19, 4, 3, N'Chanh Nha Dam', 2.0000, N'1 Ly', 0, 4.6)
INSERT [dbo].[MenuItems] ([Id], [MerchantId], [ItemTypeId], [Name], [UnitPrice], [Description], [IsClosed], [Rating]) VALUES (20, 6, 1, N'Lau Ga La E - Nho', 15.0000, N'2 Nguoi an', 0, 4.8)
INSERT [dbo].[MenuItems] ([Id], [MerchantId], [ItemTypeId], [Name], [UnitPrice], [Description], [IsClosed], [Rating]) VALUES (21, 6, 1, N'Lau Ga La E - Lon', 30.0000, N'6 Nguoi an', 0, 4.9)
INSERT [dbo].[MenuItems] ([Id], [MerchantId], [ItemTypeId], [Name], [UnitPrice], [Description], [IsClosed], [Rating]) VALUES (22, 6, 2, N'Dau Phong Rang', 2.0000, N'1 bich', 0, 3)
INSERT [dbo].[MenuItems] ([Id], [MerchantId], [ItemTypeId], [Name], [UnitPrice], [Description], [IsClosed], [Rating]) VALUES (23, 6, 2, N'Muc Say', 5.0000, N'1 bich', 0, 4.2)
INSERT [dbo].[MenuItems] ([Id], [MerchantId], [ItemTypeId], [Name], [UnitPrice], [Description], [IsClosed], [Rating]) VALUES (24, 6, 2, N'Snack Mix', 5.0000, N'1 Bich', 0, 4.9)
INSERT [dbo].[MenuItems] ([Id], [MerchantId], [ItemTypeId], [Name], [UnitPrice], [Description], [IsClosed], [Rating]) VALUES (25, 6, 2, N'Snack Khoai Tay', 2.0000, N'1 Bich', 0, 4.1)
INSERT [dbo].[MenuItems] ([Id], [MerchantId], [ItemTypeId], [Name], [UnitPrice], [Description], [IsClosed], [Rating]) VALUES (26, 5, 2, N'Che Thai', 3.0000, N'1 Ly', 0, 4.3)
INSERT [dbo].[MenuItems] ([Id], [MerchantId], [ItemTypeId], [Name], [UnitPrice], [Description], [IsClosed], [Rating]) VALUES (27, 5, 2, N'Nhan Nhuc', 3.0000, N'1 Ly', 0, 4.2)
INSERT [dbo].[MenuItems] ([Id], [MerchantId], [ItemTypeId], [Name], [UnitPrice], [Description], [IsClosed], [Rating]) VALUES (28, 5, 2, N'Che Dau Xanh Pho Tai', 2.0000, N'1 Ly', 0, 4)
INSERT [dbo].[MenuItems] ([Id], [MerchantId], [ItemTypeId], [Name], [UnitPrice], [Description], [IsClosed], [Rating]) VALUES (29, 5, 2, N'Che Vai', 2.0000, N'1 Ly', 0, 4.5)
INSERT [dbo].[MenuItems] ([Id], [MerchantId], [ItemTypeId], [Name], [UnitPrice], [Description], [IsClosed], [Rating]) VALUES (30, 5, 2, N'Suong Sa Hot Luu', 2.0000, N'1 Ly', 0, 4.9)
INSERT [dbo].[MenuItems] ([Id], [MerchantId], [ItemTypeId], [Name], [UnitPrice], [Description], [IsClosed], [Rating]) VALUES (31, 5, 2, N'Khuc Bach', 2.5000, N'1 Ly', 0, 4.7)
SET IDENTITY_INSERT [dbo].[MenuItems] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderDetails] ON 

INSERT [dbo].[OrderDetails] ([OrderId], [MenuItemId], [Quantity], [UnitPrice], [SpecialInstruction], [Id]) VALUES (6, 1, 2, 4.0000, NULL, 16)
INSERT [dbo].[OrderDetails] ([OrderId], [MenuItemId], [Quantity], [UnitPrice], [SpecialInstruction], [Id]) VALUES (7, 8, 4, 6.0000, NULL, 17)
INSERT [dbo].[OrderDetails] ([OrderId], [MenuItemId], [Quantity], [UnitPrice], [SpecialInstruction], [Id]) VALUES (7, 9, 2, 7.0000, NULL, 18)
INSERT [dbo].[OrderDetails] ([OrderId], [MenuItemId], [Quantity], [UnitPrice], [SpecialInstruction], [Id]) VALUES (8, 15, 3, 2.0000, NULL, 19)
INSERT [dbo].[OrderDetails] ([OrderId], [MenuItemId], [Quantity], [UnitPrice], [SpecialInstruction], [Id]) VALUES (8, 18, 2, 2.5000, NULL, 20)
INSERT [dbo].[OrderDetails] ([OrderId], [MenuItemId], [Quantity], [UnitPrice], [SpecialInstruction], [Id]) VALUES (8, 16, 2, 2.5000, NULL, 21)
INSERT [dbo].[OrderDetails] ([OrderId], [MenuItemId], [Quantity], [UnitPrice], [SpecialInstruction], [Id]) VALUES (9, 2, 2, 4.5000, NULL, 22)
INSERT [dbo].[OrderDetails] ([OrderId], [MenuItemId], [Quantity], [UnitPrice], [SpecialInstruction], [Id]) VALUES (9, 3, 3, 2.5000, NULL, 23)
INSERT [dbo].[OrderDetails] ([OrderId], [MenuItemId], [Quantity], [UnitPrice], [SpecialInstruction], [Id]) VALUES (9, 4, 2, 3.5000, NULL, 24)
INSERT [dbo].[OrderDetails] ([OrderId], [MenuItemId], [Quantity], [UnitPrice], [SpecialInstruction], [Id]) VALUES (9, 5, 1, 5.0000, NULL, 25)
INSERT [dbo].[OrderDetails] ([OrderId], [MenuItemId], [Quantity], [UnitPrice], [SpecialInstruction], [Id]) VALUES (9, 1, 3, 4.0000, NULL, 26)
INSERT [dbo].[OrderDetails] ([OrderId], [MenuItemId], [Quantity], [UnitPrice], [SpecialInstruction], [Id]) VALUES (10, 17, 1, 2.0000, NULL, 27)
INSERT [dbo].[OrderDetails] ([OrderId], [MenuItemId], [Quantity], [UnitPrice], [SpecialInstruction], [Id]) VALUES (10, 16, 1, 2.5000, NULL, 28)
INSERT [dbo].[OrderDetails] ([OrderId], [MenuItemId], [Quantity], [UnitPrice], [SpecialInstruction], [Id]) VALUES (10, 15, 1, 2.0000, NULL, 29)
INSERT [dbo].[OrderDetails] ([OrderId], [MenuItemId], [Quantity], [UnitPrice], [SpecialInstruction], [Id]) VALUES (11, 27, 1, 3.0000, NULL, 30)
INSERT [dbo].[OrderDetails] ([OrderId], [MenuItemId], [Quantity], [UnitPrice], [SpecialInstruction], [Id]) VALUES (11, 30, 3, 2.0000, NULL, 31)
INSERT [dbo].[OrderDetails] ([OrderId], [MenuItemId], [Quantity], [UnitPrice], [SpecialInstruction], [Id]) VALUES (12, 1, 2, 4.0000, NULL, 32)
INSERT [dbo].[OrderDetails] ([OrderId], [MenuItemId], [Quantity], [UnitPrice], [SpecialInstruction], [Id]) VALUES (12, 2, 2, 4.5000, NULL, 33)
INSERT [dbo].[OrderDetails] ([OrderId], [MenuItemId], [Quantity], [UnitPrice], [SpecialInstruction], [Id]) VALUES (13, 30, 1, 2.0000, NULL, 34)
INSERT [dbo].[OrderDetails] ([OrderId], [MenuItemId], [Quantity], [UnitPrice], [SpecialInstruction], [Id]) VALUES (14, 8, 2, 6.0000, NULL, 35)
INSERT [dbo].[OrderDetails] ([OrderId], [MenuItemId], [Quantity], [UnitPrice], [SpecialInstruction], [Id]) VALUES (14, 9, 1, 7.0000, NULL, 36)
SET IDENTITY_INSERT [dbo].[OrderDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[MenuItemImages] ON 

INSERT [dbo].[MenuItemImages] ([Id], [MenuItemId], [Path]) VALUES (1, 1, N'/api/FileAPI/MenuItemImage_0000001_2023-06-20T15-33-00-473128.png')
INSERT [dbo].[MenuItemImages] ([Id], [MenuItemId], [Path]) VALUES (2, 2, N'/api/FileAPI/MenuItemImage_0000002_2023-06-20T15-34-06-096707.png')
INSERT [dbo].[MenuItemImages] ([Id], [MenuItemId], [Path]) VALUES (3, 3, N'/api/FileAPI/MenuItemImage_0000003_2023-06-20T15-35-30-412908.png')
INSERT [dbo].[MenuItemImages] ([Id], [MenuItemId], [Path]) VALUES (4, 4, N'/api/FileAPI/MenuItemImage_0000004_2023-06-20T15-36-50-704029.png')
INSERT [dbo].[MenuItemImages] ([Id], [MenuItemId], [Path]) VALUES (5, 5, N'/api/FileAPI/MenuItemImage_0000005_2023-06-20T15-38-08-198304.png')
INSERT [dbo].[MenuItemImages] ([Id], [MenuItemId], [Path]) VALUES (6, 6, N'/api/FileAPI/MenuItemImage_0000006_2023-06-20T15-39-02-792616.png')
INSERT [dbo].[MenuItemImages] ([Id], [MenuItemId], [Path]) VALUES (7, 7, N'/api/FileAPI/MenuItemImage_0000007_2023-06-20T15-40-04-836959.png')
INSERT [dbo].[MenuItemImages] ([Id], [MenuItemId], [Path]) VALUES (8, 8, N'/api/FileAPI/MenuItemImage_0000008_2023-06-20T15-42-45-689300.png')
INSERT [dbo].[MenuItemImages] ([Id], [MenuItemId], [Path]) VALUES (9, 9, N'/api/FileAPI/MenuItemImage_0000009_2023-06-20T15-43-50-945950.png')
INSERT [dbo].[MenuItemImages] ([Id], [MenuItemId], [Path]) VALUES (10, 10, N'/api/FileAPI/MenuItemImage_0000010_2023-06-20T15-45-03-981817.png')
INSERT [dbo].[MenuItemImages] ([Id], [MenuItemId], [Path]) VALUES (11, 11, N'/api/FileAPI/MenuItemImage_0000011_2023-06-20T15-45-56-927538.png')
INSERT [dbo].[MenuItemImages] ([Id], [MenuItemId], [Path]) VALUES (12, 12, N'/api/FileAPI/MenuItemImage_0000012_2023-06-20T15-48-14-915533.png')
INSERT [dbo].[MenuItemImages] ([Id], [MenuItemId], [Path]) VALUES (13, 13, N'/api/FileAPI/MenuItemImage_0000013_2023-06-20T15-48-05-108011.png')
INSERT [dbo].[MenuItemImages] ([Id], [MenuItemId], [Path]) VALUES (14, 14, N'/api/FileAPI/MenuItemImage_0000014_2023-06-20T15-49-09-804468.png')
INSERT [dbo].[MenuItemImages] ([Id], [MenuItemId], [Path]) VALUES (15, 15, N'/api/FileAPI/MenuItemImage_0000015_2023-06-20T16-02-09-839263.png')
INSERT [dbo].[MenuItemImages] ([Id], [MenuItemId], [Path]) VALUES (16, 16, N'/api/FileAPI/MenuItemImage_0000016_2023-06-20T16-02-52-014644.png')
INSERT [dbo].[MenuItemImages] ([Id], [MenuItemId], [Path]) VALUES (17, 17, N'/api/FileAPI/MenuItemImage_0000017_2023-06-20T16-03-32-032592.png')
INSERT [dbo].[MenuItemImages] ([Id], [MenuItemId], [Path]) VALUES (18, 18, N'/api/FileAPI/MenuItemImage_0000018_2023-06-20T16-04-10-722382.png')
INSERT [dbo].[MenuItemImages] ([Id], [MenuItemId], [Path]) VALUES (19, 19, N'/api/FileAPI/MenuItemImage_0000019_2023-06-20T16-04-58-481349.png')
INSERT [dbo].[MenuItemImages] ([Id], [MenuItemId], [Path]) VALUES (20, 20, N'/api/FileAPI/MenuItemImage_0000020_2023-06-20T16-06-35-217624.png')
INSERT [dbo].[MenuItemImages] ([Id], [MenuItemId], [Path]) VALUES (21, 21, N'/api/FileAPI/MenuItemImage_0000021_2023-06-20T16-07-08-230954.png')
INSERT [dbo].[MenuItemImages] ([Id], [MenuItemId], [Path]) VALUES (22, 22, N'/api/FileAPI/MenuItemImage_0000022_2023-06-20T16-07-57-794789.png')
INSERT [dbo].[MenuItemImages] ([Id], [MenuItemId], [Path]) VALUES (23, 23, N'/api/FileAPI/MenuItemImage_0000023_2023-06-20T16-08-45-718718.png')
INSERT [dbo].[MenuItemImages] ([Id], [MenuItemId], [Path]) VALUES (24, 24, N'/api/FileAPI/MenuItemImage_0000024_2023-06-20T16-09-35-656318.png')
INSERT [dbo].[MenuItemImages] ([Id], [MenuItemId], [Path]) VALUES (25, 25, N'/api/FileAPI/MenuItemImage_0000025_2023-06-20T16-10-34-572556.png')
INSERT [dbo].[MenuItemImages] ([Id], [MenuItemId], [Path]) VALUES (26, 26, N'/api/FileAPI/MenuItemImage_0000026_2023-06-20T16-13-20-914070.png')
INSERT [dbo].[MenuItemImages] ([Id], [MenuItemId], [Path]) VALUES (27, 27, N'/api/FileAPI/MenuItemImage_0000027_2023-06-20T16-14-11-402533.png')
INSERT [dbo].[MenuItemImages] ([Id], [MenuItemId], [Path]) VALUES (28, 28, N'/api/FileAPI/MenuItemImage_0000028_2023-06-20T16-14-48-573515.png')
INSERT [dbo].[MenuItemImages] ([Id], [MenuItemId], [Path]) VALUES (29, 29, N'/api/FileAPI/MenuItemImage_0000029_2023-06-20T16-15-23-180773.png')
INSERT [dbo].[MenuItemImages] ([Id], [MenuItemId], [Path]) VALUES (30, 30, N'/api/FileAPI/MenuItemImage_0000030_2023-06-20T16-15-59-192740.png')
INSERT [dbo].[MenuItemImages] ([Id], [MenuItemId], [Path]) VALUES (31, 31, N'/api/FileAPI/MenuItemImage_0000031_2023-06-20T16-16-30-663346.png')
SET IDENTITY_INSERT [dbo].[MenuItemImages] OFF
GO
SET IDENTITY_INSERT [dbo].[MerchantProfileImages] ON 

INSERT [dbo].[MerchantProfileImages] ([Id], [MerchantId], [Path]) VALUES (1, 1, N'/api/FileAPI/MerchantProfileImage_0000001_2023-06-23T16-07-46-072505.png')
INSERT [dbo].[MerchantProfileImages] ([Id], [MerchantId], [Path]) VALUES (2, 2, N'/api/FileAPI/MerchantProfileImage_0000002_2023-06-20T15-06-16-750506.png')
INSERT [dbo].[MerchantProfileImages] ([Id], [MerchantId], [Path]) VALUES (3, 3, N'/api/FileAPI/MerchantProfileImage_0000003_2023-06-23T15-59-33-250945.png')
INSERT [dbo].[MerchantProfileImages] ([Id], [MerchantId], [Path]) VALUES (4, 4, N'/api/FileAPI/MerchantProfileImage_0000004_2023-06-20T15-56-01-981587.png')
INSERT [dbo].[MerchantProfileImages] ([Id], [MerchantId], [Path]) VALUES (5, 5, N'/api/FileAPI/MerchantProfileImage_0000005_2023-06-20T15-58-14-776762.png')
INSERT [dbo].[MerchantProfileImages] ([Id], [MerchantId], [Path]) VALUES (6, 6, N'/api/FileAPI/MerchantProfileImage_0000006_2023-06-20T16-00-47-156547.png')
INSERT [dbo].[MerchantProfileImages] ([Id], [MerchantId], [Path]) VALUES (8, 8, N'/api/FileAPI/MerchantProfileImage_0000008_2023-06-26T20-35-38-175349.jpg')
SET IDENTITY_INSERT [dbo].[MerchantProfileImages] OFF
GO
SET IDENTITY_INSERT [dbo].[MerchantRatings] ON 

INSERT [dbo].[MerchantRatings] ([Id], [FromUserId], [FromUserType], [ToMerchantId], [Rating], [OrderId]) VALUES (1, 9, N'Shipper', 1, 4, 9)
INSERT [dbo].[MerchantRatings] ([Id], [FromUserId], [FromUserType], [ToMerchantId], [Rating], [OrderId]) VALUES (2, 9, N'Shipper', 4, 4.5, 10)
INSERT [dbo].[MerchantRatings] ([Id], [FromUserId], [FromUserType], [ToMerchantId], [Rating], [OrderId]) VALUES (5, 8, N'Shipper', 5, 3, 11)
INSERT [dbo].[MerchantRatings] ([Id], [FromUserId], [FromUserType], [ToMerchantId], [Rating], [OrderId]) VALUES (9, 6, N'Customer', 4, 2, 10)
INSERT [dbo].[MerchantRatings] ([Id], [FromUserId], [FromUserType], [ToMerchantId], [Rating], [OrderId]) VALUES (10, 6, N'Customer', 1, 4, 12)
SET IDENTITY_INSERT [dbo].[MerchantRatings] OFF
GO
SET IDENTITY_INSERT [dbo].[NormalOpenHours] ON 

INSERT [dbo].[NormalOpenHours] ([Id], [MerchantId], [DayOfWeek], [SessionNo], [OpenTime], [CloseTime]) VALUES (3, 1, 3, 1, CAST(N'2023-06-22T06:00:00.0000000' AS DateTime2), CAST(N'2023-06-22T21:00:00.0000000' AS DateTime2))
INSERT [dbo].[NormalOpenHours] ([Id], [MerchantId], [DayOfWeek], [SessionNo], [OpenTime], [CloseTime]) VALUES (4, 1, 4, 1, CAST(N'2023-06-22T06:00:00.0000000' AS DateTime2), CAST(N'2023-06-22T21:00:00.0000000' AS DateTime2))
INSERT [dbo].[NormalOpenHours] ([Id], [MerchantId], [DayOfWeek], [SessionNo], [OpenTime], [CloseTime]) VALUES (5, 1, 5, 1, CAST(N'2023-06-22T06:00:00.0000000' AS DateTime2), CAST(N'2023-06-22T21:00:00.0000000' AS DateTime2))
INSERT [dbo].[NormalOpenHours] ([Id], [MerchantId], [DayOfWeek], [SessionNo], [OpenTime], [CloseTime]) VALUES (6, 2, 0, 1, CAST(N'2023-06-20T06:00:00.0000000' AS DateTime2), CAST(N'2023-06-20T22:00:00.0000000' AS DateTime2))
INSERT [dbo].[NormalOpenHours] ([Id], [MerchantId], [DayOfWeek], [SessionNo], [OpenTime], [CloseTime]) VALUES (7, 2, 1, 1, CAST(N'2023-06-20T06:00:00.0000000' AS DateTime2), CAST(N'2023-06-20T22:00:00.0000000' AS DateTime2))
INSERT [dbo].[NormalOpenHours] ([Id], [MerchantId], [DayOfWeek], [SessionNo], [OpenTime], [CloseTime]) VALUES (8, 2, 2, 1, CAST(N'2023-06-20T06:00:00.0000000' AS DateTime2), CAST(N'2023-06-20T22:00:00.0000000' AS DateTime2))
INSERT [dbo].[NormalOpenHours] ([Id], [MerchantId], [DayOfWeek], [SessionNo], [OpenTime], [CloseTime]) VALUES (9, 2, 3, 1, CAST(N'2023-06-20T06:00:00.0000000' AS DateTime2), CAST(N'2023-06-20T22:00:00.0000000' AS DateTime2))
INSERT [dbo].[NormalOpenHours] ([Id], [MerchantId], [DayOfWeek], [SessionNo], [OpenTime], [CloseTime]) VALUES (10, 2, 4, 1, CAST(N'2023-06-20T06:00:00.0000000' AS DateTime2), CAST(N'2023-06-20T22:00:00.0000000' AS DateTime2))
INSERT [dbo].[NormalOpenHours] ([Id], [MerchantId], [DayOfWeek], [SessionNo], [OpenTime], [CloseTime]) VALUES (11, 2, 5, 1, CAST(N'2023-06-20T06:00:00.0000000' AS DateTime2), CAST(N'2023-06-20T22:00:00.0000000' AS DateTime2))
INSERT [dbo].[NormalOpenHours] ([Id], [MerchantId], [DayOfWeek], [SessionNo], [OpenTime], [CloseTime]) VALUES (12, 2, 6, 1, CAST(N'2023-06-20T06:00:00.0000000' AS DateTime2), CAST(N'2023-06-20T22:00:00.0000000' AS DateTime2))
INSERT [dbo].[NormalOpenHours] ([Id], [MerchantId], [DayOfWeek], [SessionNo], [OpenTime], [CloseTime]) VALUES (13, 3, 0, 1, CAST(N'2023-06-20T06:00:00.0000000' AS DateTime2), CAST(N'2023-06-20T22:00:00.0000000' AS DateTime2))
INSERT [dbo].[NormalOpenHours] ([Id], [MerchantId], [DayOfWeek], [SessionNo], [OpenTime], [CloseTime]) VALUES (14, 3, 6, 1, CAST(N'2023-06-20T06:00:00.0000000' AS DateTime2), CAST(N'2023-06-20T22:00:00.0000000' AS DateTime2))
INSERT [dbo].[NormalOpenHours] ([Id], [MerchantId], [DayOfWeek], [SessionNo], [OpenTime], [CloseTime]) VALUES (15, 4, 1, 1, CAST(N'2023-06-20T06:00:00.0000000' AS DateTime2), CAST(N'2023-06-20T23:00:00.0000000' AS DateTime2))
INSERT [dbo].[NormalOpenHours] ([Id], [MerchantId], [DayOfWeek], [SessionNo], [OpenTime], [CloseTime]) VALUES (16, 4, 2, 1, CAST(N'2023-06-20T06:00:00.0000000' AS DateTime2), CAST(N'2023-06-20T23:00:00.0000000' AS DateTime2))
INSERT [dbo].[NormalOpenHours] ([Id], [MerchantId], [DayOfWeek], [SessionNo], [OpenTime], [CloseTime]) VALUES (17, 4, 3, 1, CAST(N'2023-06-20T06:00:00.0000000' AS DateTime2), CAST(N'2023-06-20T23:00:00.0000000' AS DateTime2))
INSERT [dbo].[NormalOpenHours] ([Id], [MerchantId], [DayOfWeek], [SessionNo], [OpenTime], [CloseTime]) VALUES (18, 4, 4, 1, CAST(N'2023-06-20T06:00:00.0000000' AS DateTime2), CAST(N'2023-06-20T23:00:00.0000000' AS DateTime2))
INSERT [dbo].[NormalOpenHours] ([Id], [MerchantId], [DayOfWeek], [SessionNo], [OpenTime], [CloseTime]) VALUES (19, 4, 5, 1, CAST(N'2023-06-20T06:00:00.0000000' AS DateTime2), CAST(N'2023-06-20T23:00:00.0000000' AS DateTime2))
INSERT [dbo].[NormalOpenHours] ([Id], [MerchantId], [DayOfWeek], [SessionNo], [OpenTime], [CloseTime]) VALUES (20, 5, 1, 1, CAST(N'2023-06-20T06:00:00.0000000' AS DateTime2), CAST(N'2023-06-20T22:00:00.0000000' AS DateTime2))
INSERT [dbo].[NormalOpenHours] ([Id], [MerchantId], [DayOfWeek], [SessionNo], [OpenTime], [CloseTime]) VALUES (21, 5, 2, 1, CAST(N'2023-06-20T06:00:00.0000000' AS DateTime2), CAST(N'2023-06-20T23:00:00.0000000' AS DateTime2))
INSERT [dbo].[NormalOpenHours] ([Id], [MerchantId], [DayOfWeek], [SessionNo], [OpenTime], [CloseTime]) VALUES (22, 5, 3, 1, CAST(N'2023-06-20T06:00:00.0000000' AS DateTime2), CAST(N'2023-06-20T23:00:00.0000000' AS DateTime2))
INSERT [dbo].[NormalOpenHours] ([Id], [MerchantId], [DayOfWeek], [SessionNo], [OpenTime], [CloseTime]) VALUES (23, 5, 4, 1, CAST(N'2023-06-20T06:00:00.0000000' AS DateTime2), CAST(N'2023-06-20T23:00:00.0000000' AS DateTime2))
INSERT [dbo].[NormalOpenHours] ([Id], [MerchantId], [DayOfWeek], [SessionNo], [OpenTime], [CloseTime]) VALUES (24, 5, 5, 1, CAST(N'2023-06-20T06:00:00.0000000' AS DateTime2), CAST(N'2023-06-20T23:00:00.0000000' AS DateTime2))
INSERT [dbo].[NormalOpenHours] ([Id], [MerchantId], [DayOfWeek], [SessionNo], [OpenTime], [CloseTime]) VALUES (25, 6, 1, 1, CAST(N'2023-06-20T06:00:00.0000000' AS DateTime2), CAST(N'2023-06-20T22:00:00.0000000' AS DateTime2))
INSERT [dbo].[NormalOpenHours] ([Id], [MerchantId], [DayOfWeek], [SessionNo], [OpenTime], [CloseTime]) VALUES (28, 6, 4, 1, CAST(N'2023-06-20T06:00:00.0000000' AS DateTime2), CAST(N'2023-06-20T22:00:00.0000000' AS DateTime2))
INSERT [dbo].[NormalOpenHours] ([Id], [MerchantId], [DayOfWeek], [SessionNo], [OpenTime], [CloseTime]) VALUES (29, 6, 5, 1, CAST(N'2023-06-20T06:00:00.0000000' AS DateTime2), CAST(N'2023-06-20T22:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[NormalOpenHours] OFF
GO
SET IDENTITY_INSERT [dbo].[UserRatings] ON 

INSERT [dbo].[UserRatings] ([Id], [FromUserId], [FromUserType], [ToUserId], [ToUserType], [Rating], [OrderId]) VALUES (1, 2, N'Merchant', 6, N'Customer', 4, 6)
INSERT [dbo].[UserRatings] ([Id], [FromUserId], [FromUserType], [ToUserId], [ToUserType], [Rating], [OrderId]) VALUES (2, 9, N'Shipper', 6, N'Customer', 5, 9)
INSERT [dbo].[UserRatings] ([Id], [FromUserId], [FromUserType], [ToUserId], [ToUserType], [Rating], [OrderId]) VALUES (3, 6, N'Customer', 9, N'Shipper', 4, 9)
INSERT [dbo].[UserRatings] ([Id], [FromUserId], [FromUserType], [ToUserId], [ToUserType], [Rating], [OrderId]) VALUES (4, 9, N'Shipper', 6, N'Customer', 4.5, 10)
INSERT [dbo].[UserRatings] ([Id], [FromUserId], [FromUserType], [ToUserId], [ToUserType], [Rating], [OrderId]) VALUES (5, 8, N'Shipper', 6, N'Customer', 1.5, 11)
INSERT [dbo].[UserRatings] ([Id], [FromUserId], [FromUserType], [ToUserId], [ToUserType], [Rating], [OrderId]) VALUES (6, 6, N'Customer', 9, N'Shipper', 3.5, 10)
INSERT [dbo].[UserRatings] ([Id], [FromUserId], [FromUserType], [ToUserId], [ToUserType], [Rating], [OrderId]) VALUES (7, 2, N'Merchant', 6, N'Customer', 4.5, 12)
SET IDENTITY_INSERT [dbo].[UserRatings] OFF
GO
INSERT [dbo].[OnlineShipperStatuses] ([ShipperId], [GeoLatitude], [GeoLongitude], [IsAvailable]) VALUES (8, 10.7621464, 106.6903352, 1)
INSERT [dbo].[OnlineShipperStatuses] ([ShipperId], [GeoLatitude], [GeoLongitude], [IsAvailable]) VALUES (9, 10.756765, 106.668935, 1)
GO
