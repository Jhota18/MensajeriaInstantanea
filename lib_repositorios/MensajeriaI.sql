CREATE DATABASE db_MensajeriaI
GO
USE db_MensajeriaI
GO

CREATE TABLE [Personas]
(
	[Id] INT NOT NULL IDENTITY (1, 1),
	[Cedula] NVARCHAR(15) NOT NULL UNIQUE,
	[Nombre] NVARCHAR(50) NOT NULL,
	CONSTRAINT [PK_Personas] PRIMARY KEY CLUSTERED ([Id])
)

GO

CREATE TABLE [Grupos]
(
	[Id] INT NOT NULL IDENTITY (1, 1),
	[Nombre] NVARCHAR(30) NOT NULL,
	CONSTRAINT [PK_Grupos] PRIMARY KEY CLUSTERED ([Id]),
)
GO

CREATE TABLE [PersGrups]
(
	[Id] INT NOT NULL IDENTITY (1, 1),
	[Grupo] int NOT NULL,
	[Persona] int NOT NULL,
	CONSTRAINT [PK_PersGrups] PRIMARY KEY CLUSTERED ([Id]),
	CONSTRAINT [FK_PersGrups_Personas] FOREIGN KEY ([Persona]) REFERENCES [Personas] ([Id]) ON DELETE No Action ON UPDATE No Action,
	CONSTRAINT [FK_PersGrups_Grupos] FOREIGN KEY ([Grupo]) REFERENCES [Grupos] ([Id]) ON DELETE No Action ON UPDATE No Action
)
GO


CREATE TABLE [Estados]
(
	[Id] INT NOT NULL IDENTITY (1, 1),
	[Nombre] NVARCHAR(50) NOT NULL,
	CONSTRAINT [PK_Estados] PRIMARY KEY CLUSTERED ([Id])
)
GO

CREATE TABLE [Mensajes]
(
	[Id] INT NOT NULL IDENTITY (1, 1),
	[Contenido] Text NOT NULL,
	[Fecha] SMALLDATETIME,
	[Estado] INT NOT NULL,
	[Borrado] BIT NOT NULL,
	[De] INT NOT NULL,
	[Para] INT,
	[Grupo] INT,
	CONSTRAINT [PK_Mensajes] PRIMARY KEY CLUSTERED ([Id]),
	CONSTRAINT [FK_MensajesD_Personas] FOREIGN KEY ([De]) REFERENCES [Personas] ([Id]) ON DELETE No Action ON UPDATE No Action,
	CONSTRAINT [FK_MensajesP_Personas] FOREIGN KEY ([Para]) REFERENCES [Personas] ([Id]) ON DELETE No Action ON UPDATE No Action,
	CONSTRAINT [FK_Mensajes_Estados] FOREIGN KEY ([Estado]) REFERENCES [Estados] ([Id]) ON DELETE No Action ON UPDATE No Action,
	CONSTRAINT [FK_Mensajes_Grupos] FOREIGN KEY ([Grupo]) REFERENCES [Grupos] ([Id]) ON DELETE No Action ON UPDATE No Action
)
GO

CREATE TABLE [Detalles]
(
	[Id] INT NOT NULL IDENTITY (1, 1),
	[Mensaje] INT NOT NULL,
	[Para] INT NOT NULL,
	[Estado] INT NOT NULL,
	CONSTRAINT [PK_Detalles] PRIMARY KEY CLUSTERED ([Id]),
	CONSTRAINT [FK_Detalles_Personas] FOREIGN KEY ([Para]) REFERENCES [Personas] ([Id]) ON DELETE No Action ON UPDATE No Action,
	CONSTRAINT [FK_Detalles_Estados] FOREIGN KEY ([Estado]) REFERENCES [Estados] ([Id]) ON DELETE No Action ON UPDATE No Action,
	CONSTRAINT [FK_Detalles_Mensajes] FOREIGN KEY ([Mensaje]) REFERENCES [Mensajes] ([Id]) ON DELETE No Action ON UPDATE No Action
)
GO


INSERT INTO [Personas] ([Cedula],[Nombre])
VALUES (1000, 'Carlos Mario');

INSERT INTO [Personas] ([Cedula],[Nombre])
VALUES (2000, 'Dorlan Mauricio');

INSERT INTO [Personas] ([Cedula],[Nombre])
VALUES (3000, 'Gerardo');

SELECT * FROM [Personas];

------------

INSERT INTO [Estados] ([Nombre])
VALUES ('Recibido'),
('Leido');

----------------------

INSERT INTO [Grupos] ([Nombre])
VALUES ('Grupo A'),
('Grupo B'),
('Grupo C')

-----------
INSERT INTO [PersGrups] ([Grupo],[Persona])
values (1, 2),
(2,3);

----------

INSERT INTO [Mensajes] ([Contenido],[Fecha],[Estado],[Borrado],[De],[Para],[Grupo])
VALUES ('que dice el socio', GETDATE(), 2, 0, 1, 2, NULL ),
('Llego la hora feliz', GETDATE(), 1, 0, 2, null, 2);

-----------------

INSERT INTO [Detalles] ([Mensaje],[Para],[Estado])
VALUES (1, 2, 1),
(1, 3, 1)




DBCC CHECKIDENT ('Estados', RESEED, 0); --PARA INICIALIZAR LOS ID EN 0 NUEVAMENTE