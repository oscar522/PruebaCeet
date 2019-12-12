using DtoModels;
using WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Logic
{
    public class ProductosLogic
    {
        Productos ModCtx = new Productos();
        public DtoProductos Crear(DtoProductos a)
        {
            using (FalabellaSegurosEntities Ctx = new FalabellaSegurosEntities())
            {
                Productos Nuevo = new Productos
                {
                    id = a.id,
                    Producto = a.Producto,
                    valor = a.valor,
                    descripcion = a.descripcion,
                    estado = a.Estado,
                    idAliado = a.idAliado
                };
                Nuevo.estado = true;
                Ctx.Productos.Add(Nuevo);
                Ctx.SaveChanges();
                return a;
            }
        }

        public List<DtoProductos> Consulta()
        {
            FalabellaSegurosEntities Ctx = new FalabellaSegurosEntities();
             DtoProductos b = new DtoProductos();
            var lista = Ctx.Productos
                .Join(Ctx.Aliados, x => x.idAliado, c => c.id, (x, c) =>
                 new {idAliado=c.id, x.id, x.Producto,x.valor,x.descripcion,x.estado,c.Aliado })
                .Where(x => x.estado == true )
                .Select(a => new DtoProductos
            {
                id = a.id,
                Producto = a.Producto,
                valor = a.valor.Value,
                descripcion = a.descripcion,
                Estado = a.estado.Value,
                idAliado = a.idAliado,
                NombreAliado = a.Aliado
                
            });

            return lista.ToList();
        }

        public DtoProductos ConsultarId(int id)
        {
            FalabellaSegurosEntities Ctx = new FalabellaSegurosEntities();
            var f = Ctx.Productos
                 .Join(Ctx.Aliados, x => x.idAliado, c => c.id, (x, c) =>
                 new { idAliado = c.id, x.id, x.Producto, x.valor, x.descripcion, x.estado, c.Aliado })
                .Where(w => w.id == id)
                .Select(a => new DtoProductos
                {
                    id = a.id,
                    Producto = a.Producto,
                    valor = a.valor.Value,
                    descripcion = a.descripcion,
                    Estado = a.estado.Value,
                    idAliado = a.idAliado,
                    NombreAliado = a.Aliado

                }).FirstOrDefault();
            return f;
        }

        public List<DtoProductos> ConsultarAliadoId(int id)
        {
            FalabellaSegurosEntities Ctx = new FalabellaSegurosEntities();
            var f = Ctx.Productos
                 .Join(Ctx.Aliados, x => x.idAliado, c => c.id, (x, c) =>
                 new { idAliado = c.id, x.id, x.Producto, x.valor, x.descripcion, x.estado, c.Aliado })
                .Where(w => w.idAliado == id)
                .Select(a => new DtoProductos
                {
                    id = a.id,
                    Producto = a.Producto,
                    valor = a.valor.Value,
                    descripcion = a.descripcion,
                    Estado = a.estado.Value,
                    idAliado = a.idAliado,
                    NombreAliado = a.Aliado

                });
            return f.ToList();
        }

        public DtoProductos Actualizar(DtoProductos a)
        {
            using (var Ctx = new FalabellaSegurosEntities())
            {
                var b = Ctx.Productos.Where(s => s.id == a.id).FirstOrDefault();
                if (b != null)
                {
                    b.Producto = a.Producto;
                    b.valor = a.valor;
                    b.descripcion = a.descripcion;
                    b.estado = a.Estado;
                    b.idAliado = a.idAliado;
                    Ctx.SaveChanges();
                }
            }
            return a;
        }

        public String Eliminar(int id)
        {
            using (var Ctx = new FalabellaSegurosEntities())
            {
                var ResCtx = Ctx.Productos.Where(s => s.id == id).FirstOrDefault();
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