USE [Wagner]
GO

-- ==========================================================================================================
-- Author:					Victor Cruz
-- Create date: 2025/01/09
-- Description: Script para crear objectos en la base de datos
-- ==========================================================================================================

--; CLIENTES
-- ============================================
IF EXISTS (SELECT 1 FROM SYS.OBJECTS WHERE OBJECT_ID = OBJECT_ID(N'[dbo].[Usp_Clientes_Insert]') AND TYPE = 'P')
BEGIN
	DROP PROCEDURE [dbo].[Usp_Clientes_Insert];
END
GO
IF EXISTS (SELECT 1 FROM SYS.OBJECTS WHERE OBJECT_ID = OBJECT_ID(N'[dbo].[Usp_Clientes_GetAll]') AND TYPE = 'P')
BEGIN
	DROP PROCEDURE [dbo].[Usp_Clientes_GetAll];
END
GO
IF EXISTS (SELECT 1 FROM SYS.OBJECTS WHERE OBJECT_ID = OBJECT_ID(N'[dbo].[Usp_Clientes_GetPage]') AND TYPE = 'P')
BEGIN
	DROP PROCEDURE [dbo].[Usp_Clientes_GetPage];
END
GO
IF EXISTS (SELECT 1 FROM SYS.OBJECTS WHERE OBJECT_ID = OBJECT_ID(N'[dbo].[Usp_Clientes_Update]') AND TYPE = 'P')
BEGIN
	DROP PROCEDURE [dbo].[Usp_Clientes_Update];
END
GO
IF EXISTS (SELECT 1 FROM SYS.OBJECTS WHERE OBJECT_ID = OBJECT_ID(N'[dbo].[Usp_Clientes_Delete]') AND TYPE = 'P')
BEGIN
	DROP PROCEDURE [dbo].[Usp_Clientes_Delete];
END
GO
--; PRODUCTOS
-- ============================================
IF EXISTS (SELECT 1 FROM SYS.OBJECTS WHERE OBJECT_ID = OBJECT_ID(N'[dbo].[Usp_Productos_Insert]') AND TYPE = 'P')
BEGIN
	DROP PROCEDURE [dbo].[Usp_Productos_Insert];
END
GO
IF EXISTS (SELECT 1 FROM SYS.OBJECTS WHERE OBJECT_ID = OBJECT_ID(N'[dbo].[Usp_Productos_GetAll]') AND TYPE = 'P')
BEGIN
	DROP PROCEDURE [dbo].[Usp_Productos_GetAll];
END
GO
IF EXISTS (SELECT 1 FROM SYS.OBJECTS WHERE OBJECT_ID = OBJECT_ID(N'[dbo].[Usp_Productos_GetPage]') AND TYPE = 'P')
BEGIN
	DROP PROCEDURE [dbo].[Usp_Productos_GetPage];
END
GO
IF EXISTS (SELECT 1 FROM SYS.OBJECTS WHERE OBJECT_ID = OBJECT_ID(N'[dbo].[Usp_Productos_Update]') AND TYPE = 'P')
BEGIN
	DROP PROCEDURE [dbo].[Usp_Productos_Update];
END
GO
IF EXISTS (SELECT 1 FROM SYS.OBJECTS WHERE OBJECT_ID = OBJECT_ID(N'[dbo].[Usp_Productos_Delete]') AND TYPE = 'P')
BEGIN
	DROP PROCEDURE [dbo].[Usp_Productos_Delete];
END
GO

--; VENTAS
-- ============================================
IF EXISTS (SELECT 1 FROM SYS.OBJECTS WHERE OBJECT_ID = OBJECT_ID(N'[dbo].[Usp_Ventas_Insert]') AND TYPE = 'P')
BEGIN
	DROP PROCEDURE [dbo].[Usp_Ventas_Insert];
