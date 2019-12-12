using DtoModels;
using System.Collections.Generic;
using System.Web.Http;
using WebApi.Logic;


namespace Prueba.Controllers
{
    [RoutePrefix("api/CompraProductos")]
    public class CompraProductosController : ApiController
    {
        [Route("GetCompraProductosId/{id}")]
        public DtoCompraProducto Getid(int id)
        {
            CompraProductoLogic a = new CompraProductoLogic();
            return a.ConsultarId(id);
        }

        [Route("GetCompraProductos")]
        public List<DtoCompraProducto> Get()
        {
            CompraProductoLogic a = new CompraProductoLogic();
            return a.Consulta();
        }

        [HttpPost]
        [Route("CompraProductosCreate")]
        public IHttpActionResult Post(DtoCompraProducto b)
        {
            CompraProductoLogic a = new CompraProductoLogic();
            var result = a.Crear(b);
            if (!string.IsNullOrEmpty(result.id.ToString())) return Ok(result);
            return NotFound();
        }


        [HttpPut]
        [Route("CompraProductosUpdate")]
        public IHttpActionResult Put(DtoCompraProducto b)
        {
            CompraProductoLogic a = new CompraProductoLogic();
            var result = a.Actualizar(b);
            if (!string.IsNullOrEmpty(result.id.ToString())) return Ok(result);
            return NotFound();
        }

        [Route("CompraProductosDelete/{id}")]
        [HttpDelete]
        public string Delete(int id)
        {
            CompraProductoLogic a = new CompraProductoLogic();
            string resul = a.Eliminar(id);
            return resul;
        }
    }
}