/*
 Navicat Premium Dump SQL

 Source Server         : sqlserver2-local
 Source Server Type    : SQL Server
 Source Server Version : 16001000 (16.00.1000)
 Source Host           : localhost\SQLEXPRESS:1433
 Source Catalog        : organic_shop
 Source Schema         : dbo

 Target Server Type    : SQL Server
 Target Server Version : 16001000 (16.00.1000)
 File Encoding         : 65001

 Date: 24/09/2026 07:25:03
*/


-- ----------------------------
-- Table structure for category
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[category]') AND type IN ('U'))
	DROP TABLE [dbo].[category]
GO

CREATE TABLE [dbo].[category] (
  [CatId] int  IDENTITY(1,1) NOT NULL,
  [CatName] nvarchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL
)
GO

ALTER TABLE [dbo].[category] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of category
-- ----------------------------
SET IDENTITY_INSERT [dbo].[category] ON
GO

INSERT INTO [dbo].[category] ([CatId], [CatName]) VALUES (N'2', N'Trái cây organic')
GO

INSERT INTO [dbo].[category] ([CatId], [CatName]) VALUES (N'3', N'Gạo & Ngũ cốc organic')
GO

INSERT INTO [dbo].[category] ([CatId], [CatName]) VALUES (N'4', N'Sữa & Trứng organic')
GO

INSERT INTO [dbo].[category] ([CatId], [CatName]) VALUES (N'5', N'Thực phẩm khô organic')
GO

INSERT INTO [dbo].[category] ([CatId], [CatName]) VALUES (N'6', N'Đồ uống organic')
GO

INSERT INTO [dbo].[category] ([CatId], [CatName]) VALUES (N'7', N'Gia vị organic')
GO

INSERT INTO [dbo].[category] ([CatId], [CatName]) VALUES (N'8', N'Hạt dinh dưỡng organic')
GO

SET IDENTITY_INSERT [dbo].[category] OFF
GO


-- ----------------------------
-- Table structure for product
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[product]') AND type IN ('U'))
	DROP TABLE [dbo].[product]
GO

CREATE TABLE [dbo].[product] (
  [ProId] int  IDENTITY(1,1) NOT NULL,
  [ProName] nvarchar(200) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [Price] decimal(12,2)  NOT NULL,
  [Discount] decimal(5,2) DEFAULT 0 NULL,
  [CreatedAt] datetime DEFAULT getdate() NULL,
  [Img] nvarchar(500) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [CatId] int  NULL
)
GO

ALTER TABLE [dbo].[product] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of product
-- ----------------------------
SET IDENTITY_INSERT [dbo].[product] ON
GO

INSERT INTO [dbo].[product] ([ProId], [ProName], [Price], [Discount], [CreatedAt], [Img], [CatId]) VALUES (N'1', N'Cải xoăn organic', N'45000.00', N'10.00', N'2024-11-01 08:00:00.000', N'cai-xoan-organic.jpg', NULL)
GO

INSERT INTO [dbo].[product] ([ProId], [ProName], [Price], [Discount], [CreatedAt], [Img], [CatId]) VALUES (N'2', N'Cà rốt organic Đà Lạt', N'35000.00', N'5.00', N'2024-11-02 08:00:00.000', N'ca-rot-organic.jpg', NULL)
GO

INSERT INTO [dbo].[product] ([ProId], [ProName], [Price], [Discount], [CreatedAt], [Img], [CatId]) VALUES (N'3', N'Bông cải xanh organic', N'55000.00', N'0.00', N'2024-11-03 08:00:00.000', N'bong-cai-xanh.jpg', NULL)
GO

INSERT INTO [dbo].[product] ([ProId], [ProName], [Price], [Discount], [CreatedAt], [Img], [CatId]) VALUES (N'4', N'Cà chua bi organic', N'65000.00', N'15.00', N'2024-11-04 08:00:00.000', N'ca-chua-bi.jpg', NULL)
GO

