USE [Wagner]
GO

-- ==========================================================================================================
-- Author:					Victor Cruz
-- Create date: 2025/01/09
-- Description: Script para crear objectos en la base de datos
-- ==========================================================================================================

--;
IF EXISTS(SELECT 1 FROM SYS.OBJECTS WHERE OBJECT_ID = OBJECT_ID(N'[dbo].[Clientes]'))
BEGIN
	DROP TABLE [dbo].[Clientes]
END
GO
IF EXISTS(SELECT 1 FROM SYS.OBJECTS WHERE OBJECT_ID = OBJECT_ID(N'[dbo].[Productos]'))
BEGIN
	DROP TABLE [dbo].[Productos]
END
GO
IF EXISTS(SELECT 1 FROM SYS.OBJECTS WHERE OBJECT_ID = OBJECT_ID(N'[dbo].[Ventas]'))
BEGIN
	DROP TABLE [dbo].[Ventas]
END
GO
IF EXISTS(SELECT 1 FROM SYS.OBJECTS WHERE OBJECT_ID = OBJECT_ID(N'[dbo].[ErrorDetailsLogs]'))
BEGIN 
	DROP TABLE [dbo].[ErrorDetailsLogs]
END
IF EXISTS(SELECT 1 FROM SYS.OBJECTS WHERE OBJECT_ID = OBJECT_ID(N'[dbo].[ApplicationLogs]'))
BEGIN 
	DROP TABLE [dbo].[ApplicationLogs]
END 
GO
IF EXISTS(SELECT 1 FROM SYS.OBJECTS WHERE OBJECT_ID = OBJECT_ID(N'[dbo].[OperationsLogs]'))
BEGIN
	DROP TABLE [dbo].[OperationsLogs]
END
GO


CREATE TABLE [dbo].[Clientes] (
    [Id] [nvarchar](128) NOT NULL,
    [Nombre] [nvarchar](max),
    [Apellido] [nvarchar](max),
    [RFC] [nvarchar](max),
    [CuentaBancariaId] [nvarchar](max),
	[Activo] [bit] DEFAULT 0,
    CONSTRAINT [PK_dbo.Clientes] PRIMARY KEY ([Id])
)

CREATE TABLE [dbo].[Productos] (
    [Id] [nvarchar](128) NOT NULL,
    [Nombre] [nvarchar](max),
    [Descripcion] [nvarchar](max),
    [PrecioCompra] [decimal](18, 2) NOT NULL,
    [PrecioPublico] [decimal](18, 2) NOT NULL,
    [PrecioEspecial] [decimal](18, 2) NOT NULL,
	[Activo] [bit] DEFAULT 0,
    CONSTRAINT [PK_dbo.Productos] PRIMARY KEY ([Id])
)

CREATE TABLE [dbo].[Ventas] (
    [Id] [nvarchar](128) NOT NULL,
    [Folio] [nvarchar](max),
    [CodigoCliente] [nvarchar](max),
    [Cantidad] [int] NOT NULL,
    [CodigoTasaIva] [int] NOT NULL,
    [PrecioUnitario] [decimal](18, 2) NOT NULL,
    [SubTotal] [decimal](18, 2) NOT NULL,
    [IVA] [decimal](18, 2) NOT NULL,
    [ImporteTotal] [decimal](18, 2) NOT NULL,
    [FechaVenta] [datetime] NOT NULL,
	[Activo] [bit] DEFAULT 0,
    CONSTRAINT [PK_dbo.Ventas] PRIMARY KEY ([Id])
)

CREATE TABLE ApplicationLogs (
    IdLog INT IDENTITY(1,1) PRIMARY KEY,
    IdCorrelation NVARCHAR(255) NOT NULL, 
	--MonoliticName NVARCHAR(100),
    Environment NVARCHAR(255),
    LogDate DATETIME NOT NULL DEFAULT GETDATE(),
    ExceptionMessage  NVARCHAR(MAX),
    LogLevel NVARCHAR(50),
    LoggerName NVARCHAR(255),
    Message NVARCHAR(MAX),
    ExceptionStackTrace NVARCHAR(MAX),
    ThreadId NVARCHAR(50)
);

CREATE TABLE ErrorDetailsLogs (
    IdErrorLog INT IDENTITY(1,1) PRIMARY KEY,
    IdCorrelation NVARCHAR(255) NOT NULL, 
    ServerName NVARCHAR(255),
    LineNumber INT,
    FileName NVARCHAR(255),
    LogDate DATETIME NOT NULL DEFAULT GETDATE(),
);

CREATE TABLE OperationsLogs(
	IdLog INT IDENTITY(1,1) PRIMARY KEY,
	Action NVARCHAR(50) NOT NULL,
	Message NVARCHAR(100) NOT NULL,
	LogDate DATETIME NOT NULL DEFAULT GETDATE()
);











/**
SELECT * FROM #TablaTemporal
DECLARE @PageNumber INT 
SET @PageNumber = 1
DECLARE @PageSize INT
SET @PageSize = 50

SELECT * 
FROM Clientes
ORDER BY Nombre
OFFSET (@PageNumber - 1) * @PageSize ROWS
FETCH NEXT @PageSize ROWS ONLY;

SELECT COUNT(*) AS TotalCount 
FROM Clientes;


SELECT * FROM ApplicationLogs;
SELECT * FROM ErrorDetailsLogs;
SELECT * FROM OperationsLogs;

select A.IdCorrelation, 
	A.Environment, 
	A.LogLevel, 
	A.LoggerName, 
	E.ServerName, 
	E.LineNumber, 
	E.FileName, 
	E.LogDate from 
ApplicationLogs A (NOLOCK)
	INNER JOIN ErrorDetailsLogs E ON A.IdCorrelation = E.IdCorrelation

SELECT * FROM CLIENTES
SELECT * FROM PRODUCTOS
**/