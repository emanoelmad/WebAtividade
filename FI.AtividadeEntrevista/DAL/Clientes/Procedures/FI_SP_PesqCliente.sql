﻿CREATE PROC FI_SP_PesqCliente
    @iniciarEm int,
    @quantidade int,
    @campoOrdenacao varchar(200),
    @crescente bit	
AS
BEGIN
    DECLARE @SCRIPT NVARCHAR(MAX)
    DECLARE @CAMPOS NVARCHAR(MAX)
    DECLARE @ORDER VARCHAR(50)
	
    IF(@campoOrdenacao = 'EMAIL')
        SET @ORDER =  ' EMAIL '
    ELSE
        SET @ORDER = ' NOME '

    IF(@crescente = 0)
        SET @ORDER = @ORDER + ' DESC'
    ELSE
        SET @ORDER = @ORDER + ' ASC'

    SET @CAMPOS = '@iniciarEm int,@quantidade int'

    SET @SCRIPT = 
    'SELECT ID, NOME, SOBRENOME, NACIONALIDADE, CEP, ESTADO, CIDADE, LOGRADOURO, EMAIL, TELEFONE, CPF FROM
        (
            SELECT ROW_NUMBER() OVER (ORDER BY ' + @ORDER + ') AS Row, 
                   ID, NOME, SOBRENOME, NACIONALIDADE, CEP, ESTADO, CIDADE, LOGRADOURO, EMAIL, TELEFONE, CPF 
            FROM CLIENTES WITH(NOLOCK)
        ) AS ClientesWithRowNumbers
     WHERE Row > @iniciarEm AND Row <= (@iniciarEm + @quantidade)
     ORDER BY ' + @ORDER

    EXECUTE SP_EXECUTESQL @SCRIPT, @CAMPOS, @iniciarEm, @quantidade

    SELECT COUNT(1) FROM CLIENTES WITH(NOLOCK)
END
