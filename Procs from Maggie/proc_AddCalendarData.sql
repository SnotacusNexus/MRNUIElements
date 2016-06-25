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
-- Create date: 4/5/2016
-- Description:	Adds new data to CalendarData table
-- =============================================
CREATE PROCEDURE proc_AddCalendarData
	-- Add the parameters for the stored procedure here
	@EmployeeID int,
	@StartTime datetime,
	@EndTime datetime,
	@ClaimID int = null,
	@Note varchar(255),
	@new_identity int = null OUTPUT
	-- add lock?
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET FMTONLY OFF;
    -- Insert statements for procedure here
	INSERT INTO CalendarData 
		(EmployeeID, 
		StartTime, 
		EndTime, 
		ClaimID, 
		Note)
	VALUES 
		(@EmployeeID, 
		@StartTime, 
		@EndTime, 
		@ClaimID, 
		@Note);
		
	SET @new_identity = IDENT_CURRENT('CalendarData');
END
GO

