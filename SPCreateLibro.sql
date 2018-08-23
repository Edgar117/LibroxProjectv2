
-- =============================================
-- Author:      Edgar Vazquez
-- Create date: 23/08/2018
-- Description: sp Para insertar un nuevo libro y calcular el precio y su ranking si es la primera vez, si no se hace el update deacuerdo a la flag que se mande
-- =============================================

--#region StoredProcedure [dbo].[spInsertBook]
IF OBJECT_ID(N'[dbo].[spInsertBook]') IS NOT NULL
    DROP PROCEDURE [dbo].[spInsertBook]
GO

/*SET NOCOUNT ON added to prevent extra result sets from interfering with SELECT statements.*/
    SET NOCOUNT ON;
    /* for NULL values specifies ISO compliant behavior  */
    SET ANSI_NULLS ON;
    /* This is for use with double quotes the Strings */
    SET QUOTED_IDENTIFIER ON;
GO
CREATE PROCEDURE [dbo].[spInsertBook]
@IDLibro INT = NULL							 --ID del libro por si se va a actualizar
,@Titulo NVARCHAR(20)						 --Titulo del libro por si se va a actualizar o insertar
,@Sinopsis NVARCHAR(1000)						 --sinopsis del libro si seva actualizar o insertar
,@IDAutor INT								 --ID del autor para insertar y eliminar
,@Imagen NVARCHAR(30)						 --Imagen que tendra el libro
,@PRECIO INT							 --Precio del libro este se calcula 
,@Ranking INT							 --Ranking del libro este se calcula 
,@LibroFisico NVARCHAR(35)				--Ubicacion del libro fisico
AS
BEGIN
     --Variables que se usuaran

     DECLARE @Var4 INT; DECLARE @Var5 VARCHAR(400); DECLARE  @Var6 NVARCHAR(MAX)

    /*Store-Procedure Body*/
   
   IF @IDLibro IS NULL
   BEGIN
   INSERT INTO 
   END

    /*END Store-Procedure Body*/
 
END

GO