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
    public class AliadosController :  Controller
    {
        EmployeeProvider employeeProvider = new EmployeeProvider();
        DictionaryModel DictionaryModel = new DictionaryModel();

        //public async Task<ActionResult> ListDepto()
        //{
        //    string Id = "0";
        //    string Controller = "hvctDepto";
        //    string Method = "gethvctDepto";
        //    string result = await employeeProvider.Get(Id, Controller, Method);
        //    var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
        //    List<HvCtDeptoModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<HvCtDeptoModel>>(jsonResult.ToString());
        //    return Json(processModel.Select(x => new SelectListItem { Text = x.NOMBRE, Value = x.ID_CT_DEPTO.ToString() }).ToList());
        //}
        //public async Task<ActionResult> ListDeptoId(string IdP)
        //{
        //    string Controller = "hvctDepto";
        //    string Method = "gethvctdepto";
        //    string result = await employeeProvider.Get(IdP, Controller, Method);
        //    var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
        //    List<HvCtDeptoModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<HvCtDeptoModel>>(jsonResult.ToString());
        //    return Json(processModel.Select(x => new SelectListItem { Text = x.NOMBRE, Value = x.ID_CT_DEPTO.ToString() }).ToList());

        //}
        //public async Task<ActionResult> ListPais()
        //{
        //    string Id = "0";
        //    string Controller = "hvctpais";
        //    string Method = "gethvctpais";
        //    string result = await employeeProvider.Get(Id, Controller, Method);
        //    var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
        //    List<HvCtPaisModel> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<HvCtPaisModel>>(jsonResult.ToString());
        //    return Json(processModel.Select(x => new SelectListItem { Text = x.NOMBRE, Value = x.ID_CT_PAIS.ToString() }).ToList());
        //}
        //public async Task<ActionResult> ListCiudadId(string IdP)
        //{
        //    string Id = IdP.ToString();
        //    string Controller = "Aliados";
        //    string Method = "getAliados";
        //    string result = await employeeProvider.Get(Id, Controller, Method);
        //    var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
        //    List<DtoAliados> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<DtoAliados>>(jsonResult.ToString());
        //    return Json(processModel.Select(x => new SelectListItem { Text = x.NOMBRE, Value = x.ID_CT_CIUDAD.ToString() }).ToList());
        //}

        public async Task<ActionResult> Index()
        {
            string Id = "0";
            string Controller = "Aliados";
            string Method = "GetAliados";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            List<DtoAliados> processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<DtoAliados>>(jsonResult.ToString());
            return View(processModel);
        }

        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Crear(DtoAliados ObjData)
        {
            string Controller = "Aliados";
            string Method = "AliadosCreate";
            if (ModelState.IsValid)
            {
                try
                {
                    Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
                    DictionaryModel ObjDictionary = new DictionaryModel();
                    keyValuePairs = ObjDictionary.ToDictionary(ObjData);
                    string Result = await employeeProvider.Post(keyValuePairs, Controller, Method);
                    var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(Result);
                    DtoAliados processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<DtoAliados>(jsonResult.ToString());
                    if (processModel.Aliado.Equals(""))
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
            string Controller = "Aliados";
            string Method = "GetAliadosId";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            DtoAliados processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<DtoAliados>(jsonResult.ToString());
            return View(processModel);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(DtoAliados ObjData)
        {
            string Controller = "Aliados";
            string Method = "AliadosUpdate";

            if (ModelState.IsValid)
            {
                try
                {
                    Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
                    DictionaryModel ObjDictionary = new DictionaryModel();
                    keyValuePairs = ObjDictionary.ToDictionary(ObjData);
                    string Result = await employeeProvider.Put(keyValuePairs, Controller, Method);
                    var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(Result);
                    DtoAliados processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<DtoAliados>(jsonResult.ToString());
                    if (processModel.Aliado.Equals(""))
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
            string Controller = "Aliados";
            string Method = "GetAliadosId";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            DtoAliados processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<DtoAliados>(jsonResult.ToString());
            return  View(processModel);
        }

        public async Task<ActionResult> Delete(int IdTable)
        {
            string Id = IdTable.ToString();
            string Controller = "Aliados";
            string Method = "getAliadosid";
            string result = await employeeProvider.Get(Id, Controller, Method);
            var jsonResult = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            DtoAliados processModel = Newtonsoft.Json.JsonConvert.DeserializeObject<DtoAliados>(jsonResult.ToString());
            return  View(processModel);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(DtoAliados ObjData, int IdTable)  // --------------------- //
        {
            string Id = IdTable.ToString();
            string Controller = "Aliados";
            string Method = "AliadosDelete";
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