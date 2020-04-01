using DtoModels;
using WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Logic
{
    public class VendedorLogic
    {
        Vendedor ModCtx = new Vendedor();
        public DtoVendedor Crear(DtoModels.DtoVendedor a)
        {
            using (EntitiesModel Ctx = new EntitiesModel())
            {
                Vendedor Nuevo = new Vendedor
                {
                    Id = a.Id,
                    Nombre = a.Nombre,
                    Apellido = a.Apellidos,
                    Identificacion = a.Identificacion,
                    IdCiuada = a.IdCiudad,
                };
                Nuevo.Estado = true;
                Ctx.Vendedor.Add(Nuevo);
                Ctx.SaveChanges();
                return a;
            }
        }

        public List<DtoModels.DtoVendedor> Consulta()
        {
            EntitiesModel Ctx = new EntitiesModel();
            DtoModels.DtoVendedor b = new DtoModels.DtoVendedor();
            var lista = Ctx.Vendedor.Where(x => x.Estado == true )
                 .Join(Ctx.Ciudad, x => x.IdCiuada, c => c.Id, (x, c) =>
                 new {x,c  })
                .Select(a => new DtoModels.DtoVendedor
            {
                Id = a.x.Id,
                Nombre = a.x.Nombre,
                Apellidos = a.x.Apellido,
                Identificacion = a.x.Identificacion.Value,
                IdCiudad = a.x.IdCiuada.Value,
                Estado = a.x.Estado.Value,
                NombreCiudad = a.c.Nombre
            });

            return lista.ToList();
        }

        public DtoVendedor ConsultarId(int id)
        {
            EntitiesModel Ctx = new EntitiesModel();
            var a = Ctx.Vendedor.Where(w => w.Id == id)
                .Join(Ctx.Ciudad, x => x.IdCiuada, c => c.Id, (x, c) =>
                new { x, c })
                .Select(s => s).FirstOrDefault();
            DtoModels.DtoVendedor b = new DtoModels.DtoVendedor() {
                Id = a.x.Id,
                Nombre = a.x.Nombre,
                Apellidos = a.x.Apellido,
                Identificacion = a.x.Identificacion.Value,
                IdCiudad = a.x.IdCiuada.Value,
                Estado = a.x.Estado.Value,
                NombreCiudad = a.c.Nombre
            };
               
            return b;
        }

        public DtoVendedor Actualizar(DtoModels.DtoVendedor a)
        {
            using (var Ctx = new EntitiesModel())
            {
                var b = Ctx.Vendedor.Where(s => s.Id == a.Id).FirstOrDefault();
                if (b != null)
                {
                    b.Id = a.Id;
                    b.Nombre = a.Nombre;
                    b.Apellido = a.Apellidos;
                    b.Identificacion = a.Identificacion;
                    b.IdCiuada = a.IdCiudad;
                    b.Estado = a.Estado;
                    Ctx.SaveChanges();
                }
            }
            return a;
        }

        public String Eliminar(int id)
        {
            using (var Ctx = new EntitiesModel())
            {
                var ResCtx = Ctx.Vendedor.Where(s => s.Id == id).FirstOrDefault();
                if (ResCtx != null)
                {
                    if (ResCtx != null)
                        ResCtx.Estado = false;
                    Ctx.SaveChanges();
                }
            }
            return "Realizado";
        }
    }
}