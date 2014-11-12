USE Company
GO

CREATE PROCEDURE [dbo].[sp_createCacheTable]
AS
BEGIN
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('CacheTable') 
AND type in (N'U'))
	DROP TABLE [dbo].[CacheTable]

DECLARE @SQLString NVARCHAR(MAX)
    Set @SQLString = 'CREATE TABLE [CacheTable]
    (
		[Employee Full Name] [nvarchar](41) NOT NULL,
		[Project Name] [nvarchar](50) NOT NULL,
		[Department Name] [nvarchar](50) NOT NULL,
		[Starting Date] [date] NOT NULL,
		[Ending Date] [date] NOT NULL,
		[Reports For Project] [int] NOT NULL
	) ON [PRIMARY]'

EXEC (@SQLString)
END