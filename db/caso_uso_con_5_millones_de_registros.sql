USE [Wagner]
GO

-- ==========================================================================================================
-- Author:					Victor Cruz
-- Create date: 2025/01/09
-- Description: Caso de Uso el cual crea 5 millones de registros en una tabla temporal
-- ==========================================================================================================

IF EXISTS(SELECT 1 FROM tempdb.sys.objects WHERE object_id = OBJECT_ID('tempdb..#CasoUsoTemporal'))
BEGIN
	DROP TABLE #CasoUsoTemporal
	PRINT (' ');
	PRINT ('--; La tabla temporal #CasoUsoTemporal ha sido borrada.');
END
ELSE BEGIN
	PRINT (' ');
	PRINT ('--; La tabla temporal #CasoUsoTemporal no existe.');
END
GO

CREATE TABLE #CasoUsoTemporal
(
    Id INT IDENTITY(1,1),
    CasoUsoTexto1 NVARCHAR(50),
    CasoUsoTexto2 NVARCHAR(50),
    CasoUsoTexto3 NVARCHAR(50),
    CasoUsoTexto4 NVARCHAR(50),
    CasoUso1 INT,
    CasoUso2 DECIMAL(18,2),
    CasoUso3 FLOAT,
    CasoUso4 INT,
    CasoUso5 DECIMAL(18,2)
);

ALTER TABLE #CasoUsoTemporal
	ADD CONSTRAINT PK_CasoUsoTemporal_Id PRIMARY KEY (Id);
CREATE NONCLUSTERED INDEX IX_CasoUsoTemporal_Id
	ON #CasoUsoTemporal (Id);
CREATE NONCLUSTERED INDEX IX_CasoUsoTemporal_CasoUsoTexto1
	ON #CasoUsoTemporal (CasoUsoTexto1);

--; poblacion de la tabla temporal
DECLARE @value INT = 1;
DECLARE @total INT = 5000000;

WHILE @value <= @total
BEGIN
    INSERT INTO #CasoUsoTemporal (CasoUsoTexto1, CasoUsoTexto2, CasoUsoTexto3, CasoUsoTexto4, CasoUso1, CasoUso2, CasoUso3, CasoUso4, CasoUso5)
    SELECT 
        'Texto' + CAST(@value AS NVARCHAR(50)),
        'Texto' + CAST(@value + 1 AS NVARCHAR(50)),
        'Texto' + CAST(@value + 2 AS NVARCHAR(50)),
        'Texto' + CAST(@value + 3 AS NVARCHAR(50)),
        @value % 100,
        RAND() * 1000,
        RAND() * 500,
        @value % 200,
        RAND() * 3000;
    
    SET @value += 1;
END;

--; SELECT * FROM #CasoDeUsoTemporal
--; Mostrar los datos paginados
DECLARE @PageNumber INT 
SET @PageNumber = 1
DECLARE @PageSize INT
SET @PageSize = 50

SELECT * 
FROM #CasoUsoTemporal
ORDER BY Id
OFFSET (@PageNumber - 1) * @PageSize ROWS
FETCH NEXT @PageSize ROWS ONLY;

--; Total de datos en tabla temporal
SELECT COUNT(*) AS TotalCount 
FROM #CasoUsoTemporal;