END
GO
IF EXISTS (SELECT 1 FROM SYS.OBJECTS WHERE OBJECT_ID = OBJECT_ID(N'[dbo].[Usp_Ventas_GetAll]') AND TYPE = 'P')
BEGIN
	DROP PROCEDURE [dbo].[Usp_Ventas_GetAll];
END
GO
IF EXISTS (SELECT 1 FROM SYS.OBJECTS WHERE OBJECT_ID = OBJECT_ID(N'[dbo].[Usp_Ventas_GetPage]') AND TYPE = 'P')
BEGIN
	DROP PROCEDURE [dbo].[Usp_Ventas_GetPage];
END
GO
IF EXISTS (SELECT 1 FROM SYS.OBJECTS WHERE OBJECT_ID = OBJECT_ID(N'[dbo].[Usp_Ventas_Update]') AND TYPE = 'P')
BEGIN
	DROP PROCEDURE [dbo].[Usp_Ventas_Update];
END
GO
IF EXISTS (SELECT 1 FROM SYS.OBJECTS WHERE OBJECT_ID = OBJECT_ID(N'[dbo].[Usp_Ventas_Delete]') AND TYPE = 'P')
BEGIN
	DROP PROCEDURE [dbo].[Usp_Ventas_Delete];
END
GO





--; CLIENTES
-- ============================================
CREATE OR ALTER PROCEDURE 
	Usp_Clientes_Insert
		@Id VARCHAR(128),
		@Nombre VARCHAR(50),
		@Apellido VARCHAR(50),
		@RFC VARCHAR(50),
		@CuentaBancariaId VARCHAR(100),
		@Activo BIT
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @Result AS TABLE
	(
		ResultStatus BIT,
		ResultMessage VARCHAR(50),
		LastKey INT
	)
	BEGIN TRY
		BEGIN TRANSACTION 
		IF EXISTS(SELECT Id FROM Clientes WHERE Id = @Id)
		BEGIN 
			INSERT INTO @Result(ResultStatus, ResultMessage, LastKey)
			SELECT 0, 'Error inserting data', 0

			ROLLBACK TRANSACTION 
		END
		ELSE
		BEGIN 
			INSERT INTO Clientes
			(
				Id,
				Nombre,
				Apellido,
				RFC,
				CuentaBancariaId,
				Activo
			)
			VALUES
			(
				@Id,
				@Nombre,
				@Apellido,
				@RFC,
				@CuentaBancariaId,
				@Activo
			)

			INSERT INTO @Result(ResultStatus, ResultMessage, LastKey)
			SELECT 1, 'Successful inserting data', (SELECT SCOPE_IDENTITY())

			COMMIT TRANSACTION 
		END
	END TRY

	BEGIN CATCH
		IF @@TRANCOUNT > 0
		BEGIN
			ROLLBACK TRANSACTION 
		END
	END CATCH

	SET NOCOUNT OFF;
	SELECT * FROM @Result
END
GO

-- ============================================
CREATE OR ALTER PROCEDURE
	Usp_Clientes_GetAll
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT
	C.Id
	, C.Nombre
	, C.Apellido
	, C.RFC
	, C.CuentaBancariaId
	, C.Activo
	FROM Clientes C (NOLOCK)

	SET NOCOUNT OFF;
END
GO

-- ============================================
CREATE PROCEDURE Usp_Clientes_GetPage
    @PageNumber INT,
    @PageSize INT,
    @Search NVARCHAR(100)
AS
BEGIN
	SET NOCOUNT ON;
    SELECT * 
    FROM Clientes
    WHERE Nombre LIKE '%' + @Search + '%' 
       OR Apellido LIKE '%' + @Search + '%' 
       OR RFC LIKE '%' + @Search + '%'
    ORDER BY Nombre
    OFFSET (@PageNumber - 1) * @PageSize ROWS
    FETCH NEXT @PageSize ROWS ONLY;

    SELECT COUNT(*) AS TotalCount 
    FROM Clientes
    WHERE Nombre LIKE '%' + @Search + '%' 
       OR Apellido LIKE '%' + @Search + '%' 
       OR RFC LIKE '%' + @Search + '%';
	SET NOCOUNT OFF;
