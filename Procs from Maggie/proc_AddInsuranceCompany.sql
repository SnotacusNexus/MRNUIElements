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
-- Description:	Add an InsuranceCompany
-- =============================================
CREATE PROCEDURE proc_AddInsuranceCompany
	-- Add the parameters for the stored procedure here
		@CompanyName varchar(255),
        @CompanyAddress varchar(255),
        @Zip varchar(10) = null,
        @TollFreeNumber varchar(12),
        @ClaimPhoneNumber varchar(12),
        @ClaimPhoneExt varchar(10) = null,
        @FaxNumber varchar(12) = null,
        @FaxExt varchar(10) = null,
        @Email varchar(100),
        @Independent bit,

		@new_identity int = null OUTPUT

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET FMTONLY OFF;

    -- Insert statements for procedure here
	INSERT INTO InsuranceCompanies
		(CompanyName,
        CompanyAddress,
        Zip,
        TollFreeNumber,
        ClaimPhoneNumber,
        ClaimPhoneExt,
        FaxNumber,
        FaxExt,
        Email,
        Independent)
	VALUES
		(@CompanyName,
        @CompanyAddress,
        @Zip,
        @TollFreeNumber,
        @ClaimPhoneNumber,
        @ClaimPhoneExt,
        @FaxNumber,
        @FaxExt,
        @Email,
        @Independent);

	SET @new_identity = IDENT_CURRENT('InsuranceCompanies');
END
GO
    