using DtoModels;
using System.Collections.Generic;
using System.Web.Http;
using WebApi.Logic;


namespace Prueba.Controllers
{
    [RoutePrefix("api/Aliados")]
    public class AliadosController : ApiController
    {
        [Route("GetAliadosId/{id}")]
        public DtoAliados Getid(int id)
        {
            AliadosLogic a = new AliadosLogic();
            return a.ConsultarId(id);
        }

        [Route("GetAliados")]
        public List<DtoAliados> Get()
        {
            AliadosLogic a = new AliadosLogic();
            return a.Consulta();
        }

        [HttpPost]
        [Route("AliadosCreate")]
        public IHttpActionResult Post(DtoAliados b)
        {
            AliadosLogic a = new AliadosLogic();
            var result = a.Crear(b);
            if (!string.IsNullOrEmpty(result.id.ToString())) return Ok(result);
            return NotFound();
        }

        [HttpPut]
        [Route("AliadosUpdate")]
        public IHttpActionResult Put(DtoAliados b)
        {
            AliadosLogic a = new AliadosLogic();
            var result = a.Actualizar(b);
            if (!string.IsNullOrEmpty(result.id.ToString())) return Ok(result);
            return NotFound();
        }

        [Route("AliadosDelete/{id}")]
        [HttpDelete]
        public string Delete(int id)
        {
            AliadosLogic a = new AliadosLogic();
            string resul = a.Eliminar(id);
            return resul;
        }
    }
}