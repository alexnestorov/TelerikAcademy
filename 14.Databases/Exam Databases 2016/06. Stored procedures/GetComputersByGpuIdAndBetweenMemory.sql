USE ComputersDb
GO
CREATE PROCEDURE dbo.usp_GetComputersWithGpuAndRamBetween
AS
BEGIN
	BEGIN  
		SELECT * FROM dbo.Computers
		WHERE GPUId = 2
		AND Memory LIKE '%8 GB%'
		OR Memory LIKE '%9 GB%'
		OR Memory LIKE '%10 GB%'
		OR Memory LIKE '%11 GB%'
		OR Memory LIKE '%12 GB%'
		OR Memory LIKE '%13 GB%'
		OR Memory LIKE '%14 GB%'
		OR Memory LIKE '%15 GB%'
		OR Memory LIKE '%16 GB%'
		
	END
END
GO


EXEC dbo.usp_GetComputersWithGpuAndRamBetween
GO