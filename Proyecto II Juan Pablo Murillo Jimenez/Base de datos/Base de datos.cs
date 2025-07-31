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

 create table usuarios

 (

 UsuarioID int identity primary key,  

 Nombre varchar(100),

 correo varchar(50),

 Telefono varchar(10),

 clave varchar(50),

 tipousuario varchar(30)

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


 INSERT INTO usuarios (Nombre, correo, Telefono, clave, tipousuario)
 VALUES ('juan', '@juan', '2534', 'adios', 'admin');
     */
}