END
GO

-- ============================================
CREATE OR ALTER PROCEDURE Usp_Clientes_Update
	@Id VARCHAR(128),
	@Nombre VARCHAR(50),
	@Apellido VARCHAR(50),
	@RFC VARCHAR(50),
	@CuentaBancariaId VARCHAR(100),
	@Activo BIT
AS
BEGIN
	DECLARE @Result AS TABLE
	(
		ResultStatus BIT,
		ResultMessage VARCHAR(50),
		LastKey INT
	)
	BEGIN TRY
		BEGIN TRANSACTION 
		IF NOT EXISTS(SELECT Id FROM Clientes WHERE Id = @Id)
		BEGIN 
			INSERT INTO @Result(ResultStatus, ResultMessage, LastKey)
			SELECT 0, 'Error updating data', 0

			ROLLBACK TRANSACTION 
		END
		ELSE
		BEGIN 
			UPDATE Clientes
			SET
				Nombre = @Nombre,
				Apellido = @Apellido,
				RFC = @RFC,
				CuentaBancariaId = @CuentaBancariaId,
				Activo = @Activo
			WHERE Id = @Id

			INSERT INTO @Result(ResultStatus, ResultMessage, LastKey)
			SELECT 1, 'Successful inserting data', (SELECT SCOPE_IDENTITY())

			COMMIT TRANSACTION 
		END
	END TRY

	BEGIN CATCH
		IF @@TRANCOUNT > 0
		BEGIN
			ROLLBACK TRANSACTION 
		END
	END CATCH

	SELECT * FROM @Result
END
GO

-- ============================================
CREATE OR ALTER PROCEDURE Usp_Clientes_Delete
	@Id VARCHAR(128)
AS
BEGIN
	DECLARE @Result AS TABLE
	(
		ResultStatus BIT,
		ResultMessage VARCHAR(50),
		LastKey INT
	)
	BEGIN TRY
		BEGIN TRANSACTION 
		IF NOT EXISTS(SELECT Id FROM Clientes WHERE Id = @Id)
		BEGIN 
			INSERT INTO @Result(ResultStatus, ResultMessage, LastKey)
			SELECT 0, 'Error deleting data', 0

			ROLLBACK TRANSACTION 
		END
		ELSE
		BEGIN 
			UPDATE Clientes
			SET
				Activo = 0
			WHERE Id = @Id

			INSERT INTO @Result(ResultStatus, ResultMessage, LastKey)
			SELECT 1, 'Successful deleting data', (SELECT SCOPE_IDENTITY())

			COMMIT TRANSACTION 
		END
	END TRY

	BEGIN CATCH
		IF @@TRANCOUNT > 0
		BEGIN
			ROLLBACK TRANSACTION 
		END
	END CATCH

	SELECT * FROM @Result
END
GO

--; PRODUCTOS
-- ============================================
CREATE OR ALTER PROCEDURE 
	Usp_Productos_Insert
		@Id VARCHAR(128),
		@Nombre VARCHAR(50),
		@Descripcion VARCHAR(50),
		@PrecioCompra DECIMAL(18,2),
		@PrecioPublico DECIMAL(18,2),
		@PrecioEspecial DECIMAL(18,2),
		@Activo BIT
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @Result AS TABLE
	(
		ResultStatus BIT,
		ResultMessage VARCHAR(50),
		LastKey INT
	)
	BEGIN TRY
		BEGIN TRANSACTION 
		IF EXISTS(SELECT Id FROM Productos WHERE Id = @Id)
		BEGIN 
			INSERT INTO @Result(ResultStatus, ResultMessage, LastKey)
			SELECT 0, 'Error inserting data', 0

			ROLLBACK TRANSACTION 
		END
		ELSE
		BEGIN 
			INSERT INTO Productos
			(
				Id,
				Nombre,
				Descripcion,
				PrecioCompra,
				PrecioPublico,
				PrecioEspecial,
				Activo
			)
			VALUES
			(
				@Id,
				@Nombre,
				@Descripcion,
				@PrecioCompra,
				@PrecioPublico,
				@PrecioEspecial,
				@Activo
			)

			INSERT INTO @Result(ResultStatus, ResultMessage, LastKey)
			SELECT 1, 'Successful inserting data', (SELECT SCOPE_IDENTITY())

			COMMIT TRANSACTION 
		END
	END TRY

	BEGIN CATCH
		IF @@TRANCOUNT > 0
		BEGIN
			ROLLBACK TRANSACTION 
		END
	END CATCH

	SET NOCOUNT OFF;
	SELECT * FROM @Result
