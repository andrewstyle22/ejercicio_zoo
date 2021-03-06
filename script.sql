/*
USE [zoodb]
GO
/****** Object:  User [testuser]    Script Date: 12/06/2017 19:00:34 ******/
/*CREATE USER [testuser] FOR LOGIN [testuser] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [testuser]
GO*/
/****** Object:  Table [dbo].[Clasificaciones]    Script Date: 12/06/2017 19:00:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clasificaciones](
	[idClasificacion] [int] IDENTITY(1,1) NOT NULL,
	[denominacion] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Clasificaciones] PRIMARY KEY CLUSTERED 
(
	[idClasificacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Especies]    Script Date: 12/06/2017 19:00:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Especies](
	[idEspecie] [bigint] IDENTITY(1,1) NOT NULL,
	[idClasificacion] [int] NOT NULL,
	[idTipoAnimal] [bigint] NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[nPatas] [smallint] NOT NULL,
	[esMascotas] [bit] NOT NULL,
 CONSTRAINT [PK_Especies] PRIMARY KEY CLUSTERED 
(
	[idEspecie] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TiposAnimal]    Script Date: 12/06/2017 19:00:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TiposAnimal](
	[idTipoAnimal] [bigint] IDENTITY(1,1) NOT NULL,
	[denominacion] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TiposAnimal] PRIMARY KEY CLUSTERED 
(
	[idTipoAnimal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Clasificaciones] ON 

INSERT [dbo].[Clasificaciones] ([idClasificacion], [denominacion]) VALUES (1, N'Ovíparos')
INSERT [dbo].[Clasificaciones] ([idClasificacion], [denominacion]) VALUES (2, N'Vivíparos')
INSERT [dbo].[Clasificaciones] ([idClasificacion], [denominacion]) VALUES (3, N'Ovovivíparos')
INSERT [dbo].[Clasificaciones] ([idClasificacion], [denominacion]) VALUES (4, N'Omnívoros')
INSERT [dbo].[Clasificaciones] ([idClasificacion], [denominacion]) VALUES (5, N'Carnívoros')
INSERT [dbo].[Clasificaciones] ([idClasificacion], [denominacion]) VALUES (6, N'Herbívoros')
SET IDENTITY_INSERT [dbo].[Clasificaciones] OFF
SET IDENTITY_INSERT [dbo].[Especies] ON 

INSERT [dbo].[Especies] ([idEspecie], [idClasificacion], [idTipoAnimal], [nombre], [nPatas], [esMascotas]) VALUES (1, 1, 1, N'Peces', 0, 0)
INSERT [dbo].[Especies] ([idEspecie], [idClasificacion], [idTipoAnimal], [nombre], [nPatas], [esMascotas]) VALUES (2, 2, 6, N'Monos', 2, 1)
INSERT [dbo].[Especies] ([idEspecie], [idClasificacion], [idTipoAnimal], [nombre], [nPatas], [esMascotas]) VALUES (3, 5, 2, N'León', 4, 0)
INSERT [dbo].[Especies] ([idEspecie], [idClasificacion], [idTipoAnimal], [nombre], [nPatas], [esMascotas]) VALUES (4, 6, 4, N'Pajaro', 0, 1)
INSERT [dbo].[Especies] ([idEspecie], [idClasificacion], [idTipoAnimal], [nombre], [nPatas], [esMascotas]) VALUES (5, 4, 2, N'Cerdo', 4, 1)
INSERT [dbo].[Especies] ([idEspecie], [idClasificacion], [idTipoAnimal], [nombre], [nPatas], [esMascotas]) VALUES (6, 3, 4, N'Serpiente', 0, 1)
INSERT [dbo].[Especies] ([idEspecie], [idClasificacion], [idTipoAnimal], [nombre], [nPatas], [esMascotas]) VALUES (7, 5, 3, N'Ciempiés', 100, 0)
INSERT [dbo].[Especies] ([idEspecie], [idClasificacion], [idTipoAnimal], [nombre], [nPatas], [esMascotas]) VALUES (8, 4, 2, N'Hormiga', 8, 1)
INSERT [dbo].[Especies] ([idEspecie], [idClasificacion], [idTipoAnimal], [nombre], [nPatas], [esMascotas]) VALUES (9, 3, 4, N'Araña', 10, 0)
INSERT [dbo].[Especies] ([idEspecie], [idClasificacion], [idTipoAnimal], [nombre], [nPatas], [esMascotas]) VALUES (10, 5, 3, N'Elefante', 4, 1)
SET IDENTITY_INSERT [dbo].[Especies] OFF
SET IDENTITY_INSERT [dbo].[TiposAnimal] ON 

INSERT [dbo].[TiposAnimal] ([idTipoAnimal], [denominacion]) VALUES (1, N'ACUÁTICOS')
INSERT [dbo].[TiposAnimal] ([idTipoAnimal], [denominacion]) VALUES (2, N'TERRESTRES')
INSERT [dbo].[TiposAnimal] ([idTipoAnimal], [denominacion]) VALUES (3, N'INVERTEBRADOS')
INSERT [dbo].[TiposAnimal] ([idTipoAnimal], [denominacion]) VALUES (4, N'VERTEBRADOS')
INSERT [dbo].[TiposAnimal] ([idTipoAnimal], [denominacion]) VALUES (5, N'CUADRÚPEDOS')
INSERT [dbo].[TiposAnimal] ([idTipoAnimal], [denominacion]) VALUES (6, N'BÍPEDOS')
SET IDENTITY_INSERT [dbo].[TiposAnimal] OFF
ALTER TABLE [dbo].[Especies]  WITH CHECK ADD  CONSTRAINT [FK__Especie_Clasificaciones] FOREIGN KEY([idClasificacion])
REFERENCES [dbo].[Clasificaciones] ([idClasificacion])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Especies] CHECK CONSTRAINT [FK__Especie_Clasificaciones]
GO
ALTER TABLE [dbo].[Especies]  WITH CHECK ADD  CONSTRAINT [FK__Especie_TipoAnimal] FOREIGN KEY([idTipoAnimal])
REFERENCES [dbo].[TiposAnimal] ([idTipoAnimal])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Especies] CHECK CONSTRAINT [FK__Especie_TipoAnimal]
GO

create procedure Get_Clasificaciones
as
Begin
	select idClasificacion, denominacion from Clasificaciones
end;
go

create procedure Get_TiposAnimal
as
Begin
	select idTipoAnimal, denominacion from TiposAnimal
end;
go

create procedure  Get_Especies
as
Begin
	SELECT e.idEspecie, c.idClasificacion,c.denominacion as ClasificacionDenominacion,tp.idTipoAnimal, 
	       tp.denominacion as AnimalDenominacion,e.nombre,e.nPatas,e.esMascotas
		FROM Especies as e
		inner join Clasificaciones as c 
		on e.idClasificacion = c.idClasificacion
		inner join TiposAnimal as  tp 
		on e.idTipoAnimal = tp.idTipoAnimal
		group by 
			e.idEspecie,
			c.idClasificacion, 
			c.denominacion,
			tp.idTipoAnimal, 
			tp.denominacion,
			e.nombre,
			e.nPatas,
			e.esMascotas
		order by e.nombre
end;
go

create procedure Get_Clasificaciones_Id 
	@idClasificacion int
as
Begin
	select idClasificacion, denominacion from Clasificaciones
		where idClasificacion = @idClasificacion
end;
  
 --- exec Get_Clasificaciones_Id 2
go

create procedure Get_TiposAnimal_Id
	@idTipoAnimal bigint
as
Begin
	select idTipoAnimal, denominacion from TiposAnimal
		where idTipoAnimal = @idTipoAnimal
end;
go
  --exec Get_TiposAnimal_Id 3
  
create procedure Get_Especies_Id
	@idEspecie bigint
as
Begin
	SELECT e.idEspecie, c.idClasificacion,c.denominacion as ClasificacionDenominacion,tp.idTipoAnimal, 
	       tp.denominacion as AnimalDenominacion,e.nombre,e.nPatas,e.esMascotas
		FROM Especies as e
		inner join Clasificaciones as c 
		on e.idClasificacion = c.idClasificacion
		inner join TiposAnimal as  tp 
		on e.idTipoAnimal = tp.idTipoAnimal
		where e.idEspecie = @idEspecie
		group by 
			e.idEspecie,
			c.idClasificacion, 
			c.denominacion,
			tp.idTipoAnimal, 
			tp.denominacion,
			e.nombre,
			e.nPatas,
			e.esMascotas
		order by e.nombre
end;

 -- exec Get_Especies_Id 6
go

create procedure ActualizarClasificaciones
  	@idClasificacion int,
	@denominacion nvarchar(50)
as
begin
	UPDATE Clasificaciones SET denominacion = @denominacion where idClasificacion = @idClasificacion
end;
go

create procedure ActualizarTiposAnimal
  	@idTipoAnimal int,
	@denominacion nvarchar(50)
as
begin
	UPDATE TiposAnimal SET denominacion = @denominacion where idTipoAnimal = @idTipoAnimal
end;
go
--exec ActualizarTiposAnimal 8, "TipoAnimal9"

--exec ActualizarClasificaciones 1,'Ovíparos'

CREATE PROCEDURE EliminarClasificaciones
    @idClasificacion int
AS
BEGIN
    DELETE FROM Clasificaciones WHERE idClasificacion = @idClasificacion 
END;
go

CREATE PROCEDURE EliminarTipoAnimal
    @idTipoAnimal bigint
AS
BEGIN
    DELETE FROM TiposAnimal WHERE idTipoAnimal = @idTipoAnimal 
END;
go


CREATE PROCEDURE EliminarEspecie
    @idEspecie bigint
AS
BEGIN
    DELETE FROM Especies WHERE idEspecie = @idEspecie
END;
go

create procedure InsertarClasificacion
	@denominacion nvarchar(50)
AS
BEGIN
	INSERT [dbo].[Clasificaciones] ( [denominacion]) VALUES (@denominacion)
END;
GO

create procedure InsertarTipoAnimal
	@denominacion nvarchar(50)
AS
BEGIN
	INSERT [dbo].[TiposAnimal] ( [denominacion]) VALUES (@denominacion)
END;
GO

--SET IDENTITY_INSERT [dbo].[Clasificaciones] OFF
--exec InsertarClasificacion "robin"
--exec InsertarTipoAnimal "Un solo pie"

create procedure ActualizarEspecie
	 @idEspecie bigint
	,@idClasificacion int
	,@idTipoAnimal bigint
	,@nombre nvarchar(50)
	,@nPatas smallint
	,@esMascotas bit
as
Begin
UPDATE Especies 
	SET   idClasificacion = @idClasificacion
		 ,idTipoAnimal    = @idTipoAnimal
		 ,nombre          = @nombre
		 ,nPatas          = @nPatas
		 ,esMascotas      = @esMascotas
	WHERE idEspecie = @idEspecie
end;
go

create procedure InsertarEspecie
	 @idClasificacion int
	,@idTipoAnimal bigint
	,@nombre nvarchar(50)
	,@nPatas smallint
	,@esMascotas bit
as
Begin
INSERT INTO Especies (
		  idClasificacion
		 ,idTipoAnimal
		 ,nombre  
		 ,nPatas
		 ,esMascotas
		 )
		 values(
		  @idClasificacion
		 ,@idTipoAnimal
		 ,@nombre
		 ,@nPatas
		 ,@esMascotas
		 )
end;
go
*/