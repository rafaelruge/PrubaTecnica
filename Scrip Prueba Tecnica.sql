USE [Prueba]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 21/02/2019 7:54:31 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[Nombre] [nchar](10) NULL,
	[Apellido] [nchar](10) NULL,
	[Cedula] [int] NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[Cedula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CuentaBancaria]    Script Date: 21/02/2019 7:54:31 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CuentaBancaria](
	[Numero_cuenta] [int] NOT NULL,
	[Cedula] [int] NULL,
	[Fecha_apertura] [date] NULL,
	[Monto] [money] NULL,
 CONSTRAINT [PK_CuentaBancaria] PRIMARY KEY CLUSTERED 
(
	[Numero_cuenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[CuentaBancaria]  WITH CHECK ADD  CONSTRAINT [FK_CuentaBancaria_Cliente] FOREIGN KEY([Cedula])
REFERENCES [dbo].[Cliente] ([Cedula])
GO
ALTER TABLE [dbo].[CuentaBancaria] CHECK CONSTRAINT [FK_CuentaBancaria_Cliente]
GO
