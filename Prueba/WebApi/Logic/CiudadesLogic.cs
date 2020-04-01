using DtoModels;
using WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Logic
{
    public class CiudadesLogic
    {
        Ciudad ModCtx = new Ciudad();
        public DtoCiudades Crear(DtoCiudades a)
        {
            using (EntitiesModel Ctx = new EntitiesModel())
            {
                Ciudad Nuevo = new Ciudad
                {
                    Id = a.Id,
                    Nombre = a.Nombre,
                    Estado = true
                };
                Ctx.Ciudad.Add(Nuevo);
                Ctx.SaveChanges();
                return a;
            }
        }

        public List<DtoCiudades> Consulta()
        {
            EntitiesModel Ctx = new EntitiesModel();
             DtoCiudades b = new DtoCiudades();
            var lista = Ctx.Ciudad.Where(x => x.Estado == true ).Select(a => new DtoCiudades
            {
                Id = a.Id,
                Nombre = a.Nombre,
                Estado = true
            });

            return lista.ToList();
        }

        public DtoCiudades ConsultarId(int id)
        {
            EntitiesModel Ctx = new EntitiesModel();
            Ciudad a = Ctx.Ciudad.Where(w => w.Id == id).Select(s => s).FirstOrDefault();
            DtoCiudades b = new DtoCiudades()
            {
                Id = a.Id,
                Nombre = a.Nombre,
                Estado = true
            };
            return b;
        }

        public DtoCiudades Actualizar(DtoCiudades a)
        {
            using (var Ctx = new EntitiesModel())
            {
                var b = Ctx.Ciudad.Where(s => s.Id == a.Id).FirstOrDefault();
                if (b != null)
                {
                    b.Nombre = a.Nombre;
                    Ctx.SaveChanges();
                }
            }
            return a;
        }

        public String Eliminar(int id)
        {
            using (var Ctx = new EntitiesModel())
            {
                var ResCtx = Ctx.Ciudad.Where(s => s.Id == id).FirstOrDefault();
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