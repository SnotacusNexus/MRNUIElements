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
-- Description:	Adds new RoofMeasurements
-- =============================================
CREATE PROCEDURE proc_AddRoofMeasurements
	-- Add the parameters for the stored procedure here
		@ClaimID int,
		@SqOff float,
		@SqOn float,
		@Ridges float,
		@Hips float,
		@StepFlashing float,
		@Valleys float,
		@Rakes float,
		@Eaves float,
		@Starter float,
		@Pitch int,

		@new_identity int = null OUTPUT

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET FMTONLY OFF;

    -- Insert statements for procedure here
	IF NOT EXISTS (SELECT ClaimID FROM RoofMeasurements WHERE ClaimID = @ClaimID)
		BEGIN
			INSERT INTO RoofMeasurements
				(ClaimID,
				SqOff,
				SqOn,
				Ridges,
				Hips,
				StepFlashing,
				Valleys,
				Rakes,
				Eaves,
				Starter,
				Pitch)
			VALUES
				(@ClaimID,
				@SqOff,
				@SqOn,
				@Ridges,
				@Hips,
				@StepFlashing,
				@Valleys,
				@Rakes,
				@Eaves,
				@Starter,
				@Pitch);	

			SET @new_identity = IDENT_CURRENT('RoofMeasurements');
		END

END
GO


     
