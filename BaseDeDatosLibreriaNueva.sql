CREATE DATABASE LIBRERIA_BD_Actividad_1
GO

USE LIBRERIA_BD_Actividad_1
GO

--Crear tablas
SET DATEFORMAT DMY

CREATE TABLE barrios (
	cod_barrio int NOT NULL ,
	barrio nvarchar (50) NULL ,
	CONSTRAINT PK_barrios PRIMARY KEY (cod_barrio)
)

CREATE TABLE articulos (
	cod_articulo int IDENTITY (1, 1) NOT NULL ,
	descripcion nvarchar (50) NULL ,
	stock_minimo smallint NULL ,
	stock smallint NOT NULL,
	pre_unitario decimal(10, 2) NOT NULL ,
	observaciones nvarchar (50)NULL ,
	CONSTRAINT PK_articulos PRIMARY KEY (cod_articulo)
)

CREATE TABLE clientes (
	cod_cliente int IDENTITY (1, 1) NOT NULL ,
	nom_cliente nvarchar (50) NOT NULL ,
	ape_cliente nvarchar (50) NOT NULL ,
	calle nvarchar (50) NOT NULL ,
	altura int,
	cod_barrio int NOT NULL,
	nro_tel bigint NULL ,
	[e-mail] nvarchar (50) NULL,
	CONSTRAINT PK_clientes PRIMARY KEY (cod_cliente),
	CONSTRAINT FK_clientes_barrios FOREIGN KEY (cod_barrio) REFERENCES barrios (cod_barrio)
)

CREATE TABLE vendedores (
	cod_vendedor int IDENTITY (1, 1) NOT NULL ,
	nom_vendedor nvarchar (50) NOT NULL ,
	ape_vendedor nvarchar(50) not null,
	calle nvarchar (50) NOT NULL ,
	altura int,
	cod_barrio int NOT NULL,
	nro_tel bigint NULL ,
	[e-mail] nvarchar (50) NULL ,
	fec_nac smalldatetime NULL ,
	CONSTRAINT PK_vendedores PRIMARY KEY (cod_vendedor),
	CONSTRAINT FK_vendedores_barrios FOREIGN KEY (cod_barrio) REFERENCES barrios (cod_barrio)
)
CREATE TABLE facturas (
	nro_factura int IDENTITY (1, 1) NOT NULL ,
	fecha datetime NOT NULL ,
	cod_cliente int NOT NULL ,
	cod_vendedor int NOT NULL ,
	CONSTRAINT PK_facturas PRIMARY KEY (nro_factura),
	CONSTRAINT FK_facturas_clientes FOREIGN KEY (cod_cliente) REFERENCES clientes (cod_cliente),
	CONSTRAINT FK_facturas_vendedores FOREIGN KEY (cod_vendedor) REFERENCES vendedores (cod_vendedor)
)

CREATE TABLE detalle_facturas (
	nro_factura int NOT NULL ,
	cod_articulo int NOT NULL ,
	pre_unitario numeric(18, 2) NOT NULL ,
	cantidad smallint NOT NULL ,
	CONSTRAINT PK_detalle PRIMARY KEY  (nro_factura, cod_articulo),
	CONSTRAINT FK_detalle_articulos FOREIGN KEY (cod_articulo) REFERENCES articulos (cod_articulo),
	CONSTRAINT FK_detalle_facturas FOREIGN KEY (nro_factura) REFERENCES facturas (nro_factura)
)

-- Insert de algunos datos

INSERT INTO BARRIOS(cod_barrio, BARRIO) VALUES (1,'CENTRO') 
INSERT INTO BARRIOS(cod_barrio, BARRIO) VALUES (2,'ALTO ALBERDI') 
INSERT INTO BARRIOS(cod_barrio, BARRIO) VALUES (3,'OBSERVATORIO') 
INSERT INTO BARRIOS(cod_barrio, BARRIO) VALUES (4,'JARDÍN') 
INSERT INTO BARRIOS(cod_barrio, BARRIO) VALUES (5,'GENERAL PAZ') 

