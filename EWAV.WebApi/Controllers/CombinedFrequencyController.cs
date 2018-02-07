using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json.Linq;
using EWAV.Web.EpiDashboard;
using EWAV.Web.Services.CombinedFrequencyDomainService;
using EWAV.Web.Services;
using System.Net.Http.Headers;
using EWAV.Clients.Common.DefinedVariables;
using Newtonsoft.Json;
using System.Xml.Linq;
using System.Xml;
using EWAV.BAL;

namespace EWAV.WebApi.Controllers
{
    public class CombinedFrequencyController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public HttpResponseMessage Post([FromBody]      JObject value)
        {

            CombinedFrequencyDomainService CFDS = new CombinedFrequencyDomainService();
            HttpResponseMessage ReturnedObj = null;
            GadgetParameters GadgetParameters = null;
            ControllerCommon CommonClass = new ControllerCommon();
            List<EWAVRule_Base> Rules = new List<EWAVRule_Base>();

            JObject gadgetJSON = (JObject)value["gadget"];


            CFDS = new CombinedFrequencyDomainService();
            EWAVCombinedFrequencyGadgetParameters CombinedParameters = new EWAVCombinedFrequencyGadgetParameters();
            CombinedParameters.CombineMode = (CombineModeTypes)Enum.Parse(typeof(CombineModeTypes), gadgetJSON["combinedmode"].ToString());
            CombinedParameters.ShowDenominator = Convert.ToBoolean(gadgetJSON["showdenominator"].ToString());
            CombinedParameters.SortHighToLow = Convert.ToBoolean(gadgetJSON["sort"].ToString());
            CombinedParameters.TrueValue = (gadgetJSON["truevalue"].ToString().Trim().Length == 0 ? null : value["truevalue"].ToString());


            GadgetParameters = new GadgetParameters();

            GadgetParameters.DatasourceName = gadgetJSON["@DatasourceName"].ToString();
            GadgetParameters.MainVariableName = gadgetJSON["mainVariable"].ToString();
            GadgetParameters.InputVariableList = new Dictionary<string, string>();
            GadgetParameters.InputVariableList.Add("tableName", gadgetJSON["@DatasourceName"].ToString());
           
            GadgetParameters.TableName = CommonClass.GetDatabaseObject(GadgetParameters.DatasourceName);

            string groupVar = gadgetJSON["mainVariable"].ToString();

            List<EWAVDataFilterCondition> dashboardFilters = new List<EWAVDataFilterCondition>();


            Rules = CommonClass.ReadRules(value);

            dashboardFilters = CommonClass.GetFilters(value);


            GadgetParameters.GadgetFilters = CommonClass.GetFilters(gadgetJSON, true);



            DatatableBag dtBag = CFDS.GenerateCombinedFrequency(CombinedParameters, groupVar, GadgetParameters, dashboardFilters, Rules);

            ReturnedObj = new HttpResponseMessage()
            {
                Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(dtBag))

            };

            ReturnedObj.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");


            return ReturnedObj;
        }



        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}