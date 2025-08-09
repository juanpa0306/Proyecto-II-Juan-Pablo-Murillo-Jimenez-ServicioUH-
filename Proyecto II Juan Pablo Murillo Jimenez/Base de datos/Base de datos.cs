using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_II_Juan_Pablo_Murillo_Jimenez.Base_de_datos
{
    /*    
    create database servicioUh

go
 
use servicioUh

go
 

create table roles
(
ID int identity primary key,
NombreRol varchar(50),
)


INSERT INTO roles (NombreRol)
VALUES ('admin'), ('usuario'), ('tecnico');



create table usuarios

(

UsuarioID int identity primary key,  

Nombre varchar(100),

correo varchar(50),

Telefono varchar(10),

clave varchar(50),

tipousuario int,
 CONSTRAINT FK_tipoUsuario FOREIGN KEY(tipousuario) REFERENCES roles(ID)
 

)

go
 
 
-- integridad refencial : cuidar los datos 

-- mantener la consistencia de datos

create table equipos

(

EquipoID int identity primary key,

TipoEquipo Varchar(30),

modelo varchar(30),

UsuarioID int

CONSTRAINT FK_USUARIOID FOREIGN KEY(UsuarioID) REFERENCES usuarios(UsuarioID)

)
 
 
create table reparaciones

(

  ReparacionID int identity primary key,

  EquipoID int, -- foranea

  FechaSolicitud datetime,

  Estado varchar(30),

  CONSTRAINT FK_EQUIPOID FOREIGN KEY(EquipoID) REFERENCES equipos(EquipoID)
 
 
)
 
 create table DetallesReparacion
 (
 DetalleID int identity primary key,
 ReparacionID int,
 Descripcion varChar(30),
 FechaInicio datetime,
 FechaFin datetime,
 CONSTRAINT FK_REPARACIONID FOREIGN KEY(ReparacionID) REFERENCES reparaciones(ReparacionID)
 )

 create table Tecnicos
 (
 TecnicoID int identity primary key,
 Nombre varchar(50),
 Especialidad varchar(50),
 )


 create table Asignaciones
 (
 AsignacionID int identity primary key,
 ReparacionID int,
 TecnicoID int, 
 FechaAsignacion datetime
   CONSTRAINT FK_REPARACION_ASIG FOREIGN KEY(ReparacionID) REFERENCES reparaciones(ReparacionID),
      CONSTRAINT FK_TECNICOS_ASIG FOREIGN KEY(TecnicoID) REFERENCES Tecnicos(TecnicoID), 
 )


 ALTER TABLE reparaciones
 ALTER COLUMN FechaSolicitud VARCHAR(50);

 ALTER TABLE DetallesReparacion
 ALTER COLUMN FechaInicio VARCHAR(50);

 ALTER TABLE DetallesReparacion
 ALTER COLUMN FechaFin VARCHAR(50);

ALTER TABLE Asignaciones
ALTER COLUMN FechaAsignacion VARCHAR(50);



----------------------------------------------------------------
--Agregar usuario
CREATE PROCEDURE PA_AgregarUsuario
    @Nombre VARCHAR(100),
    @Correo VARCHAR(50),
    @Telefono VARCHAR(10),
    @Clave VARCHAR(50),
    @TipoUsuario INT
AS
BEGIN
    INSERT INTO usuarios (Nombre, correo, Telefono, clave, tipousuario)
    VALUES (@Nombre, @Correo, @Telefono, @Clave, @TipoUsuario)
END

--Actualizar usuario
CREATE PROCEDURE PA_ActualizarUsuario
    @UsuarioID INT,
    @Nombre VARCHAR(100),
    @Correo VARCHAR(50),
    @Telefono VARCHAR(10),
    @Clave VARCHAR(50),
    @TipoUsuario INT
AS
BEGIN
    UPDATE usuarios
    SET Nombre = @Nombre, correo = @Correo, Telefono = @Telefono, clave = @Clave, tipousuario = @TipoUsuario
    WHERE UsuarioID = @UsuarioID
END

--Eliminar usuario
CREATE PROCEDURE PA_EliminarUsuario
    @UsuarioID INT
AS
BEGIN
    DELETE FROM usuarios WHERE UsuarioID = @UsuarioID
END



--Equipo
--Agregar equipo
CREATE PROCEDURE PA_AgregarEquipo
    @TipoEquipo VARCHAR(30),
    @Modelo VARCHAR(30),
    @UsuarioID INT
AS
BEGIN
    INSERT INTO equipos (TipoEquipo, modelo, UsuarioID)
    VALUES (@TipoEquipo, @Modelo, @UsuarioID)
END

--Actualzar equipo
CREATE PROCEDURE PA_ActualizarEquipo
    @EquipoID INT,
    @TipoEquipo VARCHAR(30),
    @Modelo VARCHAR(30),
    @UsuarioID INT
AS
BEGIN
    UPDATE equipos
    SET TipoEquipo = @TipoEquipo, modelo = @Modelo, UsuarioID = @UsuarioID
    WHERE EquipoID = @EquipoID
END

--Eliminar equipo
CREATE PROCEDURE PA_EliminarEquipo
    @EquipoID INT
AS
BEGIN
    DELETE FROM equipos WHERE EquipoID = @EquipoID
END


--Reparaciones
--Agregar reparacion
CREATE PROCEDURE PA_AgregarReparacion
    @EquipoID INT,
    @FechaSolicitud VARCHAR(50),
    @Estado VARCHAR(30)
AS
BEGIN
    INSERT INTO reparaciones (EquipoID, FechaSolicitud, Estado)
    VALUES (@EquipoID, @FechaSolicitud, @Estado)
END

--Actualizar 
CREATE PROCEDURE PA_ActualizarReparacion
    @ReparacionID INT,
    @EquipoID INT,
    @FechaSolicitud VARCHAR(50),
    @Estado VARCHAR(30)
AS
BEGIN
    UPDATE reparaciones
    SET EquipoID = @EquipoID, FechaSolicitud = @FechaSolicitud, Estado = @Estado
    WHERE ReparacionID = @ReparacionID
END

--Borrar
CREATE PROCEDURE PA_EliminarReparacion
    @ReparacionID INT
AS
BEGIN
    DELETE FROM reparaciones WHERE ReparacionID = @ReparacionID
END


--Detalles reparacion
--Agregar
CREATE PROCEDURE PA_AgregarDetalle
    @ReparacionID INT,
    @Descripcion VARCHAR(30),
    @FechaInicio VARCHAR(50),
    @FechaFin VARCHAR(50)
AS
BEGIN
    INSERT INTO DetallesReparacion (ReparacionID, Descripcion, FechaInicio, FechaFin)
    VALUES (@ReparacionID, @Descripcion, @FechaInicio, @FechaFin)
END

--Actualizar
CREATE PROCEDURE PA_ActualizarDetalle
    @DetalleID INT,
    @ReparacionID INT,
    @Descripcion VARCHAR(30),
    @FechaInicio VARCHAR(50),
    @FechaFin VARCHAR(50)
AS
BEGIN
    UPDATE DetallesReparacion
    SET ReparacionID = @ReparacionID, Descripcion = @Descripcion,
        FechaInicio = @FechaInicio, FechaFin = @FechaFin
    WHERE DetalleID = @DetalleID
END

--Borrar
CREATE PROCEDURE PA_EliminarDetalle
    @DetalleID INT
AS
BEGIN
    DELETE FROM DetallesReparacion WHERE DetalleID = @DetalleID
END

--Tecnicos
--Agregar
CREATE PROCEDURE PA_AgregarTecnico
    @Nombre VARCHAR(50),
    @Especialidad VARCHAR(50)
AS
BEGIN
    INSERT INTO Tecnicos (Nombre, Especialidad)
    VALUES (@Nombre, @Especialidad)
END

--Actualizar
CREATE PROCEDURE PA_ActualizarTecnico
    @TecnicoID INT,
    @Nombre VARCHAR(50),
    @Especialidad VARCHAR(50)
AS
BEGIN
    UPDATE Tecnicos
    SET Nombre = @Nombre, Especialidad = @Especialidad
    WHERE TecnicoID = @TecnicoID
END

--Borrar
CREATE PROCEDURE PA_EliminarTecnico
    @TecnicoID INT
AS
BEGIN
    DELETE FROM Tecnicos WHERE TecnicoID = @TecnicoID
END

--Asignaciones
--Agregar
CREATE PROCEDURE PA_AgregarAsignacion
    @ReparacionID INT,
    @TecnicoID INT,
    @FechaAsignacion VARCHAR(50)
AS
BEGIN
    INSERT INTO Asignaciones (ReparacionID, TecnicoID, FechaAsignacion)
    VALUES (@ReparacionID, @TecnicoID, @FechaAsignacion)
END

--Actualizar
CREATE PROCEDURE PA_ActualizarAsignacion
    @AsignacionID INT,
    @ReparacionID INT,
    @TecnicoID INT,
    @FechaAsignacion VARCHAR(50)
AS
BEGIN
    UPDATE Asignaciones
    SET ReparacionID = @ReparacionID,
        TecnicoID = @TecnicoID,
        FechaAsignacion = @FechaAsignacion
    WHERE AsignacionID = @AsignacionID
END

--Borrar
CREATE PROCEDURE PA_EliminarAsignacion
    @AsignacionID INT
AS
BEGIN
    DELETE FROM Asignaciones WHERE AsignacionID = @AsignacionID
END

--validar usuario
CREATE procedure validar_usuario
 @correo varchar(50),
 @clave varchar(50)
as 
begin
	select correo, clave, nombre, tipousuario from usuarios 
	where correo =@correo and clave=@clave
end
     */
}