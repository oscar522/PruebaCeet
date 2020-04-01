using DtoModels;
using System.Collections.Generic;
using System.Web.Http;
using WebApi.Logic;


namespace Prueba.Controllers
{
    [RoutePrefix("api/Ciudades")]
    public class CiudadesController : ApiController
    {
        [Route("GetCiudadesId/{id}")]
        public DtoCiudades Getid(int id)
        {
            CiudadesLogic a = new CiudadesLogic();
            return a.ConsultarId(id);
        }

        [Route("GetCiudades")]
        public List<DtoCiudades> Get()
        {
            CiudadesLogic a = new CiudadesLogic();
            return a.Consulta();
        }

        [HttpPost]
        [Route("CiudadesCreate")]
        public IHttpActionResult Post(DtoCiudades b)
        {
            CiudadesLogic a = new CiudadesLogic();
            var result = a.Crear(b);
            if (!string.IsNullOrEmpty(result.Id.ToString())) return Ok(result);
            return NotFound();
        }

        [HttpPut]
        [Route("CiudadesUpdate")]
        public IHttpActionResult Put(DtoCiudades b)
        {
            CiudadesLogic a = new CiudadesLogic();
            var result = a.Actualizar(b);
            if (!string.IsNullOrEmpty(result.Id.ToString())) return Ok(result);
            return NotFound();
        }

        [Route("CiudadesDelete/{id}")]
        [HttpDelete]
        public string Delete(int id)
        {
            CiudadesLogic a = new CiudadesLogic();
            string resul = a.Eliminar(id);
            return resul;
        }
    }
}