END
GO

-- ============================================
CREATE OR ALTER PROCEDURE
	Usp_Productos_GetAll
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT
	C.Id
	, C.Nombre
	, C.Descripcion
	, C.PrecioCompra
	, C.PrecioPublico
	, C.PrecioEspecial
	, C.Activo
	FROM Productos C (NOLOCK)

	SET NOCOUNT OFF;
END
GO

-- ============================================
CREATE PROCEDURE Usp_Productos_GetPage
    @PageNumber INT,
    @PageSize INT,
    @Search NVARCHAR(100)
AS
BEGIN
	SET NOCOUNT ON;
    SELECT * 
    FROM Productos
    WHERE Nombre LIKE '%' + @Search + '%' 
       OR Descripcion LIKE '%' + @Search + '%'
    ORDER BY Nombre
    OFFSET (@PageNumber - 1) * @PageSize ROWS
    FETCH NEXT @PageSize ROWS ONLY;

    SELECT COUNT(*) AS TotalCount 
    FROM Productos
    WHERE Nombre LIKE '%' + @Search + '%' 
       OR Descripcion LIKE '%' + @Search + '%';
	SET NOCOUNT OFF;
END
GO

-- ============================================
CREATE OR ALTER PROCEDURE Usp_Productos_Update
		@Id VARCHAR(128),
		@Nombre VARCHAR(50),
		@Descripcion VARCHAR(50),
		@PrecioCompra DECIMAL(18,2),
		@PrecioPublico DECIMAL(18,2),
		@PrecioEspecial DECIMAL(18,2),
		@Activo BIT
AS
BEGIN
	DECLARE @Result AS TABLE
	(
		ResultStatus BIT,
		ResultMessage VARCHAR(50),
		LastKey INT
	)
	BEGIN TRY
		BEGIN TRANSACTION 
		IF NOT EXISTS(SELECT Id FROM Productos WHERE Id = @Id)
		BEGIN 
			INSERT INTO @Result(ResultStatus, ResultMessage, LastKey)
			SELECT 0, 'Error updating data', 0

			ROLLBACK TRANSACTION 
		END
		ELSE
		BEGIN 
			UPDATE Productos
			SET
				Nombre = @Nombre,
				Descripcion = @Descripcion,
				PrecioCompra = @PrecioCompra,
				PrecioPublico = @PrecioPublico,
				PrecioEspecial = @PrecioEspecial,
				Activo = @Activo
			WHERE Id = @Id

			INSERT INTO @Result(ResultStatus, ResultMessage, LastKey)
			SELECT 1, 'Successful inserting data', (SELECT SCOPE_IDENTITY())

			COMMIT TRANSACTION 
		END
	END TRY

	BEGIN CATCH
		IF @@TRANCOUNT > 0
		BEGIN
			ROLLBACK TRANSACTION 
		END
	END CATCH

	SELECT * FROM @Result
END
GO

-- ============================================
CREATE OR ALTER PROCEDURE Usp_Productos_Delete
	@Id VARCHAR(128)
