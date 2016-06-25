-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Maggie Seigler
-- Create date: 4/6/2016
-- Description:	Returns user data
-- =============================================
CREATE PROCEDURE proc_GetUser
	-- Add the parameters for the stored procedure here
	@Username varchar(50),
	@EmployeeID int = null OUTPUT
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET FMTONLY OFF;

    -- Insert statements for procedure here
	SELECT * FROM Users
		WHERE Username = @Username;
	SET @EmployeeID = (SELECT EmployeeID FROM Users WHERE UserName = @UserName);
END
GO