INSERT INTO [dbo].[product] ([ProId], [ProName], [Price], [Discount], [CreatedAt], [Img], [CatId]) VALUES (N'5', N'Xà lách romaine organic', N'40000.00', N'0.00', N'2024-11-05 08:00:00.000', N'xa-lach-romaine.jpg', NULL)
GO

INSERT INTO [dbo].[product] ([ProId], [ProName], [Price], [Discount], [CreatedAt], [Img], [CatId]) VALUES (N'6', N'Khoai lang mật organic', N'45000.00', N'10.00', N'2024-11-06 08:00:00.000', N'khoai-lang-mat.jpg', NULL)
GO

INSERT INTO [dbo].[product] ([ProId], [ProName], [Price], [Discount], [CreatedAt], [Img], [CatId]) VALUES (N'7', N'Bí đỏ organic', N'38000.00', N'0.00', N'2024-11-07 08:00:00.000', N'bi-do-organic.jpg', NULL)
GO

INSERT INTO [dbo].[product] ([ProId], [ProName], [Price], [Discount], [CreatedAt], [Img], [CatId]) VALUES (N'8', N'Hành tây organic', N'32000.00', N'5.00', N'2024-11-08 08:00:00.000', N'hanh-tay-organic.jpg', NULL)
GO

INSERT INTO [dbo].[product] ([ProId], [ProName], [Price], [Discount], [CreatedAt], [Img], [CatId]) VALUES (N'9', N'Tỏi organic Lý Sơn', N'89000.00', N'0.00', N'2024-11-09 08:00:00.000', N'toi-ly-son.jpg', NULL)
GO

INSERT INTO [dbo].[product] ([ProId], [ProName], [Price], [Discount], [CreatedAt], [Img], [CatId]) VALUES (N'10', N'Ớt chuông organic', N'75000.00', N'10.00', N'2024-11-10 08:00:00.000', N'ot-chuong.jpg', NULL)
GO

INSERT INTO [dbo].[product] ([ProId], [ProName], [Price], [Discount], [CreatedAt], [Img], [CatId]) VALUES (N'11', N'Táo Envy organic', N'145000.00', N'10.00', N'2024-11-11 08:00:00.000', N'tao-envy.jpg', N'2')
GO

INSERT INTO [dbo].[product] ([ProId], [ProName], [Price], [Discount], [CreatedAt], [Img], [CatId]) VALUES (N'12', N'Chuối Laba organic', N'45000.00', N'0.00', N'2024-11-12 08:00:00.000', N'chuoi-laba.jpg', N'2')
GO

INSERT INTO [dbo].[product] ([ProId], [ProName], [Price], [Discount], [CreatedAt], [Img], [CatId]) VALUES (N'13', N'Cam sành organic', N'55000.00', N'5.00', N'2024-11-13 08:00:00.000', N'cam-sanh.jpg', N'2')
GO

INSERT INTO [dbo].[product] ([ProId], [ProName], [Price], [Discount], [CreatedAt], [Img], [CatId]) VALUES (N'14', N'Bơ Booth organic', N'95000.00', N'15.00', N'2024-11-14 08:00:00.000', N'bo-booth.jpg', N'2')
GO

INSERT INTO [dbo].[product] ([ProId], [ProName], [Price], [Discount], [CreatedAt], [Img], [CatId]) VALUES (N'15', N'Xoài cát Hòa Lộc organic', N'120000.00', N'0.00', N'2024-11-15 08:00:00.000', N'xoai-cat.jpg', N'2')
GO

INSERT INTO [dbo].[product] ([ProId], [ProName], [Price], [Discount], [CreatedAt], [Img], [CatId]) VALUES (N'16', N'Dâu tây Đà Lạt organic', N'180000.00', N'20.00', N'2024-11-16 08:00:00.000', N'dau-tay.jpg', N'2')
GO

INSERT INTO [dbo].[product] ([ProId], [ProName], [Price], [Discount], [CreatedAt], [Img], [CatId]) VALUES (N'17', N'Việt quất organic', N'220000.00', N'10.00', N'2024-11-17 08:00:00.000', N'viet-quat.jpg', N'2')
GO

