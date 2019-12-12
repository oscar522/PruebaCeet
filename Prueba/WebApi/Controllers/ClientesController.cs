using DtoModels;
using System.Collections.Generic;
using System.Web.Http;
using WebApi.Logic;


namespace Prueba.Controllers
{
    [RoutePrefix("api/Clientes")]
    public class ClientesController : ApiController
    {
        [Route("GetClientesId/{id}")]
        public DtoClientes Getid(int id)
        {
            ClientesLogic a = new ClientesLogic();
            return a.ConsultarId(id);
        }

        [Route("GetClientes")]
        public List<DtoClientes> Get()
        {
            ClientesLogic a = new ClientesLogic();
            return a.Consulta();
        }

        [HttpPost]
        [Route("ClientesCreate")]
        public IHttpActionResult Post(DtoClientes b)
        {
            ClientesLogic a = new ClientesLogic();
            var result = a.Crear(b);
            if (!string.IsNullOrEmpty(result.id.ToString())) return Ok(result);
            return NotFound();
        }


        [HttpPut]
        [Route("ClientesUpdate")]
        public IHttpActionResult Put(DtoClientes b)
        {
            ClientesLogic a = new ClientesLogic();
            var result = a.Actualizar(b);
            if (!string.IsNullOrEmpty(result.id.ToString())) return Ok(result);
            return NotFound();
        }

        [Route("ClientesDelete/{id}")]
        [HttpDelete]
        public string Delete(int id)
        {
            ClientesLogic a = new ClientesLogic();
            string resul = a.Eliminar(id);
            return resul;
        }
    }
}