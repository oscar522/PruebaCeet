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
    public class CiudadesController :  Controller
    {
        EmployeeProvider employeeProvider = new EmployeeProvider();
        DictionaryModel DictionaryModel = new DictionaryModel();

        public async Task<ActionResult> Index()
        {
            string Id = "0";
            string Controller = "Ciudades";
            string Method = "GetCiudades";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<DtoCiudades> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<DtoCiudades>>(jsonResult.ToString());
            return View(processModel);
        }

        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Crear(DtoCiudades ObjData)
        {
            string Controller = "Ciudades";
            string Method = "CiudadesCreate";
            if (ModelState.IsValid)
            {
                try
                {
                    Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
                    DictionaryModel ObjDictionary = new DictionaryModel();
                    keyValuePairs = ObjDictionary.ToDictionary(ObjData);
                    string Result = await employeeProvider.Post(keyValuePairs, Controller, Method);
                    var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(Result);
                    DtoCiudades processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<DtoCiudades>(jsonResult.ToString());
                    if (processModel.Nombre.Equals(""))
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
            string Controller = "Ciudades";
            string Method = "GetCiudadesId";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            DtoCiudades processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<DtoCiudades>(jsonResult.ToString());
            return View(processModel);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(DtoCiudades ObjData)
        {
            string Controller = "Ciudades";
            string Method = "CiudadesUpdate";

            if (ModelState.IsValid)
            {
                try
                {
                    Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
                    DictionaryModel ObjDictionary = new DictionaryModel();
                    keyValuePairs = ObjDictionary.ToDictionary(ObjData);
                    string Result = await employeeProvider.Put(keyValuePairs, Controller, Method);
                    var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(Result);
                    DtoCiudades processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<DtoCiudades>(jsonResult.ToString());
                    if (processModel.Nombre.Equals(""))
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
            string Controller = "Ciudades";
            string Method = "GetCiudadesId";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            DtoCiudades processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<DtoCiudades>(jsonResult.ToString());
            return  View(processModel);
        }

        public async Task<ActionResult> Delete(int IdTable)
        {
            string Id = IdTable.ToString();
            string Controller = "Ciudades";
            string Method = "getCiudadesid";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            DtoCiudades processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<DtoCiudades>(jsonResult.ToString());
            return  View(processModel);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(DtoCiudades ObjData, int IdTable)  // --------------------- //
        {
            string Id = IdTable.ToString();
            string Controller = "Ciudades";
            string Method = "CiudadesDelete";
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