INSERT INTO [dbo].[product] ([ProId], [ProName], [Price], [Discount], [CreatedAt], [Img], [CatId]) VALUES (N'18', N'Nho mẫu đơn organic', N'320000.00', N'0.00', N'2024-11-18 08:00:00.000', N'nho-mau-don.jpg', N'2')
GO

INSERT INTO [dbo].[product] ([ProId], [ProName], [Price], [Discount], [CreatedAt], [Img], [CatId]) VALUES (N'19', N'Kiwi vàng organic', N'165000.00', N'5.00', N'2024-11-19 08:00:00.000', N'kiwi-vang.jpg', N'2')
GO

INSERT INTO [dbo].[product] ([ProId], [ProName], [Price], [Discount], [CreatedAt], [Img], [CatId]) VALUES (N'20', N'Thanh long ruột đỏ organic', N'65000.00', N'0.00', N'2024-11-20 08:00:00.000', N'thanh-long.jpg', N'2')
GO

INSERT INTO [dbo].[product] ([ProId], [ProName], [Price], [Discount], [CreatedAt], [Img], [CatId]) VALUES (N'21', N'Gạo ST25 organic 5kg', N'285000.00', N'10.00', N'2024-11-21 08:00:00.000', N'gao-st25.jpg', N'3')
GO

INSERT INTO [dbo].[product] ([ProId], [ProName], [Price], [Discount], [CreatedAt], [Img], [CatId]) VALUES (N'22', N'Gạo lứt huyết rồng organic', N'95000.00', N'0.00', N'2024-11-22 08:00:00.000', N'gao-lut.jpg', N'3')
GO

INSERT INTO [dbo].[product] ([ProId], [ProName], [Price], [Discount], [CreatedAt], [Img], [CatId]) VALUES (N'23', N'Yến mạch cán dẹt organic', N'125000.00', N'5.00', N'2024-11-23 08:00:00.000', N'yen-mach.jpg', N'3')
GO

INSERT INTO [dbo].[product] ([ProId], [ProName], [Price], [Discount], [CreatedAt], [Img], [CatId]) VALUES (N'24', N'Quinoa trắng organic', N'195000.00', N'10.00', N'2024-11-24 08:00:00.000', N'quinoa-trang.jpg', N'3')
GO

INSERT INTO [dbo].[product] ([ProId], [ProName], [Price], [Discount], [CreatedAt], [Img], [CatId]) VALUES (N'25', N'Ngô nếp tím organic', N'65000.00', N'0.00', N'2024-11-25 08:00:00.000', N'ngo-nep-tim.jpg', N'3')
GO

INSERT INTO [dbo].[product] ([ProId], [ProName], [Price], [Discount], [CreatedAt], [Img], [CatId]) VALUES (N'26', N'Lúa mì nguyên cám organic', N'85000.00', N'5.00', N'2024-11-26 08:00:00.000', N'lua-mi.jpg', N'3')
GO

INSERT INTO [dbo].[product] ([ProId], [ProName], [Price], [Discount], [CreatedAt], [Img], [CatId]) VALUES (N'27', N'Sữa tươi organic 1L', N'78000.00', N'10.00', N'2024-11-27 08:00:00.000', N'sua-tuoi.jpg', N'4')
GO

INSERT INTO [dbo].[product] ([ProId], [ProName], [Price], [Discount], [CreatedAt], [Img], [CatId]) VALUES (N'28', N'Trứng gà organic (10 quả)', N'65000.00', N'0.00', N'2024-11-28 08:00:00.000', N'trung-ga.jpg', N'4')
GO

INSERT INTO [dbo].[product] ([ProId], [ProName], [Price], [Discount], [CreatedAt], [Img], [CatId]) VALUES (N'29', N'Sữa hạt óc chó organic', N'155000.00', N'15.00', N'2024-11-29 08:00:00.000', N'sua-oc-cho.jpg', N'4')
GO

