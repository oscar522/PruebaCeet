using DtoModels;
using System.Collections.Generic;
using System.Web.Http;
using WebApi.Logic;


namespace Prueba.Controllers
{
    [RoutePrefix("api/Vendedor")]
    public class VendedorController : ApiController
    {
        [Route("GetVendedorId/{id}")]
        public DtoVendedor Getid(int id)
        {
            VendedorLogic a = new VendedorLogic();
            return a.ConsultarId(id);
        }

        [Route("GetVendedor")]
        public List<DtoVendedor> Get()
        {
            VendedorLogic a = new VendedorLogic();
            return a.Consulta();
        }

        [HttpPost]
        [Route("VendedorCreate")]
        public IHttpActionResult Post(DtoVendedor b)
        {
            VendedorLogic a = new VendedorLogic();
            var result = a.Crear(b);
            if (!string.IsNullOrEmpty(result.Id.ToString())) return Ok(result);
            return NotFound();
        }


        [HttpPut]
        [Route("VendedorUpdate")]
        public IHttpActionResult Put(DtoVendedor b)
        {
            VendedorLogic a = new VendedorLogic();
            var result = a.Actualizar(b);
            if (!string.IsNullOrEmpty(result.Id.ToString())) return Ok(result);
            return NotFound();
        }

        [Route("VendedorDelete/{id}")]
        [HttpDelete]
        public string Delete(int id)
        {
            VendedorLogic a = new VendedorLogic();
            string resul = a.Eliminar(id);
            return resul;
        }
    }
}