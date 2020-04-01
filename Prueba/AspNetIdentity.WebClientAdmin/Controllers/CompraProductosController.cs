using WebApplicationClient.Providers;
using DtoModels;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Collections.Generic;
using System;
using System.Net.Http;
using System.Linq;
using AspNetIdentity.WebClientAdmin.Providers;

namespace WebApplicationClient.Controllers
{
    public class CompraProductosController :  Controller
    {
        EmployeeProvider employeeProvider = new EmployeeProvider();
        DictionaryModel DictionaryModel = new DictionaryModel();

        public async Task<ActionResult> ListAlidos()
        {
            string Id = "0";
            string Controller = "Aliados";
            string Method = "GetAliados";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<DtoAliados> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<DtoAliados>>(jsonResult.ToString());
            return Json(processModel.Select(x => new SelectListItem { Text = x.Aliado, Value = x.id.ToString() }).ToList());
        }

        public async Task<ActionResult> ListProductosAliados(int IdTable)
        {
            string Id = IdTable.ToString();
            string Controller = "Productos";
            string Method = "GetProductosAliadoId";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<DtoProductos> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<DtoProductos>>(jsonResult.ToString());
            return Json(processModel.Select(x => new SelectListItem { Text = x.Producto, Value = x.id.ToString() }).ToList());
        }
        public async Task<ActionResult> ListProductos()
        {
            string Id = "0";
            string Controller = "Productos";
            string Method = "GetProductos";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<DtoProductos> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<DtoProductos>>(jsonResult.ToString());
            return Json(processModel.Select(x => new SelectListItem { Text = x.Producto, Value = x.id.ToString() }).ToList());
        }

        public async Task<ActionResult> ListCliente()
        {
            string Id = "0";
            string Controller = "Clientes";
            string Method = "GetClientes";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<DtoClientes> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<DtoClientes>>(jsonResult.ToString());
            return Json(processModel.Select(x => new SelectListItem { Text = x.Nombre + " " + x.Apellidos, Value = x.id.ToString() }).ToList());
        }

        public async Task<ActionResult> Index()
        {
            string Id = "0";
            string Controller = "CompraProductos";
            string Method = "GetCompraProductos";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<DtoCompraProducto> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<DtoCompraProducto>>(jsonResult.ToString());
            return View(processModel);
        }

        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Crear(DtoCompraProducto ObjData)
        {
            string Controller = "CompraProductos";
            string Method = "CompraProductosCreate";
            if (ModelState.IsValid)
            {
                try
                {
                    Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
                    DictionaryModel ObjDictionary = new DictionaryModel();
                    keyValuePairs = ObjDictionary.ToDictionary(ObjData);
                    string Result = await employeeProvider.Post(keyValuePairs, Controller, Method);
                    var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(Result);
                    DtoCompraProducto processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<DtoCompraProducto>(jsonResult.ToString());
                    if (processModel.id.Equals(""))
                    {
                        ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                        return View(ModelState);
                    }
                    else
                    {
                                                return RedirectToAction("Index");
                    }
                }
                catch
                {
                    ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                    return Json(ModelState);
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                var errorList = (from item in ModelState
                                 from error in item.Value.Errors
                                 select new
                                 {
                                     Msg = error.ErrorMessage,
                                     Cam = item.Key
                                 }
                    ).ToList();
                return Json(errorList);
            }
        }

        public async Task<ActionResult> Edit(int IdTable)
        {
            string Id = IdTable.ToString();
            string Controller = "CompraProductos";
            string Method = "GetCompraProductosId";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            DtoCompraProducto processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<DtoCompraProducto>(jsonResult.ToString());
            return View(processModel);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(DtoCompraProducto ObjData)
        {
            string Controller = "CompraProductos";
            string Method = "CompraProductosUpdate";

            if (ModelState.IsValid)
            {
                try
                {
                    Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
                    DictionaryModel ObjDictionary = new DictionaryModel();
                    keyValuePairs = ObjDictionary.ToDictionary(ObjData);
                    string Result = await employeeProvider.Put(keyValuePairs, Controller, Method);
                    var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(Result);
                    DtoCompraProducto processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<DtoCompraProducto>(jsonResult.ToString());
                    if (processModel.id.Equals(""))
                    {
                        ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                        return Json(ModelState);
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                }
                catch
                {
                    ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                    return Json(ModelState);
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                var errorList = (from item in ModelState
                                 from error in item.Value.Errors
                                 select new
                                 {
                                     Msg = error.ErrorMessage,
                                     Cam = item.Key
                                 }
                    ).ToList();
                return Json(errorList);
            }
        }

        public async Task<ActionResult> Details(int IdTable)
        {
            string Id = IdTable.ToString();
            string Controller = "CompraProductos";
            string Method = "GetCompraProductosId";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            DtoCompraProducto processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<DtoCompraProducto>(jsonResult.ToString());
            return  View(processModel);
        }

        public async Task<ActionResult> Delete(int IdTable)
        {
            string Id = IdTable.ToString();
            string Controller = "CompraProductos";
            string Method = "getCompraProductosid";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            DtoCompraProducto processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<DtoCompraProducto>(jsonResult.ToString());
            return  View(processModel);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(DtoCompraProducto ObjData, int IdTable)  // --------------------- //
        {
            string Id = IdTable.ToString();
            string Controller = "CompraProductos";
            string Method = "CompraProductosDelete";
            string result = await employeeProvider.Delete(Controller, Method, Id); // ----------- //
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            var processModel = (jsonResult.ToString());
            if (processModel.Equals(""))
            {
                ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                return Json(ModelState);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }


}