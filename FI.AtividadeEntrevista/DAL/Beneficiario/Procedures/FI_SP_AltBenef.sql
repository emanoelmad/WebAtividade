CREATE PROC [FI_SP_AltBenef]
    @NOME          VARCHAR (50),
	@CPF           VARCHAR (11),
	@ID			BIGINT
AS
BEGIN
	UPDATE 
		[BENEFICIARIOS]
	SET 
		[CPF] = @CPF,
		[NOME] = @NOME
	WHERE
		[ID] = @ID
END