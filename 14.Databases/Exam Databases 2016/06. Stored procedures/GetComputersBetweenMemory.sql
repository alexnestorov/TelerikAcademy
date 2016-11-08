USE ComputersDb
GO
CREATE PROCEDURE dbo.usp_GetComputersWithRamBetween
AS
BEGIN
	BEGIN  
		SELECT Vendor, Model, Id FROM dbo.Computers
		WHERE Memory LIKE '%1 GB%'
		OR Memory LIKE '%2 GB%'
		OR Memory LIKE '%3 GB%'
		OR Memory LIKE '%4 GB%'
		OR Memory LIKE '%5 GB%'
		OR Memory LIKE '%6 GB%'
	END
END
GO


EXEC dbo.usp_GetComputersWithRamBetween
GO
