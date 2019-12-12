using DtoModels;
using WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Logic
{
    public class AliadosLogic
    {
        Aliados ModCtx = new Aliados();
        public DtoAliados Crear(DtoAliados a)
        {
            using (FalabellaSegurosEntities Ctx = new FalabellaSegurosEntities())
            {
                Aliados Nuevo = new Aliados
                {
                    id = a.id,
                    Aliado = a.Aliado,
                };
                Nuevo.estado = true;
                Ctx.Aliados.Add(Nuevo);
                Ctx.SaveChanges();
                return a;
            }
        }

        public List<DtoAliados> Consulta()
        {
            FalabellaSegurosEntities Ctx = new FalabellaSegurosEntities();
             DtoAliados b = new DtoAliados();
            var lista = Ctx.Aliados.Where(x => x.estado == true ).Select(a => new DtoAliados
            {
                id = a.id,
                Aliado = a.Aliado,
                Estado = a.estado.Value,
            });

            return lista.ToList();
        }

        public DtoAliados ConsultarId(int id)
        {
            FalabellaSegurosEntities Ctx = new FalabellaSegurosEntities();
            Aliados a = Ctx.Aliados.Where(w => w.id == id).Select(s => s).FirstOrDefault();
            DtoAliados b = new DtoAliados();
            b.id = a.id;
            b.Aliado = a.Aliado;
            b.Estado = a.estado.Value;
            return b;
        }

        public DtoAliados Actualizar(DtoAliados a)
        {
            using (var Ctx = new FalabellaSegurosEntities())
            {
                var b = Ctx.Aliados.Where(s => s.id == a.id).FirstOrDefault();
                if (b != null)
                {
                    b.Aliado = a.Aliado;
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
                var ResCtx = Ctx.Aliados.Where(s => s.id == id).FirstOrDefault();
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