-- Articulos
insert into articulos (descripcion, stock_minimo, stock, pre_unitario, observaciones) values ('Lápiz Evolution HB2 * 4 u',null,150, 1600.00, null);--1
insert into articulos (descripcion, stock_minimo, stock, pre_unitario, observaciones) values ('Papel p/forrar Fantasía * 10 u',100,100,5000.00, null);--2
insert into articulos (descripcion, stock_minimo, stock, pre_unitario, observaciones) values ('Papel p/forrar Araña * 10 u',20,155,6000.00, 'Color rojo - azul - verde');
insert into articulos (descripcion, stock_minimo, stock, pre_unitario, observaciones) values ('Lápices Color cortos  * 12 u',50,100, 1200.50, null);--4
insert into articulos (descripcion, stock_minimo, stock, pre_unitario, observaciones) values ('Fibras cortas * 6',50,50,125.30,null);--5
insert into articulos (descripcion, stock_minimo, stock, pre_unitario, observaciones) values ('Lápices Color largos * 12 u',null,0,1300,null);--6
insert into articulos (descripcion, stock_minimo, stock, pre_unitario, observaciones) values ('Separadores tamaño rivadavia * 6 u',null,100, 850.70,'Motivos de Disney');
insert into articulos (descripcion, stock_minimo, stock, pre_unitario, observaciones) values ('Carpeta fibra negra - Tamaño rivadavia',null,54, 2020.90,'3 anillos');--8
insert into articulos (descripcion, stock_minimo, stock, pre_unitario, observaciones) values ('Carpeta Fantasía - Tamaño Rivadavia',60,100, 2500.90,'3 anillos');
insert into articulos (descripcion, stock_minimo, stock, pre_unitario, observaciones) values ('Adhesivo sintético 30 gr',NULL,20,560.00, null);--10
insert into articulos (descripcion, stock_minimo, stock, pre_unitario, observaciones) values ('Cuaderno Tamaño rivadavia rayado',150,180,520.70,null);
insert into articulos (descripcion, stock_minimo, stock, pre_unitario, observaciones) values ('Cuaderno Tamaño rivadavia cuadriculado',50,65,520.70,null);--12
insert into articulos (descripcion, stock_minimo, stock, pre_unitario, observaciones) values ('Repuesto Gloria rallado',150,120, 6410.00,'400 hojas');
insert into articulos (descripcion, stock_minimo, stock, pre_unitario, observaciones) values ('Repuesto Gloria cuadriculado',20,90, 6410.00,'400 hojas');--14
insert into articulos (descripcion, stock_minimo, stock, pre_unitario, observaciones) values ('Conjunto Geométrico',null,20,1850.90,'Regla - escuadra - transportador');
insert into articulos (descripcion, stock_minimo, stock, pre_unitario, observaciones) values ('Cartuchera Lata',5,60, 5650.50,'2 pisos');--16
insert into articulos (descripcion, stock_minimo, stock, pre_unitario, observaciones) values ('Cartuchera de Tela',30,55,2602.60,null);
insert into articulos (descripcion, stock_minimo, stock, pre_unitario, observaciones) values ('Correctores Bic Lápiz * 1 u',null,3,801.40,null);--18
insert into articulos (descripcion, stock_minimo, stock, pre_unitario, observaciones) values ('Rótulos * 18 u',100,120,705.90,null);
insert into articulos (descripcion, stock_minimo, stock, pre_unitario, observaciones) values ('Resma hoja A4',50,45,5805.00,null);--20

