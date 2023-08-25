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
    documento varchar(50),
    razonSocial varchar(50),
    correo varchar(50),
    telefono varchar(50),
    estado bit,
    fechaCreacion datetime default getdate()
);
GO

create table Cliente(
    idCliente int primary key identity,
    documento varchar(50),
    nombreCompleto varchar (100),
    correo varchar(50),
    telefono varchar(50),
    estado bit,
    fechaCreacion datetime default getdate()
);
GO

create table Usuario(
    idUsuario int primary key identity,
    documento varchar (50),
    nombreCompleto varchar (100),
    correo varchar(50),
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