 
<h1 align="center"> Práctica Profesionalizante Concesionaria   </h1>


<p align="center"><img src="https://i.postimg.cc/XYm72YfN/Conesionaria-1.png"/></p> 
<hr>
<p align="center"><img src="https://i.postimg.cc/vmn8Cwhr/Concesionaria-2.png"/></p> 


## Descripción y contexto
---
- La aplicación consiste en un gestor de concesionaria, donde se muestran vehiculos disponibles para comercializar y se ofrecen planes de financiación para usuarios que se registren, 
 lo que les permitirá poder consultar el estado de plan de pago de acuerdo al vehiculo seleccionado, los administradores (vendedores) podrán visualizar las facturaciones totales por tipo de plan adquirido, además, actualizar datos de clientes, añadir nuevos vehiculos, realizar modificaciones y generar facturas.

## Guía de instalación
---

La guía de instalación:

- Se requiere Visual Studio 2022 y SQL Server Management Studio instalados en su sistema operativo.
- Descargue la carpeta principal del proyecto y guardelo en su directorio de preferencia para abrirlo desde Visual Studio.
- Dependencias: Microsoft.EntityFrameworkCore.Design, Microsoft.EntityFrameworkCore.Tools, Microsoft.EntityFrameworkCore.SqlServer, Microsoft.VisualStudio.Web.CodeGeneration.Design.
- Instale los paquetes desde "Administrador de paquetes NuGet". 


## Guía de usuario
---
- Desde la Clase ConcesionariaContext modifique optionsBuider.UseSqlServer de acuerdo a su configuración personal de SQL Server en su sistema. 
- Ejecute la aplicación.
- Desde Administradores podrá gestionar la aplicación web, es recomendable ingresar un Vendedor de pruebas desde SQL Server, una vez ingrese podrá añadir vehiculos, 
  editarlos, generar facturas, gestionarlas, visualizar la facturación total de acuerdo a los planes vendidos, administrar los clientes y los planes de pagos.
  Los clientes podrán seleccionar un vehiculo, registrarse, adquirir un plan de pago y posteriormente, desde la sección "Consultá tu plan", tener acceso a la información
  sobre su entrega.

## Autor/es
---
Práctica profesionalizante PNT1 (ORT) de Leandro Martín Rognoni.

## Licencia
---
Código abierto.
 
