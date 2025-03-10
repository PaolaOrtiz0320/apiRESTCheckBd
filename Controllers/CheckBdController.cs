using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
// ----------
using apiRESTCheckBd.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
// ----- 
namespace apiRESTCheckBd.Controllers
{
    public class CheckBdController : ApiController
    {
        //Creacion y configuracion del endpoint
        [HttpPost]
        [Route("tads/checkbd")]
        public clsApiStatus checkBd()
        {
            //Definicion de objetos de salida 
            clsApiStatus objRespuesta = new clsApiStatus();
            JObject jsonResp = new JObject();
            //----------------------------------

            // Creacion del Objeto clsCheckBd
            clsCheckBd objCheckBd = new clsCheckBd();

            //Ejecucion del checkBD
            objCheckBd.checkBd();
            //Configuracion del objeto de salida
            objRespuesta.ban = objCheckBd.ban;
            if (objRespuesta.ban == 1)
                objRespuesta.statusExec = true;
            else
                objRespuesta.statusExec = false;

            objRespuesta.msg = objCheckBd.statusMsg;
            jsonResp.Add("msgData", objCheckBd.statusMsg);
            objRespuesta.datos = jsonResp;


            //------------------------------
            //Retorno del objeto de salida
            return objRespuesta;
        }




    }
}
