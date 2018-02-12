-- Script Date: 2018/02/12 7:35 PM  - ErikEJ.SqlCeScripting version 3.5.2.75
-- Database information:
-- Locale Identifier: 7177
-- Encryption Mode: 
-- Case Sensitive: False
-- Database: D:\Documents\Visual Studio 2017\Projects\GitLab\SmartManager\Managers\EManager.sdf
-- ServerVersion: 4.0.8482.1
-- DatabaseSize: 160 KB
-- SpaceAvailable: 3,999 GB
-- Created: 2018/02/09 8:13 AM

-- User Table information:
-- Number of tables: 7
-- Account: 2 row(s)
-- AccountType: 3 row(s)
-- ExpenseCategory: 4 row(s)
-- ExpenseTransaction: 2 row(s)
-- IncomeCategory: 6 row(s)
-- IncomeTransaction: 4 row(s)
-- PaymentType: 3 row(s)

CREATE TABLE [PaymentType] (
  [PaymentTypeId] int IDENTITY (4,1)  NOT NULL
, [TypeName] nvarchar(100)  NOT NULL
);
GO
CREATE TABLE [IncomeCategory] (
  [IncomeCategoryId] int IDENTITY (7,1)  NOT NULL
, [TypeName] nvarchar(100)  NOT NULL
);
GO
CREATE TABLE [ExpenseCategory] (
  [ExpenseCategoryId] int IDENTITY (5,1)  NOT NULL
, [Name] nvarchar(100)  NOT NULL
);
GO
CREATE TABLE [AccountType] (
  [AccountTypeId] int IDENTITY (4,1)  NOT NULL
, [TypeName] nvarchar(100)  NOT NULL
);
GO
CREATE TABLE [Account] (
  [AccountId] int IDENTITY (7,1)  NOT NULL
, [Name] nvarchar(100)  NOT NULL
, [Bank] nvarchar(100)  NOT NULL
, [AccountNum] nchar(100)  NOT NULL
, [Balance] money NOT NULL
, [AccountTypeId] int  NOT NULL
, [CurrencyCountry] nvarchar(25)  NULL
);
GO
CREATE TABLE [IncomeTransaction] (
  [IncomeTransactionId] int IDENTITY (10,1)  NOT NULL
, [Date] datetime NOT NULL
, [Details] nvarchar(100)  NOT NULL
, [Amount] money NOT NULL
, [AccountId] int  NOT NULL
, [PaymentTypeId] int  NOT NULL
, [IncomeCategoryId] int  NOT NULL
);
GO
CREATE TABLE [ExpenseTransaction] (
  [ExpenseTransactionId] int IDENTITY (6,1)  NOT NULL
, [Date] datetime NOT NULL
, [Details] nvarchar(100)  NOT NULL
, [Amount] money NOT NULL
, [AccountId] int  NOT NULL
, [PaymentTypeId] int  NOT NULL
, [ExpenseCategoryId] int  NOT NULL
);
GO
SET IDENTITY_INSERT [PaymentType] ON;
GO
INSERT INTO [PaymentType] ([PaymentTypeId],[TypeName]) VALUES (
1,N'Cash');
GO
INSERT INTO [PaymentType] ([PaymentTypeId],[TypeName]) VALUES (
2,N'EFT');
GO
INSERT INTO [PaymentType] ([PaymentTypeId],[TypeName]) VALUES (
3,N'Credit');
GO
SET IDENTITY_INSERT [PaymentType] OFF;
GO
SET IDENTITY_INSERT [IncomeCategory] ON;
GO
INSERT INTO [IncomeCategory] ([IncomeCategoryId],[TypeName]) VALUES (
1,N'Salary');
GO
INSERT INTO [IncomeCategory] ([IncomeCategoryId],[TypeName]) VALUES (
2,N'Present');
GO
INSERT INTO [IncomeCategory] ([IncomeCategoryId],[TypeName]) VALUES (
3,N'Save');
GO
INSERT INTO [IncomeCategory] ([IncomeCategoryId],[TypeName]) VALUES (
4,N'New');
GO
INSERT INTO [IncomeCategory] ([IncomeCategoryId],[TypeName]) VALUES (
5,N'New');
GO
INSERT INTO [IncomeCategory] ([IncomeCategoryId],[TypeName]) VALUES (
6,N'Medical');
GO
SET IDENTITY_INSERT [IncomeCategory] OFF;
GO
SET IDENTITY_INSERT [ExpenseCategory] ON;
GO
INSERT INTO [ExpenseCategory] ([ExpenseCategoryId],[Name]) VALUES (
1,N'General');
GO
INSERT INTO [ExpenseCategory] ([ExpenseCategoryId],[Name]) VALUES (
2,N'Food');
GO
INSERT INTO [ExpenseCategory] ([ExpenseCategoryId],[Name]) VALUES (
3,N'Medical');
GO
INSERT INTO [ExpenseCategory] ([ExpenseCategoryId],[Name]) VALUES (
4,N'Test');
GO
SET IDENTITY_INSERT [ExpenseCategory] OFF;
GO
SET IDENTITY_INSERT [AccountType] ON;
GO
INSERT INTO [AccountType] ([AccountTypeId],[TypeName]) VALUES (
1,N'Savings');
GO
INSERT INTO [AccountType] ([AccountTypeId],[TypeName]) VALUES (
2,N'Cheques');
GO
INSERT INTO [AccountType] ([AccountTypeId],[TypeName]) VALUES (
3,N'Credit');
GO
SET IDENTITY_INSERT [AccountType] OFF;
GO
SET IDENTITY_INSERT [Account] ON;
GO
INSERT INTO [Account] ([AccountId],[Name],[Bank],[AccountNum],[Balance],[AccountTypeId],[CurrencyCountry]) VALUES (
2,N'Koos',N'fs',N'1244                                                                                                ',22121,2,N'Bhutan');
GO
INSERT INTO [Account] ([AccountId],[Name],[Bank],[AccountNum],[Balance],[AccountTypeId],[CurrencyCountry]) VALUES (
6,N'MyAccount',N'Capitec',N'11467781                                                                                            ',5200,1,N'South Africa');
GO
SET IDENTITY_INSERT [Account] OFF;
GO
SET IDENTITY_INSERT [IncomeTransaction] ON;
GO
INSERT INTO [IncomeTransaction] ([IncomeTransactionId],[Date],[Details],[Amount],[AccountId],[PaymentTypeId],[IncomeCategoryId]) VALUES (
6,{ts '2018-02-15 00:00:00.000'},N'fsbd',20,2,1,1);
GO
INSERT INTO [IncomeTransaction] ([IncomeTransactionId],[Date],[Details],[Amount],[AccountId],[PaymentTypeId],[IncomeCategoryId]) VALUES (
7,{ts '2018-02-20 00:00:00.000'},N'fdsb',22200,2,1,1);
GO
INSERT INTO [IncomeTransaction] ([IncomeTransactionId],[Date],[Details],[Amount],[AccountId],[PaymentTypeId],[IncomeCategoryId]) VALUES (
8,{ts '2018-02-12 00:00:00.000'},N'vgjbk',100,2,1,1);
GO
INSERT INTO [IncomeTransaction] ([IncomeTransactionId],[Date],[Details],[Amount],[AccountId],[PaymentTypeId],[IncomeCategoryId]) VALUES (
9,{ts '2018-02-13 00:00:00.000'},N'Anual Salary',20000,6,2,1);
GO
SET IDENTITY_INSERT [IncomeTransaction] OFF;
GO
SET IDENTITY_INSERT [ExpenseTransaction] ON;
GO
INSERT INTO [ExpenseTransaction] ([ExpenseTransactionId],[Date],[Details],[Amount],[AccountId],[PaymentTypeId],[ExpenseCategoryId]) VALUES (
4,{ts '2018-02-13 00:00:00.000'},N'mnbvc',200,2,1,1);
GO
INSERT INTO [ExpenseTransaction] ([ExpenseTransactionId],[Date],[Details],[Amount],[AccountId],[PaymentTypeId],[ExpenseCategoryId]) VALUES (
5,{ts '2018-02-13 00:00:00.000'},N'Fppd',15000,6,1,2);
GO
SET IDENTITY_INSERT [ExpenseTransaction] OFF;
GO
ALTER TABLE [PaymentType] ADD CONSTRAINT [PK_PaymentType] PRIMARY KEY ([PaymentTypeId]);
GO
ALTER TABLE [IncomeCategory] ADD CONSTRAINT [PK_IncomeCategory] PRIMARY KEY ([IncomeCategoryId]);
GO
ALTER TABLE [ExpenseCategory] ADD CONSTRAINT [PK_ExpenseCategory] PRIMARY KEY ([ExpenseCategoryId]);
GO
ALTER TABLE [AccountType] ADD CONSTRAINT [PK_AccountType] PRIMARY KEY ([AccountTypeId]);
GO
ALTER TABLE [Account] ADD CONSTRAINT [PK_Account] PRIMARY KEY ([AccountId]);
GO
ALTER TABLE [IncomeTransaction] ADD CONSTRAINT [PK_ExpenseTransaction] PRIMARY KEY ([IncomeTransactionId]);
GO
ALTER TABLE [ExpenseTransaction] ADD CONSTRAINT [PK_ExpenseTransaction1] PRIMARY KEY ([ExpenseTransactionId]);
GO
ALTER TABLE [Account] ADD CONSTRAINT [FK_Account_AccountType] FOREIGN KEY ([AccountTypeId]) REFERENCES [AccountType]([AccountTypeId]) ON DELETE NO ACTION ON UPDATE NO ACTION;
GO
ALTER TABLE [IncomeTransaction] ADD CONSTRAINT [FK_IncomeTransaction_Account] FOREIGN KEY ([AccountId]) REFERENCES [Account]([AccountId]) ON DELETE NO ACTION ON UPDATE NO ACTION;
GO
ALTER TABLE [IncomeTransaction] ADD CONSTRAINT [FK_IncomeTransaction_Category] FOREIGN KEY ([IncomeCategoryId]) REFERENCES [IncomeCategory]([IncomeCategoryId]) ON DELETE NO ACTION ON UPDATE NO ACTION;
GO
ALTER TABLE [IncomeTransaction] ADD CONSTRAINT [FK_IncomeTransaction_PaymentType] FOREIGN KEY ([PaymentTypeId]) REFERENCES [PaymentType]([PaymentTypeId]) ON DELETE NO ACTION ON UPDATE NO ACTION;
GO
ALTER TABLE [ExpenseTransaction] ADD CONSTRAINT [FK_ExpenseTransaction_Account] FOREIGN KEY ([AccountId]) REFERENCES [Account]([AccountId]) ON DELETE NO ACTION ON UPDATE NO ACTION;
GO
ALTER TABLE [ExpenseTransaction] ADD CONSTRAINT [FK_ExpenseTransaction_Category] FOREIGN KEY ([ExpenseCategoryId]) REFERENCES [ExpenseCategory]([ExpenseCategoryId]) ON DELETE NO ACTION ON UPDATE NO ACTION;
GO
ALTER TABLE [ExpenseTransaction] ADD CONSTRAINT [FK_ExpenseTransaction_PaymentType] FOREIGN KEY ([PaymentTypeId]) REFERENCES [PaymentType]([PaymentTypeId]) ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

