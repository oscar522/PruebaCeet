using DtoModels;
using WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Logic
{
    public class CompraProductoLogic
    {
        CompraProducto ModCtx = new CompraProducto();
        public DtoCompraProducto Crear(DtoCompraProducto a)
        {
            using (FalabellaSegurosEntities Ctx = new FalabellaSegurosEntities())
            {
                CompraProducto Nuevo = new CompraProducto
                {
                    Id = a.id,
                    IdCliente = a.IdCliente,
                    IdProducto = a.IdProducto,
                    Fecha = a.Fecha,
                };
                Nuevo.estado = true;
                Ctx.CompraProducto.Add(Nuevo);
                Ctx.SaveChanges();
                return a;
            }
        }

        public List<DtoCompraProducto> Consulta()
        {
            FalabellaSegurosEntities Ctx = new FalabellaSegurosEntities();
             DtoCompraProducto b = new DtoCompraProducto();

            var lista = Ctx.CompraProducto
                 .Join(Ctx.Productos, x => x.IdProducto, c => c.id, (x, c) =>
                 new { x.estado,x.Fecha,x.Id,x.IdCliente,x.IdProducto , c.idAliado, NombreProducto = c.Producto  })
                 .Join(Ctx.Aliados, x => x.idAliado, c => c.id, (x, c) =>
                 new { x.estado, x.Fecha, x.Id, x.IdCliente, x.IdProducto, x.idAliado, x.NombreProducto, NombreAliado = c.Aliado })
                .Join(Ctx.Clientes, x => x.IdCliente, c => c.id, (x, c) =>
                 new { x.estado, x.Fecha, x.Id, x.IdCliente, x.IdProducto, x.idAliado, x.NombreProducto, x.NombreAliado, NombreCliente = c.Nombre + " " + c.Apellidos })

                 .Where(x => x.estado == true ).Select(a => new DtoCompraProducto
            {
                id = a.Id,
                IdCliente = a.IdCliente.Value,
                IdProducto = a.IdProducto.Value,
                Fecha = a.Fecha.Value,
                Estado = a.estado.Value,
                IdAliado = a.idAliado,
                NombreAliado = a.NombreAliado,
                NombreCliente = a.NombreCliente,
                NombreProducto = a.NombreProducto
                
            });

            return lista.ToList();
        }

        public DtoCompraProducto ConsultarId(int id)
        {
            FalabellaSegurosEntities Ctx = new FalabellaSegurosEntities();
            var f = Ctx.CompraProducto
                 .Join(Ctx.Productos, x => x.IdProducto, c => c.id, (x, c) =>
                 new { x.estado,x.Fecha,x.Id,x.IdCliente,x.IdProducto , c.idAliado, NombreProducto = c.Producto  })
                 .Join(Ctx.Aliados, x => x.idAliado, c => c.id, (x, c) =>
                 new { x.estado, x.Fecha, x.Id, x.IdCliente, x.IdProducto, x.idAliado, x.NombreProducto, NombreAliado = c.Aliado })
                .Join(Ctx.Clientes, x => x.IdCliente, c => c.id, (x, c) =>
                 new { x.estado, x.Fecha, x.Id, x.IdCliente, x.IdProducto, x.idAliado, x.NombreProducto, x.NombreAliado, NombreCliente = c.Nombre + " " + c.Apellidos })
                .Where(w => w.Id == id).Select(a => new DtoCompraProducto
                {
                    id = a.Id,
                    IdCliente = a.IdCliente.Value,
                    IdProducto = a.IdProducto.Value,
                    Fecha = a.Fecha.Value,
                    Estado = a.estado.Value,
                    IdAliado = a.idAliado,
                    NombreAliado = a.NombreAliado,
                    NombreCliente = a.NombreCliente,
                    NombreProducto = a.NombreProducto

                }).FirstOrDefault();
            return f;
        }

        public DtoCompraProducto Actualizar(DtoCompraProducto a)
        {
            using (var Ctx = new FalabellaSegurosEntities())
            {
                var b = Ctx.CompraProducto.Where(s => s.Id == a.id).FirstOrDefault();
                if (b != null)
                {
                    b.IdCliente = a.IdCliente;
                    b.IdProducto = a.IdProducto;
                    b.Fecha = a.Fecha;
                    b.estado = a.Estado;
                    Ctx.SaveChanges();
                }
            }
            return a;
        }

        public String Eliminar(int id)
        {
            using (var Ctx = new FalabellaSegurosEntities())
            {
                var ResCtx = Ctx.CompraProducto.Where(s => s.Id == id).FirstOrDefault();
                if (ResCtx != null)
                {
                    if (ResCtx != null)
                        ResCtx.estado = false;
                    Ctx.SaveChanges();
                }
            }
            return "Realizado";
        }
    }
}