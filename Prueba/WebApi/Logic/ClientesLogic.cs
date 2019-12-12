using DtoModels;
using WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Logic
{
    public class ClientesLogic
    {
        Clientes ModCtx = new Clientes();
        public DtoClientes Crear(DtoClientes a)
        {
            using (FalabellaSegurosEntities Ctx = new FalabellaSegurosEntities())
            {
                Clientes Nuevo = new Clientes
                {
                    id = a.id,
                    Nombre = a.Nombre,
                    Apellidos = a.Apellidos,
                    Identificacion = a.Identificacion,
                    Direccion = a.Direccion,
                    Email = a.Email,
                };
                Nuevo.estado = true;
                Ctx.Clientes.Add(Nuevo);
                Ctx.SaveChanges();
                return a;
            }
        }

        public List<DtoClientes> Consulta()
        {
            FalabellaSegurosEntities Ctx = new FalabellaSegurosEntities();
             DtoClientes b = new DtoClientes();
            var lista = Ctx.Clientes.Where(x => x.estado == true ).Select(a => new DtoClientes
            {
                id = a.id,
                Nombre = a.Nombre,
                Apellidos = a.Apellidos,
                Identificacion = a.Identificacion.Value,
                Direccion = a.Direccion,
                Email = a.Email,
            });

            return lista.ToList();
        }

        public DtoClientes ConsultarId(int id)
        {
            FalabellaSegurosEntities Ctx = new FalabellaSegurosEntities();
            Clientes a = Ctx.Clientes.Where(w => w.id == id).Select(s => s).FirstOrDefault();
            DtoClientes b = new DtoClientes();
            b.id = a.id;
            b.Nombre = a.Nombre;
            b.Apellidos = a.Apellidos;
            b.Identificacion = a.Identificacion.Value;
            b.Direccion = a.Direccion;
            b.Email = a.Email;
            b.Estado = a.estado.Value;
            return b;
        }

        public DtoClientes Actualizar(DtoClientes a)
        {
            using (var Ctx = new FalabellaSegurosEntities())
            {
                var b = Ctx.Clientes.Where(s => s.id == a.id).FirstOrDefault();
                if (b != null)
                {
                    b.Nombre = a.Nombre;
                    b.Apellidos = a.Apellidos;
                    b.Identificacion = a.Identificacion;
                    b.Direccion = a.Direccion;
                    b.Email = a.Email;
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
                var ResCtx = Ctx.Clientes.Where(s => s.id == id).FirstOrDefault();
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