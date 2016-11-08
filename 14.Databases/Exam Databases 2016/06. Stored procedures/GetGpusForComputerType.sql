USE ComputersDb
GO
CREATE PROCEDURE dbo.usp_GetGpusForComputerType
AS
BEGIN
	BEGIN  
		SELECT * FROM dbo.GPUs
		INNER JOIN Computers c
		ON GPUId = c.Id
		WHERE ComputerType = 'Ultrabook'
	END
END
GO


EXEC dbo.usp_GetGpusForComputerType
GO