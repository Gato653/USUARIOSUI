USE [UsuariosDB]
GO
/****** Object:  StoredProcedure [dbo].[VerificarUsuarioid]    Script Date: 23/10/2023 01:01:43 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ==========================================================================================
-- Author:		<Author,,Gerald Laguna>
-- Create date: <Create 19/10/23,,>
-- Description:	<optiene un resultado si existe un usuaria para iniciar sesión,,>
-- ==========================================================================================

ALTER PROCEDURE [dbo].[VerificarUsuarioid]

@pusername NVARCHAR(50),
@ppasword NVARCHAR(180)

AS

BEGIN

   SET NOCOUNT ON; 
   -- Verificar si el usuario existe y la contraseña coincide 
   IF EXISTS (
      SELECT 1 FROM T_Usuarios  
            WHERE NombreUsuario = @pusername
			AND  ContraseñaUsuario = @ppasword

  )
  BEGIN 
      -- El usuario y/o contraseña son validos 
       SELECT 'Éxito al iniciar sesión' AS Estado
  END  
    ELSE
       BEGIN 
       -- El usuario y/o contraseña son incorrectos  
       SELECT 'Érror,el usuario o la contraseña no son validos' AS Estado
      END
  END