-- Clientes
insert into clientes (ape_cliente, nom_cliente, calle, altura, cod_barrio, nro_tel, [e-mail]) values ('Perez', 'Rodolfo','San Martín', 120,1,NULL,NULL);
insert into clientes (ape_cliente, nom_cliente, calle, altura, cod_barrio, nro_tel, [e-mail]) values ('Castillo', 'Marta Analía','Pedro Lozano', 1450,7,NULL,'castillo_marta@yahoo.com');
insert into clientes (ape_cliente, nom_cliente, calle, altura, cod_barrio, nro_tel, [e-mail]) values ('Abarca', 'Héctor','Luis Gongora', 160,12,4701314,'habarca@hotmail.com');
insert into clientes (ape_cliente, nom_cliente, calle, altura, cod_barrio, nro_tel, [e-mail]) values ('Morales','Santiago','León y Pizarro', 55,2,155471516,NULL);
insert into clientes (ape_cliente, nom_cliente, calle, altura, cod_barrio, nro_tel, [e-mail]) values ('Perez', 'Carlos Antonio','A. Garzón', 455,2,4554466,NULL);
insert into clientes (ape_cliente, nom_cliente, calle, altura, cod_barrio, nro_tel, [e-mail]) values ('Morales', 'Pilar','León y Pizarro', 55,2,155471516,NULL);
insert into clientes (ape_cliente, nom_cliente, calle, altura, cod_barrio, nro_tel, [e-mail]) values ('Paez', 'Roque','Humberto Primo', 79,1,4262630,NULL);
insert into clientes (ape_cliente, nom_cliente, calle, altura, cod_barrio, nro_tel, [e-mail]) values ('Luque', 'Elvira Josefa','Mariano Usandivaras', 360,3,4502829,NULL);
insert into clientes (ape_cliente, nom_cliente, calle, altura, cod_barrio, nro_tel, [e-mail]) values ('Ruiz', 'Marcos','Rivera Indarte', 780,1,NULL,'ruiz_marcos@hotmail.com');
insert into clientes (ape_cliente, nom_cliente, calle, altura, cod_barrio, nro_tel, [e-mail]) values ('Moriel', 'Roberto','Santa Rosa', 73,1,NULL,NULL);
insert into clientes (ape_cliente, nom_cliente, calle, altura, cod_barrio, nro_tel, [e-mail]) values ('Perez', 'Ana María','Av. Colón', 1655,2,NULL,NULL);


-- Vendedores

insert into vendedores (ape_vendedor, nom_vendedor, calle, altura, cod_barrio, nro_tel, [e-mail], fec_nac) values ('Carrizo', 'Martín','San Lorenzo', 369,2,NULL,'mcarrizo@latinmail.com',null);
insert into vendedores (ape_vendedor, nom_vendedor, calle, altura, cod_barrio, nro_tel, [e-mail], fec_nac) values ('Ledesma', 'Mariela','Chachapoyas', 1560,5,4526060,NULL,'22/2/1989');
insert into vendedores (ape_vendedor, nom_vendedor, calle, altura, cod_barrio, nro_tel, [e-mail], fec_nac) values ('Lopez', 'Alejandro','Alsina', 12,3,4612525,'NULL','6/3/1985');
insert into vendedores (ape_vendedor, nom_vendedor, calle, altura, cod_barrio, nro_tel, [e-mail], fec_nac) values ('Miranda', 'Marcelo','Rivera Indarte', 320,1,NULL,NULL,'7/10/1996');
insert into vendedores (ape_vendedor, nom_vendedor, calle, altura, cod_barrio, nro_tel, [e-mail], fec_nac) values ('Monti', 'Gabriel','Altoaguirre', 1245,4,4522122,NULL,'Jul 30 1992');
insert into vendedores (ape_vendedor, nom_vendedor, calle, altura, cod_barrio, nro_tel, [e-mail], fec_nac) values ('Juarez','Susana','Antofagasta', 1785,9,458976,NULL,'30/7/1989'); --Cod_vendedor=6


-- Procedimientos almacenados
CREATE PROCEDURE SP_Insertar
    @Nombre NVARCHAR(100),
    @Apellido NVARCHAR(100),
    @Edad INT
AS
BEGIN
    -- Inserta un nuevo registro en la tabla Clientes
    INSERT INTO Clientes (Nombre, Apellido, Edad)
    VALUES (@Nombre, @Apellido, @Edad);
END;
