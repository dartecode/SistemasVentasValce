--Crear base de datos
create database sistemasVentas;
go

use sistemasVentas;
go

--Crear tablas
create table Rol(
    idRol int primary key identity,
    descripcion varchar(50),
    fechaCreacion datetime default getdate()
);
GO

create table Permiso(
    idPermiso int primary key identity,
    idRol int references Rol(idRol),
    nombreMenu varchar(100),
    fechaCreacion datetime default getdate()
);
GO

create table Proveedor(
    idProveedor int primary key identity,
    cedula varchar(50),
    razonSocial varchar(50),
    email varchar(50),
    telefono varchar(50),
    estado bit,
    fechaCreacion datetime default getdate()
);
GO

create table Cliente(
    idCliente int primary key identity,
    cedula varchar(50),
    nombreCompleto varchar (100),
    email varchar(50),
    telefono varchar(50),
    estado bit,
    fechaCreacion datetime default getdate()
);
GO

create table Usuario(
    idUsuario int primary key identity,
    cedula varchar (50),
    nombreCompleto varchar (100),
    email varchar(50),
    clave varchar (50),
    idRol int references Rol(idRol),
    estado bit,
    fechaCreacion datetime default getdate()
);
go

create table Categoria(
    idCategoria int primary key identity,
    descripcion varchar(100),
    estado bit,
    fechaCreacion datetime default getdate()
);
GO

create table Producto(
    idProducto int primary key identity,
    codigo varchar(50),
    nombreProducto varchar(50),
    descripcion varchar(100),
    idCategoria int references Categoria(idCategoria),
    stock int not null default 0,
    precioCompra decimal(10,2) default 0,
    precioVenta decimal(10,2) default 0,
    estado bit,
    fechaCreacion datetime default getdate()
);
GO

create table Compra(
    idCompra int primary key identity,
    idUsuario int references Usuario(idUsuario),
    idProveedor int references Proveedor(idProveedor),
    tipoDocumento varchar(50),
    numeroDocumento varchar(50),
    montoTotal decimal(10,2),
    fechaRegistro datetime default getdate()
);
go

create table DetalleCompra(
    idDetalleCompra int primary key identity,
    idCompra int references Compra(idCompra),
    idProducto int references Producto(idProducto),
    precioCompra decimal(10,2) default 0,
    precioVenta decimal(10,2) default 0,
    cantidad int,
    total decimal(10,2),
    fechaRegistro datetime default getdate()
);
go

create table Venta(
    idVenta int primary key identity,
    idUsuario int references Usuario(idUsuario),
    tipoDocumento varchar(50),
    numeroDocumento varchar(50),
    documentoCliente varchar(50),
    nombreCliente varchar(100),
    montoPago decimal(10,2),
    montoCambio decimal(10,2),
    montoTotal decimal(10,2),
    fechaRegistro datetime default getdate()
);
go

create table DetalleVenta(
    idDetalleVenta int primary key identity,
    idVenta int references Venta(idVenta),
    idProducto int references Producto(idProducto),
    PrecioVenta decimal(10,2),
    cantidad int,
    subtotal decimal(10,2),
    fechaRegistro datetime default getdate()
);


-- Insertar Datos en las tablas

--Agregar Roles
insert into Rol (descripcion)
values ('Administrador');

insert into Rol (descripcion)
values ('Empleado');

select * from Rol;

--Agregar Permisos al Administrador
insert into Permiso (idRol, nombreMenu) values 
(1, 'menuUsuarios'),
(1, 'menuMantenedor'),
(1, 'menuVentas'),
(1, 'menuCompras'),
(1, 'menuClientes'),
(1, 'menuProveedores'),
(1, 'menuReportes'),
(1, 'menuAcercaDe');

--Agregar Permisos al Empleado
insert into Permiso (idRol, nombreMenu) values 
(2, 'menuVentas'),
(2, 'menuCompras'),
(2, 'menuClientes'),
(2, 'menuProveedores'),
(2, 'menuAcercaDe');

select * from Permiso;

--Mostrar Menus que tiene permiso el usuario mediante su ID
SELECT p.idRol, p.nombremenu FROM Permiso p
INNER JOIN Rol r ON r.idRol = p.idRol
INNER JOIN Usuario u ON u.idRol = p.idRol
WHERE u.idUsuario = 1;


--Agregar usuarios
insert into Usuario (cedula, nombreCompleto, correo, clave, idRol, estado)
values ('1316068301', 'Dario Valdez', 'dariovaldezc21@gmail.com', 'Admin123.', 1,1);

