using DtoModels;
using System.Collections.Generic;
using System.Web.Http;
using WebApi.Logic;


namespace Prueba.Controllers
{
    [RoutePrefix("api/Productos")]
    public class ProductosController : ApiController
    {
        [Route("GetProductosId/{id}")]
        public DtoProductos Getid(int id)
        {
            ProductosLogic a = new ProductosLogic();
            return a.ConsultarId(id);
        }

        [Route("GetProductosAliadoId/{id}")]
        public List<DtoProductos> GetidA(int id)
        {
            ProductosLogic a = new ProductosLogic();
            return a.ConsultarAliadoId(id);
        }

        [Route("GetProductos")]
        public List<DtoProductos> Get()
        {
            ProductosLogic a = new ProductosLogic();
            return a.Consulta();
        }

        [HttpPost]
        [Route("ProductosCreate")]
        public IHttpActionResult Post(DtoProductos b)
        {
            ProductosLogic a = new ProductosLogic();
            var result = a.Crear(b);
            if (!string.IsNullOrEmpty(result.id.ToString())) return Ok(result);
            return NotFound();
        }


        [HttpPut]
        [Route("ProductosUpdate")]
        public IHttpActionResult Put(DtoProductos b)
        {
            ProductosLogic a = new ProductosLogic();
            var result = a.Actualizar(b);
            if (!string.IsNullOrEmpty(result.id.ToString())) return Ok(result);
            return NotFound();
        }

        [Route("ProductosDelete/{id}")]
        [HttpDelete]
        public string Delete(int id)
        {
            ProductosLogic a = new ProductosLogic();
            string resul = a.Eliminar(id);
            return resul;
        }
    }
}