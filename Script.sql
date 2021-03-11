USE [DesignacionArbitral]
GO
/****** Object:  Table [dbo].[Arbitro]    Script Date: 10/3/2021 22:25:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Arbitro](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NULL,
	[Apellido] [nvarchar](100) NULL,
	[FechaNacimiento] [date] NULL,
	[IdGenero] [bigint] NULL,
	[Ranking] [bigint] NULL,
	[IdNivel] [bigint] NULL,
	[IdDeporte] [bigint] NULL,
	[Habilitado] [bit] NULL,
	[Dni] [bigint] NULL,
	[NotaAFA] [int] NULL,
	[PoseeTituloValidoArgentina] [bit] NULL,
	[PoseeLicenciaInternacional] [bit] NULL,
	[ExamenFisicoAprobado] [bit] NULL,
	[ExamenTeoricoAprobado] [bit] NULL,
	[AniosExperiencia] [int] NULL,
 CONSTRAINT [PK_Arbitro] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ArbitroAud]    Script Date: 10/3/2021 22:25:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArbitroAud](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Apellido] [varchar](100) NOT NULL,
	[FechaNacimiento] [datetime] NOT NULL,
	[IdGenero] [bigint] NOT NULL,
	[Ranking] [bigint] NOT NULL,
	[IdNivel] [bigint] NOT NULL,
	[IdDeporte] [bigint] NOT NULL,
	[Estado] [bit] NOT NULL,
	[IdArbitro] [bigint] NOT NULL,
	[IdBitacora] [bigint] NOT NULL,
	[Dni] [bigint] NULL,
	[NotaAFA] [int] NULL,
	[TituloValidoArgentina] [bit] NULL,
	[LicenciaInternacional] [bit] NULL,
	[ExamenFisico] [bit] NULL,
	[ExamenTeorico] [bit] NULL,
	[AniosExperiencia] [int] NULL,
 CONSTRAINT [PK_Arbitro_Aud] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bitacora]    Script Date: 10/3/2021 22:25:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bitacora](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [bigint] NOT NULL,
	[IdTipoEvento] [bigint] NOT NULL,
	[Descripcion] [varchar](100) NULL,
	[Fecha] [datetime] NOT NULL,
 CONSTRAINT [PK_Bitacora] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Calificacion]    Script Date: 10/3/2021 22:25:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Calificacion](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ReglasPuntaje] [int] NULL,
	[DisciplinaPuntaje] [int] NULL,
	[CondicionFisicaPuntaje] [int] NULL,
	[JugadasPuntaje] [int] NULL,
	[DificultadPartidoPuntaje] [float] NULL,
 CONSTRAINT [PK_Calificacion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Campeonato]    Script Date: 10/3/2021 22:25:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Campeonato](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](100) NULL,
	[IdFixture] [bigint] NULL,
	[IdCategoria] [bigint] NULL,
 CONSTRAINT [PK_Campeonato] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 10/3/2021 22:25:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](100) NULL,
	[IdDeporte] [bigint] NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Deporte]    Script Date: 10/3/2021 22:25:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Deporte](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](100) NULL,
 CONSTRAINT [PK_Deporte] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DVV]    Script Date: 10/3/2021 22:25:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DVV](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[NombreTabla] [varchar](50) NOT NULL,
	[Valor] [varchar](max) NOT NULL,
 CONSTRAINT [PK_DVV] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Equipo]    Script Date: 10/3/2021 22:25:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Equipo](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NULL,
	[Ponderacion] [tinyint] NULL,
	[IdCategoria] [bigint] NULL,
 CONSTRAINT [PK_Equipo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fecha]    Script Date: 10/3/2021 22:25:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fecha](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdFixture] [bigint] NULL,
	[FechaDesde] [datetime] NULL,
	[FechaHasta] [datetime] NULL,
	[Nombre] [nvarchar](50) NULL,
	[Numero] [bigint] NULL,
	[Designado] [bit] NULL,
 CONSTRAINT [PK_Fecha] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fixture]    Script Date: 10/3/2021 22:25:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fixture](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](50) NULL,
 CONSTRAINT [PK_Fixture_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genero]    Script Date: 10/3/2021 22:25:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genero](
	[Id] [bigint] NOT NULL,
	[Descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_Genero] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Idioma]    Script Date: 10/3/2021 22:25:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Idioma](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Idioma] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Leyenda]    Script Date: 10/3/2021 22:25:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Leyenda](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Etiqueta] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Nivel]    Script Date: 10/3/2021 22:25:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nivel](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[NombreNivel] [nvarchar](100) NULL,
	[IdDeporte] [bigint] NULL,
 CONSTRAINT [PK_Nivel] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NivelRegla]    Script Date: 10/3/2021 22:25:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NivelRegla](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdNivel] [bigint] NOT NULL,
	[IdCategoria] [bigint] NOT NULL,
	[IdTipoArbitro] [bigint] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Partido]    Script Date: 10/3/2021 22:25:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Partido](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdEquipo1] [bigint] NULL,
	[IdEquipo2] [bigint] NULL,
	[Prioridad] [bigint] NULL,
	[Fecha] [datetime] NULL,
	[IdFecha] [bigint] NULL,
 CONSTRAINT [PK_Partido] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PartidoArbitro]    Script Date: 10/3/2021 22:25:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PartidoArbitro](
	[IdPartido] [bigint] NOT NULL,
	[IdArbitro] [bigint] NOT NULL,
	[IdTipoArbitro] [bigint] NULL,
	[IdCalificacion] [bigint] NULL,
	[Procesado] [bit] NULL,
 CONSTRAINT [Id_Arbitro] PRIMARY KEY CLUSTERED 
(
	[IdPartido] ASC,
	[IdArbitro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permiso]    Script Date: 10/3/2021 22:25:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permiso](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
	[EsPermiso] [bit] NOT NULL,
 CONSTRAINT [PK_Permiso] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PermisoPermiso]    Script Date: 10/3/2021 22:25:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PermisoPermiso](
	[IdPadre] [bigint] NULL,
	[IdHijo] [bigint] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Resguardo]    Script Date: 10/3/2021 22:25:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Resguardo](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[NombreArchivo] [varchar](50) NOT NULL,
	[Directorio] [varchar](max) NOT NULL,
 CONSTRAINT [PK_Backup] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoArbitro]    Script Date: 10/3/2021 22:25:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoArbitro](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdDeporte] [bigint] NULL,
	[Descripcion] [nvarchar](50) NULL,
 CONSTRAINT [PK_TipoArbitro] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoEvento]    Script Date: 10/3/2021 22:25:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoEvento](
	[Id] [bigint] NOT NULL,
	[Descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_TipoEvento] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Traduccion]    Script Date: 10/3/2021 22:25:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Traduccion](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdIdioma] [bigint] NOT NULL,
	[IdLeyenda] [bigint] NOT NULL,
	[TextoTraducido] [varchar](max) NULL,
 CONSTRAINT [PK_Traduccion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 10/3/2021 22:25:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Apellido] [varchar](50) NULL,
	[Nombre] [varchar](50) NULL,
	[NombreUsuario] [varchar](50) NOT NULL,
	[Password] [varchar](max) NOT NULL,
	[Activo] [bit] NOT NULL,
	[IdIdioma] [bigint] NULL,
	[DVH] [varchar](max) NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsuarioPermiso]    Script Date: 10/3/2021 22:25:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuarioPermiso](
	[IdPermiso] [bigint] NOT NULL,
	[IdUsuario] [bigint] NOT NULL,
 CONSTRAINT [PK_UsuarioPermiso] PRIMARY KEY CLUSTERED 
(
	[IdPermiso] ASC,
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Arbitro] ON 

INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (1, N' DARIO', N'SANTAMARIA', CAST(N'1973-04-06' AS Date), 1, 1, 1, 1, 1, 1, 10, 1, 1, 1, 1, 15)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (2, N' BAIS', N'MARCELO', CAST(N'1974-05-25' AS Date), 1, 2, 1, 1, 1, 1, 10, 1, 1, 1, 1, 14)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (3, N' LEANDRO', N'LORENZO', CAST(N'1977-08-18' AS Date), 1, 3, 1, 1, 1, 1, 10, 1, 1, 1, 1, 14)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (4, N' JUAN PABLO', N'GALLEGO', CAST(N'1978-03-21' AS Date), 1, 4, 1, 1, 1, 1, 10, 1, 1, 1, 1, 16)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (5, N' DIEGO', N'RICCIO', CAST(N'1978-11-20' AS Date), 1, 5, 1, 1, 1, 1, 9, 1, 1, 1, 1, 17)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (6, N' PATRICIO', N'BALINER', CAST(N'1982-07-24' AS Date), 1, 6, 1, 1, 1, 1, 9, 1, 1, 1, 1, 10)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (7, N' ANDRES', N'PENA', CAST(N'1984-09-15' AS Date), 1, 7, 1, 1, 1, 1, 9, 1, 1, 1, 1, 10)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (8, N' DARIO', N'COLOMBANI', CAST(N'1984-12-21' AS Date), 1, 8, 1, 1, 1, 1, 9, 1, 1, 1, 1, 10)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (9, N' FABIO', N'PATE', CAST(N'1985-08-09' AS Date), 1, 9, 1, 1, 1, 1, 9, 1, 1, 1, 1, 10)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (10, N' FERNANDO', N'LABALLOS', CAST(N'1985-10-07' AS Date), 1, 10, 1, 1, 1, 1, 9, 1, 1, 1, 1, 2)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (11, N' MARIANO', N'ROMO', CAST(N'1987-09-13' AS Date), 1, 11, 1, 1, 1, 1, 9, 1, 1, 1, 1, 4)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (12, N' PABLO', N'DEL PUERTO', CAST(N'1987-12-11' AS Date), 1, 12, 1, 1, 1, 1, 9, 1, 1, 1, 1, 6)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (13, N' IVAN', N'ALIENDE', CAST(N'1969-12-03' AS Date), 1, 13, 1, 1, 1, 1, 9, 1, 1, 1, 1, 8)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (14, N' NAHUEL', N'RASULLO', CAST(N'1989-09-28' AS Date), 1, 14, 1, 1, 1, 1, 9, 1, 1, 1, 1, 9)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (15, N' ARNALDO', N'MELGAREJO', CAST(N'1990-06-16' AS Date), 1, 15, 1, 1, 1, 1, 9, 1, 1, 1, 1, 7)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (16, N' HERNAN', N'FERNANDEZ', CAST(N'1992-04-10' AS Date), 1, 16, 1, 1, 1, 1, 9, 1, 1, 1, 1, 5)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (17, N' JULIO', N'VERON', CAST(N'1993-01-08' AS Date), 1, 17, 1, 1, 1, 1, 9, 1, 1, 1, 1, 4)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (18, N' PABLO', N'DEFELLIPI', CAST(N'1993-06-19' AS Date), 1, 18, 1, 1, 1, 1, 9, 1, 1, 1, 1, 3)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (19, N' CARLOS', N'MAIDANA', CAST(N'1994-07-18' AS Date), 1, 19, 1, 1, 1, 1, 9, 1, 1, 1, 1, 6)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (20, N' CRISTIAN', N'SCORZA', CAST(N'1997-03-31' AS Date), 1, 20, 1, 1, 1, 1, 9, 1, 0, 1, 1, 7)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (21, N' FERNANDO', N'RODRIGUEZ', CAST(N'2000-02-26' AS Date), 1, 21, 1, 1, 1, 1, 9, 1, 0, 1, 1, 8)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (22, N' EMANUEL', N'VIERA', CAST(N'2004-03-12' AS Date), 1, 22, 1, 1, 1, 1, 9, 1, 0, 1, 1, 5)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (23, N' LUIS', N'ROTMAN', CAST(N'2007-03-12' AS Date), 1, 23, 1, 1, 1, 1, 8, 1, 0, 1, 1, 4)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (24, N' GONZALO', N'ARIN DE FREITAS', CAST(N'2009-11-10' AS Date), 1, 24, 1, 1, 1, 1, 8, 1, 0, 1, 1, 4)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (25, N' PABLO', N'ACEVEDO', CAST(N'2010-02-18' AS Date), 1, 25, 1, 1, 1, 1, 8, 1, 0, 1, 1, 5)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (26, N' MANUEL', N'ZUNINO', CAST(N'1969-05-25' AS Date), 1, 26, 1, 1, 1, 1, 8, 1, 0, 1, 1, 6)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (27, N' FACUNDO', N'NOSACH', CAST(N'1971-04-30' AS Date), 1, 27, 1, 1, 1, 1, 8, 1, 0, 1, 1, 7)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (28, N' RODRIGO', N'MOLINA', CAST(N'1974-10-16' AS Date), 1, 28, 1, 1, 1, 1, 8, 1, 0, 1, 1, 8)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (29, N' GABRIEL', N'VILLAREAL', CAST(N'1978-01-13' AS Date), 1, 29, 1, 1, 1, 1, 8, 1, 0, 1, 1, 9)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (30, N' PATRICIO', N'POZZI', CAST(N'1978-02-27' AS Date), 1, 30, 1, 1, 1, 1, 8, 1, 0, 1, 1, 1)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (31, N' SOFIA', N'MARTINEZ', CAST(N'1983-10-14' AS Date), 1, 31, 1, 1, 1, 1, 8, 1, 0, 1, 1, 2)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (32, N' CECILIO', N'CALCAGNO', CAST(N'1984-04-02' AS Date), 1, 32, 1, 1, 1, 1, 8, 1, 0, 1, 1, 3)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (33, N' LUCAS', N'CUETO', CAST(N'1985-07-23' AS Date), 1, 33, 2, 1, 1, 1, 8, 1, 0, 1, 1, 4)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (34, N'JULIAN', N'GUZMAN', CAST(N'1986-03-12' AS Date), 1, 34, 2, 1, 1, 1, 8, 1, 0, 1, 1, 5)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (35, N'JULIA', N'RODRIGUEZ', CAST(N'1987-04-27' AS Date), 2, 35, 2, 1, 1, 1, 8, 1, 0, 1, 1, 6)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (36, N' GABRIEL', N'LOMBAR', CAST(N'1989-04-23' AS Date), 1, 36, 2, 1, 1, 1, 8, 1, 0, 1, 1, 8)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (37, N' DAMIAN', N'ORELLANA', CAST(N'1989-12-06' AS Date), 1, 37, 2, 1, 1, 1, 8, 1, 0, 1, 1, 9)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (38, N' LEONARDO', N'RUFFO', CAST(N'1989-12-30' AS Date), 1, 38, 2, 1, 1, 1, 8, 1, 0, 1, 1, 9)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (39, N' LAUTARO', N'ROMERO', CAST(N'1991-04-03' AS Date), 1, 39, 2, 1, 1, 1, 8, 1, 0, 1, 1, 8)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (40, N' DIEGO', N'CUEVAS', CAST(N'1993-06-14' AS Date), 1, 40, 2, 1, 1, 1, 8, 1, 0, 1, 1, 7)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (41, N' JHONATAN', N'DE OTO', CAST(N'1994-07-23' AS Date), 1, 41, 2, 1, 1, 1, 8, 1, 0, 1, 1, 6)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (42, N' LEONARDO', N'MOLLARD', CAST(N'1994-08-17' AS Date), 1, 42, 2, 1, 1, 1, 8, 1, 0, 1, 1, 5)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (43, N' ANGEL', N'REBUSCINI', CAST(N'1995-04-18' AS Date), 1, 43, 2, 1, 1, 1, 8, 1, 0, 1, 1, 4)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (44, N' JOSE', N'MOREYRA', CAST(N'1995-12-15' AS Date), 1, 44, 2, 1, 1, 1, 8, 1, 0, 1, 1, 3)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (45, N' JORGE', N'OLIVERA', CAST(N'1997-10-25' AS Date), 1, 45, 2, 1, 1, 1, 8, 1, 0, 1, 1, 2)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (46, N' ROBERTO', N'IBAÑEZ', CAST(N'1998-02-15' AS Date), 1, 46, 2, 1, 1, 1, 7, 1, 0, 1, 1, 1)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (47, N' ESTEFANIA', N'PINTO', CAST(N'1998-03-18' AS Date), 2, 47, 2, 1, 1, 1, 7, 1, 0, 1, 1, 2)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (48, N' ARIEL', N'MICELI', CAST(N'1998-08-16' AS Date), 1, 48, 2, 1, 1, 1, 7, 1, 0, 1, 1, 3)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (49, N' BETINA', N'CINGARI', CAST(N'1998-12-12' AS Date), 2, 49, 2, 1, 1, 1, 7, 1, 0, 1, 1, 4)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (50, N' MARCELO', N'ERRANTE', CAST(N'1999-07-28' AS Date), 1, 50, 2, 1, 1, 1, 7, 1, 0, 1, 1, 5)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (51, N' FEDERICO', N'ARCE', CAST(N'1970-10-22' AS Date), 1, 51, 2, 1, 1, 1, 7, 1, 0, 1, 1, 6)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (52, N' MATIAS', N'IRVINI', CAST(N'1971-06-14' AS Date), 1, 52, 2, 1, 1, 1, 7, 1, 0, 1, 1, 7)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (53, N'CARLOS', N'FORTUNATO', CAST(N'1971-08-30' AS Date), 1, 53, 2, 1, 1, 1, 7, 1, 0, 1, 1, 8)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (54, N' DANIEL', N'AVILA', CAST(N'1971-09-11' AS Date), 1, 54, 2, 1, 1, 1, 7, 1, 0, 1, 1, 2)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (55, N' LUIS', N'CASTILLO', CAST(N'1972-10-09' AS Date), 1, 55, 2, 1, 1, 1, 7, 1, 0, 1, 1, 9)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (56, N' ISMAEL', N'PARRAGUEZ', CAST(N'1973-03-28' AS Date), 1, 56, 2, 1, 1, 1, 7, 1, 0, 1, 1, 5)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (57, N' ALAN', N'GONZALEZ', CAST(N'1974-01-09' AS Date), 1, 57, 2, 1, 1, 1, 7, 1, 0, 1, 1, 6)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (58, N' MARIA', N'ROCCO', CAST(N'1975-10-09' AS Date), 2, 58, 2, 1, 1, 1, 7, 1, 0, 1, 1, 7)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (59, N' FACUNDO', N'FALVO', CAST(N'1979-03-11' AS Date), 1, 59, 2, 1, 1, 1, 7, 1, 0, 1, 1, 8)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (60, N' VICTOR', N'AVALOS', CAST(N'1979-08-29' AS Date), 1, 60, 2, 1, 1, 1, 7, 1, 0, 1, 1, 9)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (61, N' DIEGO', N'GONZALEZ', CAST(N'1980-06-12' AS Date), 1, 61, 2, 1, 1, 1, 7, 1, 0, 1, 1, 8)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (62, N' LUCAS', N'BRUMER', CAST(N'1983-12-02' AS Date), 1, 62, 2, 1, 1, 1, 7, 1, 0, 1, 1, 7)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (63, N' CRISTIAN', N'PANDOL', CAST(N'1984-12-15' AS Date), 1, 63, 2, 1, 1, 1, 7, 1, 0, 1, 1, 6)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (64, N' JAVIER', N'DEL BARBA', CAST(N'1985-12-23' AS Date), 1, 64, 2, 1, 1, 1, 6, 1, 0, 1, 1, 5)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (65, N' PABLO', N'GUALTIERI', CAST(N'1986-10-24' AS Date), 1, 65, 3, 1, 1, 1, 7, 1, 0, 1, 1, 4)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (66, N' HECTOR', N'DOMINGUEZ', CAST(N'1987-10-14' AS Date), 1, 66, 3, 1, 1, 1, 7, 1, 0, 1, 1, 3)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (67, N' ISAIAS', N'GONZALEZ', CAST(N'1987-12-19' AS Date), 1, 67, 3, 1, 1, 1, 7, 1, 0, 1, 1, 2)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (68, N' NESTOR', N'OLIVERA', CAST(N'1988-07-16' AS Date), 1, 68, 3, 1, 1, 1, 7, 1, 0, 1, 1, 1)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (69, N' MARIANO', N'BRUNERO', CAST(N'1989-06-21' AS Date), 1, 69, 3, 1, 1, 1, 7, 1, 0, 1, 1, 2)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (70, N' FERNANDO', N'ZILBER', CAST(N'1991-01-15' AS Date), 1, 70, 3, 1, 1, 1, 7, 1, 0, 1, 1, 3)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (71, N' CARLOS', N'IVALDE', CAST(N'1996-11-03' AS Date), 1, 71, 3, 1, 1, 1, 6, 1, 0, 1, 1, 4)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (72, N' FACUNDO', N'LOPARDO', CAST(N'1998-02-01' AS Date), 1, 72, 3, 1, 1, 1, 6, 1, 0, 1, 1, 5)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (73, N' LUCAS', N'OZUNA', CAST(N'1999-01-16' AS Date), 1, 73, 3, 1, 1, 1, 6, 1, 0, 1, 1, 6)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (74, N' CESAR', N'CORDOBA', CAST(N'1999-07-26' AS Date), 1, 74, 3, 1, 1, 1, 6, 1, 0, 1, 1, 7)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (75, N' LORENA', N'SANCHEZ', CAST(N'1999-10-10' AS Date), 2, 75, 3, 1, 1, 1, 6, 1, 0, 1, 1, 8)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (76, N' CRISTIAN', N'AMARILLA', CAST(N'1970-04-02' AS Date), 1, 76, 3, 1, 1, 1, 6, 1, 0, 1, 1, 9)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (77, N' LEONARDO', N'SANCHEZ', CAST(N'1972-09-25' AS Date), 1, 77, 3, 1, 1, 1, 6, 1, 0, 1, 1, 9)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (78, N' FERNANDO', N'BROIN', CAST(N'1973-11-25' AS Date), 1, 78, 3, 1, 1, 1, 6, 1, 0, 1, 1, 8)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (79, N' MATIAS', N'LACAZE', CAST(N'1974-02-17' AS Date), 1, 79, 3, 1, 1, 1, 6, 1, 0, 1, 1, 7)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (80, N' AGUSTIN', N'PERALTA', CAST(N'1975-02-22' AS Date), 1, 80, 3, 1, 1, 1, 6, 1, 0, 1, 1, 6)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (81, N' DANIEL', N'ZAMORA', CAST(N'1975-10-05' AS Date), 1, 81, 3, 1, 1, 1, 6, 1, 0, 1, 1, 5)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (82, N' LUCAS', N'SCHULZ', CAST(N'1976-04-12' AS Date), 1, 82, 3, 1, 1, 1, 6, 1, 0, 1, 1, 4)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (83, N' ARIEL', N'LOPEZ', CAST(N'1976-05-08' AS Date), 1, 83, 3, 1, 1, 1, 6, 1, 0, 1, 1, 3)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (84, N' NICOLAS', N'CANO', CAST(N'1981-03-15' AS Date), 1, 84, 3, 1, 1, 1, 6, 1, 0, 1, 1, 21)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (85, N' FERNANDO', N'LAGORIO', CAST(N'1981-03-19' AS Date), 1, 85, 3, 1, 1, 1, 5, 1, 0, 1, 1, 2)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (86, N' NICOLAS', N'DI PLACIDO', CAST(N'1981-11-10' AS Date), 1, 86, 3, 1, 1, 1, 5, 1, 0, 1, 1, 3)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (87, N' LEONARDO', N'BRITO', CAST(N'1982-06-07' AS Date), 1, 87, 3, 1, 1, 1, 5, 1, 0, 1, 1, 4)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (88, N' SANTIAGO', N'SCALERANDI', CAST(N'1986-08-03' AS Date), 1, 88, 3, 1, 1, 1, 5, 1, 0, 1, 1, 5)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (89, N' RENZO', N'DONATO', CAST(N'1987-12-20' AS Date), 1, 89, 3, 1, 1, 1, 5, 1, 0, 1, 1, 6)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (90, N' ARIEL', N'BARAN', CAST(N'1989-09-12' AS Date), 1, 90, 3, 1, 1, 1, 5, 1, 0, 1, 1, 7)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (91, N'FERNANDO', N'VIGANO', CAST(N'1992-03-16' AS Date), 1, 91, 3, 1, 1, 1, 5, 1, 0, 1, 1, 8)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (92, N' KEVIN', N'ALEGRE', CAST(N'1992-09-21' AS Date), 1, 92, 3, 1, 1, 1, 5, 1, 0, 1, 1, 9)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (93, N' EDUARDO', N'SILVA', CAST(N'1993-01-04' AS Date), 1, 93, 3, 1, 1, 1, 5, 1, 0, 1, 1, 8)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (94, N' ELVIO', N'CHAVEZ', CAST(N'1994-01-15' AS Date), 1, 94, 3, 1, 1, 1, 5, 1, 0, 1, 1, 7)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (95, N'JAVIER', N'BRITEZ', CAST(N'1996-06-23' AS Date), 1, 95, 4, 1, 1, 1, 5, 1, 0, 1, 1, 6)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (96, N' DAMIAN', N'MAROT', CAST(N'1996-08-12' AS Date), 1, 96, 4, 1, 1, 1, 5, 1, 0, 1, 1, 5)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (97, N' GUILLERMO', N'MEDINA', CAST(N'1996-10-09' AS Date), 1, 97, 4, 1, 1, 1, 5, 1, 0, 1, 1, 4)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (98, N' MARTIN', N'RAFFO', CAST(N'1996-10-30' AS Date), 1, 98, 4, 1, 1, 1, 5, 1, 0, 1, 1, 4)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (99, N'MARTIN', N'ARAGONEZ', CAST(N'1998-04-24' AS Date), 1, 99, 4, 1, 1, 1, 5, 1, 0, 1, 1, 3)
GO
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (100, N' JUAN', N'ARCOS', CAST(N'2000-06-14' AS Date), 1, 100, 4, 1, 1, 1, 5, 1, 0, 1, 1, 2)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (101, N' MARIO', N'BARDINA', CAST(N'1969-07-27' AS Date), 1, 101, 4, 1, 1, 1, 5, 1, 0, 1, 1, 3)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (102, N'ARIEL', N'BRITEZ', CAST(N'1974-10-13' AS Date), 1, 102, 4, 1, 1, 1, 5, 1, 0, 1, 1, 4)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (103, N' FEDERICO', N'BRITEZ', CAST(N'1978-02-04' AS Date), 1, 103, 4, 1, 1, 1, 5, 1, 0, 1, 1, 5)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (104, N' LEANDRO', N'BRITEZ', CAST(N'1978-10-31' AS Date), 1, 104, 4, 1, 1, 1, 5, 1, 0, 1, 1, 6)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (105, N' EMANUEL', N'CHAVEZ', CAST(N'1979-01-14' AS Date), 1, 105, 4, 1, 1, 1, 5, 1, 0, 1, 1, 7)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (106, N' LUIS', N'COLLI', CAST(N'1979-05-14' AS Date), 1, 106, 4, 1, 1, 1, 5, 1, 0, 1, 1, 8)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (107, N' ALAN', N'COLMAN', CAST(N'1979-06-17' AS Date), 1, 107, 4, 1, 1, 1, 5, 1, 0, 1, 1, 9)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (108, N' LUCAS', N'COLOMBO', CAST(N'1980-03-01' AS Date), 1, 108, 4, 1, 1, 1, 4, 1, 0, 1, 1, 7)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (109, N' BRIAN', N'DACAL', CAST(N'1981-05-01' AS Date), 1, 109, 4, 1, 1, 1, 4, 1, 0, 1, 1, 6)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (110, N' SEBASTIAN', N'DOMINGUEZ', CAST(N'1981-10-13' AS Date), 1, 110, 4, 1, 1, 1, 4, 1, 0, 1, 1, 5)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (111, N'CARLA', N'FORTUNATO', CAST(N'1982-01-20' AS Date), 2, 111, 4, 1, 1, 1, 4, 1, 0, 1, 1, 4)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (112, N' LAURA', N'FORTUNATO', CAST(N'1983-08-06' AS Date), 2, 112, 4, 1, 1, 1, 4, 1, 0, 1, 1, 4)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (113, N' MARÍA', N'FORTUNATO', CAST(N'1984-10-12' AS Date), 2, 113, 4, 1, 1, 1, 4, 1, 0, 1, 1, 3)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (114, N' FERNANDO', N'GANDUGLIA', CAST(N'1984-10-21' AS Date), 1, 114, 4, 1, 1, 1, 4, 1, 0, 1, 1, 6)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (115, N'ANA', N'GUZMAN', CAST(N'1984-12-05' AS Date), 2, 115, 4, 1, 1, 1, 4, 1, 0, 1, 1, 4)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (116, N' FABIAN', N'JAIMES', CAST(N'1990-05-31' AS Date), 1, 116, 4, 1, 1, 1, 4, 1, 0, 1, 1, 3)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (117, N' SILVIA', N'MARTINEZ B.', CAST(N'1991-12-24' AS Date), 2, 117, 4, 1, 1, 1, 4, 1, 0, 1, 1, 6)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (118, N' SEBASTIAN', N'MARTINEZ', CAST(N'1993-12-25' AS Date), 1, 118, 4, 1, 1, 1, 4, 1, 0, 1, 1, 8)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (119, N'MARIA', N'RODRIGUEZ', CAST(N'1994-08-20' AS Date), 2, 119, 4, 1, 1, 1, 4, 1, 0, 1, 1, 4)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (120, N' FITO', N'VIGANO', CAST(N'1996-05-31' AS Date), 1, 120, 4, 1, 1, 1, 4, 1, 0, 1, 1, 3)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (121, N' FACUNDO', N'VIGANO', CAST(N'1997-10-24' AS Date), 1, 121, 4, 1, 1, 1, 4, 1, 0, 1, 1, 5)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (122, N' FAUSTO', N'VIGANO', CAST(N'1998-02-14' AS Date), 1, 122, 4, 1, 1, 1, 4, 1, 0, 1, 1, 6)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (123, N' EDGARDO', N'ZAMORA', CAST(N'1999-04-28' AS Date), 1, 123, 4, 1, 1, 1, 4, 1, 0, 1, 1, 8)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (124, N' AGUSTÍN', N'TOIBERO', CAST(N'1999-07-13' AS Date), 1, 124, 4, 1, 1, 1, 4, 1, 0, 1, 1, 9)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (125, N' NAHUEL', N'VALDEON', CAST(N'2000-08-06' AS Date), 1, 125, 4, 1, 1, 1, 4, 1, 0, 1, 1, 7)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (126, N' MARIO', N'VARGAS', CAST(N'1984-08-31' AS Date), 1, 126, 4, 1, 1, 1, 4, 1, 0, 1, 1, 6)
INSERT [dbo].[Arbitro] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Habilitado], [Dni], [NotaAFA], [PoseeTituloValidoArgentina], [PoseeLicenciaInternacional], [ExamenFisicoAprobado], [ExamenTeoricoAprobado], [AniosExperiencia]) VALUES (127, N'Pepe', N'Perez', CAST(N'1990-03-01' AS Date), 1, 50, 2, 1, 1, 12345678, 9, 1, 1, 1, 1, 5)
SET IDENTITY_INSERT [dbo].[Arbitro] OFF
SET IDENTITY_INSERT [dbo].[ArbitroAud] ON 

INSERT [dbo].[ArbitroAud] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Estado], [IdArbitro], [IdBitacora], [Dni], [NotaAFA], [TituloValidoArgentina], [LicenciaInternacional], [ExamenFisico], [ExamenTeorico], [AniosExperiencia]) VALUES (1, N'BAIS', N'MARCELO', CAST(N'2000-01-01T00:00:00.000' AS DateTime), 1, 2, 1, 1, 1, 2, 357, 1, 1, 1, 0, 1, 1, 0)
INSERT [dbo].[ArbitroAud] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Estado], [IdArbitro], [IdBitacora], [Dni], [NotaAFA], [TituloValidoArgentina], [LicenciaInternacional], [ExamenFisico], [ExamenTeorico], [AniosExperiencia]) VALUES (2, N'SANTAMARIA, DARIO', N'', CAST(N'2000-01-01T00:00:00.000' AS DateTime), 1, 1, 1, 1, 1, 1, 359, 1, 1, 1, 0, 1, 1, 0)
INSERT [dbo].[ArbitroAud] ([Id], [Nombre], [Apellido], [FechaNacimiento], [IdGenero], [Ranking], [IdNivel], [IdDeporte], [Estado], [IdArbitro], [IdBitacora], [Dni], [NotaAFA], [TituloValidoArgentina], [LicenciaInternacional], [ExamenFisico], [ExamenTeorico], [AniosExperiencia]) VALUES (3, N'Carlos', N'Mentaberry', CAST(N'1988-06-15T00:00:00.000' AS DateTime), 1, 1029, 1, 1, 0, 1029, 362, 1, 1, 1, 0, 1, 1, 0)
SET IDENTITY_INSERT [dbo].[ArbitroAud] OFF
SET IDENTITY_INSERT [dbo].[Bitacora] ON 

INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [IdTipoEvento], [Descripcion], [Fecha]) VALUES (1, 1, 2, N'Inicio de sesión', CAST(N'2021-03-08T11:52:36.000' AS DateTime))
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [IdTipoEvento], [Descripcion], [Fecha]) VALUES (2, 1, 2, N'Inicio de sesión', CAST(N'2021-03-08T11:54:03.000' AS DateTime))
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [IdTipoEvento], [Descripcion], [Fecha]) VALUES (3, 1, 2, N'Inicio de sesión', CAST(N'2021-03-08T11:58:27.000' AS DateTime))
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [IdTipoEvento], [Descripcion], [Fecha]) VALUES (4, 1, 5, N'Alta de Árbitro', CAST(N'2021-03-08T12:02:03.000' AS DateTime))
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [IdTipoEvento], [Descripcion], [Fecha]) VALUES (5, 1, 2, N'Inicio de sesión', CAST(N'2021-03-08T12:14:06.000' AS DateTime))
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [IdTipoEvento], [Descripcion], [Fecha]) VALUES (6, 1, 2, N'Inicio de sesión', CAST(N'2021-03-08T12:23:20.000' AS DateTime))
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [IdTipoEvento], [Descripcion], [Fecha]) VALUES (7, 1, 2, N'Inicio de sesión', CAST(N'2021-03-08T12:27:17.000' AS DateTime))
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [IdTipoEvento], [Descripcion], [Fecha]) VALUES (8, 1, 2, N'Inicio de sesión', CAST(N'2021-03-08T12:31:47.000' AS DateTime))
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [IdTipoEvento], [Descripcion], [Fecha]) VALUES (9, 1, 2, N'Inicio de sesión', CAST(N'2021-03-08T12:35:19.000' AS DateTime))
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [IdTipoEvento], [Descripcion], [Fecha]) VALUES (10, 1, 2, N'Inicio de sesión', CAST(N'2021-03-08T12:42:04.000' AS DateTime))
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [IdTipoEvento], [Descripcion], [Fecha]) VALUES (11, 1, 2, N'Inicio de sesión', CAST(N'2021-03-08T12:53:03.000' AS DateTime))
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [IdTipoEvento], [Descripcion], [Fecha]) VALUES (12, 1, 2, N'Inicio de sesión', CAST(N'2021-03-08T12:53:49.000' AS DateTime))
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [IdTipoEvento], [Descripcion], [Fecha]) VALUES (13, 1, 2, N'Inicio de sesión', CAST(N'2021-03-08T12:54:57.000' AS DateTime))
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [IdTipoEvento], [Descripcion], [Fecha]) VALUES (14, 1, 2, N'Inicio de sesión', CAST(N'2021-03-08T13:00:05.000' AS DateTime))
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [IdTipoEvento], [Descripcion], [Fecha]) VALUES (15, 1, 2, N'Inicio de sesión', CAST(N'2021-03-08T13:10:14.000' AS DateTime))
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [IdTipoEvento], [Descripcion], [Fecha]) VALUES (16, 1, 2, N'Inicio de sesión', CAST(N'2021-03-08T13:12:50.000' AS DateTime))
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [IdTipoEvento], [Descripcion], [Fecha]) VALUES (17, 1, 2, N'Inicio de sesión', CAST(N'2021-03-08T13:41:37.000' AS DateTime))
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [IdTipoEvento], [Descripcion], [Fecha]) VALUES (18, 1, 2, N'Inicio de sesión', CAST(N'2021-03-08T15:11:01.000' AS DateTime))
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [IdTipoEvento], [Descripcion], [Fecha]) VALUES (19, 1, 2, N'Inicio de sesión', CAST(N'2021-03-08T15:27:37.000' AS DateTime))
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [IdTipoEvento], [Descripcion], [Fecha]) VALUES (20, 1, 2, N'Inicio de sesión', CAST(N'2021-03-08T15:35:37.000' AS DateTime))
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [IdTipoEvento], [Descripcion], [Fecha]) VALUES (21, 1, 2, N'Inicio de sesión', CAST(N'2021-03-08T15:39:48.000' AS DateTime))
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [IdTipoEvento], [Descripcion], [Fecha]) VALUES (22, 1, 2, N'Inicio de sesión', CAST(N'2021-03-08T16:00:46.000' AS DateTime))
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [IdTipoEvento], [Descripcion], [Fecha]) VALUES (23, 1, 2, N'Inicio de sesión', CAST(N'2021-03-08T16:09:39.000' AS DateTime))
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [IdTipoEvento], [Descripcion], [Fecha]) VALUES (24, 1, 2, N'Inicio de sesión', CAST(N'2021-03-08T20:38:42.000' AS DateTime))
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [IdTipoEvento], [Descripcion], [Fecha]) VALUES (25, 1, 2, N'Inicio de sesión', CAST(N'2021-03-08T21:52:09.000' AS DateTime))
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [IdTipoEvento], [Descripcion], [Fecha]) VALUES (26, 1, 2, N'Inicio de sesión', CAST(N'2021-03-09T08:18:35.000' AS DateTime))
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [IdTipoEvento], [Descripcion], [Fecha]) VALUES (27, 1, 2, N'Inicio de sesión', CAST(N'2021-03-09T08:32:53.000' AS DateTime))
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [IdTipoEvento], [Descripcion], [Fecha]) VALUES (28, 1, 2, N'Inicio de sesión', CAST(N'2021-03-09T08:39:19.000' AS DateTime))
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [IdTipoEvento], [Descripcion], [Fecha]) VALUES (29, 1, 2, N'Inicio de sesión', CAST(N'2021-03-09T08:43:04.000' AS DateTime))
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [IdTipoEvento], [Descripcion], [Fecha]) VALUES (30, 1, 2, N'Inicio de sesión', CAST(N'2021-03-09T08:52:28.000' AS DateTime))
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [IdTipoEvento], [Descripcion], [Fecha]) VALUES (31, 1, 2, N'Inicio de sesión', CAST(N'2021-03-09T08:53:45.000' AS DateTime))
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [IdTipoEvento], [Descripcion], [Fecha]) VALUES (32, 1, 2, N'Inicio de sesión', CAST(N'2021-03-09T08:57:45.000' AS DateTime))
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [IdTipoEvento], [Descripcion], [Fecha]) VALUES (33, 1, 2, N'Inicio de sesión', CAST(N'2021-03-09T09:00:09.000' AS DateTime))
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [IdTipoEvento], [Descripcion], [Fecha]) VALUES (34, 1, 2, N'Inicio de sesión', CAST(N'2021-03-09T09:04:08.000' AS DateTime))
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [IdTipoEvento], [Descripcion], [Fecha]) VALUES (35, 1, 2, N'Inicio de sesión', CAST(N'2021-03-09T09:10:09.000' AS DateTime))
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [IdTipoEvento], [Descripcion], [Fecha]) VALUES (36, 1, 2, N'Inicio de sesión', CAST(N'2021-03-09T09:13:44.000' AS DateTime))
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [IdTipoEvento], [Descripcion], [Fecha]) VALUES (37, 1, 2, N'Inicio de sesión', CAST(N'2021-03-09T09:28:35.000' AS DateTime))
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [IdTipoEvento], [Descripcion], [Fecha]) VALUES (38, 1, 2, N'Inicio de sesión', CAST(N'2021-03-09T09:31:23.000' AS DateTime))
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [IdTipoEvento], [Descripcion], [Fecha]) VALUES (39, 1, 2, N'Inicio de sesión', CAST(N'2021-03-09T09:37:09.000' AS DateTime))
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [IdTipoEvento], [Descripcion], [Fecha]) VALUES (40, 1, 2, N'Inicio de sesión', CAST(N'2021-03-09T10:01:17.000' AS DateTime))
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [IdTipoEvento], [Descripcion], [Fecha]) VALUES (41, 1, 2, N'Inicio de sesión', CAST(N'2021-03-09T10:06:31.000' AS DateTime))
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [IdTipoEvento], [Descripcion], [Fecha]) VALUES (42, 1, 2, N'Inicio de sesión', CAST(N'2021-03-09T10:09:45.000' AS DateTime))
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [IdTipoEvento], [Descripcion], [Fecha]) VALUES (43, 1, 2, N'Inicio de sesión', CAST(N'2021-03-09T11:08:05.000' AS DateTime))
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [IdTipoEvento], [Descripcion], [Fecha]) VALUES (44, 1, 2, N'Inicio de sesión', CAST(N'2021-03-09T11:42:08.000' AS DateTime))
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [IdTipoEvento], [Descripcion], [Fecha]) VALUES (45, 1, 2, N'Inicio de sesión', CAST(N'2021-03-09T11:43:37.000' AS DateTime))
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [IdTipoEvento], [Descripcion], [Fecha]) VALUES (46, 1, 2, N'Inicio de sesión', CAST(N'2021-03-09T11:50:26.000' AS DateTime))
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [IdTipoEvento], [Descripcion], [Fecha]) VALUES (47, 1, 2, N'Inicio de sesión', CAST(N'2021-03-09T11:57:50.000' AS DateTime))
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [IdTipoEvento], [Descripcion], [Fecha]) VALUES (48, 1, 2, N'Inicio de sesión', CAST(N'2021-03-09T12:17:51.000' AS DateTime))
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [IdTipoEvento], [Descripcion], [Fecha]) VALUES (49, 1, 2, N'Inicio de sesión', CAST(N'2021-03-09T17:27:10.000' AS DateTime))
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [IdTipoEvento], [Descripcion], [Fecha]) VALUES (50, 1, 2, N'Inicio de sesión', CAST(N'2021-03-09T17:28:50.000' AS DateTime))
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [IdTipoEvento], [Descripcion], [Fecha]) VALUES (51, 1, 2, N'Inicio de sesión', CAST(N'2021-03-09T17:32:46.000' AS DateTime))
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [IdTipoEvento], [Descripcion], [Fecha]) VALUES (52, 1, 2, N'Inicio de sesión', CAST(N'2021-03-09T17:34:36.000' AS DateTime))
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [IdTipoEvento], [Descripcion], [Fecha]) VALUES (53, 1, 2, N'Inicio de sesión', CAST(N'2021-03-09T17:49:55.000' AS DateTime))
INSERT [dbo].[Bitacora] ([Id], [IdUsuario], [IdTipoEvento], [Descripcion], [Fecha]) VALUES (54, 1, 2, N'Inicio de sesión', CAST(N'2021-03-09T18:10:55.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Bitacora] OFF
SET IDENTITY_INSERT [dbo].[Calificacion] ON 

INSERT [dbo].[Calificacion] ([Id], [ReglasPuntaje], [DisciplinaPuntaje], [CondicionFisicaPuntaje], [JugadasPuntaje], [DificultadPartidoPuntaje]) VALUES (1, 1, 1, 1, 1, 0.5)
INSERT [dbo].[Calificacion] ([Id], [ReglasPuntaje], [DisciplinaPuntaje], [CondicionFisicaPuntaje], [JugadasPuntaje], [DificultadPartidoPuntaje]) VALUES (2, 2, 2, 2, 2, 0.25)
INSERT [dbo].[Calificacion] ([Id], [ReglasPuntaje], [DisciplinaPuntaje], [CondicionFisicaPuntaje], [JugadasPuntaje], [DificultadPartidoPuntaje]) VALUES (3, 3, 3, 3, 3, 0.25)
INSERT [dbo].[Calificacion] ([Id], [ReglasPuntaje], [DisciplinaPuntaje], [CondicionFisicaPuntaje], [JugadasPuntaje], [DificultadPartidoPuntaje]) VALUES (4, 4, 4, 4, 4, 0.25)
INSERT [dbo].[Calificacion] ([Id], [ReglasPuntaje], [DisciplinaPuntaje], [CondicionFisicaPuntaje], [JugadasPuntaje], [DificultadPartidoPuntaje]) VALUES (5, 5, 5, 5, 5, 0.25)
INSERT [dbo].[Calificacion] ([Id], [ReglasPuntaje], [DisciplinaPuntaje], [CondicionFisicaPuntaje], [JugadasPuntaje], [DificultadPartidoPuntaje]) VALUES (6, 6, 6, 6, 6, 0.75)
INSERT [dbo].[Calificacion] ([Id], [ReglasPuntaje], [DisciplinaPuntaje], [CondicionFisicaPuntaje], [JugadasPuntaje], [DificultadPartidoPuntaje]) VALUES (7, 7, 7, 7, 7, 0.25)
INSERT [dbo].[Calificacion] ([Id], [ReglasPuntaje], [DisciplinaPuntaje], [CondicionFisicaPuntaje], [JugadasPuntaje], [DificultadPartidoPuntaje]) VALUES (8, 8, 8, 8, 8, 0.5)
INSERT [dbo].[Calificacion] ([Id], [ReglasPuntaje], [DisciplinaPuntaje], [CondicionFisicaPuntaje], [JugadasPuntaje], [DificultadPartidoPuntaje]) VALUES (9, 9, 9, 9, 9, 0.25)
INSERT [dbo].[Calificacion] ([Id], [ReglasPuntaje], [DisciplinaPuntaje], [CondicionFisicaPuntaje], [JugadasPuntaje], [DificultadPartidoPuntaje]) VALUES (10, 10, 10, 10, 10, 0.25)
INSERT [dbo].[Calificacion] ([Id], [ReglasPuntaje], [DisciplinaPuntaje], [CondicionFisicaPuntaje], [JugadasPuntaje], [DificultadPartidoPuntaje]) VALUES (11, 9, 9, 9, 9, 0.25)
INSERT [dbo].[Calificacion] ([Id], [ReglasPuntaje], [DisciplinaPuntaje], [CondicionFisicaPuntaje], [JugadasPuntaje], [DificultadPartidoPuntaje]) VALUES (12, 3, 3, 3, 3, 0.5)
INSERT [dbo].[Calificacion] ([Id], [ReglasPuntaje], [DisciplinaPuntaje], [CondicionFisicaPuntaje], [JugadasPuntaje], [DificultadPartidoPuntaje]) VALUES (13, 2, 2, 2, 2, 0.25)
INSERT [dbo].[Calificacion] ([Id], [ReglasPuntaje], [DisciplinaPuntaje], [CondicionFisicaPuntaje], [JugadasPuntaje], [DificultadPartidoPuntaje]) VALUES (14, 9, 9, 9, 9, 0.25)
SET IDENTITY_INSERT [dbo].[Calificacion] OFF
SET IDENTITY_INSERT [dbo].[Campeonato] ON 

INSERT [dbo].[Campeonato] ([Id], [Descripcion], [IdFixture], [IdCategoria]) VALUES (1, N'Liga de Primera', 1, 1)
INSERT [dbo].[Campeonato] ([Id], [Descripcion], [IdFixture], [IdCategoria]) VALUES (2, N'Liga 2 div', 2, 2)
INSERT [dbo].[Campeonato] ([Id], [Descripcion], [IdFixture], [IdCategoria]) VALUES (3, N'Liga 3 div', 3, 3)
INSERT [dbo].[Campeonato] ([Id], [Descripcion], [IdFixture], [IdCategoria]) VALUES (4, N'Liga 4 div', 4, 4)
SET IDENTITY_INSERT [dbo].[Campeonato] OFF
SET IDENTITY_INSERT [dbo].[Categoria] ON 

INSERT [dbo].[Categoria] ([Id], [Descripcion], [IdDeporte]) VALUES (1, N'1era Div. Masc.', 1)
INSERT [dbo].[Categoria] ([Id], [Descripcion], [IdDeporte]) VALUES (2, N'2da Div. Masc.', 1)
INSERT [dbo].[Categoria] ([Id], [Descripcion], [IdDeporte]) VALUES (3, N'3era Div. Masc.', 1)
INSERT [dbo].[Categoria] ([Id], [Descripcion], [IdDeporte]) VALUES (4, N'4ta Div. Masc.', 1)
INSERT [dbo].[Categoria] ([Id], [Descripcion], [IdDeporte]) VALUES (6, N'1era Div. Masc.', 2)
INSERT [dbo].[Categoria] ([Id], [Descripcion], [IdDeporte]) VALUES (7, N'2da Div. Masc.', 2)
INSERT [dbo].[Categoria] ([Id], [Descripcion], [IdDeporte]) VALUES (8, N'3era Div. Masc.', 2)
INSERT [dbo].[Categoria] ([Id], [Descripcion], [IdDeporte]) VALUES (9, N'4ta Div. Masc.', 2)
SET IDENTITY_INSERT [dbo].[Categoria] OFF
SET IDENTITY_INSERT [dbo].[Deporte] ON 

INSERT [dbo].[Deporte] ([Id], [Descripcion]) VALUES (1, N'Futsal')
INSERT [dbo].[Deporte] ([Id], [Descripcion]) VALUES (11, N'Futbol')
SET IDENTITY_INSERT [dbo].[Deporte] OFF
SET IDENTITY_INSERT [dbo].[DVV] ON 

INSERT [dbo].[DVV] ([Id], [NombreTabla], [Valor]) VALUES (1, N'Usuario', N'7e862d6fd15dc3fb8a6d9256b18cfbe2')
SET IDENTITY_INSERT [dbo].[DVV] OFF
SET IDENTITY_INSERT [dbo].[Equipo] ON 

INSERT [dbo].[Equipo] ([Id], [Nombre], [Ponderacion], [IdCategoria]) VALUES (1, N'MERLO', 1, 1)
INSERT [dbo].[Equipo] ([Id], [Nombre], [Ponderacion], [IdCategoria]) VALUES (2, N'AMERICA DEL SUD', 2, 1)
INSERT [dbo].[Equipo] ([Id], [Nombre], [Ponderacion], [IdCategoria]) VALUES (3, N'BARRACAS CENTRAL', 3, 1)
INSERT [dbo].[Equipo] ([Id], [Nombre], [Ponderacion], [IdCategoria]) VALUES (4, N'BOCA JUNIORS', 4, 1)
INSERT [dbo].[Equipo] ([Id], [Nombre], [Ponderacion], [IdCategoria]) VALUES (5, N'COUNTRY BANFIELD', 5, 1)
INSERT [dbo].[Equipo] ([Id], [Nombre], [Ponderacion], [IdCategoria]) VALUES (6, N'ESTRELLA DE BOEDO', 6, 1)
INSERT [dbo].[Equipo] ([Id], [Nombre], [Ponderacion], [IdCategoria]) VALUES (7, N'FERRO', 7, 1)
INSERT [dbo].[Equipo] ([Id], [Nombre], [Ponderacion], [IdCategoria]) VALUES (8, N'GLORIAS', 8, 1)
INSERT [dbo].[Equipo] ([Id], [Nombre], [Ponderacion], [IdCategoria]) VALUES (9, N'HEBRAICA', 9, 1)
INSERT [dbo].[Equipo] ([Id], [Nombre], [Ponderacion], [IdCategoria]) VALUES (10, N'HURACAN', 10, 1)
INSERT [dbo].[Equipo] ([Id], [Nombre], [Ponderacion], [IdCategoria]) VALUES (11, N'INDEPENDIENTE', 11, 1)
INSERT [dbo].[Equipo] ([Id], [Nombre], [Ponderacion], [IdCategoria]) VALUES (12, N'JORGE NEWBERY', 12, 1)
INSERT [dbo].[Equipo] ([Id], [Nombre], [Ponderacion], [IdCategoria]) VALUES (13, N'KIMBERLEY', 13, 1)
INSERT [dbo].[Equipo] ([Id], [Nombre], [Ponderacion], [IdCategoria]) VALUES (14, N'PINOCHO', 14, 1)
INSERT [dbo].[Equipo] ([Id], [Nombre], [Ponderacion], [IdCategoria]) VALUES (15, N'RACING CLUB', 15, 1)
INSERT [dbo].[Equipo] ([Id], [Nombre], [Ponderacion], [IdCategoria]) VALUES (16, N'RIVER PLATE', 16, 1)
INSERT [dbo].[Equipo] ([Id], [Nombre], [Ponderacion], [IdCategoria]) VALUES (17, N'SAN LORENZO', 17, 1)
INSERT [dbo].[Equipo] ([Id], [Nombre], [Ponderacion], [IdCategoria]) VALUES (18, N'VILLA LA ÑATA', 18, 1)
INSERT [dbo].[Equipo] ([Id], [Nombre], [Ponderacion], [IdCategoria]) VALUES (19, N'ALVEAR', 19, 2)
INSERT [dbo].[Equipo] ([Id], [Nombre], [Ponderacion], [IdCategoria]) VALUES (20, N'ARGENTINOS JRS.', 20, 2)
INSERT [dbo].[Equipo] ([Id], [Nombre], [Ponderacion], [IdCategoria]) VALUES (21, N'ASTURIANO', 21, 2)
INSERT [dbo].[Equipo] ([Id], [Nombre], [Ponderacion], [IdCategoria]) VALUES (22, N'BANFIELD', 22, 2)
INSERT [dbo].[Equipo] ([Id], [Nombre], [Ponderacion], [IdCategoria]) VALUES (23, N'CABALLITO JRS.', 23, 2)
INSERT [dbo].[Equipo] ([Id], [Nombre], [Ponderacion], [IdCategoria]) VALUES (24, N'CIDECO', 24, 2)
INSERT [dbo].[Equipo] ([Id], [Nombre], [Ponderacion], [IdCategoria]) VALUES (25, N'DEP. MORON', 25, 2)
INSERT [dbo].[Equipo] ([Id], [Nombre], [Ponderacion], [IdCategoria]) VALUES (26, N'EL PORVENIR', 26, 2)
INSERT [dbo].[Equipo] ([Id], [Nombre], [Ponderacion], [IdCategoria]) VALUES (27, N'EL TALAR', 27, 2)
INSERT [dbo].[Equipo] ([Id], [Nombre], [Ponderacion], [IdCategoria]) VALUES (28, N'ESTRELLA MALDONADO', 28, 2)
INSERT [dbo].[Equipo] ([Id], [Nombre], [Ponderacion], [IdCategoria]) VALUES (29, N'HURLINGHAM', 29, 2)
INSERT [dbo].[Equipo] ([Id], [Nombre], [Ponderacion], [IdCategoria]) VALUES (30, N'JUVENCIA', 30, 2)
INSERT [dbo].[Equipo] ([Id], [Nombre], [Ponderacion], [IdCategoria]) VALUES (31, N'LAS HERAS', 31, 2)
INSERT [dbo].[Equipo] ([Id], [Nombre], [Ponderacion], [IdCategoria]) VALUES (32, N'NUEVA ESTRELLA', 32, 2)
INSERT [dbo].[Equipo] ([Id], [Nombre], [Ponderacion], [IdCategoria]) VALUES (33, N'PLATENSE', 33, 2)
INSERT [dbo].[Equipo] ([Id], [Nombre], [Ponderacion], [IdCategoria]) VALUES (34, N'S.E.C.L.A.', 34, 2)
INSERT [dbo].[Equipo] ([Id], [Nombre], [Ponderacion], [IdCategoria]) VALUES (35, N'SOCIAL PARQUE', 35, 2)
INSERT [dbo].[Equipo] ([Id], [Nombre], [Ponderacion], [IdCategoria]) VALUES (36, N'UAI URQUIZA', 36, 2)
INSERT [dbo].[Equipo] ([Id], [Nombre], [Ponderacion], [IdCategoria]) VALUES (37, N'UNION EZPELETA', 37, 2)
INSERT [dbo].[Equipo] ([Id], [Nombre], [Ponderacion], [IdCategoria]) VALUES (38, N'ALL BOYS', 38, 3)
INSERT [dbo].[Equipo] ([Id], [Nombre], [Ponderacion], [IdCategoria]) VALUES (39, N'ALMAFUERTE', 39, 3)
INSERT [dbo].[Equipo] ([Id], [Nombre], [Ponderacion], [IdCategoria]) VALUES (40, N'ARSENAL', 40, 3)
INSERT [dbo].[Equipo] ([Id], [Nombre], [Ponderacion], [IdCategoria]) VALUES (41, N'ATLANTA', 41, 3)
INSERT [dbo].[Equipo] ([Id], [Nombre], [Ponderacion], [IdCategoria]) VALUES (42, N'BOMBEROS MTZA.', 42, 3)
INSERT [dbo].[Equipo] ([Id], [Nombre], [Ponderacion], [IdCategoria]) VALUES (43, N'CAMIONEROS', 43, 3)
INSERT [dbo].[Equipo] ([Id], [Nombre], [Ponderacion], [IdCategoria]) VALUES (44, N'COMUNICACIONES', 44, 3)
INSERT [dbo].[Equipo] ([Id], [Nombre], [Ponderacion], [IdCategoria]) VALUES (45, N'DEF. CERVANTES', 45, 3)
INSERT [dbo].[Equipo] ([Id], [Nombre], [Ponderacion], [IdCategoria]) VALUES (46, N'DON BOSCO', 46, 3)
INSERT [dbo].[Equipo] ([Id], [Nombre], [Ponderacion], [IdCategoria]) VALUES (47, N'FRANJA DE ORO', 47, 3)
INSERT [dbo].[Equipo] ([Id], [Nombre], [Ponderacion], [IdCategoria]) VALUES (48, N'G.E.V.S.', 48, 3)
INSERT [dbo].[Equipo] ([Id], [Nombre], [Ponderacion], [IdCategoria]) VALUES (49, N'ITUZAINGO', 49, 3)
INSERT [dbo].[Equipo] ([Id], [Nombre], [Ponderacion], [IdCategoria]) VALUES (50, N'JUV. TAPIALES', 50, 3)
INSERT [dbo].[Equipo] ([Id], [Nombre], [Ponderacion], [IdCategoria]) VALUES (51, N'JUV. UNIDA', 51, 3)
INSERT [dbo].[Equipo] ([Id], [Nombre], [Ponderacion], [IdCategoria]) VALUES (52, N'LAMADRID', 52, 3)
INSERT [dbo].[Equipo] ([Id], [Nombre], [Ponderacion], [IdCategoria]) VALUES (53, N'NUEVA CHICAGO', 53, 3)
INSERT [dbo].[Equipo] ([Id], [Nombre], [Ponderacion], [IdCategoria]) VALUES (54, N'PACIFICO', 54, 3)
INSERT [dbo].[Equipo] ([Id], [Nombre], [Ponderacion], [IdCategoria]) VALUES (55, N'VILLA ARGENTINA', 55, 3)
INSERT [dbo].[Equipo] ([Id], [Nombre], [Ponderacion], [IdCategoria]) VALUES (56, N'VILLA MODELO', 56, 3)
INSERT [dbo].[Equipo] ([Id], [Nombre], [Ponderacion], [IdCategoria]) VALUES (57, N'ALMAGRO', 57, 4)
INSERT [dbo].[Equipo] ([Id], [Nombre], [Ponderacion], [IdCategoria]) VALUES (58, N'BROWN ADROGUE', 58, 4)
INSERT [dbo].[Equipo] ([Id], [Nombre], [Ponderacion], [IdCategoria]) VALUES (59, N'CHACARITA JRS.', 59, 4)
INSERT [dbo].[Equipo] ([Id], [Nombre], [Ponderacion], [IdCategoria]) VALUES (60, N'CIRC. POLICIAL', 60, 4)
INSERT [dbo].[Equipo] ([Id], [Nombre], [Ponderacion], [IdCategoria]) VALUES (61, N'COLEGIALES', 61, 4)
INSERT [dbo].[Equipo] ([Id], [Nombre], [Ponderacion], [IdCategoria]) VALUES (62, N'CTRO. ESPAÑOL', 62, 4)
INSERT [dbo].[Equipo] ([Id], [Nombre], [Ponderacion], [IdCategoria]) VALUES (63, N'CULTURAL', 63, 4)
INSERT [dbo].[Equipo] ([Id], [Nombre], [Ponderacion], [IdCategoria]) VALUES (64, N'DEP. RIESTRA', 64, 4)
INSERT [dbo].[Equipo] ([Id], [Nombre], [Ponderacion], [IdCategoria]) VALUES (65, N'EXCURSIONISTAS', 65, 4)
INSERT [dbo].[Equipo] ([Id], [Nombre], [Ponderacion], [IdCategoria]) VALUES (66, N'FERRO DE MERLO', 66, 4)
INSERT [dbo].[Equipo] ([Id], [Nombre], [Ponderacion], [IdCategoria]) VALUES (67, N'G.O.N.', 67, 4)
INSERT [dbo].[Equipo] ([Id], [Nombre], [Ponderacion], [IdCategoria]) VALUES (68, N'GIMNASIA L.P.', 68, 4)
INSERT [dbo].[Equipo] ([Id], [Nombre], [Ponderacion], [IdCategoria]) VALUES (69, N'J.J. URQUIZA', 69, 4)
INSERT [dbo].[Equipo] ([Id], [Nombre], [Ponderacion], [IdCategoria]) VALUES (70, N'LOS MUCHACHOS', 70, 4)
INSERT [dbo].[Equipo] ([Id], [Nombre], [Ponderacion], [IdCategoria]) VALUES (71, N'MIRIÑAQUE', 71, 4)
INSERT [dbo].[Equipo] ([Id], [Nombre], [Ponderacion], [IdCategoria]) VALUES (72, N'PRIMERA JUNTA', 72, 4)
INSERT [dbo].[Equipo] ([Id], [Nombre], [Ponderacion], [IdCategoria]) VALUES (73, N'S.A.B.E.R.', 73, 4)
INSERT [dbo].[Equipo] ([Id], [Nombre], [Ponderacion], [IdCategoria]) VALUES (74, N'SAN MARTIN BZCO.', 74, 4)
INSERT [dbo].[Equipo] ([Id], [Nombre], [Ponderacion], [IdCategoria]) VALUES (75, N'SANTA LEONOR', 75, 4)
INSERT [dbo].[Equipo] ([Id], [Nombre], [Ponderacion], [IdCategoria]) VALUES (76, N'SEL. HURLINGHAM', 76, 4)
INSERT [dbo].[Equipo] ([Id], [Nombre], [Ponderacion], [IdCategoria]) VALUES (77, N'SPORT. BARRACAS', 77, 4)
INSERT [dbo].[Equipo] ([Id], [Nombre], [Ponderacion], [IdCategoria]) VALUES (78, N'TEMPERLEY', 78, 4)
INSERT [dbo].[Equipo] ([Id], [Nombre], [Ponderacion], [IdCategoria]) VALUES (79, N'U.N.L.A.M.', 79, 4)
INSERT [dbo].[Equipo] ([Id], [Nombre], [Ponderacion], [IdCategoria]) VALUES (80, N'UNION DE MONTE VIEJO', 80, 4)
SET IDENTITY_INSERT [dbo].[Equipo] OFF
SET IDENTITY_INSERT [dbo].[Fecha] ON 

INSERT [dbo].[Fecha] ([Id], [IdFixture], [FechaDesde], [FechaHasta], [Nombre], [Numero], [Designado]) VALUES (1, 1, CAST(N'2018-02-17T00:00:00.000' AS DateTime), CAST(N'2018-01-01T00:00:00.000' AS DateTime), N'FECHA:  1', 1, 1)
INSERT [dbo].[Fecha] ([Id], [IdFixture], [FechaDesde], [FechaHasta], [Nombre], [Numero], [Designado]) VALUES (2, 2, CAST(N'2018-02-17T00:00:00.000' AS DateTime), CAST(N'2018-01-08T00:00:00.000' AS DateTime), N'FECHA:  1', 1, 1)
INSERT [dbo].[Fecha] ([Id], [IdFixture], [FechaDesde], [FechaHasta], [Nombre], [Numero], [Designado]) VALUES (3, 3, CAST(N'2018-02-17T00:00:00.000' AS DateTime), CAST(N'2018-01-15T00:00:00.000' AS DateTime), N'FECHA:  1', 1, 1)
INSERT [dbo].[Fecha] ([Id], [IdFixture], [FechaDesde], [FechaHasta], [Nombre], [Numero], [Designado]) VALUES (4, 4, CAST(N'2018-02-17T00:00:00.000' AS DateTime), CAST(N'2018-01-24T00:00:00.000' AS DateTime), N'FECHA:  1', 1, 1)
INSERT [dbo].[Fecha] ([Id], [IdFixture], [FechaDesde], [FechaHasta], [Nombre], [Numero], [Designado]) VALUES (5, 1, CAST(N'2018-02-17T00:00:00.000' AS DateTime), CAST(N'2018-02-02T00:00:00.000' AS DateTime), N'FECHA:  2', 2, 1)
INSERT [dbo].[Fecha] ([Id], [IdFixture], [FechaDesde], [FechaHasta], [Nombre], [Numero], [Designado]) VALUES (6, 2, CAST(N'2018-02-17T00:00:00.000' AS DateTime), CAST(N'2018-02-09T00:00:00.000' AS DateTime), N'FECHA:  2', 2, 1)
INSERT [dbo].[Fecha] ([Id], [IdFixture], [FechaDesde], [FechaHasta], [Nombre], [Numero], [Designado]) VALUES (7, 3, CAST(N'2018-02-17T00:00:00.000' AS DateTime), CAST(N'2018-02-16T00:00:00.000' AS DateTime), N'FECHA:  2', 2, 1)
INSERT [dbo].[Fecha] ([Id], [IdFixture], [FechaDesde], [FechaHasta], [Nombre], [Numero], [Designado]) VALUES (8, 4, CAST(N'2018-02-17T00:00:00.000' AS DateTime), CAST(N'2018-02-23T00:00:00.000' AS DateTime), N'FECHA:  2', 2, 1)
INSERT [dbo].[Fecha] ([Id], [IdFixture], [FechaDesde], [FechaHasta], [Nombre], [Numero], [Designado]) VALUES (9, 1, CAST(N'2018-02-17T00:00:00.000' AS DateTime), CAST(N'2018-03-17T00:00:00.000' AS DateTime), N'FECHA:  3', 3, 1)
INSERT [dbo].[Fecha] ([Id], [IdFixture], [FechaDesde], [FechaHasta], [Nombre], [Numero], [Designado]) VALUES (10, 2, CAST(N'2018-02-17T00:00:00.000' AS DateTime), CAST(N'2018-03-17T00:00:00.000' AS DateTime), N'FECHA:  3', 3, 1)
INSERT [dbo].[Fecha] ([Id], [IdFixture], [FechaDesde], [FechaHasta], [Nombre], [Numero], [Designado]) VALUES (11, 3, CAST(N'2018-02-17T00:00:00.000' AS DateTime), CAST(N'2018-03-17T00:00:00.000' AS DateTime), N'FECHA:  3', 3, 1)
INSERT [dbo].[Fecha] ([Id], [IdFixture], [FechaDesde], [FechaHasta], [Nombre], [Numero], [Designado]) VALUES (12, 4, CAST(N'2018-02-17T00:00:00.000' AS DateTime), CAST(N'2018-03-17T00:00:00.000' AS DateTime), N'FECHA:  3', 3, 1)
INSERT [dbo].[Fecha] ([Id], [IdFixture], [FechaDesde], [FechaHasta], [Nombre], [Numero], [Designado]) VALUES (13, 1, CAST(N'2018-02-17T00:00:00.000' AS DateTime), CAST(N'2018-04-17T00:00:00.000' AS DateTime), N'FECHA:  4', 4, 1)
INSERT [dbo].[Fecha] ([Id], [IdFixture], [FechaDesde], [FechaHasta], [Nombre], [Numero], [Designado]) VALUES (14, 2, CAST(N'2018-02-17T00:00:00.000' AS DateTime), CAST(N'2018-04-17T00:00:00.000' AS DateTime), N'FECHA:  4', 4, 1)
INSERT [dbo].[Fecha] ([Id], [IdFixture], [FechaDesde], [FechaHasta], [Nombre], [Numero], [Designado]) VALUES (15, 3, CAST(N'2018-02-17T00:00:00.000' AS DateTime), CAST(N'2018-04-17T00:00:00.000' AS DateTime), N'FECHA:  4', 4, 1)
INSERT [dbo].[Fecha] ([Id], [IdFixture], [FechaDesde], [FechaHasta], [Nombre], [Numero], [Designado]) VALUES (16, 4, CAST(N'2018-02-17T00:00:00.000' AS DateTime), CAST(N'2018-04-17T00:00:00.000' AS DateTime), N'FECHA:  4', 4, 1)
INSERT [dbo].[Fecha] ([Id], [IdFixture], [FechaDesde], [FechaHasta], [Nombre], [Numero], [Designado]) VALUES (17, 1, CAST(N'2018-02-17T00:00:00.000' AS DateTime), CAST(N'2018-05-17T00:00:00.000' AS DateTime), N'FECHA:  5', 5, 1)
INSERT [dbo].[Fecha] ([Id], [IdFixture], [FechaDesde], [FechaHasta], [Nombre], [Numero], [Designado]) VALUES (18, 2, CAST(N'2018-02-17T00:00:00.000' AS DateTime), CAST(N'2018-05-17T00:00:00.000' AS DateTime), N'FECHA:  5', 5, 1)
INSERT [dbo].[Fecha] ([Id], [IdFixture], [FechaDesde], [FechaHasta], [Nombre], [Numero], [Designado]) VALUES (19, 3, CAST(N'2018-02-17T00:00:00.000' AS DateTime), CAST(N'2018-05-17T00:00:00.000' AS DateTime), N'FECHA:  5', 5, 1)
INSERT [dbo].[Fecha] ([Id], [IdFixture], [FechaDesde], [FechaHasta], [Nombre], [Numero], [Designado]) VALUES (20, 4, CAST(N'2018-02-17T00:00:00.000' AS DateTime), CAST(N'2018-05-17T00:00:00.000' AS DateTime), N'FECHA:  5', 5, 1)
INSERT [dbo].[Fecha] ([Id], [IdFixture], [FechaDesde], [FechaHasta], [Nombre], [Numero], [Designado]) VALUES (21, 1, CAST(N'2018-02-17T00:00:00.000' AS DateTime), CAST(N'2018-06-17T00:00:00.000' AS DateTime), N'FECHA:  6', 6, 1)
INSERT [dbo].[Fecha] ([Id], [IdFixture], [FechaDesde], [FechaHasta], [Nombre], [Numero], [Designado]) VALUES (22, 2, CAST(N'2018-02-17T00:00:00.000' AS DateTime), CAST(N'2018-06-17T00:00:00.000' AS DateTime), N'FECHA:  6', 6, 1)
INSERT [dbo].[Fecha] ([Id], [IdFixture], [FechaDesde], [FechaHasta], [Nombre], [Numero], [Designado]) VALUES (23, 3, CAST(N'2018-02-17T00:00:00.000' AS DateTime), CAST(N'2018-06-17T00:00:00.000' AS DateTime), N'FECHA:  6', 6, 1)
INSERT [dbo].[Fecha] ([Id], [IdFixture], [FechaDesde], [FechaHasta], [Nombre], [Numero], [Designado]) VALUES (24, 4, CAST(N'2018-02-17T00:00:00.000' AS DateTime), CAST(N'2018-06-17T00:00:00.000' AS DateTime), N'FECHA:  6', 6, 1)
INSERT [dbo].[Fecha] ([Id], [IdFixture], [FechaDesde], [FechaHasta], [Nombre], [Numero], [Designado]) VALUES (25, 1, CAST(N'2018-02-17T00:00:00.000' AS DateTime), CAST(N'2018-07-17T00:00:00.000' AS DateTime), N'FECHA:  7', 7, 0)
INSERT [dbo].[Fecha] ([Id], [IdFixture], [FechaDesde], [FechaHasta], [Nombre], [Numero], [Designado]) VALUES (26, 2, CAST(N'2018-02-17T00:00:00.000' AS DateTime), CAST(N'2018-07-17T00:00:00.000' AS DateTime), N'FECHA:  7', 7, 1)
INSERT [dbo].[Fecha] ([Id], [IdFixture], [FechaDesde], [FechaHasta], [Nombre], [Numero], [Designado]) VALUES (27, 3, CAST(N'2018-02-17T00:00:00.000' AS DateTime), CAST(N'2018-07-17T00:00:00.000' AS DateTime), N'FECHA:  7', 7, 1)
INSERT [dbo].[Fecha] ([Id], [IdFixture], [FechaDesde], [FechaHasta], [Nombre], [Numero], [Designado]) VALUES (28, 4, CAST(N'2018-02-17T00:00:00.000' AS DateTime), CAST(N'2018-07-17T00:00:00.000' AS DateTime), N'FECHA:  7', 7, 1)
INSERT [dbo].[Fecha] ([Id], [IdFixture], [FechaDesde], [FechaHasta], [Nombre], [Numero], [Designado]) VALUES (29, 1, CAST(N'2018-02-17T00:00:00.000' AS DateTime), CAST(N'2018-08-17T00:00:00.000' AS DateTime), N'FECHA:  8', 8, 0)
INSERT [dbo].[Fecha] ([Id], [IdFixture], [FechaDesde], [FechaHasta], [Nombre], [Numero], [Designado]) VALUES (30, 2, CAST(N'2018-02-17T00:00:00.000' AS DateTime), CAST(N'2018-08-17T00:00:00.000' AS DateTime), N'FECHA:  8', 8, 1)
INSERT [dbo].[Fecha] ([Id], [IdFixture], [FechaDesde], [FechaHasta], [Nombre], [Numero], [Designado]) VALUES (31, 3, CAST(N'2018-02-17T00:00:00.000' AS DateTime), CAST(N'2018-08-17T00:00:00.000' AS DateTime), N'FECHA:  8', 8, 1)
INSERT [dbo].[Fecha] ([Id], [IdFixture], [FechaDesde], [FechaHasta], [Nombre], [Numero], [Designado]) VALUES (32, 4, CAST(N'2018-02-17T00:00:00.000' AS DateTime), CAST(N'2018-08-17T00:00:00.000' AS DateTime), N'FECHA:  8', 8, 1)
INSERT [dbo].[Fecha] ([Id], [IdFixture], [FechaDesde], [FechaHasta], [Nombre], [Numero], [Designado]) VALUES (33, 1, CAST(N'2018-02-17T00:00:00.000' AS DateTime), CAST(N'2018-09-17T00:00:00.000' AS DateTime), N'FECHA:  9', 9, 0)
INSERT [dbo].[Fecha] ([Id], [IdFixture], [FechaDesde], [FechaHasta], [Nombre], [Numero], [Designado]) VALUES (34, 2, CAST(N'2018-02-17T00:00:00.000' AS DateTime), CAST(N'2018-09-17T00:00:00.000' AS DateTime), N'FECHA:  9', 9, 1)
INSERT [dbo].[Fecha] ([Id], [IdFixture], [FechaDesde], [FechaHasta], [Nombre], [Numero], [Designado]) VALUES (35, 3, CAST(N'2018-02-17T00:00:00.000' AS DateTime), CAST(N'2018-09-17T00:00:00.000' AS DateTime), N'FECHA:  9', 9, 1)
INSERT [dbo].[Fecha] ([Id], [IdFixture], [FechaDesde], [FechaHasta], [Nombre], [Numero], [Designado]) VALUES (36, 4, CAST(N'2018-02-17T00:00:00.000' AS DateTime), CAST(N'2018-09-17T00:00:00.000' AS DateTime), N'FECHA:  9', 9, 1)
INSERT [dbo].[Fecha] ([Id], [IdFixture], [FechaDesde], [FechaHasta], [Nombre], [Numero], [Designado]) VALUES (37, 1, CAST(N'2018-02-17T00:00:00.000' AS DateTime), CAST(N'2018-10-17T00:00:00.000' AS DateTime), N'FECHA:  10', 10, 0)
INSERT [dbo].[Fecha] ([Id], [IdFixture], [FechaDesde], [FechaHasta], [Nombre], [Numero], [Designado]) VALUES (38, 2, CAST(N'2018-02-17T00:00:00.000' AS DateTime), CAST(N'2018-10-17T00:00:00.000' AS DateTime), N'FECHA:  10', 10, 0)
INSERT [dbo].[Fecha] ([Id], [IdFixture], [FechaDesde], [FechaHasta], [Nombre], [Numero], [Designado]) VALUES (39, 3, CAST(N'2018-02-17T00:00:00.000' AS DateTime), CAST(N'2018-10-17T00:00:00.000' AS DateTime), N'FECHA:  10', 10, 0)
INSERT [dbo].[Fecha] ([Id], [IdFixture], [FechaDesde], [FechaHasta], [Nombre], [Numero], [Designado]) VALUES (40, 4, CAST(N'2018-02-17T00:00:00.000' AS DateTime), CAST(N'2018-10-17T00:00:00.000' AS DateTime), N'FECHA:  10', 10, 0)
INSERT [dbo].[Fecha] ([Id], [IdFixture], [FechaDesde], [FechaHasta], [Nombre], [Numero], [Designado]) VALUES (41, 1, CAST(N'2018-02-17T00:00:00.000' AS DateTime), CAST(N'2018-11-17T00:00:00.000' AS DateTime), N'FECHA:  11', 11, 0)
INSERT [dbo].[Fecha] ([Id], [IdFixture], [FechaDesde], [FechaHasta], [Nombre], [Numero], [Designado]) VALUES (42, 2, CAST(N'2018-02-17T00:00:00.000' AS DateTime), CAST(N'2018-11-17T00:00:00.000' AS DateTime), N'FECHA:  11', 11, 0)
INSERT [dbo].[Fecha] ([Id], [IdFixture], [FechaDesde], [FechaHasta], [Nombre], [Numero], [Designado]) VALUES (43, 3, CAST(N'2018-02-17T00:00:00.000' AS DateTime), CAST(N'2018-11-17T00:00:00.000' AS DateTime), N'FECHA:  11', 11, 0)
INSERT [dbo].[Fecha] ([Id], [IdFixture], [FechaDesde], [FechaHasta], [Nombre], [Numero], [Designado]) VALUES (44, 4, CAST(N'2018-02-17T00:00:00.000' AS DateTime), CAST(N'2018-11-17T00:00:00.000' AS DateTime), N'FECHA:  11', 11, 0)
INSERT [dbo].[Fecha] ([Id], [IdFixture], [FechaDesde], [FechaHasta], [Nombre], [Numero], [Designado]) VALUES (45, 1, CAST(N'2018-02-17T00:00:00.000' AS DateTime), CAST(N'2018-12-17T00:00:00.000' AS DateTime), N'FECHA:  12', 12, 0)
INSERT [dbo].[Fecha] ([Id], [IdFixture], [FechaDesde], [FechaHasta], [Nombre], [Numero], [Designado]) VALUES (46, 2, CAST(N'2018-02-17T00:00:00.000' AS DateTime), CAST(N'2018-12-17T00:00:00.000' AS DateTime), N'FECHA:  12', 12, 0)
INSERT [dbo].[Fecha] ([Id], [IdFixture], [FechaDesde], [FechaHasta], [Nombre], [Numero], [Designado]) VALUES (47, 3, CAST(N'2018-02-17T00:00:00.000' AS DateTime), CAST(N'2018-12-17T00:00:00.000' AS DateTime), N'FECHA:  12', 12, 0)
INSERT [dbo].[Fecha] ([Id], [IdFixture], [FechaDesde], [FechaHasta], [Nombre], [Numero], [Designado]) VALUES (48, 4, CAST(N'2018-02-17T00:00:00.000' AS DateTime), CAST(N'2018-12-17T00:00:00.000' AS DateTime), N'FECHA:  12', 12, 0)
INSERT [dbo].[Fecha] ([Id], [IdFixture], [FechaDesde], [FechaHasta], [Nombre], [Numero], [Designado]) VALUES (49, 1, CAST(N'2018-02-17T00:00:00.000' AS DateTime), CAST(N'2019-01-17T00:00:00.000' AS DateTime), N'FECHA:  13', 13, 0)
INSERT [dbo].[Fecha] ([Id], [IdFixture], [FechaDesde], [FechaHasta], [Nombre], [Numero], [Designado]) VALUES (50, 2, CAST(N'2018-02-17T00:00:00.000' AS DateTime), CAST(N'2019-01-17T00:00:00.000' AS DateTime), N'FECHA:  13', 13, 0)
INSERT [dbo].[Fecha] ([Id], [IdFixture], [FechaDesde], [FechaHasta], [Nombre], [Numero], [Designado]) VALUES (51, 3, CAST(N'2018-02-17T00:00:00.000' AS DateTime), CAST(N'2019-01-17T00:00:00.000' AS DateTime), N'FECHA:  13', 13, 0)
INSERT [dbo].[Fecha] ([Id], [IdFixture], [FechaDesde], [FechaHasta], [Nombre], [Numero], [Designado]) VALUES (52, 4, CAST(N'2018-02-17T00:00:00.000' AS DateTime), CAST(N'2019-01-17T00:00:00.000' AS DateTime), N'FECHA:  13', 13, 0)
INSERT [dbo].[Fecha] ([Id], [IdFixture], [FechaDesde], [FechaHasta], [Nombre], [Numero], [Designado]) VALUES (53, 1, CAST(N'2018-02-17T00:00:00.000' AS DateTime), CAST(N'2019-02-17T00:00:00.000' AS DateTime), N'FECHA:  14', 14, 0)
INSERT [dbo].[Fecha] ([Id], [IdFixture], [FechaDesde], [FechaHasta], [Nombre], [Numero], [Designado]) VALUES (54, 2, CAST(N'2018-02-17T00:00:00.000' AS DateTime), CAST(N'2019-02-17T00:00:00.000' AS DateTime), N'FECHA:  14', 14, 0)
INSERT [dbo].[Fecha] ([Id], [IdFixture], [FechaDesde], [FechaHasta], [Nombre], [Numero], [Designado]) VALUES (55, 3, CAST(N'2018-02-17T00:00:00.000' AS DateTime), CAST(N'2019-02-17T00:00:00.000' AS DateTime), N'FECHA:  14', 14, 0)
INSERT [dbo].[Fecha] ([Id], [IdFixture], [FechaDesde], [FechaHasta], [Nombre], [Numero], [Designado]) VALUES (56, 4, CAST(N'2018-02-17T00:00:00.000' AS DateTime), CAST(N'2019-02-17T00:00:00.000' AS DateTime), N'FECHA:  14', 14, 0)
INSERT [dbo].[Fecha] ([Id], [IdFixture], [FechaDesde], [FechaHasta], [Nombre], [Numero], [Designado]) VALUES (57, 1, CAST(N'2018-02-17T00:00:00.000' AS DateTime), CAST(N'2019-03-17T00:00:00.000' AS DateTime), N'FECHA:  15', 15, 0)
INSERT [dbo].[Fecha] ([Id], [IdFixture], [FechaDesde], [FechaHasta], [Nombre], [Numero], [Designado]) VALUES (58, 2, CAST(N'2018-02-17T00:00:00.000' AS DateTime), CAST(N'2019-03-17T00:00:00.000' AS DateTime), N'FECHA:  15', 15, 0)
INSERT [dbo].[Fecha] ([Id], [IdFixture], [FechaDesde], [FechaHasta], [Nombre], [Numero], [Designado]) VALUES (59, 3, CAST(N'2018-02-17T00:00:00.000' AS DateTime), CAST(N'2019-03-17T00:00:00.000' AS DateTime), N'FECHA:  15', 15, 0)
INSERT [dbo].[Fecha] ([Id], [IdFixture], [FechaDesde], [FechaHasta], [Nombre], [Numero], [Designado]) VALUES (60, 1, CAST(N'2018-02-17T00:00:00.000' AS DateTime), CAST(N'2019-03-17T00:00:00.000' AS DateTime), N'FECHA:  16', 16, 0)
INSERT [dbo].[Fecha] ([Id], [IdFixture], [FechaDesde], [FechaHasta], [Nombre], [Numero], [Designado]) VALUES (61, 2, CAST(N'2018-02-17T00:00:00.000' AS DateTime), CAST(N'2019-04-17T00:00:00.000' AS DateTime), N'FECHA:  16', 16, 0)
INSERT [dbo].[Fecha] ([Id], [IdFixture], [FechaDesde], [FechaHasta], [Nombre], [Numero], [Designado]) VALUES (62, 3, CAST(N'2018-02-17T00:00:00.000' AS DateTime), CAST(N'2019-04-17T00:00:00.000' AS DateTime), N'FECHA:  16', 16, 0)
INSERT [dbo].[Fecha] ([Id], [IdFixture], [FechaDesde], [FechaHasta], [Nombre], [Numero], [Designado]) VALUES (63, 1, CAST(N'2018-02-17T00:00:00.000' AS DateTime), CAST(N'2019-04-17T00:00:00.000' AS DateTime), N'FECHA:  17', 17, 0)
INSERT [dbo].[Fecha] ([Id], [IdFixture], [FechaDesde], [FechaHasta], [Nombre], [Numero], [Designado]) VALUES (64, 2, CAST(N'2018-02-17T00:00:00.000' AS DateTime), CAST(N'2019-04-17T00:00:00.000' AS DateTime), N'FECHA:  17', 17, 0)
INSERT [dbo].[Fecha] ([Id], [IdFixture], [FechaDesde], [FechaHasta], [Nombre], [Numero], [Designado]) VALUES (65, 3, CAST(N'2018-02-17T00:00:00.000' AS DateTime), CAST(N'2019-05-17T00:00:00.000' AS DateTime), N'FECHA:  17', 17, 0)
INSERT [dbo].[Fecha] ([Id], [IdFixture], [FechaDesde], [FechaHasta], [Nombre], [Numero], [Designado]) VALUES (66, 1, CAST(N'2018-02-17T00:00:00.000' AS DateTime), CAST(N'2019-05-17T00:00:00.000' AS DateTime), N'FECHA:  18', 18, 0)
INSERT [dbo].[Fecha] ([Id], [IdFixture], [FechaDesde], [FechaHasta], [Nombre], [Numero], [Designado]) VALUES (67, 2, CAST(N'2018-02-17T00:00:00.000' AS DateTime), CAST(N'2019-05-17T00:00:00.000' AS DateTime), N'FECHA:  18', 18, 0)
INSERT [dbo].[Fecha] ([Id], [IdFixture], [FechaDesde], [FechaHasta], [Nombre], [Numero], [Designado]) VALUES (68, 3, CAST(N'2018-02-17T00:00:00.000' AS DateTime), CAST(N'2019-05-17T00:00:00.000' AS DateTime), N'FECHA:  18', 18, 0)
INSERT [dbo].[Fecha] ([Id], [IdFixture], [FechaDesde], [FechaHasta], [Nombre], [Numero], [Designado]) VALUES (69, 1, CAST(N'2018-02-17T00:00:00.000' AS DateTime), CAST(N'2019-06-17T00:00:00.000' AS DateTime), N'FECHA:  19', 19, 0)
INSERT [dbo].[Fecha] ([Id], [IdFixture], [FechaDesde], [FechaHasta], [Nombre], [Numero], [Designado]) VALUES (70, 2, CAST(N'2018-02-17T00:00:00.000' AS DateTime), CAST(N'2019-06-17T00:00:00.000' AS DateTime), N'FECHA:  19', 19, 0)
INSERT [dbo].[Fecha] ([Id], [IdFixture], [FechaDesde], [FechaHasta], [Nombre], [Numero], [Designado]) VALUES (71, 3, CAST(N'2018-02-17T00:00:00.000' AS DateTime), CAST(N'2019-06-17T00:00:00.000' AS DateTime), N'FECHA:  19', 19, 0)
INSERT [dbo].[Fecha] ([Id], [IdFixture], [FechaDesde], [FechaHasta], [Nombre], [Numero], [Designado]) VALUES (72, 1, CAST(N'2018-02-17T00:00:00.000' AS DateTime), CAST(N'2019-06-17T00:00:00.000' AS DateTime), N'FECHA:  20', 20, 0)
INSERT [dbo].[Fecha] ([Id], [IdFixture], [FechaDesde], [FechaHasta], [Nombre], [Numero], [Designado]) VALUES (73, 2, CAST(N'2018-02-17T00:00:00.000' AS DateTime), CAST(N'2019-07-17T00:00:00.000' AS DateTime), N'FECHA:  20', 20, 0)
INSERT [dbo].[Fecha] ([Id], [IdFixture], [FechaDesde], [FechaHasta], [Nombre], [Numero], [Designado]) VALUES (74, 3, CAST(N'2018-02-17T00:00:00.000' AS DateTime), CAST(N'2019-07-17T00:00:00.000' AS DateTime), N'FECHA:  20', 20, 0)
INSERT [dbo].[Fecha] ([Id], [IdFixture], [FechaDesde], [FechaHasta], [Nombre], [Numero], [Designado]) VALUES (75, 1, CAST(N'2018-02-17T00:00:00.000' AS DateTime), CAST(N'2019-07-17T00:00:00.000' AS DateTime), N'FECHA:  21', 21, 0)
INSERT [dbo].[Fecha] ([Id], [IdFixture], [FechaDesde], [FechaHasta], [Nombre], [Numero], [Designado]) VALUES (76, 2, CAST(N'2018-02-17T00:00:00.000' AS DateTime), CAST(N'2019-07-17T00:00:00.000' AS DateTime), N'FECHA:  21', 21, 0)
INSERT [dbo].[Fecha] ([Id], [IdFixture], [FechaDesde], [FechaHasta], [Nombre], [Numero], [Designado]) VALUES (77, 3, CAST(N'2018-02-17T00:00:00.000' AS DateTime), CAST(N'2019-08-17T00:00:00.000' AS DateTime), N'FECHA:  21', 21, 0)
INSERT [dbo].[Fecha] ([Id], [IdFixture], [FechaDesde], [FechaHasta], [Nombre], [Numero], [Designado]) VALUES (78, 1, CAST(N'2018-02-17T00:00:00.000' AS DateTime), CAST(N'2019-08-17T00:00:00.000' AS DateTime), N'FECHA:  22', 22, 0)
INSERT [dbo].[Fecha] ([Id], [IdFixture], [FechaDesde], [FechaHasta], [Nombre], [Numero], [Designado]) VALUES (79, 2, CAST(N'2018-02-17T00:00:00.000' AS DateTime), CAST(N'2019-08-17T00:00:00.000' AS DateTime), N'FECHA:  22', 22, 0)
INSERT [dbo].[Fecha] ([Id], [IdFixture], [FechaDesde], [FechaHasta], [Nombre], [Numero], [Designado]) VALUES (80, 1, CAST(N'2018-02-17T00:00:00.000' AS DateTime), CAST(N'2019-08-17T00:00:00.000' AS DateTime), N'FECHA:  23', 23, 0)
INSERT [dbo].[Fecha] ([Id], [IdFixture], [FechaDesde], [FechaHasta], [Nombre], [Numero], [Designado]) VALUES (81, 2, CAST(N'2018-02-17T00:00:00.000' AS DateTime), CAST(N'2019-09-17T00:00:00.000' AS DateTime), N'FECHA:  23', 23, 0)
INSERT [dbo].[Fecha] ([Id], [IdFixture], [FechaDesde], [FechaHasta], [Nombre], [Numero], [Designado]) VALUES (82, 2, CAST(N'2018-02-17T00:00:00.000' AS DateTime), CAST(N'2019-09-17T00:00:00.000' AS DateTime), N'FECHA:  24', 24, 0)
SET IDENTITY_INSERT [dbo].[Fecha] OFF
SET IDENTITY_INSERT [dbo].[Fixture] ON 

INSERT [dbo].[Fixture] ([Id], [Descripcion]) VALUES (1, N'FIXTURE 1')
INSERT [dbo].[Fixture] ([Id], [Descripcion]) VALUES (2, N'FIXTURE 2')
INSERT [dbo].[Fixture] ([Id], [Descripcion]) VALUES (3, N'FIXTURE 3')
INSERT [dbo].[Fixture] ([Id], [Descripcion]) VALUES (4, N'FIXTURE 4')
SET IDENTITY_INSERT [dbo].[Fixture] OFF
INSERT [dbo].[Genero] ([Id], [Descripcion]) VALUES (1, N'Masculino')
INSERT [dbo].[Genero] ([Id], [Descripcion]) VALUES (2, N'Femenino')
SET IDENTITY_INSERT [dbo].[Idioma] ON 

INSERT [dbo].[Idioma] ([Id], [Descripcion]) VALUES (1, N'Español')
INSERT [dbo].[Idioma] ([Id], [Descripcion]) VALUES (2, N'English')
SET IDENTITY_INSERT [dbo].[Idioma] OFF
SET IDENTITY_INSERT [dbo].[Leyenda] ON 

INSERT [dbo].[Leyenda] ([Id], [Etiqueta]) VALUES (1, N'txtLogin')
INSERT [dbo].[Leyenda] ([Id], [Etiqueta]) VALUES (2, N'txtUsuario')
INSERT [dbo].[Leyenda] ([Id], [Etiqueta]) VALUES (3, N'txtPassword')
INSERT [dbo].[Leyenda] ([Id], [Etiqueta]) VALUES (4, N'txtSolicitarNueva')
INSERT [dbo].[Leyenda] ([Id], [Etiqueta]) VALUES (5, N'btnCerrar')
INSERT [dbo].[Leyenda] ([Id], [Etiqueta]) VALUES (6, N'btnIniciar')
INSERT [dbo].[Leyenda] ([Id], [Etiqueta]) VALUES (7, N'runOlvidaste')
INSERT [dbo].[Leyenda] ([Id], [Etiqueta]) VALUES (8, N'btnAceptar')
INSERT [dbo].[Leyenda] ([Id], [Etiqueta]) VALUES (9, N'Administración')
INSERT [dbo].[Leyenda] ([Id], [Etiqueta]) VALUES (10, N'Designación')
INSERT [dbo].[Leyenda] ([Id], [Etiqueta]) VALUES (11, N'Evaluación')
INSERT [dbo].[Leyenda] ([Id], [Etiqueta]) VALUES (12, N'Seguridad')
INSERT [dbo].[Leyenda] ([Id], [Etiqueta]) VALUES (13, N'Servicios')
INSERT [dbo].[Leyenda] ([Id], [Etiqueta]) VALUES (14, N'Personalizar')
INSERT [dbo].[Leyenda] ([Id], [Etiqueta]) VALUES (15, N'Árbitros')
INSERT [dbo].[Leyenda] ([Id], [Etiqueta]) VALUES (16, N'Campeonatos')
INSERT [dbo].[Leyenda] ([Id], [Etiqueta]) VALUES (17, N'Categorías')
INSERT [dbo].[Leyenda] ([Id], [Etiqueta]) VALUES (18, N'Equipos')
INSERT [dbo].[Leyenda] ([Id], [Etiqueta]) VALUES (19, N'Partidos')
INSERT [dbo].[Leyenda] ([Id], [Etiqueta]) VALUES (20, N'Realizar designación')
INSERT [dbo].[Leyenda] ([Id], [Etiqueta]) VALUES (21, N'Calificar árbitros')
INSERT [dbo].[Leyenda] ([Id], [Etiqueta]) VALUES (22, N'Promoción/Descenso')
INSERT [dbo].[Leyenda] ([Id], [Etiqueta]) VALUES (23, N'Usuarios')
INSERT [dbo].[Leyenda] ([Id], [Etiqueta]) VALUES (24, N'Gestionar Perfiles')
INSERT [dbo].[Leyenda] ([Id], [Etiqueta]) VALUES (25, N'Backup')
INSERT [dbo].[Leyenda] ([Id], [Etiqueta]) VALUES (26, N'Idioma')
INSERT [dbo].[Leyenda] ([Id], [Etiqueta]) VALUES (27, N'txtTituloMainWindow')
INSERT [dbo].[Leyenda] ([Id], [Etiqueta]) VALUES (28, N'Bitácora')
INSERT [dbo].[Leyenda] ([Id], [Etiqueta]) VALUES (29, N'txtHintDirectorio')
INSERT [dbo].[Leyenda] ([Id], [Etiqueta]) VALUES (30, N'txtHintBase')
INSERT [dbo].[Leyenda] ([Id], [Etiqueta]) VALUES (31, N'txtHintNombreArchivo')
INSERT [dbo].[Leyenda] ([Id], [Etiqueta]) VALUES (32, N'btnExaminar')
INSERT [dbo].[Leyenda] ([Id], [Etiqueta]) VALUES (33, N'btnBackup')
INSERT [dbo].[Leyenda] ([Id], [Etiqueta]) VALUES (34, N'btnRestore')
INSERT [dbo].[Leyenda] ([Id], [Etiqueta]) VALUES (35, N'tagBackup/Restore')
INSERT [dbo].[Leyenda] ([Id], [Etiqueta]) VALUES (38, N'Crear Perfiles')
INSERT [dbo].[Leyenda] ([Id], [Etiqueta]) VALUES (39, N'txtHintIdioma')
INSERT [dbo].[Leyenda] ([Id], [Etiqueta]) VALUES (40, N'HeaderIdioma')
INSERT [dbo].[Leyenda] ([Id], [Etiqueta]) VALUES (41, N'Restore')
INSERT [dbo].[Leyenda] ([Id], [Etiqueta]) VALUES (42, N'ValidationRuleNoNulo')
INSERT [dbo].[Leyenda] ([Id], [Etiqueta]) VALUES (43, N'txtArchivosResguardo')
INSERT [dbo].[Leyenda] ([Id], [Etiqueta]) VALUES (44, N'txtNombreIdioma')
INSERT [dbo].[Leyenda] ([Id], [Etiqueta]) VALUES (45, N'TituloOperacion')
INSERT [dbo].[Leyenda] ([Id], [Etiqueta]) VALUES (46, N'OperacionOk')
INSERT [dbo].[Leyenda] ([Id], [Etiqueta]) VALUES (47, N'OperacionError')
INSERT [dbo].[Leyenda] ([Id], [Etiqueta]) VALUES (48, N'titNombreUsu')
INSERT [dbo].[Leyenda] ([Id], [Etiqueta]) VALUES (49, N'titPassword')
INSERT [dbo].[Leyenda] ([Id], [Etiqueta]) VALUES (50, N'MenNombreUsuExiste')
INSERT [dbo].[Leyenda] ([Id], [Etiqueta]) VALUES (51, N'MenPasswordTexto')
INSERT [dbo].[Leyenda] ([Id], [Etiqueta]) VALUES (52, N'MenUsuarioActual')
INSERT [dbo].[Leyenda] ([Id], [Etiqueta]) VALUES (53, N'MenSeleccionarUsu')
SET IDENTITY_INSERT [dbo].[Leyenda] OFF
SET IDENTITY_INSERT [dbo].[Nivel] ON 

INSERT [dbo].[Nivel] ([Id], [NombreNivel], [IdDeporte]) VALUES (1, N'Nivel 1', 1)
INSERT [dbo].[Nivel] ([Id], [NombreNivel], [IdDeporte]) VALUES (2, N'Nivel 2', 1)
INSERT [dbo].[Nivel] ([Id], [NombreNivel], [IdDeporte]) VALUES (3, N'Nivel 3', 1)
INSERT [dbo].[Nivel] ([Id], [NombreNivel], [IdDeporte]) VALUES (4, N'Nivel 4', 1)
SET IDENTITY_INSERT [dbo].[Nivel] OFF
SET IDENTITY_INSERT [dbo].[NivelRegla] ON 

INSERT [dbo].[NivelRegla] ([Id], [IdNivel], [IdCategoria], [IdTipoArbitro]) VALUES (1, 1, 1, 1)
INSERT [dbo].[NivelRegla] ([Id], [IdNivel], [IdCategoria], [IdTipoArbitro]) VALUES (2, 1, 2, 1)
INSERT [dbo].[NivelRegla] ([Id], [IdNivel], [IdCategoria], [IdTipoArbitro]) VALUES (3, 1, 3, 1)
INSERT [dbo].[NivelRegla] ([Id], [IdNivel], [IdCategoria], [IdTipoArbitro]) VALUES (4, 1, 4, 1)
INSERT [dbo].[NivelRegla] ([Id], [IdNivel], [IdCategoria], [IdTipoArbitro]) VALUES (5, 1, 5, 1)
INSERT [dbo].[NivelRegla] ([Id], [IdNivel], [IdCategoria], [IdTipoArbitro]) VALUES (6, 2, 1, 2)
INSERT [dbo].[NivelRegla] ([Id], [IdNivel], [IdCategoria], [IdTipoArbitro]) VALUES (7, 2, 2, 1)
INSERT [dbo].[NivelRegla] ([Id], [IdNivel], [IdCategoria], [IdTipoArbitro]) VALUES (8, 2, 2, 2)
INSERT [dbo].[NivelRegla] ([Id], [IdNivel], [IdCategoria], [IdTipoArbitro]) VALUES (9, 2, 3, 1)
INSERT [dbo].[NivelRegla] ([Id], [IdNivel], [IdCategoria], [IdTipoArbitro]) VALUES (10, 2, 4, 1)
INSERT [dbo].[NivelRegla] ([Id], [IdNivel], [IdCategoria], [IdTipoArbitro]) VALUES (11, 2, 5, 1)
INSERT [dbo].[NivelRegla] ([Id], [IdNivel], [IdCategoria], [IdTipoArbitro]) VALUES (12, 3, 2, 2)
INSERT [dbo].[NivelRegla] ([Id], [IdNivel], [IdCategoria], [IdTipoArbitro]) VALUES (13, 3, 5, 1)
INSERT [dbo].[NivelRegla] ([Id], [IdNivel], [IdCategoria], [IdTipoArbitro]) VALUES (14, 3, 5, 2)
INSERT [dbo].[NivelRegla] ([Id], [IdNivel], [IdCategoria], [IdTipoArbitro]) VALUES (15, 4, 2, 2)
INSERT [dbo].[NivelRegla] ([Id], [IdNivel], [IdCategoria], [IdTipoArbitro]) VALUES (16, 4, 5, 2)
SET IDENTITY_INSERT [dbo].[NivelRegla] OFF
SET IDENTITY_INSERT [dbo].[Partido] ON 

INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (1, 15, 18, 1, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (2, 14, 16, 2, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (3, 17, 6, 3, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (4, 13, 11, 4, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (5, 7, 9, 5, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (6, 12, 3, 6, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (7, 2, 5, 7, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (8, 10, 4, 8, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (9, 1, 8, 9, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (10, 37, 35, 10, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (11, 24, 34, 11, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (12, 29, 19, 12, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (13, 31, 32, 13, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (14, 33, 21, 14, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (15, 27, 30, 15, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (16, 36, 20, 16, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (17, 23, 22, 17, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (18, 25, 28, 18, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (22, 50, 42, 22, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 3)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (23, 38, 49, 23, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 3)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (24, 39, 47, 24, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 3)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (25, 43, 45, 25, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 3)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (26, 40, 56, 26, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 3)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (27, 41, 51, 27, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 3)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (28, 46, 52, 28, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 3)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (29, 48, 53, 29, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 3)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (30, 55, 54, 30, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 3)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (31, 67, 69, 31, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 4)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (32, 71, 62, 32, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 4)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (33, 65, 73, 33, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 4)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (34, 79, 66, 34, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 4)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (35, 63, 74, 35, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 4)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (36, 64, 72, 36, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 4)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (37, 68, 58, 37, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 4)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (38, 76, 61, 38, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 4)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (39, 80, 77, 39, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 4)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (40, 57, 70, 40, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 4)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (41, 60, 59, 41, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 4)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (42, 1, 15, 42, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 5)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (43, 8, 10, 43, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 5)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (44, 4, 2, 44, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 5)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (45, 5, 12, 45, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 5)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (46, 3, 13, 46, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 5)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (47, 11, 7, 47, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 5)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (48, 9, 17, 48, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 5)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (49, 6, 14, 49, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 5)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (50, 16, 18, 50, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 5)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (54, 28, 23, 54, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 6)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (55, 22, 36, 55, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 6)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (56, 20, 27, 56, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 6)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (57, 30, 33, 57, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 6)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (58, 21, 31, 58, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 6)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (59, 32, 29, 59, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 6)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (60, 19, 24, 60, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 6)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (61, 34, 37, 61, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 6)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (62, 35, 26, 62, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 6)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (63, 54, 48, 63, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 7)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (64, 53, 46, 64, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 7)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (65, 52, 41, 65, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 7)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (66, 51, 40, 66, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 7)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (67, 56, 43, 67, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 7)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (68, 45, 39, 68, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 7)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (69, 47, 38, 69, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 7)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (70, 49, 50, 70, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 7)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (71, 42, 44, 71, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 7)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (72, 74, 79, 72, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 8)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (73, 66, 65, 73, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 8)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (74, 73, 71, 74, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 8)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (75, 62, 67, 75, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 8)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (76, 69, 78, 76, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 8)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (77, 60, 64, 77, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 8)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (78, 59, 57, 78, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 8)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (79, 70, 80, 79, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 8)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (80, 77, 75, 80, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 8)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (81, 61, 68, 81, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 8)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (82, 58, 72, 82, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 8)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (83, 15, 16, 83, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 9)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (84, 18, 6, 84, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 9)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (85, 14, 9, 85, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 9)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (86, 17, 11, 86, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 9)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (87, 7, 3, 87, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 9)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (88, 13, 5, 88, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 9)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (89, 12, 4, 89, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 9)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (90, 2, 8, 90, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 9)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (91, 10, 1, 91, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 9)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (92, 26, 34, 92, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 10)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (93, 37, 19, 93, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 10)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (94, 24, 32, 94, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 10)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (95, 29, 21, 95, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 10)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (96, 31, 30, 96, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 10)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (97, 33, 20, 97, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 10)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (98, 27, 22, 98, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 10)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (99, 36, 28, 99, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 10)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (100, 23, 25, 100, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 10)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (101, 44, 49, 101, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 11)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (102, 50, 47, 102, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 11)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (103, 38, 45, 103, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 11)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (104, 39, 56, 104, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 11)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (105, 43, 51, 105, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 11)
GO
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (106, 40, 52, 106, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 11)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (107, 41, 53, 107, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 11)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (108, 46, 54, 108, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 11)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (109, 48, 55, 109, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 11)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (110, 78, 62, 110, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 12)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (111, 67, 73, 111, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 12)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (112, 71, 66, 112, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 12)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (113, 65, 74, 113, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 12)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (114, 79, 63, 114, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 12)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (115, 64, 58, 115, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 12)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (116, 72, 61, 116, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 12)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (117, 68, 77, 117, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 12)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (118, 75, 70, 118, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 12)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (119, 80, 59, 119, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 12)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (120, 57, 60, 120, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 12)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (121, 10, 15, 121, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 13)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (122, 1, 2, 122, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 13)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (123, 8, 12, 123, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 13)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (124, 4, 13, 124, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 13)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (125, 5, 7, 125, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 13)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (126, 3, 17, 126, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 13)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (127, 11, 14, 127, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 13)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (128, 9, 18, 128, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 13)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (129, 6, 16, 129, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 13)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (130, 25, 36, 130, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 14)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (131, 28, 27, 131, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 14)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (132, 22, 33, 132, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 14)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (133, 20, 31, 133, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 14)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (134, 30, 29, 134, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 14)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (135, 21, 24, 135, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 14)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (136, 32, 37, 136, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 14)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (137, 19, 26, 137, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 14)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (138, 34, 35, 138, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 14)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (139, 55, 46, 139, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 15)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (140, 54, 41, 140, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 15)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (141, 53, 40, 141, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 15)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (142, 52, 43, 142, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 15)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (143, 51, 39, 143, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 15)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (144, 56, 38, 144, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 15)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (145, 45, 50, 145, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 15)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (146, 47, 44, 146, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 15)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (147, 49, 42, 147, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 15)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (148, 63, 65, 148, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 16)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (149, 74, 71, 149, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 16)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (150, 66, 67, 150, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 16)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (151, 73, 78, 151, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 16)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (152, 62, 69, 152, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 16)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (153, 57, 64, 153, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 16)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (154, 60, 80, 154, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 16)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (155, 59, 75, 155, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 16)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (156, 70, 68, 156, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 16)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (157, 77, 72, 157, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 16)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (158, 61, 58, 158, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 16)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (159, 65, 73, 159, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 16)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (161, 15, 6, 161, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 17)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (162, 16, 9, 162, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 17)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (163, 18, 11, 163, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 17)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (164, 14, 3, 164, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 17)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (165, 17, 5, 165, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 17)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (166, 7, 4, 166, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 17)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (167, 13, 8, 167, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 17)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (168, 12, 1, 168, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 17)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (169, 2, 10, 169, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 17)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (170, 35, 19, 170, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 18)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (171, 26, 32, 171, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 18)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (172, 37, 21, 172, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 18)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (173, 24, 30, 173, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 18)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (174, 29, 20, 174, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 18)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (175, 31, 22, 175, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 18)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (176, 33, 28, 176, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 18)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (177, 27, 25, 177, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 18)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (178, 36, 23, 178, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 18)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (179, 42, 47, 179, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 19)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (180, 44, 45, 180, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 19)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (181, 50, 56, 181, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 19)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (182, 38, 51, 182, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 19)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (183, 39, 52, 183, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 19)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (184, 43, 53, 184, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 19)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (185, 40, 54, 185, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 19)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (186, 41, 55, 186, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 19)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (187, 46, 48, 187, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 19)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (188, 69, 73, 188, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 20)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (189, 78, 66, 189, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 20)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (190, 67, 74, 190, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 20)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (191, 71, 63, 191, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 20)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (192, 65, 79, 192, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 20)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (193, 64, 61, 193, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 20)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (194, 58, 77, 194, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 20)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (195, 72, 70, 195, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 20)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (196, 68, 59, 196, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 20)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (197, 75, 60, 197, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 20)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (198, 80, 57, 198, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 20)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (199, 60, 59, 199, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 20)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (200, 2, 15, 200, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 21)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (201, 10, 12, 201, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 21)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (202, 1, 13, 202, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 21)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (203, 8, 7, 203, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 21)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (204, 4, 17, 204, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 21)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (205, 5, 14, 205, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 21)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (206, 3, 18, 206, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 21)
GO
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (207, 11, 16, 207, CAST(N'2021-02-17T00:00:00.000' AS DateTime), 21)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (208, 9, 6, 208, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 21)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (209, 23, 27, 209, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 22)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (210, 25, 33, 210, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 22)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (211, 28, 31, 211, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 22)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (212, 22, 29, 212, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 22)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (213, 20, 24, 213, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 22)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (214, 30, 37, 214, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 22)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (215, 21, 26, 215, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 22)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (216, 32, 35, 216, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 22)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (217, 19, 34, 217, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 22)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (218, 48, 41, 218, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 23)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (219, 55, 40, 219, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 23)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (220, 54, 43, 220, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 23)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (221, 53, 39, 221, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 23)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (222, 52, 38, 222, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 23)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (223, 51, 50, 223, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 23)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (224, 56, 44, 224, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 23)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (225, 45, 42, 225, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 23)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (226, 47, 49, 226, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 23)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (227, 79, 71, 227, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 24)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (228, 63, 67, 228, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 24)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (229, 74, 78, 229, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 24)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (230, 66, 69, 230, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 24)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (231, 73, 62, 231, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 24)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (232, 80, 64, 232, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 24)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (233, 57, 75, 233, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 24)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (234, 60, 68, 234, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 24)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (235, 59, 72, 235, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 24)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (236, 70, 58, 236, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 24)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (237, 77, 61, 237, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 24)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (238, 15, 9, 238, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 25)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (239, 6, 11, 239, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 25)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (240, 16, 3, 240, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 25)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (241, 18, 5, 241, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 25)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (242, 14, 4, 242, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 25)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (243, 17, 8, 243, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 25)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (244, 7, 1, 244, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 25)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (245, 13, 10, 245, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 25)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (246, 12, 2, 246, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 25)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (247, 34, 32, 247, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 26)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (248, 35, 21, 248, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 26)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (249, 26, 30, 249, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 26)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (250, 37, 20, 250, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 26)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (251, 24, 22, 251, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 26)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (252, 29, 28, 252, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 26)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (253, 31, 25, 253, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 26)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (254, 33, 23, 254, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 26)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (255, 27, 36, 255, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 26)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (256, 49, 45, 256, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 27)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (257, 42, 56, 257, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 27)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (258, 44, 51, 258, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 27)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (259, 50, 52, 259, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 27)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (260, 38, 53, 260, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 27)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (261, 39, 54, 261, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 27)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (262, 43, 55, 262, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 27)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (263, 40, 48, 263, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 27)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (264, 41, 46, 264, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 27)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (265, 62, 66, 265, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 28)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (266, 69, 74, 266, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 28)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (267, 78, 63, 267, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 28)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (268, 67, 79, 268, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 28)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (269, 71, 65, 269, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 28)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (270, 64, 77, 270, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 28)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (271, 61, 70, 271, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 28)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (272, 58, 59, 272, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 28)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (273, 72, 60, 273, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 28)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (274, 68, 57, 274, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 28)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (275, 75, 80, 275, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 28)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (276, 12, 15, 276, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 29)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (277, 2, 13, 277, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 29)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (278, 10, 7, 278, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 29)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (279, 1, 17, 279, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 29)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (280, 8, 14, 280, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 29)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (281, 4, 18, 281, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 29)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (282, 5, 16, 282, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 29)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (283, 3, 6, 283, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 29)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (284, 11, 9, 284, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 29)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (285, 36, 33, 285, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 30)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (286, 23, 31, 286, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 30)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (287, 25, 29, 287, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 30)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (288, 28, 24, 288, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 30)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (289, 22, 37, 289, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 30)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (290, 20, 26, 290, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 30)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (291, 30, 35, 291, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 30)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (292, 21, 34, 292, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 30)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (293, 32, 19, 293, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 30)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (294, 46, 40, 294, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 31)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (295, 48, 43, 295, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 31)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (296, 55, 39, 296, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 31)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (297, 54, 38, 297, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 31)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (298, 53, 50, 298, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 31)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (299, 52, 44, 299, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 31)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (300, 51, 42, 300, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 31)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (301, 56, 49, 301, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 31)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (302, 45, 47, 302, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 31)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (304, 42, 56, 304, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 31)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (305, 65, 67, 305, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 32)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (306, 79, 78, 306, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 32)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (307, 63, 69, 307, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 32)
GO
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (308, 74, 62, 308, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 32)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (309, 66, 73, 309, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 32)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (310, 75, 64, 310, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 32)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (311, 80, 68, 311, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 32)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (312, 57, 72, 312, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 32)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (313, 60, 58, 313, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 32)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (314, 59, 61, 314, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 32)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (315, 70, 77, 315, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 32)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (316, 15, 11, 316, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 33)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (317, 9, 3, 317, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 33)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (318, 6, 5, 318, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 33)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (319, 16, 4, 319, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 33)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (320, 18, 8, 320, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 33)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (321, 14, 1, 321, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 33)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (322, 17, 10, 322, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 33)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (323, 7, 2, 323, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 33)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (324, 13, 12, 324, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 33)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (325, 19, 21, 325, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 34)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (326, 34, 30, 326, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 34)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (327, 35, 20, 327, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 34)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (328, 26, 22, 328, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 34)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (329, 37, 28, 329, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 34)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (330, 24, 25, 330, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 34)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (331, 29, 23, 331, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 34)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (332, 31, 36, 332, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 34)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (333, 33, 27, 333, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 34)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (335, 28, 24, 335, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 34)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (336, 47, 56, 336, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 35)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (337, 49, 51, 337, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 35)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (338, 42, 52, 338, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 35)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (339, 44, 53, 339, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 35)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (340, 50, 54, 340, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 35)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (341, 38, 55, 341, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 35)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (342, 39, 48, 342, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 35)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (343, 43, 46, 343, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 35)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (344, 40, 41, 344, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 35)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (346, 73, 74, 346, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 36)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (347, 62, 63, 347, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 36)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (348, 69, 79, 348, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 36)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (349, 78, 65, 349, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 36)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (350, 67, 71, 350, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 36)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (351, 64, 70, 351, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 36)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (352, 77, 59, 352, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 36)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (353, 61, 60, 353, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 36)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (354, 58, 57, 354, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 36)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (355, 72, 80, 355, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 36)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (356, 68, 75, 356, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 36)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (357, 13, 15, 357, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 37)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (358, 12, 7, 358, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 37)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (359, 2, 17, 359, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 37)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (360, 10, 14, 360, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 37)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (361, 1, 18, 361, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 37)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (362, 8, 16, 362, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 37)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (363, 4, 6, 363, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 37)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (364, 5, 9, 364, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 37)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (365, 3, 11, 365, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 37)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (367, 7, 4, 367, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 37)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (368, 17, 5, 368, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 37)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (369, 27, 31, 369, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 38)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (370, 36, 29, 370, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 38)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (371, 23, 24, 371, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 38)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (372, 25, 37, 372, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 38)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (373, 28, 26, 373, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 38)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (374, 22, 35, 374, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 38)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (375, 20, 34, 375, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 38)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (376, 30, 19, 376, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 38)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (377, 21, 32, 377, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 38)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (378, 41, 43, 378, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 39)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (379, 46, 39, 379, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 39)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (380, 48, 38, 380, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 39)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (381, 55, 50, 381, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 39)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (382, 54, 44, 382, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 39)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (383, 53, 42, 383, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 39)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (384, 52, 49, 384, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 39)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (385, 51, 47, 385, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 39)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (386, 56, 48, 386, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 39)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (387, 71, 78, 387, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 40)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (388, 65, 69, 388, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 40)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (389, 79, 62, 389, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 40)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (390, 63, 73, 390, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 40)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (391, 74, 66, 391, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 40)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (392, 68, 64, 392, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 40)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (393, 75, 72, 393, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 40)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (394, 80, 58, 394, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 40)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (395, 57, 61, 395, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 40)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (396, 60, 77, 396, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 40)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (397, 59, 70, 397, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 40)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (398, 15, 3, 398, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 41)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (399, 11, 5, 399, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 41)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (400, 9, 4, 400, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 41)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (401, 6, 8, 401, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 41)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (402, 16, 1, 402, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 41)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (403, 18, 10, 403, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 41)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (404, 14, 2, 404, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 41)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (405, 17, 12, 405, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 41)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (406, 7, 13, 406, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 41)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (407, 9, 7, 407, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 41)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (408, 32, 30, 408, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 42)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (409, 19, 20, 409, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 42)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (410, 34, 22, 410, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 42)
GO
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (411, 35, 28, 411, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 42)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (412, 26, 25, 412, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 42)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (413, 37, 23, 413, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 42)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (414, 24, 36, 414, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 42)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (415, 29, 27, 415, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 42)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (416, 31, 33, 416, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 42)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (417, 45, 51, 417, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 43)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (418, 47, 52, 418, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 43)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (419, 49, 53, 419, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 43)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (420, 42, 54, 420, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 43)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (421, 44, 55, 421, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 43)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (422, 50, 48, 422, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 43)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (423, 38, 46, 423, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 43)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (424, 39, 41, 424, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 43)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (425, 43, 40, 425, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 43)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (426, 66, 63, 426, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 44)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (427, 73, 79, 427, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 44)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (428, 62, 65, 428, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 44)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (429, 69, 71, 429, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 44)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (430, 78, 67, 430, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 44)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (431, 64, 59, 431, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 44)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (432, 70, 60, 432, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 44)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (433, 77, 57, 433, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 44)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (434, 61, 80, 434, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 44)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (435, 58, 75, 435, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 44)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (436, 72, 68, 436, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 44)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (437, 7, 15, 437, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 45)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (438, 13, 17, 438, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 45)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (439, 12, 14, 439, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 45)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (440, 2, 18, 440, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 45)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (441, 10, 16, 441, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 45)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (442, 1, 6, 442, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 45)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (443, 8, 9, 443, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 45)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (444, 4, 11, 444, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 45)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (445, 5, 3, 445, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 45)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (446, 33, 29, 446, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 46)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (447, 27, 24, 447, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 46)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (448, 36, 37, 448, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 46)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (449, 23, 26, 449, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 46)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (450, 25, 35, 450, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 46)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (451, 28, 34, 451, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 46)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (452, 22, 19, 452, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 46)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (453, 20, 32, 453, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 46)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (454, 30, 21, 454, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 46)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (455, 40, 39, 455, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 47)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (456, 41, 38, 456, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 47)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (457, 46, 50, 457, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 47)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (458, 48, 44, 458, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 47)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (459, 55, 42, 459, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 47)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (460, 54, 49, 460, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 47)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (461, 53, 47, 461, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 47)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (462, 52, 45, 462, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 47)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (463, 51, 56, 463, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 47)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (464, 69, 67, 464, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 48)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (465, 62, 71, 465, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 48)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (466, 73, 65, 466, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 48)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (467, 66, 79, 467, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 48)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (468, 74, 63, 468, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 48)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (469, 72, 64, 469, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 48)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (470, 58, 68, 470, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 48)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (471, 61, 75, 471, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 48)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (472, 77, 80, 472, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 48)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (473, 70, 57, 473, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 48)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (474, 59, 60, 474, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 48)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (475, 15, 5, 475, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 49)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (476, 3, 4, 476, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 49)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (477, 11, 8, 477, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 49)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (478, 9, 1, 478, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 49)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (479, 6, 10, 479, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 49)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (480, 16, 2, 480, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 49)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (481, 18, 12, 481, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 49)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (482, 14, 13, 482, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 49)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (483, 17, 7, 483, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 49)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (485, 15, 9, 485, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 49)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (486, 21, 20, 486, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 50)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (487, 32, 22, 487, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 50)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (488, 19, 28, 488, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 50)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (489, 35, 23, 489, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 50)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (490, 34, 25, 490, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 50)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (491, 26, 36, 491, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 50)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (492, 37, 27, 492, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 50)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (493, 24, 33, 493, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 50)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (494, 29, 31, 494, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 50)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (495, 56, 52, 495, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 51)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (496, 45, 53, 496, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 51)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (497, 47, 54, 497, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 51)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (498, 49, 55, 498, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 51)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (499, 42, 48, 499, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 51)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (500, 44, 46, 500, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 51)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (501, 50, 41, 501, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 51)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (502, 38, 40, 502, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 51)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (503, 39, 43, 503, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 51)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (504, 79, 74, 504, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 52)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (505, 65, 66, 505, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 52)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (506, 71, 73, 506, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 52)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (507, 67, 62, 507, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 52)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (508, 78, 69, 508, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 52)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (509, 64, 60, 509, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 52)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (510, 57, 59, 510, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 52)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (511, 80, 70, 511, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 52)
GO
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (512, 75, 77, 512, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 52)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (513, 68, 61, 513, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 52)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (514, 72, 58, 514, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 52)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (516, 77, 57, 516, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 52)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (517, 17, 15, 517, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 53)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (518, 7, 14, 518, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 53)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (519, 13, 18, 519, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 53)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (520, 12, 16, 520, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 53)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (521, 2, 6, 521, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 53)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (522, 10, 9, 522, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 53)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (523, 1, 11, 523, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 53)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (524, 8, 3, 524, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 53)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (525, 4, 5, 525, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 53)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (526, 31, 24, 526, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 54)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (527, 33, 37, 527, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 54)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (528, 27, 26, 528, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 54)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (529, 36, 35, 529, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 54)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (530, 23, 34, 530, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 54)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (531, 25, 19, 531, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 54)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (532, 28, 32, 532, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 54)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (533, 22, 21, 533, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 54)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (534, 20, 30, 534, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 54)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (535, 43, 38, 535, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 55)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (536, 40, 50, 536, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 55)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (537, 41, 44, 537, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 55)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (538, 46, 42, 538, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 55)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (539, 48, 49, 539, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 55)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (540, 55, 47, 540, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 55)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (541, 54, 45, 541, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 55)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (542, 53, 56, 542, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 55)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (543, 52, 51, 543, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 55)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (544, 62, 78, 544, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 56)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (545, 73, 67, 545, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 56)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (546, 66, 71, 546, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 56)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (547, 74, 65, 547, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 56)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (548, 63, 79, 548, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 56)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (549, 58, 64, 549, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 56)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (550, 61, 72, 550, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 56)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (551, 77, 68, 551, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 56)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (552, 70, 75, 552, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 56)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (553, 59, 80, 553, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 56)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (554, 60, 57, 554, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 56)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (555, 15, 4, 555, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 57)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (556, 5, 8, 556, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 57)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (557, 3, 1, 557, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 57)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (558, 11, 10, 558, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 57)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (559, 9, 2, 559, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 57)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (560, 6, 12, 560, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 57)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (561, 16, 13, 561, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 57)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (562, 18, 7, 562, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 57)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (563, 14, 17, 563, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 57)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (564, 30, 22, 564, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 58)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (565, 21, 28, 565, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 58)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (566, 32, 25, 566, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 58)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (567, 19, 23, 567, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 58)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (568, 34, 36, 568, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 58)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (569, 35, 27, 569, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 58)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (570, 26, 33, 570, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 58)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (571, 37, 31, 571, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 58)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (572, 24, 29, 572, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 58)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (573, 51, 53, 573, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 59)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (574, 56, 54, 574, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 59)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (575, 45, 55, 575, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 59)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (576, 47, 48, 576, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 59)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (577, 49, 46, 577, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 59)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (578, 42, 41, 578, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 59)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (579, 44, 40, 579, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 59)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (580, 50, 43, 580, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 59)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (581, 38, 39, 581, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 59)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (582, 14, 15, 582, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 60)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (583, 17, 18, 583, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 60)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (584, 7, 16, 584, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 60)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (585, 13, 6, 585, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 60)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (586, 12, 9, 586, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 60)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (587, 2, 11, 587, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 60)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (588, 10, 3, 588, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 60)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (589, 1, 5, 589, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 60)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (590, 8, 4, 590, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 60)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (592, 7, 13, 592, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 60)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (593, 29, 37, 593, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 61)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (594, 31, 26, 594, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 61)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (595, 33, 35, 595, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 61)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (596, 27, 34, 596, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 61)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (597, 36, 19, 597, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 61)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (598, 23, 32, 598, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 61)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (599, 25, 21, 599, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 61)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (600, 28, 30, 600, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 61)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (601, 22, 20, 601, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 61)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (602, 39, 50, 602, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 62)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (603, 43, 44, 603, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 62)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (604, 40, 42, 604, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 62)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (605, 41, 49, 605, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 62)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (606, 46, 47, 606, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 62)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (607, 48, 45, 607, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 62)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (608, 55, 56, 608, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 62)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (609, 54, 51, 609, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 62)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (610, 53, 52, 610, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 62)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (611, 15, 8, 611, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 63)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (612, 4, 1, 612, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 63)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (613, 5, 10, 613, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 63)
GO
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (614, 3, 2, 614, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 63)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (615, 11, 12, 615, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 63)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (616, 9, 13, 616, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 63)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (617, 6, 7, 617, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 63)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (618, 16, 17, 618, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 63)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (619, 18, 14, 619, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 63)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (620, 20, 28, 620, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 64)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (621, 30, 25, 621, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 64)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (622, 21, 23, 622, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 64)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (623, 32, 36, 623, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 64)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (624, 19, 27, 624, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 64)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (625, 34, 33, 625, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 64)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (626, 35, 31, 626, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 64)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (627, 26, 29, 627, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 64)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (628, 37, 24, 628, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 64)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (629, 52, 54, 629, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 65)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (630, 51, 55, 630, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 65)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (631, 56, 48, 631, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 65)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (632, 45, 46, 632, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 65)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (633, 47, 41, 633, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 65)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (634, 49, 40, 634, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 65)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (635, 42, 43, 635, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 65)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (636, 44, 39, 636, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 65)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (637, 50, 38, 637, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 65)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (638, 18, 15, 638, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 66)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (639, 16, 14, 639, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 66)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (640, 6, 17, 640, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 66)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (641, 9, 7, 641, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 66)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (642, 11, 13, 642, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 66)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (643, 3, 12, 643, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 66)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (644, 5, 2, 644, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 66)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (645, 4, 10, 645, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 66)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (646, 8, 1, 646, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 66)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (647, 24, 26, 647, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 67)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (648, 29, 35, 648, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 67)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (649, 33, 19, 649, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 67)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (650, 31, 34, 650, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 67)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (651, 27, 32, 651, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 67)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (652, 36, 21, 652, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 67)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (653, 23, 30, 653, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 67)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (654, 25, 20, 654, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 67)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (655, 28, 22, 655, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 67)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (656, 38, 44, 656, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 68)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (657, 39, 42, 657, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 68)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (658, 43, 49, 658, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 68)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (659, 40, 47, 659, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 68)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (660, 41, 45, 660, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 68)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (661, 46, 56, 661, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 68)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (662, 48, 51, 662, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 68)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (663, 55, 52, 663, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 68)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (664, 54, 53, 664, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 68)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (666, 39, 50, 666, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 68)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (669, 15, 1, 669, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 69)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (670, 10, 8, 670, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 69)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (671, 2, 4, 671, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 69)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (672, 12, 5, 672, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 69)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (673, 13, 3, 673, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 69)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (674, 7, 11, 674, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 69)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (675, 17, 9, 675, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 69)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (676, 14, 6, 676, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 69)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (677, 18, 16, 677, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 69)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (679, 11, 13, 679, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 69)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (680, 22, 25, 680, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 70)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (681, 20, 23, 681, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 70)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (682, 30, 36, 682, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 70)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (683, 21, 27, 683, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 70)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (684, 32, 33, 684, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 70)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (685, 34, 29, 685, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 70)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (686, 19, 31, 686, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 70)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (687, 35, 24, 687, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 70)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (688, 26, 37, 688, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 70)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (689, 53, 54, 689, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 71)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (690, 52, 55, 690, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 71)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (691, 51, 48, 691, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 71)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (692, 56, 41, 692, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 71)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (693, 45, 40, 693, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 71)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (694, 47, 43, 694, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 71)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (695, 49, 39, 695, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 71)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (696, 42, 38, 696, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 71)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (697, 44, 50, 697, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 71)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (700, 16, 15, 700, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 72)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (701, 6, 18, 701, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 72)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (702, 9, 14, 702, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 72)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (703, 11, 17, 703, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 72)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (704, 3, 7, 704, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 72)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (705, 5, 13, 705, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 72)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (706, 4, 12, 706, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 72)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (707, 8, 2, 707, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 72)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (708, 1, 10, 708, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 72)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (709, 35, 37, 709, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 73)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (710, 34, 24, 710, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 73)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (711, 19, 29, 711, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 73)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (712, 32, 31, 712, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 73)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (713, 21, 33, 713, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 73)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (714, 30, 27, 714, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 73)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (715, 20, 36, 715, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 73)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (716, 22, 23, 716, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 73)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (717, 28, 25, 717, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 73)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (718, 42, 50, 718, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 74)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (719, 49, 38, 719, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 74)
GO
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (720, 47, 39, 720, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 74)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (721, 45, 43, 721, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 74)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (722, 56, 40, 722, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 74)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (723, 51, 41, 723, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 74)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (724, 52, 46, 724, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 74)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (725, 53, 48, 725, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 74)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (726, 54, 55, 726, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 74)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (727, 48, 54, 727, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 74)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (728, 46, 53, 728, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 74)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (729, 41, 52, 729, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 74)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (730, 40, 51, 730, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 74)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (731, 43, 56, 731, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 74)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (732, 39, 45, 732, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 74)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (733, 38, 47, 733, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 74)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (734, 50, 49, 734, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 74)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (735, 44, 42, 735, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 74)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (736, 15, 10, 736, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 75)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (737, 2, 1, 737, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 75)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (738, 12, 8, 738, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 75)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (739, 13, 4, 739, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 75)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (740, 7, 5, 740, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 75)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (741, 17, 3, 741, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 75)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (742, 14, 11, 742, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 75)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (743, 18, 9, 743, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 75)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (744, 16, 6, 744, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 75)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (745, 23, 28, 745, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 76)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (746, 36, 22, 746, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 76)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (747, 27, 20, 747, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 76)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (748, 33, 30, 748, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 76)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (749, 31, 21, 749, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 76)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (750, 29, 32, 750, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 76)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (751, 24, 19, 751, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 76)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (752, 37, 34, 752, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 76)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (753, 26, 35, 753, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 76)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (754, 48, 54, 754, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 77)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (755, 46, 53, 755, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 77)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (756, 41, 52, 756, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 77)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (757, 40, 51, 757, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 77)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (758, 43, 56, 758, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 77)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (759, 39, 45, 759, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 77)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (760, 38, 47, 760, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 77)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (761, 50, 49, 761, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 77)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (762, 44, 42, 762, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 77)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (763, 6, 15, 763, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 78)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (764, 9, 16, 764, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 78)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (765, 11, 18, 765, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 78)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (766, 3, 14, 766, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 78)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (767, 5, 17, 767, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 78)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (768, 4, 7, 768, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 78)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (769, 8, 13, 769, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 78)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (770, 1, 12, 770, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 78)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (771, 10, 2, 771, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 78)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (773, 17, 9, 773, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 78)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (774, 34, 26, 774, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 79)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (775, 19, 37, 775, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 79)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (776, 32, 24, 776, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 79)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (777, 21, 29, 777, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 79)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (778, 30, 31, 778, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 79)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (779, 20, 33, 779, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 79)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (780, 22, 27, 780, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 79)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (781, 28, 36, 781, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 79)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (782, 25, 23, 782, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 79)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (783, 15, 2, 783, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 80)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (784, 12, 10, 784, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 80)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (785, 13, 1, 785, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 80)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (786, 7, 8, 786, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 80)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (787, 17, 4, 787, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 80)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (788, 14, 5, 788, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 80)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (789, 18, 3, 789, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 80)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (790, 16, 11, 790, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 80)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (791, 6, 9, 791, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 80)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (792, 36, 25, 792, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 81)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (793, 27, 28, 793, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 81)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (794, 33, 22, 794, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 81)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (795, 31, 20, 795, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 81)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (796, 29, 30, 796, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 81)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (797, 24, 21, 797, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 81)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (798, 37, 32, 798, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 81)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (799, 26, 19, 799, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 81)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (800, 35, 34, 800, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 81)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (802, 37, 34, 802, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 81)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (803, 19, 35, 803, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 82)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (804, 32, 26, 804, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 82)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (805, 21, 37, 805, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 82)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (806, 30, 24, 806, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 82)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (807, 20, 29, 807, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 82)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (808, 22, 31, 808, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 82)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (809, 28, 33, 809, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 82)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (810, 25, 27, 810, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 82)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (811, 23, 36, 811, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 82)
INSERT [dbo].[Partido] ([Id], [IdEquipo1], [IdEquipo2], [Prioridad], [Fecha], [IdFecha]) VALUES (813, 34, 22, 813, CAST(N'2018-02-17T00:00:00.000' AS DateTime), 82)
SET IDENTITY_INSERT [dbo].[Partido] OFF
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (1, 1, 1, 11, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (1, 39, 2, 12, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (2, 2, 1, 8, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (2, 40, 2, 4, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (3, 3, 1, 7, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (3, 41, 2, 11, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (4, 4, 1, 13, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (4, 42, 2, 14, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (5, 5, 1, 12, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (5, 43, 2, 13, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (6, 6, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (6, 44, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (7, 7, 1, 14, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (7, 45, 2, 15, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (8, 8, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (8, 46, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (9, 9, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (9, 47, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (10, 10, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (10, 48, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (11, 11, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (11, 49, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (12, 12, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (12, 50, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (13, 13, 1, 8, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (13, 51, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (14, 14, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (14, 52, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (15, 15, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (15, 53, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (16, 16, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (16, 54, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (17, 17, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (17, 55, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (18, 18, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (18, 56, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (22, 19, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (22, 57, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (23, 20, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (23, 58, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (24, 21, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (24, 59, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (25, 22, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (25, 60, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (26, 23, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (26, 61, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (27, 24, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (27, 62, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (28, 25, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (28, 63, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (29, 26, 1, 9, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (29, 64, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (30, 27, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (30, 65, 2, 9, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (31, 28, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (31, 66, 2, 6, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (32, 29, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (32, 67, 2, 3, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (33, 30, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (33, 68, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (34, 31, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (34, 69, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (35, 32, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (35, 70, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (36, 33, 1, 9, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (36, 71, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (37, 34, 1, 7, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (37, 72, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (38, 35, 1, 6, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (38, 73, 2, 9, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (39, 36, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (39, 74, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (40, 37, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (40, 75, 2, 8, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (41, 38, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (41, 76, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (42, 2, 1, 8, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (42, 40, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (43, 1, 1, 9, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (43, 39, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (44, 3, 1, 7, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (44, 41, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (45, 4, 1, 6, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (45, 42, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (46, 5, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (46, 43, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (47, 6, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (47, 44, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (48, 7, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (48, 45, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (49, 8, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (49, 46, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (50, 9, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (50, 47, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (54, 10, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (54, 48, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (55, 11, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (55, 49, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (56, 12, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (56, 50, 2, NULL, 0)
GO
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (57, 13, 1, 8, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (57, 51, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (58, 15, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (58, 53, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (59, 14, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (59, 52, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (60, 16, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (60, 54, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (61, 17, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (61, 55, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (62, 18, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (62, 56, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (63, 19, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (63, 57, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (64, 20, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (64, 58, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (65, 21, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (65, 59, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (66, 22, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (66, 60, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (67, 24, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (67, 62, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (68, 23, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (68, 61, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (69, 25, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (69, 63, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (70, 26, 1, 9, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (70, 64, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (71, 27, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (71, 65, 2, 9, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (72, 28, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (72, 66, 2, 6, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (73, 29, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (73, 67, 2, 3, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (74, 31, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (74, 69, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (75, 30, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (75, 68, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (76, 32, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (76, 70, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (77, 34, 1, 7, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (77, 72, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (78, 33, 1, 9, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (78, 71, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (79, 35, 1, 6, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (79, 73, 2, 9, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (80, 37, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (80, 75, 2, 8, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (81, 36, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (81, 74, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (82, 38, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (82, 76, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (83, 4, 1, 6, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (83, 41, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (84, 2, 1, 8, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (84, 40, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (85, 1, 1, 9, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (85, 42, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (86, 5, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (86, 43, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (87, 7, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (87, 45, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (88, 6, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (88, 44, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (89, 9, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (89, 47, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (90, 8, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (90, 46, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (91, 3, 1, 7, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (91, 38, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (92, 10, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (92, 48, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (93, 11, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (93, 49, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (94, 12, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (94, 50, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (95, 13, 1, 8, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (95, 51, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (96, 14, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (96, 52, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (97, 15, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (97, 53, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (98, 16, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (98, 54, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (99, 17, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (99, 55, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (100, 19, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (100, 57, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (101, 18, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (101, 56, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (102, 20, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (102, 58, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (103, 21, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (103, 59, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (104, 22, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (104, 60, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (105, 23, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (105, 61, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (106, 24, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (106, 62, 2, NULL, 0)
GO
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (107, 25, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (107, 63, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (108, 26, 1, 9, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (108, 64, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (109, 28, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (109, 66, 2, 6, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (110, 27, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (110, 65, 2, 9, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (111, 29, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (111, 67, 2, 3, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (112, 30, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (112, 68, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (113, 31, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (113, 69, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (114, 33, 1, 9, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (114, 71, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (115, 32, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (115, 70, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (116, 34, 1, 7, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (116, 72, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (117, 35, 1, 6, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (117, 73, 2, 9, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (118, 36, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (118, 74, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (119, 37, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (119, 75, 2, 8, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (120, 39, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (120, 77, 2, 8, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (121, 5, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (121, 42, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (122, 1, 1, 9, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (122, 43, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (123, 2, 1, 8, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (123, 40, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (124, 7, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (124, 45, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (125, 3, 1, 7, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (125, 41, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (126, 4, 1, 6, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (126, 46, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (127, 9, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (127, 47, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (128, 6, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (128, 44, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (129, 10, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (129, 48, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (130, 8, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (130, 50, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (131, 11, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (131, 49, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (132, 12, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (132, 56, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (133, 17, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (133, 55, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (134, 16, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (134, 54, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (135, 18, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (135, 57, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (136, 15, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (136, 53, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (137, 13, 1, 8, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (137, 51, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (138, 14, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (138, 52, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (139, 19, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (139, 59, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (140, 20, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (140, 58, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (141, 21, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (141, 65, 2, 9, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (142, 26, 1, 9, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (142, 64, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (143, 25, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (143, 63, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (144, 27, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (144, 66, 2, 6, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (145, 24, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (145, 62, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (146, 22, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (146, 60, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (147, 23, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (147, 61, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (148, 28, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (148, 72, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (149, 33, 1, 9, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (149, 71, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (150, 32, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (150, 70, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (151, 34, 1, 7, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (151, 73, 2, 9, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (152, 31, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (152, 69, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (153, 29, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (153, 67, 2, 3, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (154, 30, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (154, 68, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (155, 35, 1, 6, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (155, 77, 2, 8, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (156, 38, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (156, 76, 2, NULL, 0)
GO
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (157, 39, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (157, 78, 2, 8, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (158, 37, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (158, 75, 2, 8, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (159, 36, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (159, 74, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (161, 6, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (161, 37, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (162, 3, 1, 7, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (162, 46, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (163, 7, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (163, 41, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (164, 10, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (164, 48, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (165, 1, 1, 9, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (165, 47, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (166, 2, 1, 8, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (166, 42, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (167, 11, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (167, 49, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (168, 5, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (168, 45, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (169, 4, 1, 6, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (169, 44, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (170, 8, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (170, 43, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (171, 9, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (171, 54, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (172, 12, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (172, 50, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (173, 17, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (173, 55, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (174, 18, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (174, 56, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (175, 19, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (175, 57, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (176, 16, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (176, 58, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (177, 13, 1, 8, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (177, 51, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (178, 14, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (178, 52, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (179, 15, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (179, 53, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (180, 20, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (180, 63, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (181, 21, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (181, 59, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (182, 26, 1, 9, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (182, 64, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (183, 27, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (183, 65, 2, 9, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (184, 28, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (184, 66, 2, 6, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (185, 25, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (185, 67, 2, 3, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (186, 22, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (186, 60, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (187, 23, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (187, 61, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (188, 24, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (188, 62, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (189, 33, 1, 9, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (189, 71, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (190, 34, 1, 7, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (190, 72, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (191, 35, 1, 6, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (191, 73, 2, 9, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (192, 32, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (192, 70, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (193, 30, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (193, 68, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (194, 29, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (194, 69, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (195, 31, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (195, 77, 2, 8, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (196, 39, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (196, 78, 2, 8, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (197, 40, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (197, 79, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (198, 38, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (198, 76, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (199, 36, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (199, 74, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (200, 9, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (200, 35, 2, 6, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (201, 7, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (201, 36, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (202, 8, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (202, 37, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (203, 4, 1, 6, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (203, 48, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (204, 6, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (204, 44, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (205, 5, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (205, 43, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (206, 3, 1, 7, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (206, 42, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (207, 1, 1, 9, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (207, 45, 2, NULL, 0)
GO
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (208, 11, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (208, 47, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (209, 2, 1, 8, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (209, 46, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (210, 10, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (210, 49, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (211, 12, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (211, 50, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (212, 15, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (212, 53, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (213, 13, 1, 8, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (213, 51, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (214, 18, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (214, 56, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (215, 16, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (215, 55, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (216, 17, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (216, 57, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (217, 19, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (217, 58, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (218, 14, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (218, 52, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (219, 20, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (219, 54, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (220, 21, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (220, 59, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (221, 24, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (221, 62, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (222, 22, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (222, 60, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (223, 27, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (223, 65, 2, 9, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (224, 25, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (224, 64, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (225, 26, 1, 9, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (225, 66, 2, 6, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (226, 28, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (226, 67, 2, 3, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (227, 23, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (227, 61, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (228, 31, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (228, 63, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (229, 29, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (229, 68, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (230, 34, 1, 7, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (230, 72, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (231, 32, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (231, 70, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (232, 39, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (232, 69, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (233, 30, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (233, 73, 2, 9, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (234, 33, 1, 9, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (234, 71, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (235, 40, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (235, 79, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (236, 41, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (236, 78, 2, 8, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (237, 38, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (237, 76, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (247, 1, 1, 9, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (247, 30, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (248, 2, 1, 8, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (248, 31, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (249, 3, 1, 7, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (249, 32, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (250, 4, 1, 6, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (250, 33, 2, 9, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (251, 5, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (251, 34, 2, 7, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (252, 6, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (252, 35, 2, 6, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (253, 7, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (253, 36, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (254, 8, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (254, 37, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (255, 9, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (255, 38, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (256, 10, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (256, 39, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (257, 11, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (257, 40, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (258, 12, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (258, 41, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (259, 13, 1, 8, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (259, 42, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (260, 14, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (260, 43, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (261, 15, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (261, 44, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (262, 16, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (262, 45, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (263, 17, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (263, 46, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (264, 18, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (264, 47, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (265, 19, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (265, 48, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (266, 20, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (266, 49, 2, NULL, 0)
GO
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (267, 21, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (267, 50, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (268, 22, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (268, 51, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (269, 23, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (269, 52, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (270, 24, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (270, 53, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (271, 25, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (271, 54, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (272, 26, 1, 9, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (272, 55, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (273, 27, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (273, 56, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (274, 28, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (274, 57, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (275, 29, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (275, 58, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (285, 1, 1, 9, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (285, 31, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (286, 2, 1, 8, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (286, 32, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (287, 3, 1, 7, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (287, 33, 2, 9, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (288, 4, 1, 6, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (288, 34, 2, 7, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (289, 5, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (289, 35, 2, 6, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (290, 6, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (290, 36, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (291, 7, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (291, 37, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (292, 8, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (292, 38, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (293, 9, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (293, 39, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (294, 10, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (294, 40, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (295, 11, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (295, 41, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (296, 12, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (296, 42, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (297, 13, 1, 8, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (297, 43, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (298, 14, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (298, 44, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (299, 15, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (299, 45, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (300, 16, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (300, 46, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (301, 17, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (301, 47, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (302, 18, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (302, 48, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (304, 19, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (304, 49, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (305, 20, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (305, 50, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (306, 21, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (306, 51, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (307, 22, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (307, 52, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (308, 23, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (308, 53, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (309, 24, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (309, 54, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (310, 25, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (310, 55, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (311, 26, 1, 9, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (311, 56, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (312, 27, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (312, 57, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (313, 28, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (313, 58, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (314, 29, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (314, 59, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (315, 30, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (315, 60, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (325, 1, 1, 9, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (325, 31, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (326, 2, 1, 8, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (326, 32, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (327, 3, 1, 7, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (327, 33, 2, 9, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (328, 4, 1, 6, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (328, 34, 2, 7, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (329, 5, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (329, 35, 2, 6, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (330, 6, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (330, 36, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (331, 7, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (331, 37, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (332, 8, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (332, 38, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (333, 9, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (333, 39, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (335, 11, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (335, 40, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (336, 10, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (336, 41, 2, NULL, 0)
GO
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (337, 12, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (337, 42, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (338, 13, 1, 8, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (338, 43, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (339, 14, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (339, 44, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (340, 15, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (340, 45, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (341, 16, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (341, 46, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (342, 17, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (342, 47, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (343, 18, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (343, 48, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (344, 19, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (344, 49, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (346, 20, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (346, 50, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (347, 21, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (347, 51, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (348, 22, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (348, 52, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (349, 23, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (349, 53, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (350, 24, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (350, 54, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (351, 25, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (351, 55, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (352, 26, 1, 9, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (352, 56, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (353, 27, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (353, 57, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (354, 28, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (354, 58, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (355, 29, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (355, 59, 2, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (356, 30, 1, NULL, 0)
INSERT [dbo].[PartidoArbitro] ([IdPartido], [IdArbitro], [IdTipoArbitro], [IdCalificacion], [Procesado]) VALUES (356, 60, 2, NULL, 0)
SET IDENTITY_INSERT [dbo].[Permiso] ON 

INSERT [dbo].[Permiso] ([Id], [Descripcion], [EsPermiso]) VALUES (1, N'Administrador', 0)
INSERT [dbo].[Permiso] ([Id], [Descripcion], [EsPermiso]) VALUES (2, N'Técnico', 0)
INSERT [dbo].[Permiso] ([Id], [Descripcion], [EsPermiso]) VALUES (3, N'Gestor', 0)
INSERT [dbo].[Permiso] ([Id], [Descripcion], [EsPermiso]) VALUES (4, N'Evaluador', 0)
INSERT [dbo].[Permiso] ([Id], [Descripcion], [EsPermiso]) VALUES (5, N'Designador', 0)
INSERT [dbo].[Permiso] ([Id], [Descripcion], [EsPermiso]) VALUES (6, N'Administración', 0)
INSERT [dbo].[Permiso] ([Id], [Descripcion], [EsPermiso]) VALUES (7, N'Designación', 0)
INSERT [dbo].[Permiso] ([Id], [Descripcion], [EsPermiso]) VALUES (8, N'Evaluación', 0)
INSERT [dbo].[Permiso] ([Id], [Descripcion], [EsPermiso]) VALUES (9, N'Seguridad', 0)
INSERT [dbo].[Permiso] ([Id], [Descripcion], [EsPermiso]) VALUES (10, N'Servicios', 0)
INSERT [dbo].[Permiso] ([Id], [Descripcion], [EsPermiso]) VALUES (11, N'Personalizar', 0)
INSERT [dbo].[Permiso] ([Id], [Descripcion], [EsPermiso]) VALUES (12, N'Árbitros', 1)
INSERT [dbo].[Permiso] ([Id], [Descripcion], [EsPermiso]) VALUES (13, N'Campeonatos', 1)
INSERT [dbo].[Permiso] ([Id], [Descripcion], [EsPermiso]) VALUES (14, N'Categorías', 1)
INSERT [dbo].[Permiso] ([Id], [Descripcion], [EsPermiso]) VALUES (15, N'Equipos', 1)
INSERT [dbo].[Permiso] ([Id], [Descripcion], [EsPermiso]) VALUES (16, N'Partidos', 1)
INSERT [dbo].[Permiso] ([Id], [Descripcion], [EsPermiso]) VALUES (17, N'Realizar designación', 1)
INSERT [dbo].[Permiso] ([Id], [Descripcion], [EsPermiso]) VALUES (18, N'Calificar árbitros', 1)
INSERT [dbo].[Permiso] ([Id], [Descripcion], [EsPermiso]) VALUES (19, N'Promoción/Descenso', 1)
INSERT [dbo].[Permiso] ([Id], [Descripcion], [EsPermiso]) VALUES (20, N'Usuarios', 1)
INSERT [dbo].[Permiso] ([Id], [Descripcion], [EsPermiso]) VALUES (21, N'Gestionar Perfiles', 1)
INSERT [dbo].[Permiso] ([Id], [Descripcion], [EsPermiso]) VALUES (22, N'Crear Perfiles', 1)
INSERT [dbo].[Permiso] ([Id], [Descripcion], [EsPermiso]) VALUES (23, N'Backup', 1)
INSERT [dbo].[Permiso] ([Id], [Descripcion], [EsPermiso]) VALUES (24, N'Idioma', 1)
INSERT [dbo].[Permiso] ([Id], [Descripcion], [EsPermiso]) VALUES (25, N'Bitácora', 1)
INSERT [dbo].[Permiso] ([Id], [Descripcion], [EsPermiso]) VALUES (26, N'Restore', 1)
INSERT [dbo].[Permiso] ([Id], [Descripcion], [EsPermiso]) VALUES (27, N'Asignar Niveles', 1)
SET IDENTITY_INSERT [dbo].[Permiso] OFF
INSERT [dbo].[PermisoPermiso] ([IdPadre], [IdHijo]) VALUES (NULL, 1)
INSERT [dbo].[PermisoPermiso] ([IdPadre], [IdHijo]) VALUES (NULL, 2)
INSERT [dbo].[PermisoPermiso] ([IdPadre], [IdHijo]) VALUES (NULL, 3)
INSERT [dbo].[PermisoPermiso] ([IdPadre], [IdHijo]) VALUES (NULL, 4)
INSERT [dbo].[PermisoPermiso] ([IdPadre], [IdHijo]) VALUES (NULL, 5)
INSERT [dbo].[PermisoPermiso] ([IdPadre], [IdHijo]) VALUES (1, 6)
INSERT [dbo].[PermisoPermiso] ([IdPadre], [IdHijo]) VALUES (1, 7)
INSERT [dbo].[PermisoPermiso] ([IdPadre], [IdHijo]) VALUES (1, 8)
INSERT [dbo].[PermisoPermiso] ([IdPadre], [IdHijo]) VALUES (1, 9)
INSERT [dbo].[PermisoPermiso] ([IdPadre], [IdHijo]) VALUES (1, 10)
INSERT [dbo].[PermisoPermiso] ([IdPadre], [IdHijo]) VALUES (1, 11)
INSERT [dbo].[PermisoPermiso] ([IdPadre], [IdHijo]) VALUES (2, 9)
INSERT [dbo].[PermisoPermiso] ([IdPadre], [IdHijo]) VALUES (2, 10)
INSERT [dbo].[PermisoPermiso] ([IdPadre], [IdHijo]) VALUES (2, 11)
INSERT [dbo].[PermisoPermiso] ([IdPadre], [IdHijo]) VALUES (3, 6)
INSERT [dbo].[PermisoPermiso] ([IdPadre], [IdHijo]) VALUES (3, 7)
INSERT [dbo].[PermisoPermiso] ([IdPadre], [IdHijo]) VALUES (3, 8)
INSERT [dbo].[PermisoPermiso] ([IdPadre], [IdHijo]) VALUES (3, 11)
INSERT [dbo].[PermisoPermiso] ([IdPadre], [IdHijo]) VALUES (4, 8)
INSERT [dbo].[PermisoPermiso] ([IdPadre], [IdHijo]) VALUES (5, 7)
INSERT [dbo].[PermisoPermiso] ([IdPadre], [IdHijo]) VALUES (6, 12)
INSERT [dbo].[PermisoPermiso] ([IdPadre], [IdHijo]) VALUES (6, 13)
INSERT [dbo].[PermisoPermiso] ([IdPadre], [IdHijo]) VALUES (6, 14)
INSERT [dbo].[PermisoPermiso] ([IdPadre], [IdHijo]) VALUES (6, 15)
INSERT [dbo].[PermisoPermiso] ([IdPadre], [IdHijo]) VALUES (6, 16)
INSERT [dbo].[PermisoPermiso] ([IdPadre], [IdHijo]) VALUES (7, 17)
INSERT [dbo].[PermisoPermiso] ([IdPadre], [IdHijo]) VALUES (8, 18)
INSERT [dbo].[PermisoPermiso] ([IdPadre], [IdHijo]) VALUES (8, 19)
INSERT [dbo].[PermisoPermiso] ([IdPadre], [IdHijo]) VALUES (9, 20)
INSERT [dbo].[PermisoPermiso] ([IdPadre], [IdHijo]) VALUES (9, 21)
INSERT [dbo].[PermisoPermiso] ([IdPadre], [IdHijo]) VALUES (9, 22)
INSERT [dbo].[PermisoPermiso] ([IdPadre], [IdHijo]) VALUES (10, 23)
INSERT [dbo].[PermisoPermiso] ([IdPadre], [IdHijo]) VALUES (10, 25)
INSERT [dbo].[PermisoPermiso] ([IdPadre], [IdHijo]) VALUES (11, 24)
INSERT [dbo].[PermisoPermiso] ([IdPadre], [IdHijo]) VALUES (10, 26)
INSERT [dbo].[PermisoPermiso] ([IdPadre], [IdHijo]) VALUES (8, 27)
SET IDENTITY_INSERT [dbo].[Resguardo] ON 

INSERT [dbo].[Resguardo] ([Id], [NombreArchivo], [Directorio]) VALUES (13, N'08-03.bak', N'C:\Backup\')
INSERT [dbo].[Resguardo] ([Id], [NombreArchivo], [Directorio]) VALUES (14, N'09-03.bak', N'C:\Backup\')
SET IDENTITY_INSERT [dbo].[Resguardo] OFF
SET IDENTITY_INSERT [dbo].[TipoArbitro] ON 

INSERT [dbo].[TipoArbitro] ([Id], [IdDeporte], [Descripcion]) VALUES (1, 1, N'Principal')
INSERT [dbo].[TipoArbitro] ([Id], [IdDeporte], [Descripcion]) VALUES (2, 1, N'Asistente')
SET IDENTITY_INSERT [dbo].[TipoArbitro] OFF
INSERT [dbo].[TipoEvento] ([Id], [Descripcion]) VALUES (1, N'NULO')
INSERT [dbo].[TipoEvento] ([Id], [Descripcion]) VALUES (2, N'MENSAJE')
INSERT [dbo].[TipoEvento] ([Id], [Descripcion]) VALUES (3, N'ADVERTENCIA')
INSERT [dbo].[TipoEvento] ([Id], [Descripcion]) VALUES (4, N'ERROR')
INSERT [dbo].[TipoEvento] ([Id], [Descripcion]) VALUES (5, N'ALTA')
INSERT [dbo].[TipoEvento] ([Id], [Descripcion]) VALUES (6, N'BAJA')
INSERT [dbo].[TipoEvento] ([Id], [Descripcion]) VALUES (7, N'MODIFICACION')
SET IDENTITY_INSERT [dbo].[Traduccion] ON 

INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (1, 1, 1, N'Iniciar sesión')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (2, 1, 2, N'Usuario')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (3, 1, 3, N'Contraseña')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (4, 1, 4, N'Solicitar una nueva contraseña a un administrador')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (5, 1, 5, N'Cerrar')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (6, 1, 6, N'Iniciar')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (7, 1, 7, N'¿Olvidaste la contraseña?')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (8, 1, 8, N'Aceptar')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (9, 1, 9, N'Administración')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (10, 1, 10, N'Designación')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (11, 1, 11, N'Evaluación')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (12, 1, 12, N'Seguridad')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (13, 1, 13, N'Servicios')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (14, 1, 14, N'Personalizar')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (15, 1, 15, N'Árbitros')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (16, 1, 16, N'Campeonatos')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (17, 1, 17, N'Categorías')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (18, 1, 18, N'Equipos')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (19, 1, 19, N'Partidos')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (20, 1, 20, N'Realizar designación')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (21, 1, 21, N'Calificar árbitros')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (22, 1, 22, N'Promoción / Descenso')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (23, 1, 23, N'Usuarios')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (24, 1, 24, N'Gestionar Perfiles')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (25, 1, 25, N'Resguardar')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (26, 1, 26, N'Gestionar idiomas')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (27, 1, 27, N'Designación Arbitral')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (28, 1, 28, N'Bitácora')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (29, 1, 29, N'Directorio')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (30, 1, 30, N'Base de datos')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (31, 1, 31, N'Nombre de archivo')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (32, 1, 32, N'Examinar')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (33, 1, 33, N'Resguardar')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (34, 1, 34, N'Restaurar')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (35, 1, 35, N'Backup / Restore')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (36, 1, 38, N'Crear Perfiles')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (37, 1, 39, N'Seleccione idioma')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (38, 1, 40, N'Idioma')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (39, 1, 41, N'Restaurar')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (40, 1, 42, N'Campo requerido')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (41, 1, 43, N'Archivos de resguardo')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (42, 2, 1, N'Login')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (43, 2, 2, N'User')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (44, 2, 3, N'Password')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (45, 2, 4, N'Request a new password from an administrator')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (46, 2, 5, N'Close')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (47, 2, 6, N'Login')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (48, 2, 7, N'Forgot password?')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (49, 2, 8, N'Ok')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (50, 2, 9, N'Administration')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (51, 2, 10, N'Designation')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (52, 2, 11, N'Evaluation')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (53, 2, 12, N'Security')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (54, 2, 13, N'Services')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (55, 2, 14, N'Personalize')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (56, 2, 15, N'Referees')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (57, 2, 16, N'Championships')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (58, 2, 17, N'Categories')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (59, 2, 18, N'Teams')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (60, 2, 19, N'Matches')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (61, 2, 20, N'Make designation')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (62, 2, 21, N'Qualify referees')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (63, 2, 22, N'Promotion / Descent')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (64, 2, 23, N'Users')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (65, 2, 24, N'Manage Profiles')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (66, 2, 25, N'Backup')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (67, 2, 26, N'Manage languages')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (68, 2, 27, N'Referee Designation')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (69, 2, 28, N'Logbook')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (70, 2, 29, N'Directory')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (71, 2, 30, N'Database')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (72, 2, 31, N'File name')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (73, 2, 32, N'Browse')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (74, 2, 33, N'Backup')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (75, 2, 34, N'Restore')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (76, 2, 35, N'Backup / Restore')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (77, 2, 38, N'Create Profiles')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (78, 2, 39, N'Select a language')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (79, 2, 40, N'Language')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (80, 2, 41, N'Restore')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (81, 2, 42, N'Required field')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (82, 2, 43, N'Backup files')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (83, 1, 45, N'Operación')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (84, 1, 46, N'La operación se realizó con éxito')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (85, 1, 47, N'Ocurrió un error al procesar la operación')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (86, 2, 45, N'Operation')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (87, 2, 46, N'The operation was successful')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (88, 2, 47, N'An error occurred while processing the operation')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (89, 1, 48, N'Nombre de usuario')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (90, 1, 49, N'Contraseña')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (91, 1, 50, N'El nombre de usuario ya existe')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (92, 1, 51, N'La contraseña no puede ser nula y deben ser iguales')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (93, 2, 48, N'Username')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (94, 2, 49, N'Password')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (95, 2, 50, N'Username already exist')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (96, 2, 51, N'The password cannot be null and must be the same')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (97, 1, 52, N'No se puede eliminar el usuario que esta actualmente utilizando la aplicación')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (98, 2, 52, N'Cannot delete the user who is currently using the application')
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (99, 1, 53, N'Debe seleccionar un usuario')
GO
INSERT [dbo].[Traduccion] ([Id], [IdIdioma], [IdLeyenda], [TextoTraducido]) VALUES (100, 2, 53, N'You must select a user')
SET IDENTITY_INSERT [dbo].[Traduccion] OFF
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([Id], [Apellido], [Nombre], [NombreUsuario], [Password], [Activo], [IdIdioma], [DVH]) VALUES (1, N'Bragazzi', N'Javier', N'jbragazzi', N'1000:kwZonzpKwX0tg0wPqaeihEcJS3uW6Q3m:qPHesEmpYz7lLenxN7AXj4w4dqw=', 1, 1, N'7681a3c2aa5a055020ecf5a0f1c4fe94')
INSERT [dbo].[Usuario] ([Id], [Apellido], [Nombre], [NombreUsuario], [Password], [Activo], [IdIdioma], [DVH]) VALUES (11, N'Mentaberry', N'Carlos', N'cmentaberry', N'1000:vrDXqcrwwtCw4KN+F0/0iHRB6oOYkfiB:fUX2jLe9AKD0SrFwrcLuWkeer3U=', 1, 1, N'151a81484603b76f1ffc2416f1c8de49')
INSERT [dbo].[Usuario] ([Id], [Apellido], [Nombre], [NombreUsuario], [Password], [Activo], [IdIdioma], [DVH]) VALUES (12, N'Bra', N'Jav', N'javierr87', N'1000:91xmlPvJkkHW4BthgjOYoXR9oRIBn5GQ:EQhvQSaOHBfvS0qrYZq2Q6jknYY=', 1, 1, N'd820c05e67ef7242b0118f8e97c52b20')
INSERT [dbo].[Usuario] ([Id], [Apellido], [Nombre], [NombreUsuario], [Password], [Activo], [IdIdioma], [DVH]) VALUES (13, N'Perez', N'Pepe', N'pperez', N'1000:uQPN24CY9fsYj6ycu8uXzbN6/hC5XHQI:1qWrL2+B4BKKrHFrxOL3eIGjmP4=', 1, 1, N'c3fec1800c0612b7bd4ec6884d08adb4')
SET IDENTITY_INSERT [dbo].[Usuario] OFF
INSERT [dbo].[UsuarioPermiso] ([IdPermiso], [IdUsuario]) VALUES (1, 1)
INSERT [dbo].[UsuarioPermiso] ([IdPermiso], [IdUsuario]) VALUES (1, 13)
INSERT [dbo].[UsuarioPermiso] ([IdPermiso], [IdUsuario]) VALUES (2, 11)
INSERT [dbo].[UsuarioPermiso] ([IdPermiso], [IdUsuario]) VALUES (3, 12)
INSERT [dbo].[UsuarioPermiso] ([IdPermiso], [IdUsuario]) VALUES (5, 14)
ALTER TABLE [dbo].[Arbitro]  WITH NOCHECK ADD  CONSTRAINT [FK_Arbitro_Deporte] FOREIGN KEY([IdDeporte])
REFERENCES [dbo].[Deporte] ([Id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[Arbitro] NOCHECK CONSTRAINT [FK_Arbitro_Deporte]
GO
ALTER TABLE [dbo].[Arbitro]  WITH CHECK ADD  CONSTRAINT [FK_Arbitro_Genero] FOREIGN KEY([IdGenero])
REFERENCES [dbo].[Genero] ([Id])
GO
ALTER TABLE [dbo].[Arbitro] CHECK CONSTRAINT [FK_Arbitro_Genero]
GO
ALTER TABLE [dbo].[Arbitro]  WITH NOCHECK ADD  CONSTRAINT [FK_Arbitro_Nivel] FOREIGN KEY([IdNivel])
REFERENCES [dbo].[Nivel] ([Id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[Arbitro] NOCHECK CONSTRAINT [FK_Arbitro_Nivel]
GO
ALTER TABLE [dbo].[ArbitroAud]  WITH NOCHECK ADD  CONSTRAINT [FK_ArbitroAud_Arbitro] FOREIGN KEY([IdArbitro])
REFERENCES [dbo].[Arbitro] ([Id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[ArbitroAud] NOCHECK CONSTRAINT [FK_ArbitroAud_Arbitro]
GO
ALTER TABLE [dbo].[ArbitroAud]  WITH NOCHECK ADD  CONSTRAINT [FK_ArbitroAud_Bitacora] FOREIGN KEY([IdBitacora])
REFERENCES [dbo].[Bitacora] ([Id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[ArbitroAud] NOCHECK CONSTRAINT [FK_ArbitroAud_Bitacora]
GO
ALTER TABLE [dbo].[ArbitroAud]  WITH NOCHECK ADD  CONSTRAINT [FK_ArbitroAud_Deporte] FOREIGN KEY([IdDeporte])
REFERENCES [dbo].[Deporte] ([Id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[ArbitroAud] NOCHECK CONSTRAINT [FK_ArbitroAud_Deporte]
GO
ALTER TABLE [dbo].[ArbitroAud]  WITH NOCHECK ADD  CONSTRAINT [FK_ArbitroAud_Nivel] FOREIGN KEY([IdNivel])
REFERENCES [dbo].[Nivel] ([Id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[ArbitroAud] NOCHECK CONSTRAINT [FK_ArbitroAud_Nivel]
GO
ALTER TABLE [dbo].[Bitacora]  WITH CHECK ADD  CONSTRAINT [FK_Bitacora_TipoEvento] FOREIGN KEY([IdTipoEvento])
REFERENCES [dbo].[TipoEvento] ([Id])
GO
ALTER TABLE [dbo].[Bitacora] CHECK CONSTRAINT [FK_Bitacora_TipoEvento]
GO
ALTER TABLE [dbo].[Bitacora]  WITH NOCHECK ADD  CONSTRAINT [FK_Bitacora_Usuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([Id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[Bitacora] NOCHECK CONSTRAINT [FK_Bitacora_Usuario]
GO
ALTER TABLE [dbo].[Campeonato]  WITH NOCHECK ADD  CONSTRAINT [FK_Campeonato_Categoria] FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Categoria] ([Id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[Campeonato] NOCHECK CONSTRAINT [FK_Campeonato_Categoria]
GO
ALTER TABLE [dbo].[Campeonato]  WITH NOCHECK ADD  CONSTRAINT [FK_Campeonato_Fixture] FOREIGN KEY([IdFixture])
REFERENCES [dbo].[Fixture] ([Id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[Campeonato] NOCHECK CONSTRAINT [FK_Campeonato_Fixture]
GO
ALTER TABLE [dbo].[Categoria]  WITH NOCHECK ADD  CONSTRAINT [FK_Categoria_Deporte] FOREIGN KEY([IdDeporte])
REFERENCES [dbo].[Deporte] ([Id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[Categoria] NOCHECK CONSTRAINT [FK_Categoria_Deporte]
GO
ALTER TABLE [dbo].[Equipo]  WITH NOCHECK ADD  CONSTRAINT [FK_Equipo_Categoria] FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Categoria] ([Id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[Equipo] NOCHECK CONSTRAINT [FK_Equipo_Categoria]
GO
ALTER TABLE [dbo].[Fecha]  WITH NOCHECK ADD  CONSTRAINT [FK_Fecha_Fixture] FOREIGN KEY([IdFixture])
REFERENCES [dbo].[Fixture] ([Id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[Fecha] NOCHECK CONSTRAINT [FK_Fecha_Fixture]
GO
ALTER TABLE [dbo].[Leyenda]  WITH NOCHECK ADD  CONSTRAINT [FK_Leyenda_Traduccion] FOREIGN KEY([Id])
REFERENCES [dbo].[Traduccion] ([Id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[Leyenda] NOCHECK CONSTRAINT [FK_Leyenda_Traduccion]
GO
ALTER TABLE [dbo].[Nivel]  WITH NOCHECK ADD  CONSTRAINT [FK_Nivel_Deporte] FOREIGN KEY([IdDeporte])
REFERENCES [dbo].[Deporte] ([Id])
GO
ALTER TABLE [dbo].[Nivel] CHECK CONSTRAINT [FK_Nivel_Deporte]
GO
ALTER TABLE [dbo].[NivelRegla]  WITH NOCHECK ADD  CONSTRAINT [FK_NivelRegla_Categoria] FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Categoria] ([Id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[NivelRegla] NOCHECK CONSTRAINT [FK_NivelRegla_Categoria]
GO
ALTER TABLE [dbo].[NivelRegla]  WITH NOCHECK ADD  CONSTRAINT [FK_NivelRegla_Nivel] FOREIGN KEY([IdNivel])
REFERENCES [dbo].[Nivel] ([Id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[NivelRegla] NOCHECK CONSTRAINT [FK_NivelRegla_Nivel]
GO
ALTER TABLE [dbo].[NivelRegla]  WITH NOCHECK ADD  CONSTRAINT [FK_NivelRegla_TipoArbitro] FOREIGN KEY([IdTipoArbitro])
REFERENCES [dbo].[TipoArbitro] ([Id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[NivelRegla] NOCHECK CONSTRAINT [FK_NivelRegla_TipoArbitro]
GO
ALTER TABLE [dbo].[Partido]  WITH NOCHECK ADD  CONSTRAINT [FK_Partido_Equipo1] FOREIGN KEY([IdEquipo1])
REFERENCES [dbo].[Equipo] ([Id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[Partido] NOCHECK CONSTRAINT [FK_Partido_Equipo1]
GO
ALTER TABLE [dbo].[Partido]  WITH NOCHECK ADD  CONSTRAINT [FK_Partido_Equipo2] FOREIGN KEY([IdEquipo2])
REFERENCES [dbo].[Equipo] ([Id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[Partido] NOCHECK CONSTRAINT [FK_Partido_Equipo2]
GO
ALTER TABLE [dbo].[Partido]  WITH NOCHECK ADD  CONSTRAINT [FK_Partido_Fecha] FOREIGN KEY([IdFecha])
REFERENCES [dbo].[Fecha] ([Id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[Partido] NOCHECK CONSTRAINT [FK_Partido_Fecha]
GO
ALTER TABLE [dbo].[PartidoArbitro]  WITH NOCHECK ADD  CONSTRAINT [FK_PartidoArbitro_Arbitro] FOREIGN KEY([IdArbitro])
REFERENCES [dbo].[Arbitro] ([Id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[PartidoArbitro] NOCHECK CONSTRAINT [FK_PartidoArbitro_Arbitro]
GO
ALTER TABLE [dbo].[PartidoArbitro]  WITH NOCHECK ADD  CONSTRAINT [FK_PartidoArbitro_Calificacion] FOREIGN KEY([IdCalificacion])
REFERENCES [dbo].[Calificacion] ([Id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[PartidoArbitro] NOCHECK CONSTRAINT [FK_PartidoArbitro_Calificacion]
GO
ALTER TABLE [dbo].[PartidoArbitro]  WITH NOCHECK ADD  CONSTRAINT [FK_PartidoArbitro_Partido] FOREIGN KEY([IdPartido])
REFERENCES [dbo].[Partido] ([Id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[PartidoArbitro] NOCHECK CONSTRAINT [FK_PartidoArbitro_Partido]
GO
ALTER TABLE [dbo].[PartidoArbitro]  WITH NOCHECK ADD  CONSTRAINT [FK_PartidoArbitro_TipoArbitro] FOREIGN KEY([IdTipoArbitro])
REFERENCES [dbo].[TipoArbitro] ([Id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[PartidoArbitro] NOCHECK CONSTRAINT [FK_PartidoArbitro_TipoArbitro]
GO
ALTER TABLE [dbo].[PermisoPermiso]  WITH NOCHECK ADD  CONSTRAINT [FK_PermisoPermiso_Permiso_Hijo] FOREIGN KEY([IdHijo])
REFERENCES [dbo].[Permiso] ([Id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[PermisoPermiso] NOCHECK CONSTRAINT [FK_PermisoPermiso_Permiso_Hijo]
GO
ALTER TABLE [dbo].[PermisoPermiso]  WITH NOCHECK ADD  CONSTRAINT [FK_PermisoPermiso_Permiso_Padre] FOREIGN KEY([IdPadre])
REFERENCES [dbo].[Permiso] ([Id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[PermisoPermiso] NOCHECK CONSTRAINT [FK_PermisoPermiso_Permiso_Padre]
GO
ALTER TABLE [dbo].[TipoArbitro]  WITH NOCHECK ADD  CONSTRAINT [FK_TipoArbitro_Deporte] FOREIGN KEY([IdDeporte])
REFERENCES [dbo].[Deporte] ([Id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[TipoArbitro] NOCHECK CONSTRAINT [FK_TipoArbitro_Deporte]
GO
ALTER TABLE [dbo].[Traduccion]  WITH NOCHECK ADD  CONSTRAINT [FK_Traduccion_Idioma] FOREIGN KEY([IdIdioma])
REFERENCES [dbo].[Idioma] ([Id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[Traduccion] NOCHECK CONSTRAINT [FK_Traduccion_Idioma]
GO
ALTER TABLE [dbo].[Usuario]  WITH NOCHECK ADD  CONSTRAINT [FK_Usuario_Idioma] FOREIGN KEY([IdIdioma])
REFERENCES [dbo].[Idioma] ([Id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[Usuario] NOCHECK CONSTRAINT [FK_Usuario_Idioma]
GO
ALTER TABLE [dbo].[UsuarioPermiso]  WITH NOCHECK ADD  CONSTRAINT [FK_UsuarioPermiso_Permiso] FOREIGN KEY([IdPermiso])
REFERENCES [dbo].[Permiso] ([Id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[UsuarioPermiso] NOCHECK CONSTRAINT [FK_UsuarioPermiso_Permiso]
GO
ALTER TABLE [dbo].[UsuarioPermiso]  WITH NOCHECK ADD  CONSTRAINT [FK_UsuarioPermiso_Usuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([Id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[UsuarioPermiso] NOCHECK CONSTRAINT [FK_UsuarioPermiso_Usuario]
GO