insert into Usuario (cedula, nombreCompleto, correo, clave, idRol, estado)
values ('1316068315', 'Joustin Valdez', 'joustinvaldez@gmail.com', 'Joustin10', 2,1);

select * from Usuario;

--Agregar Categorias
INSERT INTO Categoria (descripcion, estado)
VALUES ('Lacteos', 1);

INSERT INTO Categoria (descripcion, estado)
VALUES ('Embutidos', 1);

INSERT INTO Categoria (descripcion, estado)
VALUES ('Enlatados', 1);

SELECT * FROM Categoria;


-- Buscar Usuarios
SELECT idUsuario, cedula, nombreCompleto, email, clave, estado FROM Usuario;

-- Buscar Usuario con sus permisos
SELECT u.idUsuario, u.cedula, u.nombreCompleto, u.email, u.clave, u.estado, r.idRol, r.descripcion 
FROM Usuario u 
INNER JOIN Rol r on r.idRol = u.idRol;

--Agregar productos
INSERT INTO Producto (codigo, nombreProducto, descripcion, idCategoria, estado) 
VALUES (101010, 'Inca Kola', '1 litro', 3, 1);

SELECT * FROM Producto;

--Procedimiento almacenado para eliminar Usuario
CREATE PROCEDURE SPEliminarUsuario(
    @idUsuario int,
    @respuesta bit output,
    @mensaje varchar (500) output 
)
AS
BEGIN
    SET @respuesta = 0
    SET @mensaje = ''
    DECLARE @pasoReglas bit = 1

    IF EXISTS (SELECT * FROM Compra c 
               INNER JOIN Usuario u 
               ON u.idUsuario = c.idUsuario
               WHERE u.idUsuario = @idUsuario)
        BEGIN
            SET @pasoReglas = 0
            SET @respuesta = 0
            SET @mensaje = 'Los usuarios que se encuentran relacionado a una compra no se pueden eliminar \n'
        END

    IF EXISTS (SELECT * FROM Venta v 
               INNER JOIN Usuario u 
               ON u.idUsuario = v.idUsuario
               WHERE u.idUsuario = @idUsuario)
        BEGIN
            SET @pasoReglas = 0
            SET @respuesta = 0
            SET @mensaje = 'Los usuarios que se encuentran relacionado a una venta no se pueden eliminar \n'
        END

    IF (@pasoReglas = 1)
        BEGIN
            DELETE FROM Usuario WHERE idUsuario = @idUsuario

            SET @respuesta = 1
            SET @mensaje = 'Se elimino el usuario con exito'
        END
END

--Procedimiento para guardar categoria
CREATE PROCEDURE SPRegistrarCategoria(
    @descripcion varchar(50),
    @estado bit,
    @resultado int output,
    @mensaje varchar(500) output
)
AS
BEGIN
    SET @resultado = 0
    IF NOT EXISTS (SELECT * FROM Categoria WHERE descripcion = @descripcion)
    
        BEGIN
            INSERT INTO Categoria (descripcion, estado) VALUES (@descripcion, @estado)
            SET @resultado = SCOPE_IDENTITY()
        END
    
    ELSE
        SET @mensaje = 'Categoria ya existente'
END

--Procedimiento para editar categoria
CREATE PROCEDURE SPEditarCategoria(
    @idCategoria int,
    @descripcion varchar(50),
    @estado bit,
    @resultado bit output, 
    @mensaje varchar(500) output
)
AS
BEGIN
    SET @resultado = 1
    IF NOT EXISTS (SELECT * FROM Categoria WHERE descripcion = @descripcion AND idCategoria != @idCategoria)
        BEGIN
            UPDATE Categoria SET
            descripcion = @descripcion,
            estado = @estado
            WHERE idCategoria = @idCategoria
        END
    ELSE
        BEGIN
            SET @resultado = 0
            SET @mensaje = 'Categoria ya existente'
        END
END

--Procedimiento para eliminar categoria
CREATE PROCEDURE SPEliminarCategoria(
    @idCategoria int,
    @resultado bit output, 
    @mensaje varchar(500) output
)
AS
BEGIN
    SET @resultado = 1
    IF NOT EXISTS (SELECT * FROM Categoria c 
                   INNER JOIN Producto p 
                   ON p.idCategoria = c.idCategoria 
                   WHERE c.idCategoria = @idCategoria)
        BEGIN
            DELETE TOP(1) FROM Categoria WHERE idCategoria = @idCategoria
        END
    
    ELSE
        BEGIN
            SET @resultado = 0
            SET @mensaje = 'No se puede eliminar Categorias que se encuentran relacionadas a un producto'
        END
END