INSERT INTO [dbo].[product] ([ProId], [ProName], [Price], [Discount], [CreatedAt], [Img], [CatId]) VALUES (N'30', N'Phô mai organic', N'185000.00', N'5.00', N'2024-11-30 08:00:00.000', N'pho-mai.jpg', N'4')
GO

INSERT INTO [dbo].[product] ([ProId], [ProName], [Price], [Discount], [CreatedAt], [Img], [CatId]) VALUES (N'31', N'Sữa chua Hy Lạp organic', N'45000.00', N'0.00', N'2024-12-01 08:00:00.000', N'sua-chua.jpg', N'4')
GO

INSERT INTO [dbo].[product] ([ProId], [ProName], [Price], [Discount], [CreatedAt], [Img], [CatId]) VALUES (N'32', N'Mật ong rừng organic 500ml', N'285000.00', N'10.00', N'2024-12-02 08:00:00.000', N'mat-ong.jpg', N'5')
GO

INSERT INTO [dbo].[product] ([ProId], [ProName], [Price], [Discount], [CreatedAt], [Img], [CatId]) VALUES (N'33', N'Đậu đen organic', N'75000.00', N'0.00', N'2024-12-03 08:00:00.000', N'dau-den.jpg', N'5')
GO

INSERT INTO [dbo].[product] ([ProId], [ProName], [Price], [Discount], [CreatedAt], [Img], [CatId]) VALUES (N'34', N'Đậu gà organic', N'85000.00', N'5.00', N'2024-12-04 08:00:00.000', N'dau-ga.jpg', N'5')
GO

INSERT INTO [dbo].[product] ([ProId], [ProName], [Price], [Discount], [CreatedAt], [Img], [CatId]) VALUES (N'35', N'Mì gạo lứt organic', N'55000.00', N'10.00', N'2024-12-05 08:00:00.000', N'mi-gao-lut.jpg', N'5')
GO

INSERT INTO [dbo].[product] ([ProId], [ProName], [Price], [Discount], [CreatedAt], [Img], [CatId]) VALUES (N'36', N'Bột ca cao organic', N'145000.00', N'0.00', N'2024-12-06 08:00:00.000', N'ca-cao.jpg', N'5')
GO

INSERT INTO [dbo].[product] ([ProId], [ProName], [Price], [Discount], [CreatedAt], [Img], [CatId]) VALUES (N'37', N'Trà xanh matcha organic', N'195000.00', N'15.00', N'2024-12-07 08:00:00.000', N'matcha.jpg', N'6')
GO

INSERT INTO [dbo].[product] ([ProId], [ProName], [Price], [Discount], [CreatedAt], [Img], [CatId]) VALUES (N'38', N'Cà phê Arabica organic', N'285000.00', N'10.00', N'2024-12-08 08:00:00.000', N'ca-phe.jpg', N'6')
GO

INSERT INTO [dbo].[product] ([ProId], [ProName], [Price], [Discount], [CreatedAt], [Img], [CatId]) VALUES (N'39', N'Nước ép táo organic', N'85000.00', N'0.00', N'2024-12-09 08:00:00.000', N'nuoc-ep-tao.jpg', N'6')
GO

INSERT INTO [dbo].[product] ([ProId], [ProName], [Price], [Discount], [CreatedAt], [Img], [CatId]) VALUES (N'40', N'Kombucha organic', N'65000.00', N'5.00', N'2024-12-10 08:00:00.000', N'kombucha.jpg', N'6')
GO

INSERT INTO [dbo].[product] ([ProId], [ProName], [Price], [Discount], [CreatedAt], [Img], [CatId]) VALUES (N'41', N'Dầu oliu extra virgin organic', N'385000.00', N'10.00', N'2024-12-11 08:00:00.000', N'dau-oliu.jpg', N'7')
GO

INSERT INTO [dbo].[product] ([ProId], [ProName], [Price], [Discount], [CreatedAt], [Img], [CatId]) VALUES (N'42', N'Nước mắm organic', N'125000.00', N'0.00', N'2024-12-12 08:00:00.000', N'nuoc-mam.jpg', N'7')
GO