AS
BEGIN
	DECLARE @Result AS TABLE
	(
		ResultStatus BIT,
		ResultMessage VARCHAR(50),
		LastKey INT
	)
	BEGIN TRY
		BEGIN TRANSACTION 
		IF NOT EXISTS(SELECT Id FROM Productos WHERE Id = @Id)
		BEGIN 
			INSERT INTO @Result(ResultStatus, ResultMessage, LastKey)
			SELECT 0, 'Error deleting data', 0

			ROLLBACK TRANSACTION 
		END
		ELSE
		BEGIN 
			UPDATE Productos
			SET
				Activo = 0
			WHERE Id = @Id

			INSERT INTO @Result(ResultStatus, ResultMessage, LastKey)
			SELECT 1, 'Successful deleting data', (SELECT SCOPE_IDENTITY())

			COMMIT TRANSACTION 
		END
	END TRY

	BEGIN CATCH
		IF @@TRANCOUNT > 0
		BEGIN
			ROLLBACK TRANSACTION 
		END
	END CATCH

	SELECT * FROM @Result
END
GO


--; VENTAS
-- ============================================
CREATE OR ALTER PROCEDURE 
	Usp_Ventas_Insert
		@Id VARCHAR(128),
		@Folio NVARCHAR(128),
		@CodigoCliente NVARCHAR(128),
		@Cantidad INT,
		@CodigoTasaIva INT,
		@PrecioUnitario DECIMAL(18,2),
		@SubTotal DECIMAL(18,2),
		@IVA DECIMAL(18,2),
		@ImporteTotal DECIMAL(18,2),
		@FechaVenta DATETIME,
		@Activo BIT
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @Result AS TABLE
	(
		ResultStatus BIT,
		ResultMessage VARCHAR(50),
		LastKey INT
	)
	BEGIN TRY
		BEGIN TRANSACTION 
		IF EXISTS(SELECT Id FROM Ventas WHERE Id = @Id)
		BEGIN 
			INSERT INTO @Result(ResultStatus, ResultMessage, LastKey)
			SELECT 0, 'Error inserting data', 0

			ROLLBACK TRANSACTION 
		END
		ELSE
		BEGIN 
			INSERT INTO Ventas
			(
				Id,
				Folio,
				CodigoCliente,
				Cantidad,
				CodigoTasaIva,
				PrecioUnitario,
				SubTotal,
				IVA, 
				ImporteTotal, 
				FechaVenta, 
				Activo
			)
			VALUES
			(
				@Id,
				@Folio,
				@CodigoCliente,
				@Cantidad,
				@CodigoTasaIva,
				@PrecioUnitario,
				@SubTotal,
				@IVA, 
				@ImporteTotal, 
				@FechaVenta, 
				@Activo
			)

			INSERT INTO @Result(ResultStatus, ResultMessage, LastKey)
			SELECT 1, 'Successful inserting data', (SELECT SCOPE_IDENTITY())

			COMMIT TRANSACTION 
		END
	END TRY

	BEGIN CATCH
		IF @@TRANCOUNT > 0
		BEGIN
			ROLLBACK TRANSACTION 
		END
	END CATCH

	SET NOCOUNT OFF;
	SELECT * FROM @Result
END
GO

-- ============================================
CREATE OR ALTER PROCEDURE
	Usp_Ventas_GetAll
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT
	C.Id
	, C.Folio
	, C.CodigoCliente
	, C.Cantidad
	, C.CodigoTasaIva
	, C.PrecioUnitario
	, C.SubTotal
	, C.IVA
	, C.ImporteTotal
	, C.FechaVenta
	, C.Activo
	FROM Ventas C (NOLOCK)

	SET NOCOUNT OFF;
END
GO

-- ============================================
CREATE PROCEDURE Usp_Ventas_GetPage
    @PageNumber INT,
    @PageSize INT,
    @Search NVARCHAR(100)
