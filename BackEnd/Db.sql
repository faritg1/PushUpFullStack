CREATE DATABASE Nike;
USE Nike;

-- Tabla de User
CREATE TABLE User (
    Id INT NOT NULL,
    Username VARCHAR(50) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    Password VARCHAR(255) NOT NULL,
    CONSTRAINT PkUser PRIMARY KEY (Id)
);

-- Tabla de Producto
CREATE TABLE Producto (
    ID INT NOT NULL,
    Nombre VARCHAR(100) NOT NULL,
    Descripcion TEXT NULL,
    Precio DECIMAL(10, 2) NOT NULL,
    Existencia INT NOT NULL,
    StockMin INT DEFAULT 0,
    StockMax INT DEFAULT 100,
    CONSTRAINT PkProducto PRIMARY KEY (Id)
);

-- Tabla de Categoria
CREATE TABLE Categoria (
    Id INT NOT NULL,
    Nombre VARCHAR(50) NOT NULL,
    CONSTRAINT PkCategoria PRIMARY KEY (Id)
);

-- Relación entre Productos y Categoria
CREATE TABLE ProductoCategoria (
    IdProductoFk INT NOT NULL,
    IdCategoriaFk INT NOT NULL,
    PRIMARY KEY (IdProductoFk, IdCategoriaFk),
    CONSTRAINT FkProducto FOREIGN KEY (IdProductoFk) REFERENCES Producto(Id),
    CONSTRAINT FkCategoria FOREIGN KEY (IdCategoriaFk) REFERENCES Categoria(Id)
);

-- Tabla de Pedido
CREATE TABLE Pedido (
    Id INT NOT NULL,
    IdUserFk INT,
    Fecha DATE NOT NULL,
    Estado VARCHAR(20) NOT NULL,
    CONSTRAINT PkPedido PRIMARY KEY (Id),
    CONSTRAINT FkUser FOREIGN KEY (IdUserFk) REFERENCES User(Id)
);

-- Tabla de Detalles de Pedido
CREATE TABLE DetallePedido (
    Id INT NOT NULL,
    IdPedidoFk INT NOT NULL,
    IdProductoFk INT NULL,
    cantidad INT NOT NULL,
    PrecioUnitario DECIMAL(10, 2) NOT NULL,
    CONSTRAINT PkDetallePedido PRIMARY KEY (Id),
    CONSTRAINT FkPedido FOREIGN KEY (IdPedidoFk) REFERENCES Pedido(Id),
    CONSTRAINT FkProductoDe FOREIGN KEY (IdProductoFk) REFERENCES Producto(Id)
);

-- Tabla de Carrito
CREATE TABLE Carrito (
    Id INT NOT NULL,
    IdUserFk INT NOT NULL,
    FechaCreacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT PkCarrito PRIMARY KEY (Id),
    CONSTRAINT FkUserCar FOREIGN KEY (IdUserFk) REFERENCES User(Id)
);

-- Tabla de Detalles del Carrito
CREATE TABLE DetalleCarrito (
    Id INT NOT NULL,
    IdCarritoFk INT NOT NULL,
    IdProductoFk INT NOT NULL,
    Cantidad INT NOT NULL,
    CONSTRAINT PkDetalleCar PRIMARY KEY (Id),
    CONSTRAINT FkCarrito FOREIGN KEY (IdCarritoFk) REFERENCES Carrito(Id),
    CONSTRAINT FKProductoDec FOREIGN KEY (IdProductoFk) REFERENCES Producto(Id)
);

-- Tabla de Transaccion
CREATE TABLE Transaccion (
    Id INT NOT NULL,
    IdUserFk INT NOT NULL,
    FechaTransaccion TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    Total DECIMAL(10, 2) NOT NULL,
    CONSTRAINT PkTransaccion PRIMARY KEY (Id),
    CONSTRAINT FkUserTrans FOREIGN KEY (IdUserFk) REFERENCES User(Id)
);

-- Tabla de Detalles de Transacción
CREATE TABLE DetalleTransaccion (
    Id INT NOT NULL,
    IdTransaccionFk INT NOT NULL,
    IdProductoFk INT NOT NULL,
    Cantidad INT NOT NULL,
    PrecioUnitario DECIMAL(10, 2) NOT NULL,
    CONSTRAINT PkDetalleTransaccion PRIMARY KEY (Id),
    CONSTRAINT FkTransacionDe FOREIGN KEY (IdTransaccionFk) REFERENCES Transaccion(Id),
    CONSTRAINT FKProductoDeTrans FOREIGN KEY (IdProductoFk) REFERENCES Producto(Id)
);

-- Tabla de Inventario
CREATE TABLE Inventario (
    Id INT NOT NULL,
    IdProductoFk INT NOT NULL,
    CantidadAnterior INT NOT NULL,
    CantidadNueva INT NOT NULL,
    FechaMovimiento TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT PkInventario PRIMARY KEY (Id),
    CONSTRAINT FkProductoIn FOREIGN KEY (IdProductoFk) REFERENCES Producto(Id)
);

-- Tabla Factura
CREATE TABLE Factura (
    Id INT NOT NULL,
    IdUserFk INT NOT NULL,
    IdDetalleTransaccionFk INT NOT NULL,
    FechaFactura TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    Total DECIMAL(10, 2) NOT NULL,
    CONSTRAINT PkFactura PRIMARY KEY (Id),
    CONSTRAINT FkUserFac FOREIGN KEY (IdUserFk) REFERENCES User(Id),
    CONSTRAINT FkDetaTrans FOREIGN KEY (IdDetalleTransaccionFk) REFERENCES DetalleTransaccion(Id)
);