INSERT INTO [dbo].[product] ([ProId], [ProName], [Price], [Discount], [CreatedAt], [Img], [CatId]) VALUES (N'43', N'Muối hồng Himalaya organic', N'95000.00', N'5.00', N'2024-12-13 08:00:00.000', N'muoi-hong.jpg', N'7')
GO

INSERT INTO [dbo].[product] ([ProId], [ProName], [Price], [Discount], [CreatedAt], [Img], [CatId]) VALUES (N'44', N'Tiêu đen organic', N'85000.00', N'0.00', N'2024-12-14 08:00:00.000', N'tieu-den.jpg', N'7')
GO

INSERT INTO [dbo].[product] ([ProId], [ProName], [Price], [Discount], [CreatedAt], [Img], [CatId]) VALUES (N'45', N'Hạnh nhân organic', N'285000.00', N'10.00', N'2024-12-15 08:00:00.000', N'hanh-nhan.jpg', N'8')
GO

INSERT INTO [dbo].[product] ([ProId], [ProName], [Price], [Discount], [CreatedAt], [Img], [CatId]) VALUES (N'46', N'Óc chó organic', N'325000.00', N'5.00', N'2024-12-16 08:00:00.000', N'oc-cho.jpg', N'8')
GO

INSERT INTO [dbo].[product] ([ProId], [ProName], [Price], [Discount], [CreatedAt], [Img], [CatId]) VALUES (N'47', N'Hạt chia organic', N'155000.00', N'0.00', N'2024-12-17 08:00:00.000', N'hat-chia.jpg', N'8')
GO

INSERT INTO [dbo].[product] ([ProId], [ProName], [Price], [Discount], [CreatedAt], [Img], [CatId]) VALUES (N'48', N'Hạt điều organic', N'265000.00', N'10.00', N'2024-12-18 08:00:00.000', N'hat-dieu.jpg', N'8')
GO

INSERT INTO [dbo].[product] ([ProId], [ProName], [Price], [Discount], [CreatedAt], [Img], [CatId]) VALUES (N'49', N'Hạt lanh organic', N'125000.00', N'0.00', N'2024-12-19 08:00:00.000', N'hat-lanh.jpg', N'8')
GO

INSERT INTO [dbo].[product] ([ProId], [ProName], [Price], [Discount], [CreatedAt], [Img], [CatId]) VALUES (N'50', N'Macca organic', N'385000.00', N'15.00', N'2024-12-20 08:00:00.000', N'macca.jpg', N'8')
GO

INSERT INTO [dbo].[product] ([ProId], [ProName], [Price], [Discount], [CreatedAt], [Img], [CatId]) VALUES (N'51', N'Hat', N'1000.00', N'10.00', N'2026-09-23 16:02:57.483', N'0d65aad6-72f6-4a93-889a-d3e866f3cf15_49.jpg', N'8')
GO

SET IDENTITY_INSERT [dbo].[product] OFF
GO


-- ----------------------------
-- Auto increment value for category
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[category]', RESEED, 8)
GO


-- ----------------------------
-- Primary Key structure for table category
-- ----------------------------
ALTER TABLE [dbo].[category] ADD CONSTRAINT [PK__category__6A1C8AFADBFF93F6] PRIMARY KEY CLUSTERED ([CatId])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for product
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[product]', RESEED, 51)
GO


-- ----------------------------
-- Primary Key structure for table product
-- ----------------------------
ALTER TABLE [dbo].[product] ADD CONSTRAINT [PK__product__620295901D0F43B1] PRIMARY KEY CLUSTERED ([ProId])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Foreign Keys structure for table product
-- ----------------------------
ALTER TABLE [dbo].[product] ADD CONSTRAINT [FK_product_category] FOREIGN KEY ([CatId]) REFERENCES [dbo].[category] ([CatId]) ON DELETE SET NULL ON UPDATE NO ACTION
GO