AS
BEGIN
	SET NOCOUNT ON;
    SELECT * 
    FROM Ventas
    WHERE Folio LIKE '%' + @Search + '%' 
       OR CodigoCliente LIKE '%' + @Search + '%'
    ORDER BY Folio
    OFFSET (@PageNumber - 1) * @PageSize ROWS
    FETCH NEXT @PageSize ROWS ONLY;

    SELECT COUNT(*) AS TotalCount 
    FROM Ventas
    WHERE Folio LIKE '%' + @Search + '%' 
       OR CodigoCliente LIKE '%' + @Search + '%';
	SET NOCOUNT OFF;
END
GO

-- ============================================
CREATE OR ALTER PROCEDURE Usp_Ventas_Update
		@Id VARCHAR(128),
		@Folio NVARCHAR(128),
		@CodigoCliente NVARCHAR(128),
		@Cantidad INT,
		@CodigoTasaIva INT,
		@PrecioUnitario DECIMAL(18,2),
		@SubTotal DECIMAL(18,2),
		@IVA DECIMAL(18,2),
		@ImporteTotal DECIMAL(18,2),
		@FechaVenta DATETIME,
		@Activo BIT
AS
BEGIN
	DECLARE @Result AS TABLE
	(
		ResultStatus BIT,
		ResultMessage VARCHAR(50),
		LastKey INT
	)
	BEGIN TRY
		BEGIN TRANSACTION 
		IF NOT EXISTS(SELECT Id FROM Ventas WHERE Id = @Id)
		BEGIN 
			INSERT INTO @Result(ResultStatus, ResultMessage, LastKey)
			SELECT 0, 'Error updating data', 0

			ROLLBACK TRANSACTION 
		END
		ELSE
		BEGIN 
			UPDATE Ventas
			SET
				Id = @Id,
				Folio = @Folio,
				CodigoCliente = @CodigoCliente,
				Cantidad = @Cantidad, 
				CodigoTasaIva = @CodigoTasaIva,
				PrecioUnitario = @PrecioUnitario,
				SubTotal = @SubTotal, 
				IVA = @IVA, 
				ImporteTotal= @ImporteTotal, 
				FechaVenta = @FechaVenta, 
				Activo = @Activo 	
			WHERE Id = @Id

			INSERT INTO @Result(ResultStatus, ResultMessage, LastKey)
			SELECT 1, 'Successful inserting data', (SELECT SCOPE_IDENTITY())

			COMMIT TRANSACTION 
		END
	END TRY

	BEGIN CATCH
		IF @@TRANCOUNT > 0
		BEGIN
			ROLLBACK TRANSACTION 
		END
	END CATCH

	SELECT * FROM @Result
END
GO

-- ============================================
CREATE OR ALTER PROCEDURE Usp_Ventas_Delete
	@Id VARCHAR(128)
AS
BEGIN
	DECLARE @Result AS TABLE
	(
		ResultStatus BIT,
		ResultMessage VARCHAR(50),
		LastKey INT
	)
	BEGIN TRY
		BEGIN TRANSACTION 
		IF NOT EXISTS(SELECT Id FROM Ventas WHERE Id = @Id)
		BEGIN 
			INSERT INTO @Result(ResultStatus, ResultMessage, LastKey)
			SELECT 0, 'Error deleting data', 0

			ROLLBACK TRANSACTION 
		END
		ELSE
		BEGIN 
			UPDATE Ventas
			SET
				Activo = 0
			WHERE Id = @Id

			INSERT INTO @Result(ResultStatus, ResultMessage, LastKey)
			SELECT 1, 'Successful deleting data', (SELECT SCOPE_IDENTITY())

			COMMIT TRANSACTION 
		END
	END TRY

	BEGIN CATCH
		IF @@TRANCOUNT > 0
		BEGIN
			ROLLBACK TRANSACTION 
		END
	END CATCH

	SELECT * FROM @Result
END
GO

