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
-- Description:	Get CalendarData by EmployeeID
-- =============================================
CREATE PROCEDURE proc_GetCalendarDataByEmployeeID 
	-- Add the parameters for the stored procedure here
	@EmployeeID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET FMTONLY OFF;
    -- Insert statements for procedure here
	SELECT EntryID, StartTime, EndTime, ClaimID, Note 
		FROM CalendarData
		WHERE EmployeeID = @EmployeeID;
END
GO