GO
--Procedimiento para guardar Producto
CREATE PROCEDURE SPRegistrarProducto(
    @codigo varchar(50),
    @nombreProducto varchar(100),
    @descripcion varchar(100),
    @idCategoria int,
    @estado bit,
    @resultado int output,
    @mensaje varchar(500) output
)
AS
BEGIN
    SET @resultado = 0
    IF NOT EXISTS (SELECT * FROM Producto WHERE codigo = @codigo)
        BEGIN
            INSERT INTO Producto (codigo, nombreProducto, descripcion, idCategoria, estado) 
            VALUES (@codigo, @nombreProducto, @descripcion, @idCategoria, @estado)
            SET @resultado = SCOPE_IDENTITY()
        END
    ELSE
        SET @mensaje = 'Ya existe un producto con el mismo codigo'
END

GO

--Procedimiento para editar Producto
CREATE PROCEDURE SPEditarProducto(
    @idProducto int,
    @codigo varchar(50),
    @nombreProducto varchar(100),
    @descripcion varchar(100),
    @idCategoria int,
    @estado bit,
    @resultado bit output,
    @mensaje varchar(500) output
)
AS
BEGIN
    SET @resultado = 1
    IF NOT EXISTS (SELECT * FROM Producto WHERE codigo = @codigo AND idProducto != @idProducto)
        BEGIN
            UPDATE Producto SET
                codigo = @codigo,
                nombreProducto = @nombreProducto,
                descripcion = @descripcion,
                idCategoria = @idCategoria,
                estado = @estado
            WHERE idProducto = @idProducto
        END
    ELSE
        BEGIN
            SET @resultado = 0
            SET @mensaje = 'Producto ya existente'
        END
END

GO

CREATE PROCEDURE SPEliminarProducto(
    @idProducto int,
    @respuesta bit output, 
    @mensaje varchar(500) output
)
AS
BEGIN
    SET @respuesta = 0
    SET @mensaje = ''
    DECLARE @pasoReglas bit = 1

    IF EXISTS (SELECT * FROM DetalleCompra dc 
               INNER JOIN Producto p 
               ON p.idProducto = dc.idProducto 
               WHERE p.idProducto = @idProducto)
        BEGIN
            SET @pasoReglas = 0
            SET @respuesta = 0
            SET @mensaje = 'No se puede eliminar Producto que se encuentran relacionadas a una compra \n'
        END
    
    IF EXISTS (SELECT * FROM DetalleVenta dv 
               INNER JOIN Producto p 
               ON p.idProducto = dv.idProducto 
               WHERE p.idProducto = @idProducto)
        BEGIN
            SET @pasoReglas = 0
            SET @respuesta = 0
            SET @mensaje = 'No se puede eliminar Producto que se encuentran relacionadas a una Venta \n'
        END

    IF(@pasoReglas = 1)
        BEGIN
            DELETE FROM Producto WHERE idProducto = @idProducto
            SET @respuesta = 1
        END
END

GO


--Procedimiento almacenado para insertar Cliente
CREATE PROCEDURE SPRegistrarCliente(
    @cedula varchar(50),
    @nombreCompleto varchar(100),
    @email varchar(50),
    @telefono varchar(50),
    @estado bit,
    @resultado int output,
    @mensaje varchar (500) output 
)
AS
BEGIN
    SET @resultado = 0
    SET @mensaje = ''

    IF NOT EXISTS(SELECT * FROM Cliente WHERE cedula = @cedula)
        BEGIN
            INSERT INTO Cliente (cedula, nombreCompleto, email, telefono, estado) 
            VALUES (@cedula, @nombreCompleto, @email, @telefono, @estado)

            SET @resultado = SCOPE_IDENTITY()
        END
    ELSE
        SET @mensaje = 'No se puede crear otro cliente con la misma cedula'
END



--Procedimiento almacenado para editar Cliente
CREATE PROCEDURE SPEditarCliente(
    @idCliente int,
    @cedula varchar(50),
    @nombreCompleto varchar(100),
    @email varchar(50),
    @telefono varchar(50),
    @estado bit,
    @resultado int output,
    @mensaje varchar (500) output 
)
AS
BEGIN
    SET @resultado = 1
    SET @mensaje = ''

    IF NOT EXISTS (SELECT * FROM Cliente WHERE cedula = @cedula AND idCliente != @idCliente)
        BEGIN
            UPDATE Cliente SET
            cedula = @cedula,
            nombreCompleto = @nombreCompleto,
            email = @email,
            telefono = @telefono,
            estado = @estado
            WHERE idCliente = @idCliente 
        END
    ELSE
        SET @resultado = 0
        SET @mensaje = 'Ya existe este numero de cedula'
END