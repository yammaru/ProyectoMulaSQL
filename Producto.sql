CREATE TABLE [dbo].[Producto] (
    [CodigoProducto] VARCHAR (15)  NOT NULL,
    [NombreProducto] VARCHAR (20)  NOT NULL,
    [Existencia]     INT           NOT NULL,
    [Marca]          NVARCHAR (50) NOT NULL,
    [Referencia]     NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([CodigoProducto] ASC)
);
