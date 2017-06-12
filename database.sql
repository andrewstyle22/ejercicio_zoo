/*
ALTER TABLE [dbo].[Especies]  WITH CHECK ADD  CONSTRAINT [FK__Especie_TipoAnimal] FOREIGN KEY([idTipoAnimal])
REFERENCES [dbo].[TiposAnimal] ([idTipoAnimal])
ON DELETE CASCADE
GO
*/

ALTER TABLE [dbo].[Especies]  WITH CHECK ADD  CONSTRAINT [FK__Especie_Clasificaciones] FOREIGN KEY([idClasificacion])
REFERENCES [dbo].[Clasificaciones] ([idClasificacion])
ON DELETE CASCADE
GO


/*

CREATE TABLE [dbo].[Clasificaciones](
	[idClasificaciones] [int] IDENTITY(1,1) NOT NULL,
	[denominacion] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Clasificaciones] PRIMARY KEY CLUSTERED 
(
	[idClasificaciones] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
*/
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


