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
-- Description:	Adds new Claim
-- =============================================
CREATE PROCEDURE proc_AddClaim
	-- Add the parameters for the stored procedure here
		@CustomerID int,
        @ClaimNumber varchar(255),
        @InspectionID int,
        @DamageType varchar(50),
        @LossDate datetime,
        @Gutters bit,
        @Exterior bit,
        @Interior bit,
        @ReferralName varchar(50) = null,
        @MortgageCompany varchar(50) = null,
        @MortgageAccount varchar(50) = null,
        @LeadType bit,
        @InsuranceCompanyID int,
        @InsuranceClaimNumber varchar(255),

		@new_identity int = null OUTPUT

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SET FMTONLY OFF;

    -- Insert statements for procedure here
	INSERT INTO Claims
		(CustomerID,
        ClaimNumber,
        InspectionID,
        DamageType,
        LossDate,
        Gutters,
        Exterior,
        Interior,
        ReferralName,
        MortgageCompany,
        MortgageAccount,
        LeadType,
        InsuranceCompanyID,
        InsuranceClaimNumber)
	VALUES
		(@CustomerID,
        @ClaimNumber,
        @InspectionID,
        @DamageType,
        @LossDate,
        @Gutters,
        @Exterior,
        @Interior,
        @ReferralName,
        @MortgageCompany,
        @MortgageAccount,
        @LeadType,
        @InsuranceCompanyID,
        @InsuranceClaimNumber);


	SET @new_identity = IDENT_CURRENT('Claims');
END
GO



		   

		   