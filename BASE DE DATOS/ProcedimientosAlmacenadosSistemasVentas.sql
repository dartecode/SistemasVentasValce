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


--Procedimiento almacenado para guardar un Proveedor
CREATE PROCEDURE SPRegistrarProveedor(
    @cedula varchar(50),
    @razonSocial varchar(50),
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
    DECLARE @idPersona int

    IF NOT EXISTS(SELECT * FROM Proveedor WHERE cedula = @cedula)
        BEGIN
            INSERT INTO Proveedor (cedula, razonSocial, email, telefono, estado) 
            VALUES (@cedula, @razonSocial, @email, @telefono, @estado)

            SET @resultado = SCOPE_IDENTITY()
        END
    ELSE
        SET @mensaje = 'No se puede crear otro proveedor con la misma cedula'
END

GO

--Procedimiento almacenado para editar un proveedoor
CREATE PROCEDURE SPEditarProveedor(
    @idProveedor int,
    @cedula varchar(50),
    @razonSocial varchar(50),
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
    DECLARE @idPersona int

    IF NOT EXISTS (SELECT * FROM Proveedor WHERE cedula = @cedula AND idProveedor != @idProveedor)
        BEGIN
            UPDATE Proveedor SET
            cedula = @cedula,
            razonSocial = @razonSocial,
            email = @email,
            telefono = @telefono,
            estado = @estado
            WHERE idProveedor = @idProveedor 
        END
    ELSE
        SET @resultado = 0
        SET @mensaje = 'Ya existe este numero de cedula'
END

GO

--Procedimiento para eliminar categoria
CREATE PROCEDURE SPEliminarProveedor(
    @idProveedor int,
    @resultado bit output, 
    @mensaje varchar(500) output
)
AS
BEGIN
    SET @resultado = 1
    IF NOT EXISTS (SELECT * FROM Proveedor p 
                   INNER JOIN Compra c 
                   ON p.idProveedor = c.idProveedor 
                   WHERE p.idProveedor = @idProveedor)
        BEGIN
            DELETE TOP(1) FROM Proveedor WHERE idProveedor = @idProveedor
        END
    
    ELSE
        BEGIN
            SET @resultado = 0
            SET @mensaje = 'No se puede eliminar Categorias que se encuentran relacionadas a una compra '
        END
END



--Procesos para realizar una compra

CREATE TYPE [dbo].[EDetalleCompra] AS TABLE (
    [idProducto] int NULL,
    [precioCompra] decimal(18,2) NULL,
    [precioVenta] decimal(18,2) NULL,
    [cantidad] int NULL,
    [montoTotal] decimal(18,2) NULL
)

GO

ALTER PROCEDURE SPRegistrarCompra (
    @idUsuario int,
    @idProveedor int,
    @tipoDocumento varchar(500),
    @numeroDocumento varchar(500),
    @montoTotal decimal(18,2),
    @DetalleCompra [EDetalleCompra] READONLY,
    @resultado bit output,
    @mensaje varchar(500) output
)
AS 
BEGIN
    BEGIN TRY
        DECLARE @idCompra int = 0
        SET @resultado = 1
        SET @mensaje = ''

        BEGIN TRANSACTION registro 
            
            INSERT INTO Compra(idUsuario, idProveedor, tipoDocumento, numeroDocumento, montoTotal)
            VALUES(@idUsuario, @idProveedor, @tipoDocumento, @numeroDocumento, @montoTotal)
            SET @idCompra = SCOPE_IDENTITY()

            INSERT INTO DetalleCompra(idCompra, idProducto, precioCompra, precioVenta, cantidad, montoTotal)
            SELECT @idCompra, idProducto, precioCompra, precioVenta, cantidad, montoTotal FROM @DetalleCompra

            UPDATE p SET p.stock = p.stock + dc.cantidad,
                         p.precioCompra = dc.precioCompra,
                         p.precioVenta = dc.precioVenta
            FROM Producto p 
            INNER JOIN @DetalleCompra dc
            ON dc.idProducto = p.idProducto

        COMMIT TRANSACTION registro
    END TRY

    BEGIN CATCH
        SET @resultado = 0
        SET @mensaje = ERROR_MESSAGE()
        ROLLBACK TRANSACTION registro
    END CATCH
END

SELECT COUNT(*) +1 FROM Compra