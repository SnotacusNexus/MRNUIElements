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
-- Description:	Adds new Inspection
-- =============================================
CREATE PROCEDURE proc_AddInspection
	-- Add the parameters for the stored procedure here
		@SkyLights bit,
		@Leaks bit,
		@GutterDamage bit,
		@DrivewayDamage bit,
		@MagneticRollers bit,
		@IceWaterShield bit,
		@EmergencyRepair bit,
		@QualityControl bit,
		@ProtectLandscaping bit,
		@RemoveTrash bit,
		@TwoStories bit,
		@FurnishPermit bit,
		@CoverPool bit,
		@InteriorDamage varchar(255),
		@ExteriorDamage varchar(255),
		@Comments varchar(255) = null,
		@new_identity int = null OUTPUT

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET FMTONLY OFF;

    -- Insert statements for procedure here
	INSERT INTO Inspections 
		(SkyLights, 
		Leaks, 
		GutterDamage, 
		DrivewayDamage, 
		MagneticRollers, 
		IceWaterShield, 
		EmergencyRepair, 
		QualityControl, 
		ProtectLandscaping, 
		RemoveTrash, 
		TwoStories, 
		FurnishPermit, 
		CoverPool, 
		InteriorDamage, 
		ExteriorDamage, 
		Comments)
    VALUES 
		(@SkyLights,
		@Leaks,
		@GutterDamage,
		@DrivewayDamage,
		@MagneticRollers,
		@IceWaterShield,
		@EmergencyRepair,
		@QualityControl,
		@ProtectLandscaping,
		@RemoveTrash,
		@TwoStories,
		@FurnishPermit,
		@CoverPool,
		@InteriorDamage,
		@ExteriorDamage,
		@Comments)

		SET @new_identity = IDENT_CURRENT('Inspections');
END
GO



			