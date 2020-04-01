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
    public class VendedorController :  Controller
    {
        EmployeeProvider employeeProvider = new EmployeeProvider();
        DictionaryModel DictionaryModel = new DictionaryModel();

        public async Task<ActionResult> ListCiudad()
        {
            string Id = "0";
            string Controller = "Ciudades";
            string Method = "getCiudades";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<DtoCiudades> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<DtoCiudades>>(jsonResult.ToString());
            return Json(processModel.Select(x => new SelectListItem { Text = x.Nombre, Value = x.Id.ToString() }).ToList());
        }

        public async Task<ActionResult> Index()
        {
            string Id = "0";
            string Controller = "Vendedor";
            string Method = "GetVendedor";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<DtoVendedor> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<DtoVendedor>>(jsonResult.ToString());
            return View(processModel);
        }

        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Crear(DtoVendedor ObjData)
        {
            string Controller = "Vendedor";
            string Method = "VendedorCreate";
            if (ModelState.IsValid)
            {
                try
                {
                    Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
                    DictionaryModel ObjDictionary = new DictionaryModel();
                    keyValuePairs = ObjDictionary.ToDictionary(ObjData);
                    string Result = await employeeProvider.Post(keyValuePairs, Controller, Method);
                    var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(Result);
                    DtoVendedor processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<DtoVendedor>(jsonResult.ToString());
                    if (processModel.Id.Equals(""))
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
            string Controller = "Vendedor";
            string Method = "GetVendedorId";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            DtoVendedor processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<DtoVendedor>(jsonResult.ToString());
            return View(processModel);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(DtoVendedor ObjData)
        {
            string Controller = "Vendedor";
            string Method = "VendedorUpdate";

            if (ModelState.IsValid)
            {
                try
                {
                    Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
                    DictionaryModel ObjDictionary = new DictionaryModel();
                    keyValuePairs = ObjDictionary.ToDictionary(ObjData);
                    string Result = await employeeProvider.Put(keyValuePairs, Controller, Method);
                    var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(Result);
                    DtoVendedor processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<DtoVendedor>(jsonResult.ToString());
                    if (processModel.Id.Equals(""))
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
            string Controller = "Vendedor";
            string Method = "GetVendedorId";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            DtoVendedor processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<DtoVendedor>(jsonResult.ToString());
            return  View(processModel);
        }

        public async Task<ActionResult> Delete(int IdTable)
        {
            string Id = IdTable.ToString();
            string Controller = "Vendedor";
            string Method = "getVendedorid";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            DtoVendedor processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<DtoVendedor>(jsonResult.ToString());
            return  View(processModel);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(DtoVendedor ObjData, int IdTable)  // --------------------- //
        {
            string Id = IdTable.ToString();
            string Controller = "Vendedor";
            string Method = "VendedorDelete";
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